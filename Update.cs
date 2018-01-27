using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace DinoTem
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebRequest request1 = WebRequest.Create("http://lagun2.altervista.org/DinoTem/link.txt");
            request1.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response1 = request1.GetResponse();
            Console.WriteLine(((HttpWebResponse)response1).StatusDescription);
            Stream dataStream1 = response1.GetResponseStream();
            StreamReader reader1 = new StreamReader(dataStream1);
            string responseFromServer1 = reader1.ReadToEnd();
            string coso1 = null;
            coso1 = responseFromServer1;
            string versione1 = coso1;
            reader1.Close();
            response1.Close();
            Process.Start(versione1);
            this.Close();
            this.Dispose();
        }
    }
}
