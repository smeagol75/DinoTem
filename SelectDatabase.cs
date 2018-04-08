using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DinoTem
{
    public partial class SelectDatabase : Form
    {
        public SelectDatabase()
        {
            InitializeComponent();
        }

        private void SelectDatabase_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            DirectoryInfo d = new DirectoryInfo(Application.StartupPath + @"\Data");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.csv"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(file.Name);
            }
        }

        private void applyTeam_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select a database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }
    }
}
