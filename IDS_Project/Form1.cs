using IDS_Project.Classes;
using Newtonsoft.Json;
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
using System.IO;
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
        // Deserialize the JSON string into a list of Rule objects

        List<Classes.Rule> rules = new List<Classes.Rule>();
        public string jsonRules = File.ReadAllText("rules.json");
        public bool isSniffing { get; set; }
        public string filters { get; set; }
        delegate void SetTextCallback(RawCapture text);
        public ICaptureDevice deviceCaptured { get; set; }
        public CaptureDeviceList devices { get; set; }
        public string pcapFile {get; set;}

        public IDS()
        {
            InitializeComponent();
        }

        //Ao iniciar o programa todos os dispositivos da rede são capturados

        private void IDS_Load(object sender, EventArgs e)
        {
            //Initiate Filter Variable
            filters = string.Empty;
            //Initiate File Variable
            pcapFile = string.Empty;
            //Display NPCap Version
            TbVersion.Text = SharpPcap.Pcap.Version;
            //Display Devices in the network
            devices = CaptureDeviceList.Instance;
            //Deserialize json rules file
            rules = JsonConvert.DeserializeObject<List<Classes.Rule>>(jsonRules);            

            if (devices.Count == 0)
            {
                listDevices.Items.Add("No devices found in the network");
            }
            else
            {
                foreach (ICaptureDevice device in devices)
                {
                    listDevices.Items.Add($"{device.Description}");
                }
            }
        }

        //Inicio do sniffing para o dispositivo selecionado dando display nos seus packets
        #region Start Sniffing
        private void StartSnifferBtn_Click(object sender, EventArgs e)
        {
            //Start Sniffing
            isSniffing = true;
            //Clean Packets TextBox
            tbPackets.Clear();
            //Clean Alerts 
            tbAlerts.Clear();
            //Enable Stop Button 
            btnStopSniffing.Enabled = true;

            string selectedDevice = listDevices.SelectedItem.ToString();

            //Display Packets

            foreach (ICaptureDevice device in devices)
            {
                if (device.Description.Equals(selectedDevice))
                {
                    //Open device for capture
                    device.Open();
                    tbPackets.AppendText($"-- Listening on {device.Description}\n");
                    device.OnPacketArrival += Device_OnPacketArrival;
                    device.StartCapture();
                    break;
                }
                                        
            }   
            
        }

        #endregion

        //Inicio de sniffing através de ficheiro carregado
        #region Start Sniffing From File
        private void btnSniffFromFile_Click(object sender, EventArgs e)
        {
            tbPackets.Clear();
            tbAlerts.Clear();
            //Procurar ficheiro e associa-lo à variavel pcapFile
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                pcapFile = FD.FileName;

            deviceCaptured = new CaptureFileReaderDevice(pcapFile);
            //Start Sniffing
            isSniffing = true;
            btnStopSniffing.Enabled = true;
            //Open device for capture
            deviceCaptured.Open();
            tbPackets.AppendText($"-- Listening on {deviceCaptured.Description}\n");
            deviceCaptured.OnPacketArrival += Device_OnPacketArrival;
            deviceCaptured.StartCapture();

        }
        #endregion

        //Mostrar informações dos packets capturados
        #region Packets Information
        private void changePacketText(RawCapture packetResult)
        {
            if (this.tbPackets.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(changePacketText);
                this.Invoke(d, new object[] { packetResult });
            }
            else
            {

                if (btnRemoveFilters.Enabled == false)
                {
                    btnRemoveFilters.Enabled = true;
                    btnTcp.Enabled = true;
                    btnUDP.Enabled = true;
                    btnArp.Enabled = true;
                    btnICMP.Enabled = true;
                    btnIGMP.Enabled = true;
                }

                //Se o filtro TCP/IP foi selecionado
                if(deviceCaptured.Filter.Equals("ip and tcp") || deviceCaptured.Filter.Equals(string.Empty))
                {
                    var tcp = (TcpPacket)packetResult.GetPacket().Extract<TcpPacket>();
                    if(tcp != null)
                    {
                        //Dados Pacote
                        DateTime time = packetResult.Timeval.Date;
                        int lenPacket = packetResult.Data.Length;
                        
                        //Dados Tcp
                        string srcPort = tcp.SourcePort.ToString();
                        string dstPort = tcp.DestinationPort.ToString();

                        //Dados Ip
                        var ipPacket = (IPPacket)tcp.ParentPacket;
                        string srcAddress = ipPacket.SourceAddress.ToString();
                        string dstAddress = ipPacket.DestinationAddress.ToString();
                        
                        tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}" +
                        $" | Type: TCP/IP | Source Port: {srcPort} | Destination Port: {dstPort} | Source IP: {srcAddress} | Destination IP: {dstAddress}\n");
                    }                    
                }
                //Se o filtro UDP foi selecionado
                if (deviceCaptured.Filter.Equals("udp") || deviceCaptured.Filter.Equals(string.Empty))
                {
                    var udp = (UdpPacket)packetResult.GetPacket().Extract<UdpPacket>();
                    if (udp != null)
                    {
                        //Dados Pacote
                        DateTime time = packetResult.Timeval.Date;
                        int lenPacket = packetResult.Data.Length;

                        //Dados Udp
                        string srcPort = udp.SourcePort.ToString();
                        string dstPort = udp.DestinationPort.ToString();

                        //Dados Ip
                        var ipPacket = (IPPacket)udp.ParentPacket;
                        string srcAddress = ipPacket.SourceAddress.ToString();
                        string dstAddress = ipPacket.DestinationAddress.ToString();
                        //byte[] ipPacketHeadder = ipPacket.HeaderData;


                        tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}" +
                        $" | Type: UDP | Source Port: {srcPort} | Destination Port: {dstPort} | Source IP: {srcAddress} | Destination IP: {dstAddress}\n");
                    }
                }
                //Se o filtro ARP foi selecionado
                if (deviceCaptured.Filter.Equals("arp") || deviceCaptured.Filter.Equals(string.Empty))
                {
                    var arp = (ArpPacket)packetResult.GetPacket().Extract<ArpPacket>();
                    if (arp != null)
                    {
                        //Dados Pacote
                        DateTime time = packetResult.Timeval.Date;
                        int lenPacket = packetResult.Data.Length;

                        //Dados Arp
                        string senderHdwAdrs = arp.SenderHardwareAddress.ToString();
                        string receiverHdwAdrs = arp.TargetHardwareAddress.ToString();
                        string senderProtAdrs = arp.SenderProtocolAddress.ToString();
                        string receiverProtAdrs = arp.TargetProtocolAddress.ToString();                  

                        tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}" +
                        $" | Type: ARP" +
                        $" | Sender Hardware Address :{senderHdwAdrs} | Target Hardware Address :{receiverHdwAdrs}" +
                        $" | Sender Protocol Address :{senderProtAdrs} | Target Protocol Address :{receiverProtAdrs} \n");
                    }
                }
                //Se o filtro ICMPV4 foi selecionado
                if (deviceCaptured.Filter.Equals("icmp") || deviceCaptured.Filter.Equals(string.Empty))
                {
                    var icmp4 = (IcmpV4Packet)packetResult.GetPacket().Extract<IcmpV4Packet>();
                    var icmp6 = (IcmpV6Packet)packetResult.GetPacket().Extract<IcmpV6Packet>();
                    if (icmp4 != null)
                    {
                        //Dados Pacote
                        DateTime time = packetResult.Timeval.Date;
                        int lenPacket = packetResult.Data.Length;

                        //ICMPV4
                        string id = icmp4.Id.ToString();
                        string checksum = icmp4.Checksum.ToString();
                        string checksumValid = icmp4.ValidIcmpChecksum.ToString();

                        //Dados Ip
                        var ipPacket = (IPPacket)icmp4.ParentPacket;
                        string srcAddress = ipPacket.SourceAddress.ToString();
                        string dstAddress = ipPacket.DestinationAddress.ToString();

                        tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}" +
                        $" | Type: ICMPV4" +
                        $" | Source IP: {srcAddress} | Destination IP: {dstAddress}" +
                        $" | Id :{id} | Checksum :{checksum} | Valid Checksum :{checksumValid} \n");
                    }
                    if(icmp6 != null)
                    {
                        //Dados Pacote
                        DateTime time = packetResult.Timeval.Date;
                        int lenPacket = packetResult.Data.Length;

                        //ICMPV6
                        string color = icmp6.Color.ToString();
                        string checksum = icmp6.Checksum.ToString();
                        string checksumValid = icmp6.ValidIcmpChecksum.ToString();

                        //Dados Ip
                        var ipPacket = (IPPacket)icmp6.ParentPacket;
                        string srcAddress = ipPacket.SourceAddress.ToString();
                        string dstAddress = ipPacket.DestinationAddress.ToString();

                        tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}" +
                        $" | Type: ICMPV6" +
                        $" | Source IP: {srcAddress} | Destination IP: {dstAddress}" +
                        $" | Color :{color} | Checksum :{checksum} | Valid Checksum :{checksumValid} \n");
                    }
                }
                //Se o filtro IGMP foi selecionado
                if (deviceCaptured.Filter.Equals("igmp") || deviceCaptured.Filter.Equals(string.Empty))
                {
                    var igmp = (IgmpPacket)packetResult.GetPacket().Extract<IgmpPacket>();
                    if (igmp != null)
                    {
                        //Dados Pacote
                        DateTime time = packetResult.Timeval.Date;
                        int lenPacket = packetResult.Data.Length;

                        //Dados Ip
                        var ipPacket = (IPPacket)igmp.ParentPacket;
                        string srcAddress = ipPacket.SourceAddress.ToString();
                        string dstAddress = ipPacket.DestinationAddress.ToString();

                        tbPackets.AppendText($"Time:{time.Hour}:{time.Minute}:{time.Second} | Package Len = {lenPacket}" +
                        $" | Type: IGMP" +
                        $" | Source IP: {srcAddress} | Destination IP: {dstAddress}\n");
                    }
                }

            }
        }
        #endregion

        //Ao receber pacote executar atribuir filtros e executar função changePacketText
        #region On Packet Arrival
        private void Device_OnPacketArrival(object sender, PacketCapture e)
        {

            if (isSniffing)
            {
                deviceCaptured = e.Device;
                deviceCaptured.Filter = filters;

                foreach (Classes.Rule rule in rules)
                {
                    if (rule.IsMatch(e.GetPacket()))
                    {
                        foreach (Classes.Action action in rule.Actions)
                        {
                            string alert = action.Execute();
                            tbAlerts.Invoke(new MethodInvoker(delegate
                            {
                                tbAlerts.AppendText(alert);
                            }));
                        }
                    }
                }

                changePacketText(e.GetPacket());
            }
            else
            {
                e.Device.StopCapture();
                e.Device.Close();
            }
        }
        #endregion

        //Funções de butões
        #region Button Actions
        private void btnStopSniffing_Click(object sender, EventArgs e)
        {
            isSniffing = false;
            btnRemoveFilters.Enabled = false;
            btnTcp.Enabled = false;
            btnUDP.Enabled = false;
            btnArp.Enabled = false;
            btnICMP.Enabled = false;
            btnIGMP.Enabled = false;    
        }

        private void btnRemoveFilters_Click(object sender, EventArgs e)
        {
            tbPackets.Clear();
            tbPackets.AppendText("No Filters Applied:\n");
            filters = string.Empty;
            deviceCaptured.Filter = filters;
        }

        private void btnTcp_Click(object sender, EventArgs e)
        {
            tbPackets.Clear();
            tbPackets.AppendText("TCP/IP Filter Applied:\n");
            filters = "ip and tcp";
            deviceCaptured.Filter = filters;

        }

        private void btnUDP_Click(object sender, EventArgs e)
        {
            tbPackets.Clear();
            tbPackets.AppendText("UDP Filter Applied:\n");
            filters = "udp";
            deviceCaptured.Filter = filters;
        }

        private void btnArp_Click(object sender, EventArgs e)
        {
            tbPackets.Clear();
            tbPackets.AppendText("ARP Filter Applied:\n");
            filters = "arp";
            deviceCaptured.Filter = filters;
        }

        private void btnICMP_Click_1(object sender, EventArgs e)
        {
            tbPackets.Clear();
            tbPackets.AppendText("ICMP Filter Applied:\n");
            filters = "icmp";
            deviceCaptured.Filter = filters;
        }

        private void btnIGMP_Click(object sender, EventArgs e)
        {
            tbPackets.Clear();
            tbPackets.AppendText("IGMP Filter Applied:\n");
            filters = "igmp";
            deviceCaptured.Filter = filters;
        }

        #endregion

        //Desbloquear botão sniffing ao selecionar dispositivo
        #region Device Selected
        private void listDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartSnifferBtn.Enabled = true;
        }
        #endregion

    }
}
