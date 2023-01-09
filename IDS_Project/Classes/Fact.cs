using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SharpPcap;
using System.Net;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace IDS_Project.Classes
{
    [JsonObject]
    public class Fact
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("operatorValue")]
        public string OperatorValue { get; set; }
        [JsonProperty("value")]
        public object Value { get; set; }

        // Method to check if a packet matches this fact
        public bool IsMatch(RawCapture packet)
        {
            bool result = false;
            // Extract the value of this fact from the packet
            object packetValue = ExtractValue(packet);

            if (packetValue != null)
            {
                // Compare the value of this fact to the expected value using the specified operator
                switch (OperatorValue)
                {
                    case "equal":
                        result = packetValue.Equals(Value);
                        break;
                    case "notEqual":
                        result = !packetValue.Equals(Value);
                        break;
                    case "greaterThan":
                        result = (int)packetValue > Convert.ToInt32(Value);
                        break;
                    case "greaterThanInclusive":
                        result = (int)packetValue >= Convert.ToInt32(Value);
                        break;
                    case "lessThan":
                        result = (int)packetValue < Convert.ToInt32(Value);
                        break;
                    case "lessThanInclusive":
                        result = (int)packetValue <= Convert.ToInt32(Value);
                        break;
                    case "contains":
                        result = packetValue.ToString().Contains(Value.ToString());
                        break;
                    case "matches":
                        result = Regex.IsMatch(packetValue.ToString(), Value.ToString());
                        break;
                    case "in":
                        if (packetValue is int)
                        {
                            result = Enumerable.Contains(((JArray)Value).ToObject<int[]>(), (int)packetValue);
                        }
                        else
                        {
                            result = Enumerable.Contains((object[])((JArray)Value).ToObject<object[]>(), packetValue);
                        }

                        break;
                }
            }
            
            return result;
        }

        private object ExtractValue(RawCapture packet)
        {
            object value = null;
            var p = Packet.ParsePacket(LinkLayers.Ethernet, packet.Data);
            IPPacket ipPacket = null;
            TcpPacket tcpPacket = null;

                switch (Name)
                {
                    case "syn_packet_count":
                        value = 1;
                        // Add logic to count the number of SYN packets here
                        break;
                    case "protocol":

                        ipPacket = p.Extract<IPPacket>();
                        value = string.Empty;

                        if (ipPacket != null)
                        {
                            if (ipPacket.Protocol == ProtocolType.Tcp)
                            {
                                value = "tcp";
                            }
                            else if (ipPacket.Protocol == ProtocolType.Udp)
                            {
                                value = "udp";
                            }
                            else if (ipPacket.Protocol == ProtocolType.Icmp)
                            {
                                value = "icmp";
                            }
                            else if (ipPacket.Protocol == ProtocolType.Igmp)
                            {
                                value = "igmp";
                            }
                        }

                        break;
                    case "destination_port_count":

                        int requestCountDestPort = 1;
                        var payloadRequest = string.Empty;
                        int destPort = 0;
                        ipPacket = p.Extract<IPPacket>();

                        if (ipPacket != null)
                        {
                            if (ipPacket.Protocol == ProtocolType.Tcp)
                            {
                                tcpPacket = ipPacket.Extract<TcpPacket>();

                                if (tcpPacket != null)
                                {
                                    destPort = tcpPacket.DestinationPort;

                                    payloadRequest = Encoding.ASCII.GetString(tcpPacket.PayloadData);
                                }


                            }
                            else if (ipPacket.Protocol == ProtocolType.Udp)
                            {
                                UdpPacket udpPacket = ipPacket.Extract<UdpPacket>();

                                if (udpPacket != null)
                                {
                                    destPort = udpPacket.DestinationPort;

                                    payloadRequest = Encoding.ASCII.GetString(udpPacket.PayloadData);
                                }

                            }

                            foreach (Match match in Regex.Matches(payloadRequest, "GET|POST|PUT|DELETE|HEAD"))
                            {
                                // Extract the Host of the request
                                string requestHostHeader = Regex.Match(payloadRequest, "(?<=Host: ).*").Value;


                                // Extract the port from the URI
                                int requestPort = requestHostHeader.Contains(":") ? int.Parse(requestHostHeader.Split(':')[1]) : 80;

                                // Check if the port of the request matches the destination port of the packet
                                if (requestPort == destPort)
                                {
                                    // Increment the request count for this port
                                    requestCountDestPort++;
                                }

                            };
                        }

                        value = requestCountDestPort;

                        break;
                    case "source_ip_count":

                        int requestCountSourceIp = 1;
                        var payload = string.Empty;
                        ipPacket = p.Extract<IPPacket>();

                        if (ipPacket != null && ipPacket.PayloadData != null)
                        {
                            IPAddress sourceIp = ipPacket.SourceAddress;

                            payload = Encoding.ASCII.GetString(ipPacket.PayloadData);


                            foreach (Match match in Regex.Matches(payload, "GET|POST|PUT|DELETE|HEAD"))
                            {
                                // Extract the URI of the request
                                string requestSourceIpUri = Regex.Match(payload, "(?<= )[^ ]+(?= HTTP)").Value;
                                // Extract the source IP of the request
                                IPAddress requestSourceIp = IPAddress.Parse(requestSourceIpUri.Split(':')[1].Substring(2));

                                // Check if the ip of the request changed from the original source ip
                                if (requestSourceIp != sourceIp)
                                {
                                    // Increment the request count for this source ip
                                    requestCountSourceIp++;
                                }

                            };
                        }

                        value = requestCountSourceIp;
                        break;
                    case "destination":
                        ipPacket = p.Extract<IPPacket>();

                        if (ipPacket != null)
                        {
                            value = ipPacket.DestinationAddress.ToString();
                        }

                        break;
                    case "request_count":
                        int requestCount = 1;
                        var payloadRequestCount = Encoding.ASCII.GetString(p.PayloadData);

                        foreach (Match match in Regex.Matches(payloadRequestCount, "GET|POST|PUT|DELETE|HEAD"))
                        {
                            // Extract the URI of the request
                            string requestCountUri = Regex.Match(payloadRequestCount, "(?<= )[^ ]+(?= HTTP)").Value;

                            requestCount++;

                        };

                        value = requestCount;
                        break;
                    case "user_agent":
                        ipPacket = p.Extract<IPPacket>();
                        string userAgent = string.Empty;

                        if (ipPacket != null && ipPacket.Protocol == ProtocolType.Tcp)
                        {
                            tcpPacket = p.Extract<TcpPacket>();

                            if(tcpPacket.PayloadData != null)
                            {
                                string payloadRequestUserAgent = Encoding.ASCII.GetString(tcpPacket.PayloadData);
                                userAgent = Regex.Match(payloadRequestUserAgent, "(?<=User-Agent: ).*").Value;
                            }
                        }                                      

                        value = userAgent;
                        break;
                    case "http_request_uri":
                        ipPacket = p.Extract<IPPacket>();
                        string requestUri = string.Empty;

                        if (ipPacket != null && ipPacket.Protocol == ProtocolType.Tcp && ipPacket.PayloadData != null)
                        {
                            tcpPacket = p.Extract<TcpPacket>();

                            if(tcpPacket.PayloadData != null)
                            {
                                var payloadRequestURI = Encoding.ASCII.GetString(tcpPacket.PayloadData);
                                // Extract the URI of the request
                                requestUri = Regex.Match(payloadRequestURI, "(?<=GET|POST|PUT|DELETE|HEAD )[^\\s]+").Value;
                            }
                            
                        }

                        value = requestUri;
                        break;
                    case "destination_port":
                        int destinationPort = 0;
                        ipPacket = p.Extract<IPPacket>();

                        if (ipPacket != null)
                        {
                            if (ipPacket.Protocol == ProtocolType.Tcp)
                            {
                                tcpPacket = ipPacket.Extract<TcpPacket>();

                                if (tcpPacket != null)
                                {
                                    destinationPort = tcpPacket.DestinationPort;
                                }

                            }
                            else if (ipPacket.Protocol == ProtocolType.Udp)
                            {
                                UdpPacket udpPacket = ipPacket.Extract<UdpPacket>();

                                if (udpPacket != null)
                                {
                                    destinationPort = udpPacket.DestinationPort;
                                }

                            }
                        }

                        value = destinationPort;
                        break;
                    case "packet_size":
                        value = p.Bytes.Length;
                        break;
                    case "packet_payload":
                        value = p.PayloadData;
                        break;
                }
            
            return value;
        }
    }
}
