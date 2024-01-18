using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;
using System.Linq;
using System.Net;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DNSTool
{
    public partial class FrmMain : Form
    {
        private bool _isOpen = false;

        private string _currentDns = "";

        private List<string> _dns = new List<string>() { "172.16.7.1", "172.16.7.2" };

        public FrmMain()
        {
            InitializeComponent();
            panel1.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(panel1, true, null);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitCombobox();
            GetDns();
            timer1.Enabled = true;
        }

        private void InitCombobox()
        {
            // 读取注册表保存的列表
            var listStr = RegistryHelper.GetRegistryData("evinf", "steps");
            if (listStr != "") 
            {
                _dns = listStr.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                _dns = new List<string>() { "172.16.7.1", "172.16.7.2" };
            }

            cbDns.Items.Clear();
            foreach (string dns in _dns)
            {
                cbDns.Items.Add(dns);
            }

            cbDns.SelectedIndex = 0;
            _currentDns = cbDns.Text;
        }


        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        private static extern UInt32 DnsFlushResolverCache();

        public static void FlushMyCache() //This can be named whatever name you want and is the function you will call
        {
            UInt32 result = DnsFlushResolverCache();
        }

        private void GetDns()
        {
            var dnss = GetDnsAdress();
            _isOpen = dnss.ToString() == _currentDns;
        }

        private static IPAddress GetDnsAdress()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            //var item = networkInterfaces.FirstOrDefault(p => p.Name == "以太网");
            //if (item != null && item.OperationalStatus == OperationalStatus.Up)
            //{
            //    IPInterfaceProperties ipProperties = item.GetIPProperties();
            //    IPAddressCollection dnsAddresses = ipProperties.DnsAddresses;

            //    foreach (IPAddress dnsAdress in dnsAddresses)
            //    {
            //        return dnsAdress;
            //    }
            //}

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                    IPAddressCollection dnsAddresses = ipProperties.DnsAddresses;

                    foreach (IPAddress dnsAdress in dnsAddresses)
                    {
                        return dnsAdress;
                    }
                }
            }

            throw new InvalidOperationException("Unable to find DNS Address");
        }

        private void SetDns()
        {
            SetIPAddress(null, null, new string[] { _currentDns } , new string[] { _currentDns });
        }


        public static void SetIPAddress(string[] ip, string[] submask, string[] getway, string[] dns)
        {
            var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
            if (CurrentInterface == null) return;

            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            foreach (ManagementObject mo in moc)
            {
                //如果没有启用IP设置的网络设备则跳过 
                if (!(bool)mo["IPEnabled"])
                    continue;

                if (!mo["Description"].ToString().Equals(CurrentInterface.Description)) continue;


                    //设置IP地址和掩码 
                if (ip != null && submask != null)
                {
                    inPar = mo.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = ip;
                    inPar["SubnetMask"] = submask;
                    outPar = mo.InvokeMethod("EnableStatic", inPar, null);
                }


                //设置网关地址 
                if (getway != null)
                {
                    inPar = mo.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = getway;
                    outPar = mo.InvokeMethod("SetGateways", inPar, null);
                }


                //设置DNS地址 
                if (dns != null)
                {
                    inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    inPar["DNSServerSearchOrder"] = dns;
                    outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                    //FlushMyCache();
                }
            }
        }

        public static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()
        {
            var Nic = NetworkInterface.GetAllNetworkInterfaces().ToList().FirstOrDefault(
                a => a.OperationalStatus == OperationalStatus.Up &&
                (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

            return Nic;
        }

        private int offset = 0;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color open = Color.FromArgb(103, 194, 58);
            Color close = Color.Gainsboro;
            open = _isOpen ?  open : close;
            Graphics g = e.Graphics;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            g.Clear(Color.White);
            //g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, panel1.Height - offset, panel1.Width, offset));
            g.DrawArc(new Pen(open, 10), new RectangleF(10, 10, panel1.Width-20, panel1.Width-20), 0, offset);
            if (offset == 360 || !timer1.Enabled)
            {
                g.FillEllipse(new SolidBrush(open), new RectangleF(10, 10, panel1.Width - 20, panel1.Width - 20));
                Pen p = new Pen(Color.White, 10);

                PointF[] ps = new PointF[] 
                { 
                    new PointF(panel1.Width * 0.2f, panel1.Width * 0.6f),
                    new PointF(panel1.Width * 0.4f, panel1.Width * 0.8f),
                    new PointF(panel1.Width * 0.8f, panel1.Width * 0.3f),
                };
                g.DrawLines(p, ps);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            offset += 10;
            if (offset > 360)
            {
                timer1.Enabled = false;
                offset = 0;
                return;
            }

            panel1.Invalidate(); 
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            SetDns();
            _isOpen = true;
            timer1.Enabled = true;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void CbDns_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentDns = cbDns.Text;
            GetDns();
            panel1.Invalidate();
        }

        private void CbDns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbDns.Text.Length > 0 && !cbDns.Items.Contains(cbDns.Text))
                {
                    _dns.Add(cbDns.Text);
                    WriteRegistry();
                    InitCombobox();
                }
            }
        }

        private void WriteRegistry()
        {
            var str = "";
            foreach (var item in _dns)
            {
                str+= item.ToString() + "#";
            }

            RegistryHelper.WriteRegistry("evinf", "steps", str);
        }
    }
}
