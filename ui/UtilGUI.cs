using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Team_Editor_Manager_New_Generation.ui
{
    public class UtilGUI
    {
        public static void changeColorLabel(Label label)
        {
            try
            {
                if (int.Parse(label.Text) < 75)
                {
                    label.BackColor = System.Drawing.Color.Transparent;
                }
                if (int.Parse(label.Text) >= 75 & int.Parse(label.Text) < 80)
                {
                    label.BackColor = Color.GreenYellow;
                }
                else if (int.Parse(label.Text) >= 80 & int.Parse(label.Text) < 90)
                {
                    label.BackColor = Color.Yellow;
                }
                else if (int.Parse(label.Text) >= 90 & int.Parse(label.Text) < 95)
                {
                    label.BackColor = Color.Orange;
                }
                else if (int.Parse(label.Text) >= 95)
                {
                    label.BackColor = Color.Red;
                }
            }
            catch
            {
                label.BackColor = System.Drawing.Color.Transparent;
            }
        }

        public static void changeColorTextBox(TextBox textBox)
        {
            try
            {
                if (int.Parse(textBox.Text) < 75)
                {
                    textBox.BackColor = Color.White;
                }
                else if (int.Parse(textBox.Text) >= 75 & int.Parse(textBox.Text) < 80)
                {
                    textBox.BackColor = Color.GreenYellow;
                }
                else if (int.Parse(textBox.Text) >= 80 & int.Parse(textBox.Text) < 90)
                {
                    textBox.BackColor = Color.Yellow;
                }
                else if (int.Parse(textBox.Text) >= 90 & int.Parse(textBox.Text) < 95)
                {
                    textBox.BackColor = Color.Orange;
                }
                else if (int.Parse(textBox.Text) >= 95)
                {
                    textBox.BackColor = Color.Red;
                }
            }
            catch
            {
                textBox.BackColor = Color.White;
            }
        }

        public static void changeColorNumericUpDown(NumericUpDown numericUpDown)
        {
            try
            {
                if (numericUpDown.Value <= 3)
                {
                    numericUpDown.BackColor = Color.White;
                }
                else if (numericUpDown.Value > 3 & numericUpDown.Value <= 5)
                {
                    numericUpDown.BackColor = Color.GreenYellow;
                }
                else if (numericUpDown.Value > 5 & numericUpDown.Value <= 6)
                {
                    numericUpDown.BackColor = Color.Yellow;
                }
                else if (numericUpDown.Value > 6 & numericUpDown.Value <= 7)
                {
                    numericUpDown.BackColor = Color.Orange;
                }
                else if (numericUpDown.Value > 7 & numericUpDown.Value <= 8)
                {
                    numericUpDown.BackColor = Color.Red;
                }
            }
            catch
            {
                numericUpDown.BackColor = Color.White;
            }
        }

        public static void changeColorLabelFm(TextBox textBox)
        {
            try
            {
                if (int.Parse(textBox.Text) < 10)
                {
                    textBox.BackColor = Color.White;
                }
                else if (int.Parse(textBox.Text) >= 11 & int.Parse(textBox.Text) < 16)
                {
                    textBox.BackColor = Color.GreenYellow;
                }
                else if (int.Parse(textBox.Text) >= 16)
                {
                    textBox.BackColor = Color.Green;
                }
            }
            catch
            {
                textBox.BackColor = Color.White;
            }
        }

        /*private static int lastItm = 0;
        public static void giocatoreSearch(ListView giocatoreView, TextBox search)
        {
                int col = 0;
                int colCount = col + 1;
                bool find = false;

                if (search.Name == "searchPlayer")
                    lastItm = player;

                for (int colAll = col; colAll < colCount; colAll++)
                {
                    for (int lst12 = lastItm; lst12 < giocatoreView.Items.Count; lst12++)
                    {
                        if (giocatoreView.Items[lst12].SubItems[colAll].Text.IndexOf(search.Text) > -1 |
                            giocatoreView.Items[lst12].SubItems[colAll].Text.ToUpper().IndexOf(search.Text.ToUpper()) > -1)
                        {
                            giocatoreView.TopItem = giocatoreView.Items[lst12];

                            //if (lastItm > 0) PlayerView1.Items[lastItm - 1].BackColor = Color.Empty;
                            if (lastItm > 0) giocatoreView.Items[lastItm - 1].Selected = false;
                            giocatoreView.Items[lst12].Selected = true;
                            giocatoreView.Select();
                            //PlayerView1.Items[lst12].BackColor = Color.FromArgb(183, 215, 254);

                            lastItm = lst12 + 1;
                            find = true;
                            break;
                        }

                    }
                    if (find)
                        break;
                    DialogResult dialogResult = MessageBox.Show("Do you want restart research?", Application.ProductName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lastItm = 0;
                        giocatoreView.TopItem = giocatoreView.Items[0];
                        giocatoreView.Items[0].Selected = true;
                        giocatoreView.Select();
                    }

                }

                
                if (search.Name == "searchPlayer")
                    player = lastItm;
        }
        */

        private static int lastItm2 = 0;
        private static int ball = 0;
        private static int team = 0;
        private static int stadium = 0;
        private static int fmPlayer = 0;
        private static int player = 0;
        private static int coach = 0;
        private static int boot = 0;
        private static int glove = 0;
        public static void listBoxSearch(ListBox listbox, TextBox search)
        {
            int col = 0;
            int colCount = col + 1;
            bool find = false;

            if (search.Name == "fmSearchPlayer")
                lastItm2 = fmPlayer;
            else if (search.Name == "searchBall")
               lastItm2 = ball;
            else if (search.Name == "searchTeam")
                lastItm2 = team;
            else if (search.Name == "searchStadium")
                lastItm2 = stadium;
            else if (search.Name == "searchPlayer")
                lastItm2 = player;
            else if (search.Name == "searchCoach")
                lastItm2 = coach;
            else if (search.Name == "searchBoot")
                lastItm2 = boot;
            else if (search.Name == "searchGlove")
                lastItm2 = glove;

            for (int colAll = col; colAll < colCount; colAll++)
            {
                for (int lst12 = lastItm2; lst12 < listbox.Items.Count; lst12++)
                {
                    string textListbox = UniDecode.Unidecoder.Unidecode(listbox.Items[lst12].ToString());
                    if (textListbox.IndexOf(UniDecode.Unidecoder.Unidecode(search.Text)) > -1 |
                        textListbox.ToUpper().IndexOf(UniDecode.Unidecoder.Unidecode(search.Text).ToUpper()) > -1)
                    {
                        listbox.SelectedIndex = lst12;
                        listbox.Select();

                        lastItm2 = lst12 + 1;
                        find = true;
                        break;
                    }

                }
                if (find)
                    break;
                DialogResult dialogResult = MessageBox.Show("Do you want restart research?", Application.ProductName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    lastItm2 = 0;
                    listbox.SelectedIndex = 0;
                    listbox.Select();
                }

            }

            if (search.Name == "fmSearchPlayer")
                fmPlayer = lastItm2;
            else if (search.Name == "searchBall")
                ball = lastItm2;
            else if (search.Name == "searchTeam")
                team = lastItm2;
            else if (search.Name == "searchStadium")
                stadium = lastItm2;
            else if (search.Name == "searchPlayer")
                player = lastItm2;
            else if (search.Name == "searchCoach")
                coach = lastItm2;
            else if (search.Name == "searchBoot")
                boot = lastItm2;
            else if (search.Name == "searchGlove")
                glove = lastItm2;
        }

        private static int lastItm3 = 0;
        private static int fmTeam = 0;
        private static int teamA = 0;
        private static int teamB = 0;
        public static void comboBoxSearch(ComboBox comboBox, TextBox search)
        {
            int col = 0;
            int colCount = col + 1;
            bool find = false;

            string text = UniDecode.Unidecoder.Unidecode(search.Text);
            if (search.Name == "fmSearchTeam")
                lastItm3 = fmTeam;
            else if (search.Name == "searchTeamAB" && comboBox.Name == "teamBox1")
            {
                lastItm3 = teamA;
                text = search.Text.Substring(2);
            }
            else if (search.Name == "searchTeamAB" && comboBox.Name == "teamBox2")
            {
                lastItm3 = teamB;
                text = search.Text.Substring(2);
            }

            for (int colAll = col; colAll < colCount; colAll++)
            {
                for (int lst12 = lastItm3; lst12 < comboBox.Items.Count; lst12++)
                {
                    string textComboBox = UniDecode.Unidecoder.Unidecode(comboBox.Items[lst12].ToString());
                    if (textComboBox.IndexOf(text) > -1 |
                        textComboBox.ToUpper().IndexOf(text.ToUpper()) > -1)
                    {
                        comboBox.SelectedIndex = lst12;
                        comboBox.Select();

                        lastItm3 = lst12 + 1;
                        find = true;
                        break;
                    }

                }
                if (find)
                    break;
                DialogResult dialogResult = MessageBox.Show("Do you want restart research?", Application.ProductName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    lastItm3 = 0;
                    comboBox.SelectedIndex = 0;
                    comboBox.Select();
                }

            }

            if (search.Name == "fmSearchTeam")
                fmTeam = lastItm3;
            else if (search.Name == "searchTeamAB" && comboBox.Name == "teamBox1")
                teamA = lastItm3;
            else if (search.Name == "searchTeamAB" && comboBox.Name == "teamBox2")
                teamB = lastItm3;
        }

        public static void resetField()
        {
            player = 0;
            ball = 0;
            team = 0;
            stadium = 0;
            fmPlayer = 0;

            fmTeam = 0;
            teamA = 0;
            teamB = 0;
        }

    }
}
