using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SharpPcap;

namespace IDS_Project.Classes
{
    internal class Fact
    {
        public string Name { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }

        // Method to check if a packet matches this fact
        public bool IsMatch(RawCapture packet)
        {
            bool result = false;
            // Extract the value of this fact from the packet
            object packetValue = ExtractValue(packet);
            // Compare the value of this fact to the expected value using the specified operator
            switch (Operator)
            {
                case "equal":
                    result = packetValue.Equals(Value);
                    break;
                case "notEqual":
                    result = !packetValue.Equals(Value);
                    break;
                case "greaterThan":
                    result = (int)packetValue > (int)Value;
                    break;
                case "greaterThanInclusive":
                    result = (int)packetValue >= (int)Value;
                    break;
                case "lessThan":
                    result = (int)packetValue < (int)Value;
                    break;
                case "lessThanInclusive":
                    result = (int)packetValue <= (int)Value;
                    break;
                case "contains":
                    result = packetValue.ToString().Contains((string)Value);
                    break;
                case "matches":
                    result = Regex.IsMatch(packetValue.ToString(), (string)Value);
                    break;
            }
            return result;
        }

        private object ExtractValue(RawCapture packet)
        {
            object value = null;
            // Cast the packet to a RawCapture object
            // Use the PacketDotNet library to parse the raw packet into a Packet object
            //var parsedPacket = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            // Extract the value of this fact from the parsed packet
            switch (Name)
            {
                case "syn_packet_count":
                    // Add logic to count the number of SYN packets here
                    break;
                case "protocol":
                    value = packet.GetProtocol();
                    break;
                case "destination_port_count":
                    // Add logic to count the number of packets to each destination port here
                    break;
                case "source_ip_count":
                    // Add logic to count the number of packets from each source IP here
                    break;
                case "destination":
                    value = packet.DestinationAddress;
                    break;
                case "request_count":
                    // Add logic to count the number of requests to a specific IP here
                    break;
                case "user_agent":
                    value = packet.HttpUserAgent;
                    break;
                case "http_request_uri":
                    value = packet.HttpRequestUri;
                    break;
                    // Add additional cases for other facts here
            }
            return value;
        }
    }
}
