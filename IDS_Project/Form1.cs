using SharpPcap;
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

namespace IDS_Project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void StartSnifferBtn_Click(object sender, EventArgs e)
        {
            TbVersion.Text = SharpPcap.Pcap.Version;

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
                    TbDevices.AppendText($"{device.ToString()}");
                    TbDevices.AppendText("---------------------------------\n");

                }
            }

        }

    }
}
