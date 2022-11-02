using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace IDS_Project
{
    public partial class IDS : Form
    {
        public bool isSniffing { get; set; }
        public string filters { get; set; }
        delegate void SetTextCallback(RawCapture text);
        public ICaptureDevice deviceCaptured { get; set; }

        public IDS()
        {
            InitializeComponent();
        }

        private void StartSnifferBtn_Click(object sender, EventArgs e)
        {
            //Start Sniffing
            isSniffing = true;
            filters = string.Empty;
            //Display ShapPcap Version
            TbVersion.Text = SharpPcap.Pcap.Version;

            //Display Devices in the network
            var devices = CaptureDeviceList.Instance;

            if (devices.Count == 0)
            {
                TbDevices.Text = "No devices found in the network";
            }
            else
            {
                TbDevices.AppendText("Devices found in the network:\n");
                foreach (ICaptureDevice device in devices)
                {
                    TbDevices.AppendText($"Name:{device.Name}\nDescription:{device.Description}\n" +
                        $"MAC:{device.MacAddress}\n");
                    TbDevices.AppendText("---------------------------------\n");

                }
            }

            //Display Packets
            
                foreach (ICaptureDevice device in devices)
                {
                    //Open device for capture
                    int readTimeoutMilliseconds = 1000;
                    device.Open(DeviceModes.Promiscuous, readTimeoutMilliseconds);
                    tbPackets.AppendText($"-- Listening on {device.Description}\n");
                    device.OnPacketArrival += Device_OnPacketArrival;
                    device.StartCapture();
                    
                }   
            

        }

        private void changePacketText(RawCapture packetResult)
        {
            if (this.tbPackets.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(changePacketText);
                this.Invoke(d, new object[] { packetResult });
            }
            else
            {
                if(deviceCaptured.Filter == string.Empty)
                {
                    DateTime time = packetResult.Timeval.Date;
                    int lenPacket = packetResult.Data.Length;
                    tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}\n");
                }
                if(deviceCaptured.Filter.Equals("ip and tcp"))
                {
                    var tcp = (TcpPacket)packetResult.GetPacket().Extract<TcpPacket>();
                    if(tcp != null)
                    {
                        DateTime time = packetResult.Timeval.Date;
                        int lenPacket = packetResult.Data.Length;
                        string srcPort = tcp.SourcePort.ToString();
                        string dstPort = tcp.DestinationPort.ToString();

                        var ipPacket = (IPPacket)tcp.ParentPacket;
                        string srcAddress = ipPacket.SourceAddress.ToString();
                        string dstAddress = ipPacket.DestinationAddress.ToString();
                        
                        tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}" +
                        $" | Type: TCP/IP | Source Port: {srcPort} | Destination Port: {dstPort} | Source IP: {srcAddress} | Destination IP: {dstAddress}\n");
                    }
                    if (deviceCaptured.Filter.Equals("udp"))
                    {
                        var udp = (UdpPacket)packetResult.GetPacket().Extract<UdpPacket>();
                        if (udp != null)
                        {
                            DateTime time = packetResult.Timeval.Date;
                            int lenPacket = packetResult.Data.Length;
                            string srcPort = udp.SourcePort.ToString();
                            string dstPort = udp.DestinationPort.ToString();

                            var ipPacket = (IPPacket)udp.ParentPacket;
                            string srcAddress = ipPacket.SourceAddress.ToString();
                            string dstAddress = ipPacket.DestinationAddress.ToString();

                            tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}" +
                            $" | Type: UDP | Source Port: {srcPort} | Destination Port: {dstPort} | Source IP: {srcAddress} | Destination IP: {dstAddress}\n");
                        }
                    }
                }
                
            }
        }

        private void Device_OnPacketArrival(object sender, PacketCapture e)
        {
            if (isSniffing)
            {
                deviceCaptured = e.Device;
                deviceCaptured.Filter = filters;
                changePacketText(e.GetPacket());
            }
            else
            {
                e.Device.StopCapture();
                e.Device.Close();
            }
        }

        private void btnStopSniffing_Click(object sender, EventArgs e)
        {
            isSniffing = false;
        }

        private void btnTcp_Click(object sender, EventArgs e)
        {
            tbPackets.AppendText("TCP/IP Filter Applied:\n");
            filters = "ip and tcp";
            deviceCaptured.Filter = filters;

        }

        private void btnRemoveFilters_Click(object sender, EventArgs e)
        {
            tbPackets.AppendText("No Filters Applied:\n");
            filters = string.Empty;
            deviceCaptured.Filter = filters;
        }

        private void btnUDP_Click(object sender, EventArgs e)
        {
            tbPackets.AppendText("UDP Filter Applied:\n");
            filters = "udp";
            deviceCaptured.Filter = filters;
        }
    }
}
