using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using UniDecode;
using DinoTem.model;
using DinoTem.persistence;
using Team_Editor_Manager_New_Generation.ui;
using Team_Editor_Manager_New_Generation.persistence;

namespace DinoTem.ui
{
    public class Controller
    {
        private List<Country> countryList = new List<Country>();
        private List<BallCondition> ballConditionList = new List<BallCondition>();
        private List<Ball> ballList = new List<Ball>();
        private List<PlayerAppearance> playerAppearanceList = new List<PlayerAppearance>();
        private List<PlayerAssignment> playerAssignmentList = new List<PlayerAssignment>();
        private List<Player> playerList = new List<Player>();
        private List<TacticsFormation> tacticsFormationList = new List<TacticsFormation>();
        private List<Tactics> tacticsList = new List<Tactics>();
        private List<Team> teamList = new List<Team>();
        private List<Stadium> stadiumList = new List<Stadium>();
        private int bitRecognized = 0;

        public Controller()
        {
        }

        //form1
        //player
        //ball
        //team
        //stadium
        //DB2
        //Formazione form
        //Giocatore form
        //transferPlayer Drag&Drop
        //remove fake team
        //globalFunction
        //fm form

        public void readTeamPersister(string patch, int bitRecognized)
        {
            MyTeamPersister teamReader = new MyTeamPersister();

            try
            {
                teamList = teamReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readPlayerPersister(string patch, int bitRecognized)
        {
            MyPlayerPersister playerReader = new MyPlayerPersister();

            try
            {
                playerList = playerReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readBallConditionPersister(string patch, int bitRecognized)
        {
            MyBallConditionPersister ballConditionReader = new MyBallConditionPersister();

            try
            {
                ballConditionList = ballConditionReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readBallPersister(string patch, int bitRecognized)
        {
            MyBallPersister ballReader = new MyBallPersister();

            try
            {
                ballList = ballReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readCountryPersister(string patch, int bitRecognized)
        {
            MyCountryPersister countryReader = new MyCountryPersister();

            try
            {
                countryList = countryReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readPlayerAppearancePersister(string patch, int bitRecognized)
        {
            MyPlayerAppearancePersister playerAppearanceReader = new MyPlayerAppearancePersister();

            try
            {
                playerAppearanceList = playerAppearanceReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readPlayerAssignmentPersister(string patch, int bitRecognized)
        {
            MyPlayerAssignmentPersister playerAssignmentReader = new MyPlayerAssignmentPersister();

            try
            {
                playerAssignmentList = playerAssignmentReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readTacticsFormationPersister(string patch, int bitRecognized)
        {
            MyTacticsFormationPersister tacticsFormationReader = new MyTacticsFormationPersister();

            try
            {
                tacticsFormationList = tacticsFormationReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readTacticsPersister(string patch, int bitRecognized)
        {
            MyTacticsPersister tacticsReader = new MyTacticsPersister();

            try
            {
                tacticsList = tacticsReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void readStadiumsPersister(string patch, int bitRecognized)
        {
            MyStadiumPersister stadiumsReader = new MyStadiumPersister();

            try
            {
                stadiumList = stadiumsReader.load(patch, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void saveBallConditionPersister(string patch, Controller controller, int bitRecognized)
        {
            MyBallConditionPersister ballConditionSave = new MyBallConditionPersister();

            try
            {
                ballConditionSave.save(patch, controller, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved BallCondition.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void savePlayerAssignmentPersister(string patch, Controller controller, int bitRecognized)
        {
            MyPlayerAssignmentPersister playerAssignmentSave = new MyPlayerAssignmentPersister();

            try
            {
                playerAssignmentSave.save(patch, controller, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved PlayerAssignment.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void savePlayerAppearancePersister(string patch, Controller controller, int bitRecognized)
        {
            MyPlayerAppearancePersister playerAppearanceSave = new MyPlayerAppearancePersister();

            try
            {
                playerAppearanceSave.save(patch, controller, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved PlayerAppearance.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void saveTacticsFormationPersister(string patch, Controller controller, int bitRecognized)
        {
            MyTacticsFormationPersister tacticsFormationSave = new MyTacticsFormationPersister();

            try
            {
                tacticsFormationSave.save(patch, controller, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved TacticsFormation.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void saveBallPersister(string patch, Controller controller, int bitRecognized)
        {
            MyBallPersister ballSave = new MyBallPersister();

            try
            {
                ballSave.save(patch, controller, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Ball.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void savePlayerPersister(string patch, Controller controller, int bitRecognized)
        {
            MyPlayerPersister playerSave = new MyPlayerPersister();

            try
            {
                playerSave.save(patch, controller, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Player.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void saveTeamPersister(string patch, Controller controller, int bitRecognized)
        {
            MyTeamPersister teamSave = new MyTeamPersister();

            try
            {
                teamSave.save(patch, controller, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Team.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void saveStadiumPersister(string patch, Controller controller, int bitRecognized)
        {
            MyStadiumPersister stadiumSave = new MyStadiumPersister();

            try
            {
                stadiumSave.save(patch, controller, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Stadium.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int checkAllFile(string folder)
        {
            //PRIMO BYTE (PC/CONSOLE)
            //pc: pes17 00 pes18 04
            //xbox: pes17/pes18 01
            //ps3: pes17/18 02
            byte[] file = File.ReadAllBytes(folder + @"\Player.bin");
            MemoryStream memory = new MemoryStream(file);
            BinaryReader reader = new BinaryReader(memory);
            byte byteFirst = reader.ReadByte();
            reader.Close();
            
            byte[] file1 = File.ReadAllBytes(folder + @"\PlayerAssignment.bin");
            MemoryStream memory1 = new MemoryStream(file1);
            BinaryReader reader1 = new BinaryReader(memory1);
            byteFirst += reader1.ReadByte();
            reader1.Close();

            byte[] file2 = File.ReadAllBytes(folder + @"\Team.bin");
            MemoryStream memory2 = new MemoryStream(file2);
            BinaryReader reader2 = new BinaryReader(memory2);
            byteFirst += reader2.ReadByte();
            reader2.Close();

            byte[] file3 = File.ReadAllBytes(folder + @"\Country.bin");
            MemoryStream memory3 = new MemoryStream(file3);
            BinaryReader reader3 = new BinaryReader(memory3);
            byteFirst += reader3.ReadByte();
            reader3.Close();

            byte[] file4 = File.ReadAllBytes(folder + @"\Tactics.bin");
            MemoryStream memory4 = new MemoryStream(file4);
            BinaryReader reader4 = new BinaryReader(memory4);
            byteFirst += reader4.ReadByte();
            reader4.Close();

            byte[] file5 = File.ReadAllBytes(folder + @"\TacticsFormation.bin");
            MemoryStream memory5 = new MemoryStream(file5);
            BinaryReader reader5 = new BinaryReader(memory5);
            byteFirst += reader5.ReadByte();
            reader5.Close();

            byte[] file6 = File.ReadAllBytes(folder + @"\Ball.bin");
            MemoryStream memory6 = new MemoryStream(file6);
            BinaryReader reader6 = new BinaryReader(memory6);
            byteFirst += reader6.ReadByte();
            reader6.Close();

            byte[] file7 = File.ReadAllBytes(folder + @"\BallCondition.bin");
            MemoryStream memory7 = new MemoryStream(file7);
            BinaryReader reader7 = new BinaryReader(memory7);
            byteFirst += reader7.ReadByte();
            reader7.Close();

            byte[] file8 = File.ReadAllBytes(folder + @"\Stadium.bin");
            MemoryStream memory8 = new MemoryStream(file8);
            BinaryReader reader8 = new BinaryReader(memory8);
            byteFirst += reader8.ReadByte();
            reader8.Close();

            if (byteFirst == 0 || byteFirst == 36)
                return 0;
            else if (byteFirst == 9)
                return 1;
            else if (byteFirst == 18)
                return 2;
            else
            {
                MessageBox.Show("Check files! They may be corrupted!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return -1;
        }

        public void openDatabase(string folder, ComboBox teamBox1, ComboBox teamBox2, ListBox teamsBox, ListBox stadiumsBox, ListBox ballsBox,
            ComboBox squadraCountry, ComboBox stadiumCountry, ComboBox teamStadium, ListView giocatoreView, Form1 Form)
        {
            int bitRecognized = checkAllFile(folder);
            this.bitRecognized = bitRecognized;

            if (bitRecognized == 0)
                Form.Text = "Team Editor Manager 2018 - Pc Mode";
            else if (bitRecognized == 1)
                Form.Text = "Team Editor Manager 2018 - Xbox Mode";
            else if (bitRecognized == 2)
                Form.Text += "Team Editor Manager 2018 - Ps3 Mode";

            UtilGUI.resetField();

            teamBox1.Items.Clear();
            teamBox2.Items.Clear();
            giocatoreView.Items.Clear();
            teamsBox.Items.Clear();
            ballsBox.Items.Clear();
            stadiumsBox.Items.Clear();

            readTeamPersister(folder, bitRecognized);
            if (getListTeam().Count == 0)
            {
                MessageBox.Show("No teams found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            foreach (Team x in getListTeam())
            {
                teamBox1.Items.Add(x);
                teamBox2.Items.Add(x);
                teamsBox.Items.Add(x);
            }

            readBallConditionPersister(folder, bitRecognized);
            if (getBallConditionList().Count == 0)
            {
                MessageBox.Show("No balls conditions found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            readBallPersister(folder, bitRecognized);
            if (getListBall().Count == 0)
            {
                MessageBox.Show("No balls found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            foreach (Ball x in getListBall())
            {
                ballsBox.Items.Add(x);
            }

            readCountryPersister(folder, bitRecognized);
            if (countryList.Count == 0)
            {
                MessageBox.Show("No countries found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            foreach (Country x in getListCountry())
            {
                squadraCountry.Items.Add(x.getName());
                stadiumCountry.Items.Add(x.getName());
            }

            readPlayerAppearancePersister(folder, bitRecognized);
            if (getPlayerAppearanceList().Count == 0)
            {
                MessageBox.Show("No players appeareance found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            readPlayerAssignmentPersister(folder, bitRecognized);
            if (getPlayerAssignmentList().Count == 0)
            {
                MessageBox.Show("No countries found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            readPlayerPersister(folder, bitRecognized);
            if (getListPlayer().Count == 0)
            {
                MessageBox.Show("No players found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            foreach (Player x in getListPlayer())
            {
                giocatoreView.Items.Add(x.ToString());
            }
            readTacticsFormationPersister(folder, bitRecognized);
            if (getTacticsFormationList().Count == 0)
            {
                MessageBox.Show("No tactics formation found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            readTacticsPersister(folder, bitRecognized);
            if (getTacticsList().Count == 0)
            {
                MessageBox.Show("No tactics found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            readStadiumsPersister(folder, bitRecognized);
            if (getListStadium().Count == 0)
            {
                MessageBox.Show("No stadiums found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }
            foreach (Stadium x in getListStadium())
            {
                stadiumsBox.Items.Add(x);
                teamStadium.Items.Add(x);
            }

            teamBox1.SelectedIndex = 0;
            teamBox2.SelectedIndex = 0;
            ballsBox.SelectedIndex = 0;
            teamsBox.SelectedIndex = 0;
            stadiumsBox.SelectedIndex = 0;
        }

        public int getBitRecognized()
        {
            return bitRecognized;
        }

        public List<Team> getListTeam()
        {
            return teamList;
        }

        public List<Ball> getListBall()
        {
            return ballList;
        }

        public List<Stadium> getListStadium()
        {
            return stadiumList;
        }

        public List<Player> getListPlayer()
        {
            return playerList;
        }

        public List<Country> getListCountry()
        {
            return countryList;
        }

        public Dictionary<long, Country> getCountryMap()
        {
            var result = new Dictionary<long, Country>();

            foreach (Country country in countryList)
            {
                result.Add((long)country.getId(), country);
            }

            return result;
        }

        public List<BallCondition> getBallConditionList()
        {
            return ballConditionList;
        }

        public List<PlayerAssignment> getPlayerAssignmentList()
        {
            return playerAssignmentList;
        }

        public List<PlayerAppearance> getPlayerAppearanceList()
        {
            return playerAppearanceList;
        }

        public List<TacticsFormation> getTacticsFormationList()
        {
            return tacticsFormationList;
        }

        public List<Tactics> getTacticsList()
        {
            return tacticsList;
        }

        public List<PlayerAssignment> getPlayersTeam(int idTeam)
        {
            List<PlayerAssignment> result = new List<PlayerAssignment>();
            foreach (PlayerAssignment playerA in playerAssignmentList)
            {
                if (idTeam == playerA.getTeamId())
                    result.Add(playerA);
            }
            return result;
        }

        public Player getPlayerById(int positionList)
        {
            int k = 0;
            foreach (Player player in playerList)
            {
                if (k == positionList)
                    return player;
                k++;
            }
            return null;
        }

        public Player getPlayerById(int positionInTeam, int team)
        {
            foreach (PlayerAssignment playerA in playerAssignmentList)
            {
                if (playerA.getTeamId() == team)
                    if (playerA.getOrder() == positionInTeam)
                        return getPlayerById(playerA.getPlayerId());
            }
            return null;
        }

        public int getPositionListPlayerById(long idPlayer) {
		    int i = 0;
			foreach (Player temp in playerList) {
			    if (idPlayer == temp.getId())
				    return i;
				i++;
		    }
		    return 0;
        }
		
		public Player getPlayerById(long idPlayer) {
		    foreach (Player temp in playerList) {
			    if (idPlayer == temp.getId())
				    return temp;
		    }
		    return null;
        }

        public Team getTeamById(int positionList)
        {
            int k = 0;
            foreach (Team team in teamList)
            {
                if (k == positionList)
                    return team;
                k++;
            }
            return null;
        }

        public Team getTeamById2(int teamId) {
            foreach (Team temp in teamList)
            {
			    if (teamId == temp.getId())
                    return temp;
		    }
		    return null;
	    }

        public void changePlayerName(long idPlayer, string name)
        {
            Player temp = getPlayerById(idPlayer);
            if (idPlayer == temp.getId())
                temp.setPlayerName(name);
        }

        public void changeShirtPlayer(long idPlayer, string name)
        {
            Player temp = getPlayerById(idPlayer);
            string decode = Unidecoder.Unidecode(name);
            if (idPlayer == temp.getId())
                temp.setShirtName(decode);
        }

        public void changePlayerNumber(long idPlayer, int idTeam, int shirtNumber)
        {
            foreach (PlayerAssignment temp in playerAssignmentList)
            {
                if (idPlayer == temp.getPlayerId() && idTeam == temp.getTeamId())
                    temp.setShirtNumber(shirtNumber);
            }
        }

        public void UpdateForm(ComboBox t1, ComboBox t2)
        {
            try
            {
                t1.SelectedIndex = t1.SelectedIndex + 1;
                t1.SelectedIndex = t1.SelectedIndex - 1;
            }
            catch { 
			    t1.SelectedIndex = t1.SelectedIndex - 1;
                t1.SelectedIndex = t1.SelectedIndex + 1;
			};

            try
            {
                t2.SelectedIndex = t2.SelectedIndex + 1;
                t2.SelectedIndex = t2.SelectedIndex - 1;
            }
            catch
            {
                t2.SelectedIndex = t2.SelectedIndex - 1;
                t2.SelectedIndex = t2.SelectedIndex + 1;
            };
        }

        public void updatePlayerList(ListView l1)
        {
            l1.Items.Clear();
            foreach (Player x in getListPlayer())
            {
                l1.Items.Add(x.ToString());
            }
            l1.Items[0].Selected = true;
            l1.Select();
        }

        public void UpdateBallList(ListBox l1)
        {
            l1.Items.Clear();
            foreach (Ball x in getListBall())
            {
                l1.Items.Add(x);
            }
            l1.SelectedIndex = 0;
        }

        public void UpdateTeamList(ListBox l1, ComboBox t1, ComboBox t2)
        {
            l1.Items.Clear();
            t1.Items.Clear();
            t2.Items.Clear();
            foreach (Team x in getListTeam())
            {
                l1.Items.Add(x);
                t1.Items.Add(x);
                t2.Items.Add(x);
            }
            l1.SelectedIndex = 0;
            t1.SelectedIndex = 0;
            t2.SelectedIndex = 0;
        }

        public void UpdateFormPlayer(ListView l1, Player temp)
        {
            l1.Items[getPositionListPlayerById(temp.getId())].Text = temp.getPlayerName();
        }

        public string getStringClubTeamOfPlayer(long idPlayer, int type) {

            //club = 0; national = 1;

            List<int> b = new List<int>();
            foreach (PlayerAssignment temp in playerAssignmentList)
            {
                if (idPlayer == temp.getPlayerId())
                    b.Add(temp.getTeamId());
            }

            string finale = "";
            if (type == 0)
            {
                foreach (int i in b)
                {
                    foreach (Team temp in teamList)
                    {
                        if (i == temp.getId() && !temp.getNational())
                            return temp.getEnglish();
                    }
                }
            }
            else if (type == 1)
            {
                foreach (int i in b)
                {
                    foreach (Team temp in teamList)
                    {
                        if (i == temp.getId() && temp.getNational())
                            finale += temp.getEnglish() + "+";
                    }

                }

                if (finale.EndsWith("+"))
                {
                    finale = finale.Substring(0, finale.LastIndexOf("+"));
                }
            }
		
		    return finale;
        }

        public List<int> getNumberFormation(int idTeam) {
		    List<int> result = new List<int>();

            foreach (Tactics tactics in tacticsList)
            {
                if (idTeam == tactics.getTeamID())
                    result.Add(tactics.getTacticsID());  
		    }

		    return result;
	    }

        public List<TacticsFormation> getPositionTeam(int tattica)
        {
            List<TacticsFormation> result = new List<TacticsFormation>();

            foreach (TacticsFormation temp in tacticsFormationList)
            {
			    if (tattica == temp.getTeamTacticId())
				    result.Add(temp);
		    }
            
		    return result;
	    }

        public Ball getBallById(int positionList)
        {
            int k = 0;
            foreach (Ball ball in ballList)
            {
                if (k == positionList)
                    return ball;
                k++;
            }
            return null;
        }

        public Ball getBallById2(int idBall)
        {
            foreach (Ball ball in ballList)
            {
                if (idBall == ball.getId())
                    return ball;
            }
            return null;
        }

        public void getBallConditionById(int id, TextBox t1, TextBox t2, TextBox t3, TextBox t4)
        {
            int k = 0;
            foreach (BallCondition x in ballConditionList)
                if (x.getId() == id)
                {
                    if (t1.Enabled == false && k == 0)
                    {
                        t1.Text = x.getUnknown().ToString();
                        t1.Enabled = true;
                    }
                    if (t2.Enabled == false && k == 1)
                    {
                        t2.Text = x.getUnknown().ToString();
                        t2.Enabled = true;
                    }
                    if (t3.Enabled == false && k == 2)
                    {
                        t3.Text = x.getUnknown().ToString();
                        t3.Enabled = true;
                    }
                    if (t4.Enabled == false && k == 3)
                    {
                        t4.Text = x.getUnknown().ToString();
                        t4.Enabled = true;
                    }
                    k++;
                }
        }

        public Country getCountryById(int positionList)
        {
            int k = 0;
            foreach (Country temp in countryList)
            {
                if (k == positionList)
                    return temp;
                k++;
            }
            return null;
        }

        //Player
        public void changeNationalPlayer(Player temp, Country country)
        {
            temp.setNational(country.getId());
        }

        public void changeSecondNationalPlayer(Player temp, Country country)
        {
            temp.setNational2(country.getId());
        }

        //Ball
        public void changeBallName(Ball ball, string name)
        {
            ball.setName(name);
        }

        public void changeBallOrder(Ball ball, int order)
        {
            ball.setOrder(order);
        }

        public void changeBallUnknown(Ball x, int bytePosition, int unk)
        {
            int k = 0;
            foreach (BallCondition temp in ballConditionList)
            {
                if (x.getId() == temp.getId())  {
					if (k == bytePosition)
						temp.setUnknown(unk);
					k++;
				}
            }
        }

        //Team
        public void changeTeamName(Team team, string name)
        {
            if (team.getNational())
            {
                National temp2 = (National)team;

                temp2.setDutch(name);
                temp2.setEnglishUS(name);
                temp2.setFrench(name);
                temp2.setGerman(name);
                temp2.setGreek(name);
                temp2.setItalian(name);
                temp2.setPortuguese(name);
                temp2.setBrazilianPortuguese(name);
                temp2.setRussian(name);
                temp2.setSpanish(name);
                temp2.setLatinAmericaSpanish(name);
                temp2.setSwedish(name);
                temp2.setTurkish(name);
            }
            team.setEnglish(name);
            team.setJapanese(name);
        }

        public void changeTeamJapaneseName(Team team, string name)
        {
            team.setJapanese(name);
        }

        public void changeTeamSpanishName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setSpanish(name);
        }

        public void changeTeamTurkishName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setTurkish(name);
        }

        public void changeTeamSwedishName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setSwedish(name);
        }

        public void changeTeamGreekName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setGreek(name);
        }

        public void changeTeamPortugueseName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setPortuguese(name);
        }

        public void changeTeamItalianName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setItalian(name);
        }

        public void changeTeamEnglishName(Team team, string name)
        {
            team.setEnglish(name);
        }

        public void changeTeamGermanName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setGerman(name);
        }

        public void changeTeamRussianName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setRussian(name);
        }

        public void changeTeamLatinAmericaSpanishName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setLatinAmericaSpanish(name);
        }

        public void changeTeamBrazilianPortugueseName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setBrazilianPortuguese(name);
        }

        public void changeTeamEnglishUsName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setEnglishUS(name);
        }

        public void changeTeamFrenchName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setFrench(name);
        }

        public void changeTeamDutchName(Team team, string name)
        {
            National temp2 = (National)team;
            temp2.setDutch(name);
        }

        public void changeTeamShortName(Team team, string name)
        {
            team.setShortSquadra(name);
        }

        public void changeFakeTeam(Team team, bool boolean)
        {
            team.setFakeTeam(boolean);
        }

        public void changeLicensedTeam(Team team, bool boolean)
        {
            team.setLicensedTeam(boolean);
        }

        public void changeLicensedCoach(Team team, bool boolean)
        {
            team.setLicensedCoach(boolean);
        }

        public void changeNotPlayableLeague(Team team, int value)
        {
            team.setNotPlayableLeague(value);
        }

        public void changeCountryTeam(Team team, int positionListCountry)
        {
            Country temp2 = getCountryById(positionListCountry);
            team.setCountry(temp2.getId());
        }

        public Stadium getTeamStadium(Team temp)
        {
            for (int i = 0; i < getListStadium().Count; i++)
            {
                if (temp.getStadiumId() == getListStadium()[i].getId())
                    return getListStadium()[i];
            }

            return null;
        }

        public void changeStadiumTeam(Team team, Stadium stadium)
        {
            team.setStadiumId(stadium.getId());
        }

        public void changeHasLicensedPlayers(Team team, bool value)
        {
            team.setHasLicensedPlayers(value);
        }

        public void changeHasAnthem(Team team, bool value)
        {
            team.setHasAnthem(value);
        }

        public void changeAnthemStandingAngle(Team team, int value)
        {
            team.setAnthemStandingAngle(value);
        }

        public void changeAnthemPlayersSinging(Team team, int value)
        {
            team.setAnthemPlayersSinging(value);
        }

        public void changeAnthemStandingStyle(Team team, int value)
        {
            team.setAnthemStandingStyle(value);
        }

        public void changeUnknown(Team team, bool value)
        {
            team.setUnknown6(value);
        }

        //Stadium
        public void changeStadiumName(Stadium stadium, string name)
        {
            stadium.setName(name);
        }

        public void changeStadiumJapaneseName(Stadium stadium, string name)
        {
            stadium.setJapaneseName(name);
        }

        public void changeStadiumKonamiName(Stadium stadium, string name)
        {
            stadium.setKonamiName(name);
        }

        public void changeStadiumCapacity(Stadium stadium, int capacity)
        {
            stadium.setCapacity(capacity);
        }

        public void changeStadiumNa(Stadium stadium, int na)
        {
            stadium.setNa(na);
        }

        public void changeCountryStadium(Stadium stadium, int positionListCountry)
        {
            Country temp2 = getCountryById(positionListCountry);
            stadium.setCountry(temp2.getId());
        }

        public void changeZoneStadium(Stadium stadium, int value)
        {
            stadium.setZone(value + 2);
        }

        public void changeLicensedStadium(Stadium team, bool boolean)
        {
            team.setLicense(boolean);
        }

        //DB2
        //List<Country> countryList = new List<Country>();
        List<Stadium> stadiumList2 = new List<Stadium>();
        List<Team> teamList2 = new List<Team>();
        List<TacticsFormation> tacticsFormationList2 = new List<TacticsFormation>();
        //List<Tactics> tacticsList2 = new List<Tactics>();
        List<Player> playerList2 = new List<Player>();
        List<BallCondition> ballConditionList2 = new List<BallCondition>();
        List<Ball> ballList2 = new List<Ball>();
        List<PlayerAppearance> playerAppearanceList2 = new List<PlayerAppearance>();
        //List<PlayerAssignment> playerAssignmentList2 = new List<PlayerAssignment>();

        public List<Stadium> getListStadium2()
        {
            return stadiumList2;
        }

        public List<Team> getListTeam2()
        {
            return teamList2;
        }

        public List<TacticsFormation> getListTacticsFormationList2()
        {
            return tacticsFormationList2;
        }

        public List<Player> getListPlayer2()
        {
            return playerList2;
        }

        public List<BallCondition> getListBallCondition2()
        {
            return ballConditionList2;
        }

        public List<Ball> getListBall2()
        {
            return ballList2;
        }

        public List<PlayerAppearance> getListPlayerAppearance2()
        {
            return playerAppearanceList2;
        }

        public void openDb2(string folder)
        {
            int bitRecognized = checkAllFile(folder);

            MyTeamPersister teamReader = new MyTeamPersister();
            try
            {
                teamList2 = teamReader.load(folder, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MyPlayerPersister playerReader = new MyPlayerPersister();
            try
            {
                playerList2 = playerReader.load(folder, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MyBallConditionPersister ballConditionReader = new MyBallConditionPersister();
            try
            {
                ballConditionList2 = ballConditionReader.load(folder, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MyBallPersister ballReader = new MyBallPersister();
            try
            {
                ballList2 = ballReader.load(folder, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MyPlayerAppearancePersister playerAppearanceReader = new MyPlayerAppearancePersister();
            try
            {
                playerAppearanceList2 = playerAppearanceReader.load(folder, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MyTacticsFormationPersister tacticsFormationReader = new MyTacticsFormationPersister();
            try
            {
                tacticsFormationList2 = tacticsFormationReader.load(folder, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MyStadiumPersister stadiumsReader = new MyStadiumPersister();
            try
            {
                stadiumList2 = stadiumsReader.load(folder, bitRecognized);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void importDb2AllBalls()
        {
            for (int i = 0; i < getListBall().Count; i++)
            {
                if (i > getListBall2().Count())
                    return;
                getListBall()[i].setName(getListBall2()[i].getName());
                getListBall()[i].setOrder(getListBall2()[i].getOrder());
            }

            /*for (int i = 0; i < getBallConditionList().Count; i++)
            {
                if (i > getListBallCondition2().Count())
                    return;
                getBallConditionList()[i].setFrag(getListBallCondition2()[i].getFrag());
                getBallConditionList()[i].setUnknown(getListBallCondition2()[i].getUnknown());
            }*/
        }

        public void importDb2OrderBalls()
        {
            for (int i = 0; i < getListBall().Count; i++)
            {
                if (i > getListBall2().Count())
                    return;
                getListBall()[i].setName(getListBall2()[i].getName());
            }
        }

        public void importDb2NamesBalls()
        {
            for (int i = 0; i < getListBall().Count; i++)
            {
                if (i > getListBall2().Count())
                    return;
                getListBall()[i].setName(getListBall2()[i].getName());
            }
        }

        public void importDb2AllTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;
                getListTeam()[i].setAnthemPlayersSinging(getListTeam2()[k].getAnthemPlayersSinging());
                getListTeam()[i].setAnthemStandingAngle(getListTeam2()[k].getAnthemStandingAngle());
                getListTeam()[i].setAnthemStandingStyle(getListTeam2()[k].getAnthemStandingStyle());
                getListTeam()[i].setCountry(getListTeam2()[k].getCountry());
                getListTeam()[i].setEnglish(getListTeam2()[k].getEnglish());
                getListTeam()[i].setFakeTeam(getListTeam2()[k].getFakeTeam());
                getListTeam()[i].setFeederTeamId(getListTeam2()[k].getFeederTeamId());
                getListTeam()[i].setHasAnthem(getListTeam2()[k].getHasAnthem());
                getListTeam()[i].setHasLicensedPlayers(getListTeam2()[k].getHasLicensedPlayers());
                getListTeam()[i].setJapanese(getListTeam2()[k].getJapanese());
                getListTeam()[i].setKonami(getListTeam2()[k].getKonami());
                getListTeam()[i].setLicensedCoach(getListTeam2()[k].getLicensedCoach());
                getListTeam()[i].setLicensedTeam(getListTeam2()[k].getLicensedTeam());
                getListTeam()[i].setManagerId(getListTeam2()[k].getManagerId());
                getListTeam()[i].setNational(getListTeam2()[k].getNational());
                getListTeam()[i].setNotPlayableLeague(getListTeam2()[k].getNotPlayableLeague());
                getListTeam()[i].setParentTeamId(getListTeam2()[k].getParentTeamId());
                getListTeam()[i].setShortSquadra(getListTeam2()[k].getShortSquadra());
                getListTeam()[i].setStadiumId(getListTeam2()[k].getStadiumId());
                getListTeam()[i].setTeamSortNumber(getListTeam2()[k].getTeamSortNumber());
                getListTeam()[i].setUnknown6(getListTeam2()[k].getUnknown6());

                if (getListTeam2()[k].getNational())
                {
                    National nat2 = (National) getListTeam2()[k];
                    National nat = (National)getListTeam()[k];

                    nat.setDutch(nat2.getDutch());
                    nat.setEnglishUS(nat2.getEnglishUS());
                    nat.setFrench(nat2.getFrench());
                    nat.setGerman(nat2.getGerman());
                    nat.setGreek(nat2.getGreek());
                    nat.setItalian(nat2.getItalian());
                    nat.setPortuguese(nat2.getPortuguese());
                    nat.setBrazilianPortuguese(nat2.getBrazilianPortuguese());
                    nat.setRussian(nat2.getRussian());
                    nat.setSpanish(nat2.getSpanish());
                    nat.setLatinAmericaSpanish(nat2.getLatinAmericaSpanish());
                    nat.setSwedish(nat2.getSwedish());
                    nat.setTurkish(nat2.getTurkish());
                }
                k++;
            }
        }

        public void importDb2NamesTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setEnglish(getListTeam2()[k].getEnglish());
                getListTeam()[i].setJapanese(getListTeam2()[k].getJapanese());
                getListTeam()[i].setKonami(getListTeam2()[k].getKonami());
                if (getListTeam2()[k].getNational())
                {
                    National nat2 = (National)getListTeam2()[k];
                    National nat = (National)getListTeam()[i];

                    nat.setDutch(nat2.getDutch());
                    nat.setEnglishUS(nat2.getEnglishUS());
                    nat.setFrench(nat2.getFrench());
                    nat.setGerman(nat2.getGerman());
                    nat.setGreek(nat2.getGreek());
                    nat.setItalian(nat2.getItalian());
                    nat.setPortuguese(nat2.getPortuguese());
                    nat.setBrazilianPortuguese(nat2.getBrazilianPortuguese());
                    nat.setRussian(nat2.getRussian());
                    nat.setSpanish(nat2.getSpanish());
                    nat.setLatinAmericaSpanish(nat2.getLatinAmericaSpanish());
                    nat.setSwedish(nat2.getSwedish());
                    nat.setTurkish(nat2.getTurkish());
                }
                k++;
            }
        }

        public void importDb2ShortNamesTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setShortSquadra(getListTeam2()[k].getShortSquadra());

                k++;
            }
        }

        public void importDb2HomeStadiumsTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setStadiumId(getListTeam2()[k].getStadiumId());

                k++;
            }
        }

        public void importDb2OtherDetailsTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setAnthemPlayersSinging(getListTeam2()[k].getAnthemPlayersSinging());
                getListTeam()[i].setAnthemStandingAngle(getListTeam2()[k].getAnthemStandingAngle());
                getListTeam()[i].setAnthemStandingStyle(getListTeam2()[k].getAnthemStandingStyle());
                getListTeam()[i].setHasAnthem(getListTeam2()[k].getHasAnthem());
                getListTeam()[i].setHasLicensedPlayers(getListTeam2()[k].getHasLicensedPlayers());
                getListTeam()[i].setUnknown6(getListTeam2()[k].getUnknown6());

                k++;
            }
        }

        public void importDb2CountryTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setCountry(getListTeam2()[k].getCountry());

                k++;
            }
        }

        public void importDb2FakeTeamTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setFakeTeam(getListTeam2()[k].getFakeTeam());

                k++;
            }
        }

        public void importDb2NotPlayableLeagueTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setNotPlayableLeague(getListTeam2()[k].getNotPlayableLeague());

                k++;
            }
        }

        public void importDb2LicenseTeamTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setLicensedTeam(getListTeam2()[k].getLicensedTeam());

                k++;
            }
        }

        public void importDb2LicenseCoachTeams(int from, int to)
        {
            int k = 0;
            for (int i = from; i < to; i++)
            {
                if (k > getListTeam2().Count())
                    return;

                getListTeam()[i].setLicensedCoach(getListTeam2()[k].getLicensedCoach());

                k++;
            }
        }

        //Formazione form
        public void numeriMagliaPitch(ListView list, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            player1.Text = list.Items[0].SubItems[5].Text;
            player2.Text = list.Items[1].SubItems[5].Text;
            player3.Text = list.Items[2].SubItems[5].Text;
            player4.Text = list.Items[3].SubItems[5].Text;
            player5.Text = list.Items[4].SubItems[5].Text;
            player6.Text = list.Items[5].SubItems[5].Text;
            player7.Text = list.Items[6].SubItems[5].Text;
            player8.Text = list.Items[7].SubItems[5].Text;
            player9.Text = list.Items[8].SubItems[5].Text;
            player10.Text = list.Items[9].SubItems[5].Text;
            player11.Text = list.Items[10].SubItems[5].Text;
        }

        public void schemiPitch(int formationNumber, string nomeSchema, int typeSchema, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //typeSchema CUSTOM = 0, OFFENSIVE = 1, DEFENSIVE = 2;
            int k = 0;
            foreach (TacticsFormation temp in getPositionTeam(formationNumber))
            {
                if (nomeSchema == "Default") {
                    if (typeSchema == 0)
                        schemaDefault(temp.getX(), temp.getY(), k, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 1)
                        schemaDefault(temp.getX(), temp.getY(), k - 11, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 2)
                        schemaDefault(temp.getX(), temp.getY(), k - 22, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                }
                else if (nomeSchema == "4-5-1")
                {
                    if (typeSchema == 0)
                        schema451(temp.getX(), temp.getY(), k, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 1)
                        schema451(temp.getX(), temp.getY(), k - 11, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 2)
                        schema451(temp.getX(), temp.getY(), k - 22, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                }
                else if (nomeSchema == "4-4-2")
                {
                    if (typeSchema == 0)
                        schema442(temp.getX(), temp.getY(), k, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 1)
                        schema442(temp.getX(), temp.getY(), k - 11, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 2)
                        schema442(temp.getX(), temp.getY(), k - 22, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                }
                else if (nomeSchema == "4-3-3")
                {
                    if (typeSchema == 0)
                        schema433(temp.getX(), temp.getY(), k, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 1)
                        schema433(temp.getX(), temp.getY(), k - 11, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 2)
                        schema433(temp.getX(), temp.getY(), k - 22, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                }
                else if (nomeSchema == "3-5-2")
                {
                    if (typeSchema == 0)
                        schema352(temp.getX(), temp.getY(), k, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 1)
                        schema352(temp.getX(), temp.getY(), k - 11, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 2)
                        schema352(temp.getX(), temp.getY(), k - 22, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                }
                else if (nomeSchema == "3-4-3")
                {
                    if (typeSchema == 0)
                        schema343(temp.getX(), temp.getY(), k, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 1)
                        schema343(temp.getX(), temp.getY(), k - 11, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 2)
                        schema343(temp.getX(), temp.getY(), k - 22, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                }
                else if (nomeSchema == "5-4-1")
                {
                    if (typeSchema == 0)
                        schema541(temp.getX(), temp.getY(), k, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 1)
                        schema541(temp.getX(), temp.getY(), k - 11, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 2)
                        schema541(temp.getX(), temp.getY(), k - 22, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                }
                else if (nomeSchema == "5-3-2")
                {
                    if (typeSchema == 0)
                        schema532(temp.getX(), temp.getY(), k, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 1)
                        schema532(temp.getX(), temp.getY(), k - 11, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                    else if (typeSchema == 2)
                        schema532(temp.getX(), temp.getY(), k - 22, player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11);
                }

                k++;
            }
        }

        public void schemaDefault(int x, int y, int k, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //k = per evitare di fare una lista; si attiva solo un bottone alla volta

            //assegnare posizioni giocatori
            //  m M
            //X 7-99
            //Y 3-47
            // *3,*9
            //position default 1; 413
            if (k == 0)
                player1.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 1)
                player2.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 2)
                player3.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 3)
                player4.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 4)
                player5.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 5)
                player6.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 6)
                player7.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 7)
                player8.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 8)
                player9.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 9)
                player10.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
            if (k == 10)
                player11.Location = new System.Drawing.Point(x * 3 + 1, 413 - y * 9);
        }

        public void schema451(int x, int y, int k, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //k = per evitare di fare una lista; si attiva solo un bottone alla volta
            if (k == 0)
                player1.Location = new System.Drawing.Point(157, 386);
            if (k == 1)
                player2.Location = new System.Drawing.Point(190, 323);
            if (k == 2)
                player3.Location = new System.Drawing.Point(124, 323);
            if (k == 3)
                player4.Location = new System.Drawing.Point(268, 305);
            if (k == 4)
                player5.Location = new System.Drawing.Point(46, 305);
            if (k == 5)
                player6.Location = new System.Drawing.Point(205, 215);
            if (k == 6)
                player7.Location = new System.Drawing.Point(109, 215);
            if (k == 7)
                player8.Location = new System.Drawing.Point(268, 143);
            if (k == 8)
                player9.Location = new System.Drawing.Point(46, 143);
            if (k == 9)
                player10.Location = new System.Drawing.Point(157, 161);
            if (k == 10)
                player11.Location = new System.Drawing.Point(157, 35);
        }

        public void schema442(int x, int y, int k, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //k = per evitare di fare una lista; si attiva solo un bottone alla volta
            if (k == 0)
                player1.Location = new System.Drawing.Point(157, 386);
            if (k == 1)
                player2.Location = new System.Drawing.Point(190, 323);
            if (k == 2)
                player3.Location = new System.Drawing.Point(124, 323);
            if (k == 3)
                player4.Location = new System.Drawing.Point(268, 305);
            if (k == 4)
                player5.Location = new System.Drawing.Point(46, 305);
            if (k == 5)
                player6.Location = new System.Drawing.Point(193, 233);
            if (k == 6)
                player7.Location = new System.Drawing.Point(121, 233);
            if (k == 7)
                player8.Location = new System.Drawing.Point(259, 143);
            if (k == 8)
                player9.Location = new System.Drawing.Point(55, 143);
            if (k == 9)
                player10.Location = new System.Drawing.Point(199, 26);
            if (k == 10)
                player11.Location = new System.Drawing.Point(115, 26);
        }

        public void schema433(int x, int y, int k, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //k = per evitare di fare una lista; si attiva solo un bottone alla volta
            if (k == 0)
                player1.Location = new System.Drawing.Point(157, 386);
            if (k == 1)
                player2.Location = new System.Drawing.Point(190, 323);
            if (k == 2)
                player3.Location = new System.Drawing.Point(124, 323);
            if (k == 3)
                player4.Location = new System.Drawing.Point(268, 305);
            if (k == 4)
                player5.Location = new System.Drawing.Point(46, 305);
            if (k == 5)
                player6.Location = new System.Drawing.Point(157, 188);
            if (k == 6)
                player7.Location = new System.Drawing.Point(211, 188);
            if (k == 7)
                player8.Location = new System.Drawing.Point(100, 188);
            if (k == 8)
                player9.Location = new System.Drawing.Point(256, 80);
            if (k == 9)
                player10.Location = new System.Drawing.Point(55, 80);
            if (k == 10)
                player11.Location = new System.Drawing.Point(157, 26);
        }

        public void schema352(int x, int y, int k, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //k = per evitare di fare una lista; si attiva solo un bottone alla volta
            if (k == 0)
                player1.Location = new System.Drawing.Point(157, 386);
            if (k == 1)
                player2.Location = new System.Drawing.Point(157, 323);
            if (k == 2)
                player3.Location = new System.Drawing.Point(220, 323);
            if (k == 3)
                player4.Location = new System.Drawing.Point(94, 323);
            if (k == 4)
                player5.Location = new System.Drawing.Point(157, 197);
            if (k == 5)
                player6.Location = new System.Drawing.Point(211, 197);
            if (k == 6)
                player7.Location = new System.Drawing.Point(103, 197);
            if (k == 7)
                player8.Location = new System.Drawing.Point(265, 197);
            if (k == 8)
                player9.Location = new System.Drawing.Point(49, 197);
            if (k == 9)
                player10.Location = new System.Drawing.Point(190, 53);
            if (k == 10)
                player11.Location = new System.Drawing.Point(124, 53);
        }

        public void schema343(int x, int y, int k, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //k = per evitare di fare una lista; si attiva solo un bottone alla volta
            if (k == 0)
                player1.Location = new System.Drawing.Point(157, 386);
            if (k == 1)
                player2.Location = new System.Drawing.Point(157, 323);
            if (k == 2)
                player3.Location = new System.Drawing.Point(220, 323);
            if (k == 3)
                player4.Location = new System.Drawing.Point(94, 323);
            if (k == 4)
                player5.Location = new System.Drawing.Point(193, 197);
            if (k == 5)
                player6.Location = new System.Drawing.Point(118, 197);
            if (k == 6)
                player7.Location = new System.Drawing.Point(268, 188);
            if (k == 7)
                player8.Location = new System.Drawing.Point(46, 188);
            if (k == 8)
                player9.Location = new System.Drawing.Point(238, 62);
            if (k == 9)
                player10.Location = new System.Drawing.Point(76, 62);
            if (k == 10)
                player11.Location = new System.Drawing.Point(157, 35);
        }

        public void schema541(int x, int y, int k, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //k = per evitare di fare una lista; si attiva solo un bottone alla volta
            if (k == 0)
                player1.Location = new System.Drawing.Point(157, 386);
            if (k == 1)
                player2.Location = new System.Drawing.Point(157, 296);
            if (k == 2)
                player3.Location = new System.Drawing.Point(211, 323);
            if (k == 3)
                player4.Location = new System.Drawing.Point(109, 323);
            if (k == 4)
                player5.Location = new System.Drawing.Point(271, 296);
            if (k == 5)
                player6.Location = new System.Drawing.Point(43, 296);
            if (k == 6)
                player7.Location = new System.Drawing.Point(196, 215);
            if (k == 7)
                player8.Location = new System.Drawing.Point(115, 215);
            if (k == 8)
                player9.Location = new System.Drawing.Point(265, 134);
            if (k == 9)
                player10.Location = new System.Drawing.Point(49, 134);
            if (k == 10)
                player11.Location = new System.Drawing.Point(157, 53);
        }

        public void schema532(int x, int y, int k, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //k = per evitare di fare una lista; si attiva solo un bottone alla volta
            if (k == 0)
                player1.Location = new System.Drawing.Point(157, 386);
            if (k == 1)
                player2.Location = new System.Drawing.Point(157, 323);
            if (k == 2)
                player3.Location = new System.Drawing.Point(211, 323);
            if (k == 3)
                player4.Location = new System.Drawing.Point(100, 323);
            if (k == 4)
                player5.Location = new System.Drawing.Point(268, 305);
            if (k == 5)
                player6.Location = new System.Drawing.Point(46, 305);
            if (k == 6)
                player7.Location = new System.Drawing.Point(157, 197);
            if (k == 7)
                player8.Location = new System.Drawing.Point(238, 170);
            if (k == 8)
                player9.Location = new System.Drawing.Point(76, 170);
            if (k == 9)
                player10.Location = new System.Drawing.Point(202, 26);
            if (k == 10)
                player11.Location = new System.Drawing.Point(115, 26);
        }

        public void changeFormation(int formation, int i, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11,
            Button player13, Button player14, Button player15, Button player16, Button player17, Button player18, Button player19, Button player20, Button player21, Button player22,
            Button player24, Button player25, Button player26, Button player27, Button player28, Button player29, Button player30, Button player31, Button player32, Button player33)
        {
            //int i = 0 (CUSTOM), 1 (OFFENSIVE), 2 (DEFENSIVE)
            //CUSTOM
            int aa = -1;
            foreach (TacticsFormation x in tacticsFormationList)
            {
                if (x.getTeamTacticId() == formation)
                {
                    aa = aa + 1;
                    if (aa == 1 && i == 0)
                    {
                        //Posizione
                        int X2 = (player2.Location.X - 1) / 3;
                        int Y2 = (413 - player2.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 2 && i == 0)
                    {
                        //Posizione
                        int X2 = (player3.Location.X - 1) / 3;
                        int Y2 = (413 - player3.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 3 && i == 0)
                    {
                        //Posizione
                        int X2 = (player4.Location.X - 1) / 3;
                        int Y2 = (413 - player4.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 4 && i == 0)
                    {
                        //Posizione
                        int X2 = (player5.Location.X - 1) / 3;
                        int Y2 = (413 - player5.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 5 && i == 0)
                    {
                        //Posizione
                        int X2 = (player6.Location.X - 1) / 3;
                        int Y2 = (413 - player6.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 6 && i == 0)
                    {
                        //Posizione
                        int X2 = (player7.Location.X - 1) / 3;
                        int Y2 = (413 - player7.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 7 && i == 0)
                    {
                        //Posizione
                        int X2 = (player8.Location.X - 1) / 3;
                        int Y2 = (413 - player8.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 8 && i == 0)
                    {
                        //Posizione
                        int X2 = (player9.Location.X - 1) / 3;
                        int Y2 = (413 - player9.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 9 && i == 0)
                    {
                        //Posizione
                        int X2 = (player10.Location.X - 1) / 3;
                        int Y2 = (413 - player10.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 10 && i == 0)
                    {
                        //Posizione
                        int X2 = (player11.Location.X - 1) / 3;
                        int Y2 = (413 - player11.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    //OFFENSIVE
                    if (aa == (1 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player13.Location.X - 1) / 3;
                        int Y2 = (413 - player13.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (2 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player14.Location.X - 1) / 3;
                        int Y2 = (413 - player14.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (3 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player15.Location.X - 1) / 3;
                        int Y2 = (413 - player15.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (4 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player16.Location.X - 1) / 3;
                        int Y2 = (413 - player16.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (5 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player17.Location.X - 1) / 3;
                        int Y2 = (413 - player17.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (6 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player18.Location.X - 1) / 3;
                        int Y2 = (413 - player18.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (7 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player19.Location.X - 1) / 3;
                        int Y2 = (413 - player19.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (8 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player20.Location.X - 1) / 3;
                        int Y2 = (413 - player20.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (9 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player21.Location.X - 1) / 3;
                        int Y2 = (413 - player21.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (10 + 11) && i == 1)
                    {
                        //Posizione
                        int X2 = (player22.Location.X - 1) / 3;
                        int Y2 = (413 - player22.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    //DEFENSIVE
                    if (aa == (1 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player24.Location.X - 1) / 3;
                        int Y2 = (413 - player24.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (2 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player25.Location.X - 1) / 3;
                        int Y2 = (413 - player25.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (3 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player26.Location.X - 1) / 3;
                        int Y2 = (413 - player26.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (4 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player27.Location.X - 1) / 3;
                        int Y2 = (413 - player27.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (5 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player28.Location.X - 1) / 3;
                        int Y2 = (413 - player28.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (6 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player29.Location.X - 1) / 3;
                        int Y2 = (413 - player29.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (7 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player30.Location.X - 1) / 3;
                        int Y2 = (413 - player30.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (8 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player31.Location.X - 1) / 3;
                        int Y2 = (413 - player31.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (9 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player32.Location.X - 1) / 3;
                        int Y2 = (413 - player32.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (10 + 22) && i == 2)
                    {
                        //Posizione
                        int X2 = (player33.Location.X - 1) / 3;
                        int Y2 = (413 - player33.Location.Y) / 9;
                        x.setX(X2);
                        x.setY(Y2);
                    }
                }
            }
            
        }

        private int getPosition(int k, int subItem, ListView teamView1)
        {
            int pos = -1;
            if (k >= 11 && k < 22)
                k = k - 10;

            if (k >= 22)
                k = k - 21;
            //Position
            if (teamView1.Items[k].SubItems[subItem].Text == "GK")
                pos = 0;
            else if (teamView1.Items[k].SubItems[subItem].Text == "CB")
                pos = 1;
            else if (teamView1.Items[k].SubItems[subItem].Text == "LB")
                pos = 2;
            else if (teamView1.Items[k].SubItems[subItem].Text == "RB")
                pos = 3;
            else if (teamView1.Items[k].SubItems[subItem].Text == "DMF")
                pos = 4;
            else if (teamView1.Items[k].SubItems[subItem].Text == "CMF")
                pos = 5;
            else if (teamView1.Items[k].SubItems[subItem].Text == "LMF")
                pos = 6;
            else if (teamView1.Items[k].SubItems[subItem].Text == "AMF")
                pos = 7;
            else if (teamView1.Items[k].SubItems[subItem].Text == "RMF")
                pos = 8;
            else if (teamView1.Items[k].SubItems[subItem].Text == "LWF")
                pos = 9;
            else if (teamView1.Items[k].SubItems[subItem].Text == "RWF")
                pos = 10;
            else if (teamView1.Items[k].SubItems[subItem].Text == "SS")
                pos = 11;
            else if (teamView1.Items[k].SubItems[subItem].Text == "CF")
                pos = 12;

            return pos;
        }

        public void applyTeam(int formation, int i, ListView teamView1)
        {
            //int i = 1 (CUSTOM), 2 (OFFENSIVE), 3 (DEFENSIVE)
            //cambiare posizione ai giocatori
            int aa = -1;
            foreach (TacticsFormation x in tacticsFormationList)
            {
                if (x.getTeamTacticId() == formation)
                {
                    aa = aa + 1;
                    if (aa == 0)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 1)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 2)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 3)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 4)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 5)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 6)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 7)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 8)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 9)
                        x.setPosition(getPosition(aa, i, teamView1));
                    if (aa == 10)
                        x.setPosition(getPosition(aa, i, teamView1));
                }
            }
        }

        public void changeShooters(Team temp, int capitainSelectedIndex, int penaltySelectedIndex,
            int longSelectedIndex, int leftSelectedIndex, int shortSelectedIndex, int rightSelectedIndex)
        {
            //save Captain, etc...
            foreach (PlayerAssignment x in playerAssignmentList)
            {
                if (x.getTeamId() == temp.getId())
                {
                    x.setCaptain(false);
                    x.setLeftCkTk(false);
                    x.setLongShotLk(false);
                    x.setPenaltyKick(false);
                    x.setRightCornerKick(false);
                    x.setShortFoulFk(false);

                    if (x.getOrder() == capitainSelectedIndex)
                        x.setCaptain(true);
                    if (x.getOrder() == penaltySelectedIndex)
                        x.setPenaltyKick(true);
                    if (x.getOrder() == longSelectedIndex)
                        x.setLongShotLk(true);
                    if (x.getOrder() == leftSelectedIndex)
                        x.setLeftCkTk(true);
                    if (x.getOrder() == shortSelectedIndex)
                        x.setShortFoulFk(true);
                    if (x.getOrder() == rightSelectedIndex)
                        x.setRightCornerKick(true);
                }
            }
        }

        //Giocatore form
        public int getSkinColour(Player temp)
        {
            int output1 = 0;
            foreach (PlayerAppearance x in getPlayerAppearanceList())
            {
                if (temp.getId() == x.getId())
                {
                    if (getBitRecognized() == 0)
                    {
                        int skin = x.getEyeskinColor();
                        string eye = skin.ToString("X2");
                        eye = Convert.ToString(Convert.ToInt32(eye.ToString(), 16), 2).PadLeft(8, '0');
                        eye = eye.Substring(5, 3);
                        output1 = Convert.ToInt32(eye, 2);
                    }
                    else
                    {
                        int skin = x.getEyeskinColor();
                        string eye = skin.ToString("X2");
                        eye = Convert.ToString(Convert.ToInt32(eye.ToString(), 16), 2).PadLeft(8, '0');
                        eye = eye.Substring(0, 3);
                        output1 = Convert.ToInt32(eye, 2);
                    }
                    
                }
            }
            return output1;
        }

        public Team getYouthClub(Player temp)
        {
            Team nullo = new Club(99999);
            nullo.setEnglish("No Team");

            Team team = getTeamById2((int)temp.getYouthPlayerId());
            if (team == null)
                return nullo;

            return team;
        }

        public void changeSkinColour(Player temp, int value)
        {
            foreach (PlayerAppearance x in getPlayerAppearanceList())
            {
                if (temp.getId() == x.getId())
                {
                    if (getBitRecognized() == 0)
                    {
                        int skin = x.getEyeskinColor();
                        string eye = skin.ToString("X2");
                        eye = Convert.ToString(Convert.ToInt32(eye.ToString(), 16), 2).PadLeft(8, '0');
                        eye = eye.Substring(0, 5) + MyBinary.ToBinaryX(value, 3);
                        x.setEyeskinColor(Byte.Parse(MyBinary.BinaryToInt(eye).ToString()));
                    }
                    else
                    {
                        int skin = x.getEyeskinColor();
                        string eye = skin.ToString("X2");
                        eye = Convert.ToString(Convert.ToInt32(eye.ToString(), 16), 2).PadLeft(8, '0');
                        eye = MyBinary.ToBinaryX(value, 3) + eye.Substring(3, 5);
                        x.setEyeskinColor(Byte.Parse(MyBinary.BinaryToInt(eye).ToString()));
                    }
                }
            }
        }

        public void changeYouthClub(Player temp, Team temp2)
        {
            if (temp2.getId() == 99999)
                temp.setYouthPlayerId(0);
            else
                temp.setYouthPlayerId(temp2.getId());
        }

        //transferPlayer Drag&Drop
        public void transferPlayerAtoA(int intselectedindex, int dropIndex, int idTeam, ComboBox teamBox1, ComboBox teamBox2)
        {
            foreach (PlayerAssignment x in playerAssignmentList)
            {
                long playerID = 0;
                long playerID2 = 0;
                if (x.getTeamId() == idTeam)
                {
                    if (x.getOrder() == intselectedindex)
                        playerID = x.getPlayerId();
                    if (x.getOrder() == dropIndex)
                        playerID2 = x.getPlayerId();

                    if (x.getPlayerId() == playerID)
                        x.setOrder(dropIndex);
                    if (x.getPlayerId() == playerID2)
                        x.setOrder(intselectedindex);
                }
            }
            //
            UpdateForm(teamBox1, teamBox2);
        }

        private void setPlayerTrasfer(PlayerAssignment temp, int idTeamA, int order)
        {
            temp.setTeamId(idTeamA);
            temp.setShortFoulFk(false);
            temp.setRightCornerKick(false);
            temp.setPenaltyKick(false);
            temp.setOrder(order);
            temp.setLongShotLk(false);
            temp.setLeftCkTk(false);
            temp.setCaptain(false);
        }

        private void findEntryID(PlayerAssignment temp)
        {
            //genera anche numero causuale
            // estremi [da, a)
            int da = 1;
            int a = 99;

            // Possibili valori di numeroCasuale: {1, 2, 3, 4, 5, 6...}
            Random random = new Random();
            int numeroCasuale = random.Next(da, a);
            temp.setShirtNumber(numeroCasuale);
            //SEARCH VALUE
            int n = -1;
            while (n == -1)
            {
                // estremi [da, a)
                int da1 = 1;
                int a1 = 9999;

                // Possibili valori di numeroCasuale: {1, 2, 3, 4, 5, 6...}
                Random random1 = new Random();
                int numeroCasuale1 = random1.Next(da1, a1);

                foreach (PlayerAssignment x in playerAssignmentList)
                {
                    if (numeroCasuale1 != x.getEntryId())
                    {
                        n = numeroCasuale1;
                        temp.setEntryId(n);
                        return;
                    }
                }
            }
            return;
        }

        public void orderPlayerInTeam2(List<PlayerAssignment> getPlayersTeam)
        {
            //List<PlayerAssignment> temp = getPlayersTeam.OrderBy(o => o.getOrder()).ToList();
            for (int i = 0; i < getPlayersTeam.Count; i++)
            {
                getPlayersTeam[i].setOrder(i);
            }
        }

        public void transferPlayerBtoA(int intselectedindexPlayer, Team teamA, Team teamB, int orderTeamA, ComboBox teamBox1, ComboBox teamBox2)
        {
            bool ok = false;
            foreach (PlayerAssignment x in playerAssignmentList)
            {
                if (teamB.getId() == x.getTeamId())
                    if (x.getOrder() == intselectedindexPlayer) //trovo il giocatore della squadra di partenza
                        ok = true;

                if (ok)
                {
                    if (teamB.getNational()) //squadra partenza é una nazionale
                    {
                        if (teamA.getNational()) //se la squadra di destinazione è una nazionale
                        {
                            PlayerAssignment temp = new PlayerAssignment(x.getPlayerId(), teamA.getId());
                            setPlayerTrasfer(temp, teamA.getId(), orderTeamA);
                            findEntryID(temp);
                            playerAssignmentList.Add(temp);
                        }
                        else // se è un club
                        {
                            foreach (PlayerAssignment playerA in playerAssignmentList)
                            {
                                if (x.getPlayerId() == playerA.getPlayerId())
                                {
                                    if (!getTeamById2(playerA.getTeamId()).getNational())
                                    {
                                        setPlayerTrasfer(playerA, teamA.getId(), orderTeamA);
                                        //
                                        UpdateForm(teamBox1, teamBox2);
                                        return;
                                    }
                                }

                            }
                            // se il giocatore è svincolato
                            PlayerAssignment temp = new PlayerAssignment(x.getPlayerId(), teamA.getId());
                            setPlayerTrasfer(temp, teamA.getId(), orderTeamA);
                            findEntryID(temp);
                            playerAssignmentList.Add(temp);
                        }

                    }
                    else //squadra partenza é un club
                    {
                        if (teamA.getNational()) //se la squadra di destinazione è una nazionale
                        {
                            PlayerAssignment temp = new PlayerAssignment(x.getPlayerId(), teamA.getId());
                            setPlayerTrasfer(temp, teamA.getId(), orderTeamA);
                            findEntryID(temp);
                            playerAssignmentList.Add(temp);
                        }
                        else  //o un club
                            setPlayerTrasfer(x, teamA.getId(), orderTeamA);

                    }
                    //
                    UpdateForm(teamBox1, teamBox2);
                    return;
                }
            }
        }

        public void playerFromPlayerList(long player, int teamId, ComboBox teamBox1, ComboBox teamBox2)
        {
            if (getTeamById2(teamId).getNational()) //se il team di destinazione è una nazionale
            {
                PlayerAssignment temp = new PlayerAssignment(player, teamId);
                setPlayerTrasfer(temp, teamId, getPlayersTeam(teamId).Count);
                findEntryID(temp);
                playerAssignmentList.Add(temp);
            }
            else //se è un club
            {
                if (getStringClubTeamOfPlayer(player,0) == "") //se non ha una squadra
                {
                    PlayerAssignment temp = new PlayerAssignment(player, teamId);
                    setPlayerTrasfer(temp, teamId, getPlayersTeam(teamId).Count);
                    findEntryID(temp);
                    playerAssignmentList.Add(temp);
                }
                else  //se ha una squadra
                {

                    foreach (PlayerAssignment playerA in playerAssignmentList)
                    {
                        if (player == playerA.getPlayerId())
                        {
                            if (!getTeamById2(playerA.getTeamId()).getNational())
                            {
                                setPlayerTrasfer(playerA, teamId, getPlayersTeam(teamId).Count);
                                UpdateForm(teamBox1, teamBox2);
                                return;
                            }

                        }
                    }

                }
            }
            UpdateForm(teamBox1, teamBox2);
            return;
        }

        public void deletePlayerTeam(int intselectedindex, int teamId, ComboBox teamBox1, ComboBox teamBox2)
        {
            for (int i = 0; i < playerAssignmentList.Count; i++)
            {
                PlayerAssignment x = (PlayerAssignment) playerAssignmentList[i];
                if (x.getTeamId() == teamId)
                {
                    if (x.getOrder() == intselectedindex)
                    {
                        playerAssignmentList.Remove(x);
                    }
                }
                
            }
            //
            UpdateForm(teamBox1, teamBox2);
        }

        //remove fake team
        public void removeFakeTeam()
        {
            foreach (Team temp in teamList)
            {
                /* PREMIER LEAGUE */
                if (temp.getId() == 100)
                {
                    temp.setEnglish("MANCHESTER UNITED");
                }
                if (temp.getId() == 102)
                {
                    temp.setEnglish("CHELSEA FC");
                }
                if (temp.getId() == 105)
                {
                    temp.setEnglish("WEST HAM UNITED");
                }
                if (temp.getId() == 173)
                {
                    temp.setEnglish("MANCHESTER CITY");
                }
                if (temp.getId() == 177)
                {
                    temp.setEnglish("EVERTON FC");
                }
                if (temp.getId() == 179)
                {
                    temp.setEnglish("TOTTENHAM HOTSPUR");
                }
                if (temp.getId() == 202)
                {
                    temp.setEnglish("BOLTON WANDERERS");
                }
                if (temp.getId() == 204)
                {
                    temp.setEnglish("LEICESTER CITY");
                }
                if (temp.getId() == 205)
                {
                    temp.setEnglish("MIDDLESBROUGH FC");
                }
                if (temp.getId() == 207)
                {
                    temp.setEnglish("SOUTHAMPTON FC");
                }
                if (temp.getId() == 378)
                {
                    temp.setEnglish("BURNLEY FC");
                }
                if (temp.getId() == 382)
                {
                    temp.setEnglish("CRYSTAL PALACE");
                }
                if (temp.getId() == 387)
                {
                    temp.setEnglish("MILLWALL");
                }
                if (temp.getId() == 395)
                {
                    temp.setEnglish("STOKE CITY");
                }
                if (temp.getId() == 396)
                {
                    temp.setEnglish("SUNDERLAND AFC");
                }
                if (temp.getId() == 398)
                {
                    temp.setEnglish("WATFORD FC");
                }
                if (temp.getId() == 399)
                {
                    temp.setEnglish("WEST BROMWICH ALBION");
                }
                if (temp.getId() == 1589)
                {
                    temp.setEnglish("HULL CITY");
                }
                if (temp.getId() == 1909)
                {
                    temp.setEnglish("SWANSEA CITY");
                }
                if (temp.getId() == 4071)
                {
                    temp.setEnglish("AFC BOURNEMOTUH");
                }
                if (temp.getId() == 4194)
                {
                    temp.setEnglish("SHEFFIELD UNITED");
                }

                /* SECOND DIVISION */
                if (temp.getId() == 104)
                {
                    temp.setEnglish("LEEDS UNITED");
                }
                if (temp.getId() == 106)
                {
                    temp.setEnglish("NEWCASTLE UNITED");
                }
                if (temp.getId() == 107)
                {
                    temp.setEnglish("ASTON VILLA");
                }
                if (temp.getId() == 176)
                {
                    temp.setEnglish("BLACKBURN ROVERS");
                }
                if (temp.getId() == 178)
                {
                    temp.setEnglish("FULHAM FC");
                }
                if (temp.getId() == 201)
                {
                    temp.setEnglish("BIRMINGHAM CITY");
                }
                if (temp.getId() == 208)
                {
                    temp.setEnglish("WOLVERHAMPTON WANDERERS");
                }
                if (temp.getId() == 377)
                {
                    temp.setEnglish("BRIGHTON & HOVE ALBION");
                }
                if (temp.getId() == 379)
                {
                    temp.setEnglish("CARDIFF CITY");
                }
                if (temp.getId() == 383)
                {
                    temp.setEnglish("DERBY COUNTRY");
                }
                if (temp.getId() == 386)
                {
                    temp.setEnglish("IPSWICH TOWN");
                }
                if (temp.getId() == 388)
                {
                    temp.setEnglish("NORWICH CITY");
                }
                if (temp.getId() == 389)
                {
                    temp.setEnglish("NOTTINGHAM FOREST");
                }
                if (temp.getId() == 391)
                {
                    temp.setEnglish("READING FC");
                }
                if (temp.getId() == 394)
                {
                    temp.setEnglish("SHEFFIELD WEDNESDAY");
                }
                if (temp.getId() == 400)
                {
                    temp.setEnglish("WIGAN ATHLETIC");
                }
                if (temp.getId() == 1327)
                {
                    temp.setEnglish("QUEENS PARK RANGERS");
                }
                if (temp.getId() == 1588)
                {
                    temp.setEnglish("BARNSLEY FC");
                }
                if (temp.getId() == 1760)
                {
                    temp.setEnglish("BRYSTOL CITY");
                }
                if (temp.getId() == 2610)
                {
                    temp.setEnglish("HUDDERSFIELD TOWN");
                }
                if (temp.getId() == 4180)
                {
                    temp.setEnglish("BRENTFORD FC");
                }
                if (temp.getId() == 4192)
                {
                    temp.setEnglish("PRESTON NORTH END");
                }
                if (temp.getId() == 4193)
                {
                    temp.setEnglish("ROTHERHAM UNITED");
                }
                if (temp.getId() == 5016)
                {
                    temp.setEnglish("BURTON ALBION");
                }

                /*SERIE A */
                if (temp.getId() == 120)
                {
                    temp.setEnglish("JUVENTUS FC");
                }
                if (temp.getId() == 1919)
                {
                    temp.setEnglish("U.S. SASSUOLO");
                }

                /*SERIE B */
                if (temp.getId() == 123)
                {
                    temp.setEnglish("PARMA");
                }
                if (temp.getId() == 187)
                {
                    temp.setEnglish("BRESCIA");
                }
                if (temp.getId() == 192)
                {
                    temp.setEnglish("HELLAS VERONA");
                }
                if (temp.getId() == 235)
                {
                    temp.setEnglish("EMPOLI");
                }
                if (temp.getId() == 238)
                {
                    temp.setEnglish("PALERMO");
                }
                if (temp.getId() == 317)
                {
                    temp.setEnglish("ASCOLI");
                }
                if (temp.getId() == 319)
                {
                    temp.setEnglish("BARI");
                }
                if (temp.getId() == 328)
                {
                    temp.setEnglish("PESCARA");
                }
                if (temp.getId() == 331)
                {
                    temp.setEnglish("TERNANA");
                }
                if (temp.getId() == 337)
                {
                    temp.setEnglish("VICENZA");
                }
                if (temp.getId() == 1362)
                {
                    temp.setEnglish("AC CESENA");
                }
                if (temp.getId() == 1600)
                {
                    temp.setEnglish("SPEZIA CALCIO");
                }
                if (temp.getId() == 1920)
                {
                    temp.setEnglish("AS CITTADELLA");
                }
                if (temp.getId() == 2612)
                {
                    temp.setEnglish("PRO VERCELLI");
                }
                if (temp.getId() == 2377)
                {
                    temp.setEnglish("NOVARA CALCIO");
                }
                if (temp.getId() == 4075)
                {
                    temp.setEnglish("CARPI FC");
                }
                if (temp.getId() == 4076)
                {
                    temp.setEnglish("US LATINA CALCIO");
                }
                if (temp.getId() == 4077)
                {
                    temp.setEnglish("TRAPANI");
                }
                if (temp.getId() == 4141)
                {
                    temp.setEnglish("AVELLINO");
                }
                if (temp.getId() == 4220)
                {
                    temp.setEnglish("CREMONESE");
                }
                if (temp.getId() == 4229)
                {
                    temp.setEnglish("VENEZIA FC");
                }
                if (temp.getId() == 4230)
                {
                    temp.setEnglish("VIRTUS ENTELLA");
                }
                if (temp.getId() == 4232)
                {
                    temp.setEnglish("BENEVENTO CALCIO");
                }
                if (temp.getId() == 4234)
                {
                    temp.setEnglish("FROSINONE CALCIO");
                }
                if (temp.getId() == 4240)
                {
                    temp.setEnglish("AC PERUGIA CALCIO");
                }
                if (temp.getId() == 4241)
                {
                    temp.setEnglish("AC PISA 1909");
                }
                if (temp.getId() == 4244)
                {
                    temp.setEnglish("US SALERNITANA");
                }
                if (temp.getId() == 4923)
                {
                    temp.setEnglish("SPAL 2013");
                }
                if (temp.getId() == 4929)
                {
                    temp.setEnglish("FOGGIA CALCIO");
                }

                //SPANISH LEAGUE
                if (temp.getId() == 109)
                {
                    temp.setEnglish("REAL MADRID");
                }
                if (temp.getId() == 110)
                {
                    temp.setEnglish("VALENCIA CF");
                }
                if (temp.getId() == 111)
                {
                    temp.setEnglish("RC DEPORTIVO");
                }
                if (temp.getId() == 194)
                {
                    temp.setEnglish("REAL BETIS");
                }
                if (temp.getId() == 195)
                {
                    temp.setEnglish("CELTA DE VIGO");
                }
                if (temp.getId() == 196)
                {
                    temp.setEnglish("REAL SOCIEDAD");
                }
                if (temp.getId() == 258)
                {
                    temp.setEnglish("ATHLETIC CLUB");
                }
                if (temp.getId() == 259)
                {
                    temp.setEnglish("RCD ESPANYOL");
                }
                if (temp.getId() == 260)
                {
                    temp.setEnglish("MALAGA CF");
                }
                if (temp.getId() == 263)
                {
                    temp.setEnglish("CA OSASUNA");
                }
                if (temp.getId() == 265)
                {
                    temp.setEnglish("SEVILLA FC");
                }
                if (temp.getId() == 267)
                {
                    temp.setEnglish("VILLAREAL CF");
                }
                if (temp.getId() == 363)
                {
                    temp.setEnglish("REAL SPORTING");
                }
                if (temp.getId() == 364)
                {
                    temp.setEnglish("UD LAS PALMAS");
                }
                if (temp.getId() == 1765)
                {
                    temp.setEnglish("GRANADA CF");
                }
                if (temp.getId() == 4145)
                {
                    temp.setEnglish("ALAVES");
                }
                if (temp.getId() == 4146)
                {
                    temp.setEnglish("SD EIBAR");
                }
                if (temp.getId() == 4272)
                {
                    temp.setEnglish("CD LEGANES");
                }

                //SPANISH SECOND DIVISION
                if (temp.getId() == 261)
                {
                    temp.setEnglish("RCD MALLORCA");
                }
                if (temp.getId() == 266)
                {
                    temp.setEnglish("REAL VALLADOLID");
                }
                if (temp.getId() == 268)
                {
                    temp.setEnglish("REAL ZARAGOZA");
                }
                if (temp.getId() == 357)
                {
                    temp.setEnglish("UD ALMERIA");
                }
                if (temp.getId() == 359)
                {
                    temp.setEnglish("CORDOBA CF");
                }
                if (temp.getId() == 361)
                {
                    temp.setEnglish("ELCHE CF");
                }
                if (temp.getId() == 362)
                {
                    temp.setEnglish("GETAFE CF");
                }
                if (temp.getId() == 366)
                {
                    temp.setEnglish("LEVANTE UD");
                }
                if (temp.getId() == 368)
                {
                    temp.setEnglish("CD NUMANCIA");
                }
                if (temp.getId() == 370)
                {
                    temp.setEnglish("RAYO VALLECANO");
                }
                if (temp.getId() == 2187)
                {
                    temp.setEnglish("GIRONA CF");
                }
                if (temp.getId() == 2188)
                {
                    temp.setEnglish("SD HUESCA");
                }
                if (temp.getId() == 2393)
                {
                    temp.setEnglish("AD ALCORCON");
                }
                if (temp.getId() == 2615)
                {
                    temp.setEnglish("CD LUGO");
                }
                if (temp.getId() == 2616)
                {
                    temp.setEnglish("CD MIRANDES");
                }
                if (temp.getId() == 4090)
                {
                    temp.setEnglish("FC BARCELONA B");
                }
                if (temp.getId() == 4147)
                {
                    temp.setEnglish("CD TENERIFE");
                }
                if (temp.getId() == 4252)
                {
                    temp.setEnglish("CULTURAL Y DEPORTIVA LEONE");
                }
                if (temp.getId() == 4260)
                {
                    temp.setEnglish("REAL OVIEDO");
                }
                if (temp.getId() == 4288)
                {
                    temp.setEnglish("GIMNASTIC DE TARRAGONA");
                }
                if (temp.getId() == 4298)
                {
                    temp.setEnglish("CF REUS");
                }
                if (temp.getId() == 4308)
                {
                    temp.setEnglish("CADIZ CF");
                }
                if (temp.getId() == 4320)
                {
                    temp.setEnglish("SEVILLA ATLETICO");
                }
                if (temp.getId() == 4992)
                {
                    temp.setEnglish("UCAM MURCIA CF");
                }
                if (temp.getId() == 4302)
                {
                    temp.setEnglish("ALBACETE BALOMPIE");
                }
                if (temp.getId() == 4314)
                {
                    temp.setEnglish("LORCA");
                }

                //PORTUGAL
                if (temp.getId() == 192)
                {
                    temp.setEnglish("FC PORTO");
                }
                if (temp.getId() == 1804)
                {
                    temp.setEnglish("VITORIA FC");
                }
                if (temp.getId() == 1944)
                {
                    temp.setEnglish("CD NACIONAL");
                }
                if (temp.getId() == 1973)
                {
                    temp.setEnglish("OS BELENENSES");
                }
                if (temp.getId() == 1974)
                {
                    temp.setEnglish("SC BRAGA");
                }
                if (temp.getId() == 1976)
                {
                    temp.setEnglish("CS MARITIMO");
                }
                if (temp.getId() == 1981)
                {
                    temp.setEnglish("VITORIA CF");
                }
                if (temp.getId() == 1979)
                {
                    temp.setEnglish("RIO AVE");
                }
                if (temp.getId() == 1978)
                {
                    temp.setEnglish("PACOS DE FERREIRA");
                }
                if (temp.getId() == 2369)
                {
                    temp.setEnglish("OLHANENSE");
                }
                if (temp.getId() == 2380)
                {
                    temp.setEnglish("FC AROUCA");
                }
                if (temp.getId() == 2382)
                {
                    temp.setEnglish("ACADEMICA DE COIMBRA");
                }
                if (temp.getId() == 2383)
                {
                    temp.setEnglish("ESTORIL PRAIA");
                }
                if (temp.getId() == 2385)
                {
                    temp.setEnglish("CD FEIRENSE");
                }
                if (temp.getId() == 2388)
                {
                    temp.setEnglish("MOREIRENSE FC");
                }
                if (temp.getId() == 2614)
                {
                    temp.setEnglish("TONDELA");
                }
                if (temp.getId() == 4085)
                {
                    temp.setEnglish("GD CHAVES");
                }
                if (temp.getId() == 4323)
                {
                    temp.setEnglish("BOAVISTA FC");
                }
            }
            //
        }

        //remove fake team
        public void removeFakePlayer()
        {
            foreach (Player temp in playerList)
            {
                if (temp.getId() == 263150)
                {
                    temp.setPlayerName("O. KAHN");
                    temp.setShirtName("KAHN");
                }
                if (temp.getId() == 263063)
                {
                    temp.setPlayerName("J. STAM");
                    temp.setShirtName("STAM");
                }
                if (temp.getId() == 263109)
                {
                    temp.setPlayerName("F. CANNAVARO");
                    temp.setShirtName("CANNAVARO");
                }
                if (temp.getId() == 263022)
                {
                    temp.setPlayerName("L. THURAM");
                    temp.setShirtName("THURAM");
                }
                if (temp.getId() == 263107)
                {
                    temp.setPlayerName("P. MALDINI");
                    temp.setShirtName("MALDINI");
                }
                if (temp.getId() == 263024)
                {
                    temp.setPlayerName("P. VIERA");
                    temp.setShirtName("VIERA");
                }
                if (temp.getId() == 263001)
                {
                    temp.setPlayerName("P. GUARDIOLA");
                    temp.setShirtName("GUARDIOLA");
                }
                if (temp.getId() == 262959)
                {
                    temp.setPlayerName("D. BECKHAM");
                    temp.setShirtName("BECKHAM");
                }
                if (temp.getId() == 262984)
                {
                    temp.setPlayerName("L. FIGO");
                    temp.setShirtName("FIGO");
                }
                if (temp.getId() == 263027)
                {
                    temp.setPlayerName("Z. ZIDANE");
                    temp.setShirtName("ZIDANE");
                }
                if (temp.getId() == 264272)
                {
                    temp.setPlayerName("VAN NISTELROOY");
                    temp.setShirtName("VAN NISTELROOY");
                }
                if (temp.getId() == 263172)
                {
                    temp.setPlayerName("P. SCHMEICHEL");
                    temp.setShirtName("SCHMEICHEL");
                }
                if (temp.getId() == 262997)
                {
                    temp.setPlayerName("F. HIERRO");
                    temp.setShirtName("HIERRO");
                }
                if (temp.getId() == 263019)
                {
                    temp.setPlayerName("M. DESAILLY");
                    temp.setShirtName("DESAILLY");
                }
                if (temp.getId() == 264275)
                {
                    temp.setPlayerName("L. BLANC");
                    temp.setShirtName("BLANC");
                }
                if (temp.getId() == 263021)
                {
                    temp.setPlayerName("B. LIZARAZU");
                    temp.setShirtName("LIZARAZU");
                }
                if (temp.getId() == 262869)
                {
                    temp.setPlayerName("ROY KEANE");
                    temp.setShirtName("ROY KEANE");
                }
                if (temp.getId() == 262960)
                {
                    temp.setPlayerName("P. SCHOLES");
                    temp.setShirtName("SCHOLES");
                }
                if (temp.getId() == 262981)
                {
                    temp.setPlayerName("RUI COSTA");
                    temp.setShirtName("RUI COSTA");
                }
                if (temp.getId() == 264303)
                {
                    temp.setPlayerName("Z. BOBAN");
                    temp.setShirtName("BOBAN");
                }
                if (temp.getId() == 263072)
                {
                    temp.setPlayerName("M. OVERMARS");
                    temp.setShirtName("OVERMARS");
                }
                if (temp.getId() == 264488)
                {
                    temp.setPlayerName("R. BAGGIO");
                    temp.setShirtName("BAGGIO");
                }
                if (temp.getId() == 263509)
                {
                    temp.setPlayerName("A. SHEVCHENKO");
                    temp.setShirtName("SHEVCHENKO");
                }
                if (temp.getId() == 263392)
                {
                    temp.setPlayerName("S. MIHAJLOVIC");
                    temp.setShirtName("MIHAJLOVIC");
                }
                if (temp.getId() == 263032)
                {
                    temp.setPlayerName("C. MAKELELE");
                    temp.setShirtName("MAKELELE");
                }
                if (temp.getId() == 263154)
                {
                    temp.setPlayerName("M. BALLACK");
                    temp.setShirtName("BALLACK");
                }
                if (temp.getId() == 263134)
                {
                    temp.setPlayerName("P. NEDVED");
                    temp.setShirtName("NEDVED");
                }
                if (temp.getId() == 263246)
                {
                    temp.setPlayerName("J. LITMANEN");
                    temp.setShirtName("LITMANEN");
                }
                if (temp.getId() == 264036)
                {
                    temp.setPlayerName("D. BERGKAMP");
                    temp.setShirtName("BERGKAMP");
                }
                if (temp.getId() == 262961)
                {
                    temp.setPlayerName("M. OWEN");
                    temp.setShirtName("OWEN");
                }
                if (temp.getId() == 263116)
                {
                    temp.setPlayerName("F. INZAGHI");
                    temp.setShirtName("INZAGHI");
                }
                if (temp.getId() == 264101)
                {
                    temp.setPlayerName("A. SHEARER");
                    temp.setShirtName("SHEARER");
                }

                if (temp.getId() == 263831)
                {
                    temp.setPlayerName("J. CHILAVERT");
                    temp.setShirtName("CHILAVERT");
                }
                if (temp.getId() == 263776)
                {
                    temp.setPlayerName("ALDAIR");
                    temp.setShirtName("ALDAIR");
                }
                if (temp.getId() == 263877)
                {
                    temp.setPlayerName("R. AYALA");
                    temp.setShirtName("AYALA");
                }
                if (temp.getId() == 263769)
                {
                    temp.setPlayerName("CAFU'");
                    temp.setShirtName("CAFU'");
                }
                if (temp.getId() == 263768)
                {
                    temp.setPlayerName("ROBERTO CARLOS");
                    temp.setShirtName("ROBERTO CARLOS");
                }
                if (temp.getId() == 264478)
                {
                    temp.setPlayerName("DUNGA");
                    temp.setShirtName("DUNGA");
                }
                if (temp.getId() == 263879)
                {
                    temp.setPlayerName("D. SIMEONE");
                    temp.setShirtName("SIMEONE");
                }
                if (temp.getId() == 264483)
                {
                    temp.setPlayerName("C. VALDERRAMA");
                    temp.setShirtName("VALDERRAMA");
                }
                if (temp.getId() == 263774)
                {
                    temp.setPlayerName("ROMARIO");
                    temp.setShirtName("ROMARIO");
                }
                if (temp.getId() == 263885)
                {
                    temp.setPlayerName("G. BATISTUTA");
                    temp.setShirtName("BATISTUTA");
                }
                if (temp.getId() == 264281)
                {
                    temp.setPlayerName("RONALDO");
                    temp.setShirtName("RONALDO");
                }
                if (temp.getId() == 264470)
                {
                    temp.setPlayerName("C. TAFFAREL");
                    temp.setShirtName("TAFFAREL");
                }
                if (temp.getId() == 263744)
                {
                    temp.setPlayerName("I. CORDOBA");
                    temp.setShirtName("CORDOBA");
                }
                if (temp.getId() == 263835)
                {
                    temp.setPlayerName("F. ARCE");
                    temp.setShirtName("ARCE");
                }
                if (temp.getId() == 325168)
                {
                    temp.setPlayerName("C. BABAYARO");
                    temp.setShirtName("BABAYARO");
                }
                if (temp.getId() == 264299)
                {
                    temp.setPlayerName("F. REDONDO");
                    temp.setShirtName("REDONDO");
                }
                if (temp.getId() == 263619)
                {
                    temp.setPlayerName("J. OKOCHA");
                    temp.setShirtName("OKOCHA");
                }
                if (temp.getId() == 263898)
                {
                    temp.setPlayerName("H. NAKATA");
                    temp.setShirtName("NAKATA");
                }
                if (temp.getId() == 325171)
                {
                    temp.setPlayerName("C. LOPEZ");
                    temp.setShirtName("LOPEZ");
                }
                if (temp.getId() == 325174)
                {
                    temp.setPlayerName("DENILSON");
                    temp.setShirtName("DENILSON");
                }
                if (temp.getId() == 325170)
                {
                    temp.setPlayerName("A. ORTEGA");
                    temp.setShirtName("ORTEGA");
                }
                if (temp.getId() == 263620)
                {
                    temp.setPlayerName("N. KANU");
                    temp.setShirtName("KANU");
                }
                if (temp.getId() == 263818)
                {
                    temp.setPlayerName("M. SALAS");
                    temp.setShirtName("SALAS");
                }
                if (temp.getId() == 263699)
                {
                    temp.setPlayerName("J. CAMPOS");
                    temp.setShirtName("CAMPOS");
                }
                if (temp.getId() == 262235)
                {
                    temp.setPlayerName("MYUNG-BO HONG");
                    temp.setShirtName("MYUNG-BO HONG");
                }
                if (temp.getId() == 263854)
                {
                    temp.setPlayerName("P. MONTERO");
                    temp.setShirtName("MONTERO");
                }
                if (temp.getId() == 263770)
                {
                    temp.setPlayerName("EMERSON");
                    temp.setShirtName("EMERSON");
                }
                if (temp.getId() == 263889)
                {
                    temp.setPlayerName("M. ALMEYDA");
                    temp.setShirtName("ALMEYDA");
                }
                if (temp.getId() == 325169)
                {
                    temp.setPlayerName("N. SOLANO");
                    temp.setShirtName("SOLANO");
                }
                if (temp.getId() == 263643)
                {
                    temp.setPlayerName("P. M'BOMA");
                    temp.setShirtName("M'BOMA");
                }
                if (temp.getId() == 263819)
                {
                    temp.setPlayerName("I. ZAMORANO");
                    temp.setShirtName("ZAMORANO");
                }
                if (temp.getId() == 264184)
                {
                    temp.setPlayerName("G. WEAH");
                    temp.setShirtName("WEAH");
                }
            }

            UpdateForm(Form1._Form1.teamBox1, Form1._Form1.teamBox2);
            updatePlayerList(Form1._Form1.giocatoreView);
        }

        //globalFunction
        public void upperTeams(ListBox l1, ComboBox t1, ComboBox t2)
        {
            foreach (Team temp in getListTeam())
            {
                temp.setEnglish(temp.getEnglish().ToUpper());
                if (temp.getNational())
                {
                    //japanese
                    National temp2 = (National)temp;
                    temp2.setJapanese(temp.getJapanese().ToUpper());
                    //spanish
                    temp2.setSpanish(temp2.getSpanish().ToUpper());
                    //greek
                    temp2.setGreek(temp2.getGreek().ToUpper());
                    //latin america
                    temp2.setLatinAmericaSpanish(temp2.getLatinAmericaSpanish().ToUpper());
                    //french
                    temp2.setFrench(temp2.getFrench().ToUpper());
                    //turkish
                    temp2.setTurkish(temp2.getTurkish().ToUpper());
                    //portuguese
                    temp2.setPortuguese(temp2.getPortuguese().ToUpper());
                    //german
                    temp2.setGerman(temp2.getGerman().ToUpper());
                    //BrazilianPortuguese
                    temp2.setBrazilianPortuguese(temp2.getBrazilianPortuguese().ToUpper());
                    //dutch
                    temp2.setDutch(temp2.getDutch().ToUpper());
                    //swedish
                    temp2.setSwedish(temp2.getSwedish().ToUpper());
                    //italian
                    temp2.setItalian(temp2.getItalian().ToUpper());
                    //russian
                    temp2.setRussian(temp2.getRussian().ToUpper());
                    //englih us
                    temp2.setEnglishUS(temp2.getEnglishUS().ToUpper());
                }
            }
            UpdateTeamList(l1, t1, t2);
        }

        public void lowerTeams(ListBox l1, ComboBox t1, ComboBox t2)
        {
            foreach (Team temp in getListTeam())
            {
                temp.setEnglish(temp.getEnglish().ToLower());
                if (temp.getNational())
                {
                    //japanese
                    National temp2 = (National)temp;
                    temp2.setJapanese(temp.getJapanese().ToLower());
                    //spanish
                    temp2.setSpanish(temp2.getSpanish().ToLower());
                    //greek
                    temp2.setGreek(temp2.getGreek().ToLower());
                    //latin america
                    temp2.setLatinAmericaSpanish(temp2.getLatinAmericaSpanish().ToLower());
                    //french
                    temp2.setFrench(temp2.getFrench().ToLower());
                    //turkish
                    temp2.setTurkish(temp2.getTurkish().ToLower());
                    //portuguese
                    temp2.setPortuguese(temp2.getPortuguese().ToLower());
                    //german
                    temp2.setGerman(temp2.getGerman().ToLower());
                    //BrazilianPortuguese
                    temp2.setBrazilianPortuguese(temp2.getBrazilianPortuguese().ToLower());
                    //dutch
                    temp2.setDutch(temp2.getDutch().ToLower());
                    //swedish
                    temp2.setSwedish(temp2.getSwedish().ToLower());
                    //italian
                    temp2.setItalian(temp2.getItalian().ToLower());
                    //russian
                    temp2.setRussian(temp2.getRussian().ToLower());
                    //englih us
                    temp2.setEnglishUS(temp2.getEnglishUS().ToLower());
                }
            }
            UpdateTeamList(l1, t1, t2);
        }

        public void firstUpTeams(ListBox l1, ComboBox t1, ComboBox t2)
        {
            foreach (Team temp in getListTeam())
            {
                //english name
                string stringa = "";
                foreach (string x in temp.getEnglish().Split())
                {
                    stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                }
                temp.setEnglish(stringa.Trim());
                if (temp.getNational())
                {
                    //japanese
                    stringa = "";
                    National temp2 = (National)temp;
                    foreach (string x in temp2.getJapanese().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setJapanese(stringa.Trim());
                    //spanish
                    stringa = "";
                    foreach (string x in temp2.getSpanish().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setSpanish(stringa.Trim());
                    //greek
                    stringa = "";
                    foreach (string x in temp2.getGreek().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setGreek(stringa.Trim());
                    //latin america
                    stringa = "";
                    foreach (string x in temp2.getLatinAmericaSpanish().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setLatinAmericaSpanish(stringa.Trim());
                    //french
                    stringa = "";
                    foreach (string x in temp2.getFrench().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setFrench(stringa.Trim());
                    //turkish
                    stringa = "";
                    foreach (string x in temp2.getTurkish().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setTurkish(stringa.Trim());
                    //portuguese
                    stringa = "";
                    foreach (string x in temp2.getPortuguese().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setPortuguese(stringa.Trim());
                    //german
                    stringa = "";
                    foreach (string x in temp2.getGerman().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setGerman(stringa.Trim());
                    //BrazilianPortuguese
                    stringa = "";
                    foreach (string x in temp2.getBrazilianPortuguese().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setBrazilianPortuguese(stringa.Trim());
                    //dutch
                    stringa = "";
                    foreach (string x in temp2.getDutch().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setDutch(stringa.Trim());
                    //swedish
                    stringa = "";
                    foreach (string x in temp2.getSwedish().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setSwedish(stringa.Trim());
                    //italian
                    stringa = "";
                    foreach (string x in temp2.getItalian().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setItalian(stringa.Trim());
                    //russian
                    stringa = "";
                    foreach (string x in temp2.getRussian().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setRussian(stringa.Trim());
                    //englih us
                    stringa = "";
                    foreach (string x in temp2.getEnglishUS().Split())
                    {
                        stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                    }
                    temp2.setEnglishUS(stringa.Trim());
                }
            }

            UpdateTeamList(l1, t1, t2);
        }

        public void upperPlayers(ListView l1, ComboBox t1, ComboBox t2)
        {
            foreach (Player temp in getListPlayer())
            {
                temp.setPlayerName(temp.getPlayerName().ToUpper());
            }
            updatePlayerList(l1);
            UpdateForm(t1, t2);
        }

        public void lowerPlayers(ListView l1, ComboBox t1, ComboBox t2)
        {
            foreach (Player temp in getListPlayer())
            {
                temp.setPlayerName(temp.getPlayerName().ToLower());
            }
            updatePlayerList(l1);
            UpdateForm(t1, t2);
        }

        public void firstUpPlayers(ListView l1, ComboBox t1, ComboBox t2)
        {
            foreach (Player temp in getListPlayer())
            {
                string stringa = "";
                foreach (string x in temp.getPlayerName().Split())
                {
                    stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                }
                temp.setPlayerName(stringa.Trim());
            }
            updatePlayerList(l1);
            UpdateForm(t1, t2);
        }

        //fm form
        public Country getCountryFm(Fm temp2)
        {
            Country country = null;
            foreach (Country x in getListCountry())
            {
                if (x.getNationFm().ToUpper() == temp2.getNation().ToUpper())
                    country = x;
            }

            return country;
        }

    }
}
