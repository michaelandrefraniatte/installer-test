using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace updater_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string path = textBox2.Text;
            if (!File.Exists(path))
                SaveFile(url, path);
            if (File.Exists(path))
                Process.Start(path);
        }
        public void SaveFile(string url, string filename)
        {
            WebClient client = new WebClient();
            client.DownloadFile(url, filename);
            client.Dispose();
        }
    }
}