using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DinoTem.model;

namespace DinoTem.ui
{
    //pes 18, pes 17
    public class ControllerDB
    {
        private string stadium = "";

        public Stadium getStadiumDatabase()
        {
            Stadium st = null;

            DatabaseStadium.Stadium s = new DatabaseStadium.Stadium();
            DataTable table = s.GetData();
            if (stadium != "")
            {
                foreach (DataRow row1 in table.Rows)
                {
                    if (stadium == row1["name"].ToString())
                    {
                        st = new Stadium((ushort)row1["id"]);
                        st.setKonamiName(row1["konamiName"].ToString());
                        st.setJapaneseName(row1["japaneseName"].ToString());
                        st.setName(row1["name"].ToString());
                        st.setNa(0);
                        st.setCapacity((uint)row1["capacity"]);
                        st.setZone((byte)row1["zone"]);
                        st.setLicense((uint)row1["license"]);
                        st.setCountry((uint)row1["countryId"]);
                    }
                }
            }

            return st;
        }

        public void setStadiumDatabase(string stadium)
        {
            this.stadium = stadium;
        }

        public void loadStadium(ListView databaseView)
        {
            DatabaseStadium.Stadium s = new DatabaseStadium.Stadium();
            // Get data
            DataTable table = s.GetData();

            databaseView.Columns.Clear();
            databaseView.Items.Clear();
            databaseView.Columns.Add("name");
            databaseView.Columns[0].Width = 215;

            //EXAMPLE
            foreach (DataRow row1 in table.Rows)
            {
                ListViewItem item = new ListViewItem(row1["name"].ToString().ToString());
                databaseView.Items.Add(item); //Add this row to the ListView
            }

            //DELETE ALL DUPLICATE
            var tags = new HashSet<string>();
            var duplicates = new List<ListViewItem>();

            foreach (ListViewItem item in databaseView.Items)
            {
                // HashSet.Add() returns false if it already contains the key.
                if (!tags.Add(item.Text))
                    duplicates.Add(item);
            }

            foreach (ListViewItem item in duplicates)
                item.Remove();
        }

        public void readStadium(CheckBox db14, CheckBox db15, CheckBox db16, 
            TextBox dbHome, TextBox dbRealName, TextBox dbIdStadium, TextBox dbStadiumName,
            TextBox dbJapaneseName, TextBox dbStadiumCapacity, TextBox dbStadiumKonami,
            CheckBox dbStadiumLicensed, ListView databaseView, int intselectedindex)
        {
            db14.Checked = false;
            db15.Checked = false;
            db16.Checked = false;

            DatabaseStadium.Stadium s = new DatabaseStadium.Stadium();
            DataTable table = s.GetData();
            // //altri dati
            foreach (DataRow row1 in table.Rows)
            {
                if (row1["name"].ToString() == databaseView.Items[intselectedindex].Text)
                {
                    dbStadiumName.Text = row1["name"].ToString();
                    dbIdStadium.Text = row1["id"].ToString();
                    dbRealName.Text = row1["realName"].ToString();
                    dbHome.Text = row1["team"].ToString();
                    dbJapaneseName.Text = row1["japaneseName"].ToString();
                    dbStadiumCapacity.Text = row1["capacity"].ToString();
                    dbStadiumKonami.Text = row1["konamiName"].ToString();
                    if (row1["license"].ToString() == "1")
                        dbStadiumLicensed.Checked = true;
                    else
                        dbStadiumLicensed.Checked = false;
                    if (row1["typePes"].ToString() == "14")
                        db14.Checked = true;
                    if (row1["typePes"].ToString() == "15")
                        db15.Checked = true;
                    if (row1["typePes"].ToString() == "16")
                        db16.Checked = true;
                }
            }
            return;
        }

    }
}
