using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Net.NetworkInformation;


namespace AutoMailer
{
    public partial class Form1 : Form
    {
        public string ServerStatus;


        public string ServerStatusBy(string url)
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(url);
            Console.WriteLine("Status of Host: {0}", url);
            if (reply.Status == IPStatus.Success)
            {
                string ServerStatus = "Server - " + reply.Address.ToString() + "Status - " + reply.Status;
                Console.WriteLine("Server is live");
                return ServerStatus;
            }
            else
                Console.WriteLine("server not live");
            return ServerStatus;
        }
        public Form1()
        {
            InitializeComponent();
            var timer = new System.Threading.Timer(
                e => ServerStatusBy(ConfigurationManager.AppSettings.Get("Key0")),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(1));
            
           // label2.Text = ServerStatusBy(ConfigurationManager.AppSettings.Get("Key0"));
             label2.Text = ServerStatusBy(ConfigurationManager.AppSettings.Get("Key0"));


        }
    }
}
