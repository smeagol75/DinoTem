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
        public Controller()
        {
        }
        
        private int bitRecognized = -1;
        private MemoryStream unzlibPalloni;
        private BinaryReader leggiPalloni;
        private BinaryWriter scriviPalloni;
        private MemoryStream unzlibGuanti;
        private BinaryReader leggiGuanti;
        private BinaryWriter scriviGuanti;
        private MemoryStream unzlibScarpe;
        private BinaryReader leggiScarpe;
        private BinaryWriter scriviScarpe;
        private MemoryStream unzlibStadi;
        private BinaryReader leggiStadi;
        private BinaryWriter scriviStadi;
        private MemoryStream unzlibPaesi;
        private BinaryReader leggiPaesi;
        private BinaryWriter scriviPaesi;
        private MemoryStream unzlibAllenatori;
        private BinaryReader leggiAllenatori;
        private BinaryWriter scriviAllenatori;
        private MemoryStream unzlibGiocatori;
        private BinaryReader leggiGiocatori;
        private BinaryWriter scriviGiocatori;
        private MemoryStream unzlibSquadre;
        private BinaryReader leggiSquadre;
        private BinaryWriter scriviSquadre;
        private MemoryStream unzlibPlayerAssign;
        private BinaryReader leggiPlayerAssign;
        private BinaryWriter scriviPlayerAssign;
        private MemoryStream unzlibTattiche;
        private BinaryReader leggiTattiche;
        private BinaryWriter scriviTattiche;
        private MemoryStream unzlibTacticsFormation;
        private BinaryReader leggiTacticsFormation;
        private BinaryWriter scriviTacticsFormation;
        private MemoryStream unzlibBallCondition;
        private BinaryReader leggiBallCondition;
        private BinaryWriter scriviBallCondition;
        private MemoryStream unzlibDerby;
        private BinaryReader leggiDerby;
        private BinaryWriter scriviDerby;
        private MemoryStream unzlibCompetition;
        private BinaryReader leggiCompetition;
        private BinaryWriter scriviCompetition;
        private MemoryStream unzlibCompetitionKind;
        private BinaryReader leggiCompetitionKind;
        private BinaryWriter scriviCompetitionKind;

        public void readBallPersister(string patch, int bitRecognized)
        {
            MyBallPersister ballReader = new MyBallPersister();
            
            try
            {
                ballReader.load(patch, bitRecognized, ref unzlibPalloni, ref leggiPalloni, ref scriviPalloni);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readGlovePersister(string patch, int bitRecognized)
        {
            MyGlovePersister gloveReader = new MyGlovePersister();

            try
            {
                gloveReader.load(patch, bitRecognized, ref unzlibGuanti, ref leggiGuanti, ref scriviGuanti);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readBootPersister(string patch, int bitRecognized)
        {
            MyBootPersister bootReader = new MyBootPersister();

            try
            {
                bootReader.load(patch, bitRecognized, ref unzlibScarpe, ref leggiScarpe, ref scriviScarpe);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readStadiumPersister(string patch, int bitRecognized)
        {
            MyStadiumPersister stadiumReader = new MyStadiumPersister();

            try
            {
                stadiumReader.load(patch, bitRecognized, ref unzlibStadi, ref leggiStadi, ref scriviStadi);
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
                countryReader.load(patch, bitRecognized, ref unzlibPaesi, ref leggiPaesi, ref scriviPaesi);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readCoachPersister(string patch, int bitRecognized)
        {
            MyCoachPersister coachReader = new MyCoachPersister();

            try
            {
                coachReader.load(patch, bitRecognized, ref unzlibAllenatori, ref leggiAllenatori, ref scriviAllenatori);
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
                playerReader.load(patch, bitRecognized, ref unzlibGiocatori, ref leggiGiocatori, ref scriviGiocatori);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readTeamPersister(string patch, int bitRecognized)
        {
            MyTeamPersister teamReader = new MyTeamPersister();

            try
            {
                teamReader.load(patch, bitRecognized, ref unzlibSquadre, ref leggiSquadre, ref scriviSquadre);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readPlayerAssignmentPersister(string patch, int bitRecognized)
        {
            MyPlayerAssignmentPersister paReader = new MyPlayerAssignmentPersister();

            try
            {
                paReader.load(patch, bitRecognized, ref unzlibPlayerAssign, ref leggiPlayerAssign, ref scriviPlayerAssign);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readTacticsPersister(string patch, int bitRecognized)
        {
            MyTacticsPersister taReader = new MyTacticsPersister();

            try
            {
                taReader.load(patch, bitRecognized, ref unzlibTattiche, ref leggiTattiche, ref scriviTattiche);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readTacticsFormationPersister(string patch, int bitRecognized)
        {
            MyTacticsFormationPersister tfReader = new MyTacticsFormationPersister();

            try
            {
                tfReader.load(patch, bitRecognized, ref unzlibTacticsFormation, ref leggiTacticsFormation, ref scriviTacticsFormation);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readBallConditionPersister(string patch, int bitRecognized)
        {
            MyBallConditionPersister ballReader = new MyBallConditionPersister();

            try
            {
                ballReader.load(patch, bitRecognized, ref unzlibBallCondition, ref leggiBallCondition, ref scriviBallCondition);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readDerbyPersister(string patch, int bitRecognized)
        {
            MyDerbyPersister derbyReader = new MyDerbyPersister();

            Team nullo = new Club(99999);
            nullo.setEnglish("No Team Found");
            Form1._Form1.derbyTeam1.Items.Add(nullo);
            Form1._Form1.derbyTeam2.Items.Add(nullo);
            try
            {
                derbyReader.load(patch, bitRecognized, ref unzlibDerby, ref leggiDerby, ref scriviDerby);

                for (int i = 0; i < Form1._Form1.DataGridView_derby.RowCount - 1; i++)
                {
                    UInt32 id = uint.Parse(Form1._Form1.DataGridView_derby.Rows[i].Cells[0].Value.ToString());
                    int index = findTeam(id);
                    if (index != Form1._Form1.teamsBox.Items.Count)
                        Form1._Form1.DataGridView_derby.Rows[i].Cells[1].Value = leggiSquadra(index).getEnglish();
                    else
                        Form1._Form1.DataGridView_derby.Rows[i].Cells[1].Value = "No Team Found";

                    UInt32 id2 = uint.Parse(Form1._Form1.DataGridView_derby.Rows[i].Cells[2].Value.ToString());
                    int index2 = findTeam(id2);
                    if (index2 != Form1._Form1.teamsBox.Items.Count)
                        Form1._Form1.DataGridView_derby.Rows[i].Cells[3].Value = leggiSquadra(index2).getEnglish();
                    else
                        Form1._Form1.DataGridView_derby.Rows[i].Cells[3].Value = "No Team Found";
                }

            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readCompetitionPersister(string patch, int bitRecognized)
        {
            MyCompetitionPersister cReader = new MyCompetitionPersister();

            try
            {
                cReader.load(patch, bitRecognized, ref unzlibCompetition, ref leggiCompetition, ref scriviCompetition);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readCompetitionKindPersister(string patch, int bitRecognized)
        {
            MyCompetitionKindPersister cReader = new MyCompetitionKindPersister();

            try
            {
                cReader.load(patch, bitRecognized, ref unzlibCompetitionKind, ref leggiCompetitionKind, ref scriviCompetitionKind);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveBallPersister(string patch, Controller controller, int bitRecognized)
        {
            MyBallPersister ballSave = new MyBallPersister();

            try
            {
                ballSave.save(patch, ref unzlibPalloni, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Ball.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveGlovePersister(string patch, Controller controller, int bitRecognized)
        {
            MyGlovePersister gloveSave = new MyGlovePersister();

            try
            {
                gloveSave.save(patch, ref unzlibGuanti, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Glove.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveBootPersister(string patch, Controller controller, int bitRecognized)
        {
            MyBootPersister bootSave = new MyBootPersister();

            try
            {
                bootSave.save(patch, ref unzlibScarpe, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Boots.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveStadiumPersister(string patch, Controller controller, int bitRecognized)
        {
            MyStadiumPersister stadiumSave = new MyStadiumPersister();

            try
            {
                stadiumSave.save(patch, ref unzlibStadi, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Stadium.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveCoachPersister(string patch, Controller controller, int bitRecognized)
        {
            MyCoachPersister coachSave = new MyCoachPersister();

            try
            {
                coachSave.save(patch, ref unzlibAllenatori, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Coach.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void savePlayerPersister(string patch, Controller controller, int bitRecognized)
        {
            MyPlayerPersister playerSave = new MyPlayerPersister();

            try
            {
                playerSave.save(patch, ref unzlibGiocatori, bitRecognized);
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
                teamSave.save(patch, ref unzlibSquadre, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Team.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void savePlayerAssignmentPersister(string patch, Controller controller, int bitRecognized)
        {
            MyPlayerAssignmentPersister paSave = new MyPlayerAssignmentPersister();

            try
            {
                paSave.save(patch, ref unzlibPlayerAssign, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved PlayerAssignment.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveTacticsPersister(string patch, Controller controller, int bitRecognized)
        {
            MyTacticsPersister taSave = new MyTacticsPersister();

            try
            {
                taSave.save(patch, ref unzlibTattiche, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Tactics.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveTacticsFormationPersister(string patch, Controller controller, int bitRecognized)
        {
            MyTacticsFormationPersister tfSave = new MyTacticsFormationPersister();

            try
            {
                tfSave.save(patch, ref unzlibTacticsFormation, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved TacticsFormation.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveBallConditionPersister(string patch, Controller controller, int bitRecognized)
        {
            MyBallConditionPersister baSave = new MyBallConditionPersister();

            try
            {
                baSave.save(patch, ref unzlibBallCondition, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved BallCondition.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveDerbyPersister(string patch, Controller controller, int bitRecognized)
        {
            MyDerbyPersister dSave = new MyDerbyPersister();

            try
            {
                dSave.save(patch, ref unzlibDerby, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Derby.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveCompetitionPersister(string patch, Controller controller, int bitRecognized)
        {
            MyCompetitionPersister cSave = new MyCompetitionPersister();

            try
            {
                cSave.save(patch, ref unzlibCompetition, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved Competition.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveCompetitionKindPersister(string patch, Controller controller, int bitRecognized)
        {
            MyCompetitionKindPersister cSave = new MyCompetitionKindPersister();

            try
            {
                cSave.save(patch, ref unzlibCompetitionKind, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved CompetitionKind.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyBallPersister(int index, Ball pallone)
        {
            MyBallPersister ball = new MyBallPersister();

            try
            {
                ball.applyBall(index, unzlibPalloni, pallone, ref scriviPalloni);
            }
            catch
            {
                MessageBox.Show("Error apply " + pallone.getName(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyGlovePersister(int index, Glove guanto)
        {
            MyGlovePersister glove = new MyGlovePersister();

            try
            {
                glove.applyGlove(index, unzlibGuanti, guanto, ref scriviGuanti);
            }
            catch
            {
                MessageBox.Show("Error apply " + guanto.getName(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyBootPersister(int index, Boot scarpa)
        {
            MyBootPersister boot = new MyBootPersister();

            try
            {
                boot.applyBoot(index, unzlibScarpe, scarpa, ref scriviScarpe);
            }
            catch
            {
                MessageBox.Show("Error apply " + scarpa.getName(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyStadiumPersister(int index, Stadium stadio)
        {
            MyStadiumPersister stadium = new MyStadiumPersister();

            try
            {
                stadium.applyStadium(index, unzlibStadi, stadio, ref scriviStadi);
            }
            catch
            {
                MessageBox.Show("Error apply " + stadio.getName(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyCoachPersister(int index, Coach allenatore)
        {
            MyCoachPersister coach = new MyCoachPersister();

            try
            {
                coach.applyCoach(index, unzlibAllenatori, allenatore, ref scriviAllenatori);
            }
            catch
            {
                MessageBox.Show("Error apply " + allenatore.getName(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyPlayerPersister(int index, Player giocatore)
        {
            MyPlayerPersister player = new MyPlayerPersister();

            try
            {
                player.applyPlayer(index, unzlibGiocatori, giocatore, ref scriviGiocatori);
            }
            catch
            {
                MessageBox.Show("Error apply " + giocatore.getName(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyTeamPersister(int index, Team squadra)
        {
            MyTeamPersister team = new MyTeamPersister();

            try
            {
                team.applyTeam(index, unzlibSquadre, squadra, ref scriviSquadre);
            }
            catch
            {
                MessageBox.Show("Error apply " + squadra.getEnglish(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyPlayerAssignmentPersister(int index, PlayerAssignment pa)
        {
            MyPlayerAssignmentPersister playerA = new MyPlayerAssignmentPersister();

            try
            {
                playerA.applyPlayerA(index, unzlibPlayerAssign, pa, ref scriviPlayerAssign);
            }
            catch
            {
                MessageBox.Show("Error apply transfer - id player: " + pa.getPlayerId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyTacticsPersister(int index, Tactics ta)
        {
            MyTacticsPersister playerA = new MyTacticsPersister();

            try
            {
                playerA.applyTactics(index, unzlibPlayerAssign, ta, ref scriviPlayerAssign);
            }
            catch
            {
                MessageBox.Show("Error apply tactics - id team: " + ta.getTeamId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyTacticsFormationPersister(int index, TacticsFormation tf)
        {
            MyTacticsFormationPersister tacticF = new MyTacticsFormationPersister();

            try
            {
                tacticF.applyTacticsFormation(index, unzlibTacticsFormation, tf, ref scriviTacticsFormation);
            }
            catch
            {
                MessageBox.Show("Error apply tactics formation - id tactic: " + tf.getTeamTacticId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyBallConditionPersister(byte unk1, byte unk2, byte unk3, byte unk4, List<BallCondition> ba)
        {
            MyBallConditionPersister ball = new MyBallConditionPersister();

            if (ba.Count == 0)
                return;
            
            if (ba.Count >= 1)
                ba[0].setUnknown(unk1);
            if (ba.Count >= 2)
                ba[1].setUnknown(unk2);
            if (ba.Count >= 3)
                ba[2].setUnknown(unk3);
            if (ba.Count >= 4)
                ba[3].setUnknown(unk4);

            try
            {
                ball.applyBallCondition(unzlibBallCondition, leggiBallCondition, ba, ref scriviBallCondition);
            }
            catch
            {
                MessageBox.Show("Error apply ball condition - id ball: " + ba[0].getId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyDerbyPersister(int index, Derby d)
        {
            MyDerbyPersister derby = new MyDerbyPersister();

            try
            {
                derby.applyDerby(index, unzlibDerby, d, ref scriviDerby);
            }
            catch
            {
                MessageBox.Show("Error apply derby: " + d.getTeam1DerbyId() + "-" + d.getTeam2DerbyId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyCompetitionPersister(int index, Competition c)
        {
            MyCompetitionPersister com = new MyCompetitionPersister();

            try
            {
                com.applyCompetition(index, unzlibCompetition, c, ref scriviCompetition);
            }
            catch
            {
                MessageBox.Show("Error apply derby: " + c.getId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyCompetitionKindPersister(int index, CompetitionKind c)
        {
            MyCompetitionKindPersister com = new MyCompetitionKindPersister();

            try
            {
                com.applyCompetitionKind(index, unzlibCompetitionKind, c, ref scriviCompetitionKind);
            }
            catch
            {
                MessageBox.Show("Error apply competition kind", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void closeMemory()
        {
            if (getBitRecognized() != -1)
            {
                unzlibPalloni.Close();
                leggiPalloni.Close();
                scriviPalloni.Close();
                unzlibGuanti.Close();
                leggiGuanti.Close();
                scriviGuanti.Close();
                unzlibScarpe.Close();
                leggiScarpe.Close();
                scriviScarpe.Close();
                unzlibStadi.Close();
                leggiStadi.Close();
                scriviStadi.Close();
                unzlibAllenatori.Close();
                leggiAllenatori.Close();
                scriviAllenatori.Close();
                unzlibPaesi.Close();
                leggiPaesi.Close();
                scriviPaesi.Close();
                unzlibGiocatori.Close();
                leggiGiocatori.Close();
                scriviGiocatori.Close();
                unzlibSquadre.Close();
                leggiSquadre.Close();
                scriviSquadre.Close();
                unzlibPlayerAssign.Close();
                leggiPlayerAssign.Close();
                scriviPlayerAssign.Close();
                unzlibTattiche.Close();
                leggiTattiche.Close();
                scriviTattiche.Close();
                unzlibTacticsFormation.Close();
                leggiTacticsFormation.Close();
                scriviTacticsFormation.Close();
                unzlibBallCondition.Close();
                leggiBallCondition.Close();
                scriviBallCondition.Close();
                unzlibDerby.Close();
                leggiDerby.Close();
                scriviDerby.Close();
                unzlibCompetition.Close();
                leggiCompetition.Close();
                scriviCompetition.Close();
                unzlibCompetitionKind.Close();
                leggiCompetitionKind.Close();
                scriviCompetitionKind.Close();
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

            byte[] file9 = File.ReadAllBytes(folder + @"\Glove.bin");
            MemoryStream memory9 = new MemoryStream(file9);
            BinaryReader reader9 = new BinaryReader(memory9);
            byteFirst += reader9.ReadByte();
            reader9.Close();

            byte[] file10 = File.ReadAllBytes(folder + @"\Boots.bin");
            MemoryStream memory10 = new MemoryStream(file10);
            BinaryReader reader10 = new BinaryReader(memory10);
            byteFirst += reader10.ReadByte();
            reader10.Close();

            byte[] file11 = File.ReadAllBytes(folder + @"\Coach.bin");
            MemoryStream memory11 = new MemoryStream(file11);
            BinaryReader reader11 = new BinaryReader(memory11);
            byteFirst += reader11.ReadByte();
            reader11.Close();

            byte[] file12 = File.ReadAllBytes(folder + @"\Competition.bin");
            MemoryStream memory12 = new MemoryStream(file12);
            BinaryReader reader12 = new BinaryReader(memory12);
            byteFirst += reader12.ReadByte();
            reader12.Close();

            byte[] file13 = File.ReadAllBytes(folder + @"\CompetitionKind.bin");
            MemoryStream memory13 = new MemoryStream(file13);
            BinaryReader reader13 = new BinaryReader(memory13);
            byteFirst += reader13.ReadByte();
            reader13.Close();

            if (byteFirst == 0 || byteFirst == 56)
                return 0;
            else if (byteFirst == 14)
                return 1;
            else if (byteFirst == 28)
                return 2;
            else
            {
                MessageBox.Show("Check files! They may be corrupted!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreen._SplashScreen.Close();
            }

            return -1;
        }

        public void openDatabase(string folder, Form1 Form)
        {
            int bitRecognized = checkAllFile(folder);
            this.bitRecognized = bitRecognized;

            if (bitRecognized == 0)
                Form.Text = "DinoTem Editor 2018 - Pc Mode";
            else if (bitRecognized == 1)
                Form.Text = "DinoTem Editor 2018 - Xbox Mode";
            else if (bitRecognized == 2)
                Form.Text += "DinoTem Editor 2018 - Ps3 Mode";

            UtilGUI.resetField();

            Form1._Form1.ballsBox.Items.Clear();
            Form1._Form1.glovesBox.Items.Clear();
            Form1._Form1.bootsBox.Items.Clear();
            Form1._Form1.stadiumsBox.Items.Clear();
            Form1._Form1.coachBox.Items.Clear();
            Form1._Form1.stadiumCountry.Items.Clear();
            Form1._Form1.playersBox.Items.Clear();
            Form1._Form1.teamsBox.Items.Clear();
            Form1._Form1.teamBox1.Items.Clear();
            Form1._Form1.teamBox2.Items.Clear();
            Form1._Form1.competitionsBox.Items.Clear();
            Form1._Form1.giocatoreNationality.Items.Clear();
            Form1._Form1.teamCountry.Items.Clear();
            Form1._Form1.allenatoreNationality.Items.Clear();
            Form1._Form1.DataGridView_derby.Rows.Clear();
            Form1._Form1.derbyTeam1.Items.Clear();
            Form1._Form1.derbyTeam2.Items.Clear();
            Form1._Form1.competitionsKind.Items.Clear();

            readBallPersister(folder, bitRecognized);
            readGlovePersister(folder, bitRecognized);
            readBootPersister(folder, bitRecognized);
            readCountryPersister(folder, bitRecognized);
            readStadiumPersister(folder, bitRecognized);
            readCoachPersister(folder, bitRecognized);
            readPlayerPersister(folder, bitRecognized);
            readTeamPersister(folder, bitRecognized);
            readPlayerAssignmentPersister(folder, bitRecognized);
            readTacticsPersister(folder, bitRecognized);
            readTacticsFormationPersister(folder, bitRecognized);
            readBallConditionPersister(folder, bitRecognized);
            readDerbyPersister(folder, bitRecognized);
            readCompetitionPersister(folder, bitRecognized);
            readCompetitionKindPersister(folder, bitRecognized);

            //readCountryPersister(folder, bitRecognized);
            //if (countryList.Count == 0)
            //{
                //MessageBox.Show("No countries found", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //SplashScreen._SplashScreen.Close();
            //}

            /*readTeamPersister(folder, bitRecognized);
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
            }*/

            Form1._Form1.ballsBox.SelectedIndex = 0;
            Form1._Form1.glovesBox.SelectedIndex = 0;
            Form1._Form1.bootsBox.SelectedIndex = 0;
            Form1._Form1.stadiumsBox.SelectedIndex = 0;
            Form1._Form1.coachBox.SelectedIndex = 0;
            Form1._Form1.playersBox.SelectedIndex = 0;
            Form1._Form1.teamsBox.SelectedIndex = 0;
            Form1._Form1.teamBox1.SelectedIndex = 0;
            Form1._Form1.teamBox2.SelectedIndex = 0;
            Form1._Form1.competitionsKind.SelectedIndex = 0;
            Form1._Form1.competitionsBox.SelectedIndex = 0;
        }

        public int getBitRecognized()
        {
            return bitRecognized;
        }

        public Ball leggiPallone(int index)
        {
            MyBallPersister ballReader = new MyBallPersister();
            Ball pallone = ballReader.loadBall(index, leggiPalloni);

            return pallone;
        }

        public Glove leggiGuanto(int index)
        {
            MyGlovePersister gloveReader = new MyGlovePersister();
            Glove guanto = gloveReader.loadGlove(index, leggiGuanti);

            return guanto;
        }

        public Boot leggiScarpa(int index)
        {
            MyBootPersister bootReader = new MyBootPersister();
            Boot scarpa = bootReader.loadBoot(index, leggiScarpe);

            return scarpa;
        }

        public Stadium leggiStadium(int index)
        {
            MyStadiumPersister stadiumReader = new MyStadiumPersister();
            Stadium stadio = stadiumReader.loadStadium(index, leggiStadi);

            return stadio;
        }

        public Country leggiPaese(int index)
        {
            MyCountryPersister countryReader = new MyCountryPersister();
            Country paese = countryReader.loadCountry(index, leggiPaesi);

            return paese;
        }

        public Coach leggiCoach(int index)
        {
            MyCoachPersister coachReader = new MyCoachPersister();
            Coach coach = coachReader.loadCoach(index, leggiAllenatori);

            return coach;
        }

        public Player leggiGiocatore(int index)
        {
            MyPlayerPersister playerReader = new MyPlayerPersister();
            Player player = playerReader.loadPlayer(index, leggiGiocatori);

            return player;
        }

        public Player leggiGiocatoreById(UInt32 id)
        {
            Player player = leggiGiocatore(findPlayer(id));

            return player;
        }

        public Team leggiSquadra(int index)
        {
            MyTeamPersister teamReader = new MyTeamPersister();
            Team squadra = teamReader.loadTeam(index, leggiSquadre);

            return squadra;
        }

        public List<PlayerAssignment> leggiGiocatoriSquadra(UInt32 id)
        {
            MyPlayerAssignmentPersister paReader = new MyPlayerAssignmentPersister();
            List<PlayerAssignment> pa = paReader.loadPlayerTeam(id, unzlibPlayerAssign, leggiPlayerAssign);
            //ordinare giocatori
            pa.Sort((x, y) => x.getOrder().CompareTo(y.getOrder()));
            for (int i = 0; i < pa.Count; i++)
            {
                pa[i].setOrder((ushort) i);
            }

            return pa;
        }

        public List<Tactics> leggiTattica(UInt32 idTeam)
        {
            MyTacticsPersister tacticsReader = new MyTacticsPersister();
            List<Tactics> tattica = tacticsReader.loadTactics(idTeam, unzlibTattiche, leggiTattiche);

            return tattica;
        }

        public List<TacticsFormation> leggiFormazione(UInt16 idTactics)
        {
            MyTacticsFormationPersister tacticsReader = new MyTacticsFormationPersister();
            List<TacticsFormation> tatticaF = tacticsReader.loadTacticsFormation(idTactics, unzlibTacticsFormation, leggiTacticsFormation);

            return tatticaF;
        }

        public List<BallCondition> leggiCondizioniPalloni(UInt16 idBall)
        {
            MyBallConditionPersister ballReader = new MyBallConditionPersister();
            List<BallCondition> ball = ballReader.loadBallCondition(idBall, unzlibBallCondition, leggiBallCondition);

            return ball;
        }

        public void getBallConditionById(List<BallCondition> list, TextBox t1, TextBox t2, TextBox t3, TextBox t4)
        {
            int k = 0;
            foreach (BallCondition x in list)
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

        public Competition leggiCompetizione(int index)
        {
            MyCompetitionPersister reader = new MyCompetitionPersister();
            Competition c = reader.loadCompetition(index, unzlibCompetition, leggiCompetition);

            return c;
        }

        public CompetitionKind leggiCompetizioneKind(int index)
        {
            MyCompetitionKindPersister reader = new MyCompetitionKindPersister();
            CompetitionKind c = reader.loadCompetitionKind(index, unzlibCompetitionKind, leggiCompetitionKind);

            return c;
        }

        public int findCountry(UInt32 idCountry)
        {
            int index = -1;
            for (int i = 0; i < Form1._Form1.stadiumCountry.Items.Count - 1; i++)
            {
                Country c = leggiPaese(i);
                if (c.getId() == idCountry)
                    return i;
            }

            //for "no country" 
            if (index == -1)
                index = Form1._Form1.stadiumCountry.Items.Count;

            return index;
        }

        public int findStadium(UInt32 idStadium)
        {
            for (int i = 0; i < Form1._Form1.teamStadium.Items.Count - 1; i++)
            {
                Stadium c = leggiStadium(i);
                if (c.getId() == (UInt16)idStadium)
                    return i;
            }
            return 0;
        }

        public int findCoach(UInt32 idCoach)
        {
            for (int i = 0; i < Form1._Form1.teamCoach.Items.Count - 1; i++)
            {
                Coach c = leggiCoach(i);
                if (c.getId() == idCoach)
                    return i;
            }

            return 0;
        }

        public int findTeam(UInt32 idTeam)
        {
            int index = -1;
            for (int i = 0; i < Form1._Form1.teamsBox.Items.Count - 1; i++)
            {
                Team c = leggiSquadra(i);
                if (c.getId() == idTeam)
                    return i;
            }

            //for "no team" 
            if (index == -1)
                index = Form1._Form1.teamsBox.Items.Count;

            return index;
        }

        public int findPlayer(UInt32 idPlayer)
        {
            for (int i = 0; i < Form1._Form1.playersBox.Items.Count - 1; i++)
            {
                Player c = leggiGiocatore(i);
                if (c.getId() == idPlayer)
                    return i;
            }

            return 0;
        }

        public void UpdateTeamView(UInt32 idPlayer, string name)
        {
            for (int i = 0; i < Form1._Form1.teamView1.Items.Count; i++)
            {
                UInt32 id = uint.Parse(Form1._Form1.teamView1.Items[i].SubItems[11].Text);
                if (idPlayer == id)
                {
                    Form1._Form1.teamView1.Items[i].SubItems[2].Text = name;
                }
            }

            for (int i = 0; i < Form1._Form1.teamView2.Items.Count; i++)
            {
                UInt32 id = uint.Parse(Form1._Form1.teamView2.Items[i].SubItems[11].Text);
                if (idPlayer == id)
                {
                    Form1._Form1.teamView2.Items[i].SubItems[2].Text = name;
                }
            }
        }

        public void UpdateFormPlayer(int index, string name)
        {
            Form1._Form1.playersBox.Items[index] = name;
        }

        public void changePlayerName(UInt32 id, string name) 
        {
            int index = findPlayer(id);
            Player player = leggiGiocatore(index);
            player.setName(name);
            applyPlayerPersister(index, player);
            UpdateTeamView(player.getId(), name);
            UpdateFormPlayer(index, name);
        }

        public void changeShirtPlayer(UInt32 id, string name)
        {
            int index = findPlayer(id);
            Player player = leggiGiocatore(index);
            player.setShirtName(name);
            applyPlayerPersister(index, player);
        }

        //globalFunction
        public void upperTeams()
        {
            for (int i = 0; i < Form1._Form1.teamsBox.Items.Count - 1; i++ )
            {
                Team temp = leggiSquadra(i);
                temp.setEnglish(temp.getEnglish().ToUpper());
                if (temp.getNational() == 1)
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
                Form1._Form1.teamsBox.Items[i] = temp.getEnglish().ToUpper();
                Form1._Form1.teamBox1.Items[i] = temp.getEnglish().ToUpper();
                Form1._Form1.teamBox2.Items[i] = temp.getEnglish().ToUpper();
                Form1._Form1.derbyTeam1.Items[i] = temp.getEnglish().ToUpper();
                Form1._Form1.derbyTeam2.Items[i] = temp.getEnglish().ToUpper();
            }
        }

        public void lowerTeams()
        {
            for (int i = 0; i < Form1._Form1.teamsBox.Items.Count - 1; i++)
            {
                Team temp = leggiSquadra(i);
                temp.setEnglish(temp.getEnglish().ToLower());
                if (temp.getNational() == 1)
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
                Form1._Form1.teamsBox.Items[i] = temp.getEnglish().ToLower();
                Form1._Form1.teamBox1.Items[i] = temp.getEnglish().ToLower();
                Form1._Form1.teamBox2.Items[i] = temp.getEnglish().ToLower();
                Form1._Form1.derbyTeam1.Items[i] = temp.getEnglish().ToLower();
                Form1._Form1.derbyTeam2.Items[i] = temp.getEnglish().ToLower();
            }
        }

        public void firstUpTeams()
        {
            for (int i = 0; i < Form1._Form1.teamsBox.Items.Count - 1; i++)
            {
                Team temp = leggiSquadra(i);
                //english name
                string stringa = "";
                if (temp.getNational() == 1)
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
                foreach (string x in temp.getEnglish().Split())
                {
                    stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                }
                temp.setEnglish(stringa.Trim());
                Form1._Form1.teamsBox.Items[i] = temp.getEnglish().ToLower();
                Form1._Form1.teamBox1.Items[i] = temp.getEnglish().ToLower();
                Form1._Form1.teamBox2.Items[i] = temp.getEnglish().ToLower();
                Form1._Form1.derbyTeam1.Items[i] = temp.getEnglish().ToLower();
                Form1._Form1.derbyTeam2.Items[i] = temp.getEnglish().ToLower();
            }

        }

        public void upperPlayers()
        {
            for (int i = 0; i < Form1._Form1.playersBox.Items.Count - 1; i++)
            {
                Player temp = leggiGiocatore(i);
                temp.setName(temp.getName().ToUpper());

                UpdateTeamView(temp.getId(), temp.getName().ToUpper());
                UpdateFormPlayer(i, temp.getName().ToUpper());
            }
        }

        public void lowerPlayers()
        {
            for (int i = 0; i < Form1._Form1.playersBox.Items.Count - 1; i++)
            {
                Player temp = leggiGiocatore(i);
                temp.setName(temp.getName().ToLower());

                UpdateTeamView(temp.getId(), temp.getName().ToLower());
                UpdateFormPlayer(i, temp.getName().ToLower());
            }
        }

        public void firstUpPlayers()
        {
            for (int i = 0; i < Form1._Form1.playersBox.Items.Count - 1; i++)
            {
                Player temp = leggiGiocatore(i);
                string stringa = "";
                foreach (string x in temp.getName().Split())
                {
                    stringa += x.ToUpper().Substring(0, 1) + x.ToLower().Substring(1) + " ";
                }
                temp.setName(stringa.Trim());
                UpdateTeamView(temp.getId(), stringa.Trim());
                UpdateFormPlayer(i, stringa.Trim());
            }
        }

        private List<Ball> ballList = new List<Ball>();
        private List<PlayerAppearance> playerAppearanceList = new List<PlayerAppearance>();
        private List<PlayerAssignment> playerAssignmentList = new List<PlayerAssignment>();
        private List<TacticsFormation> tacticsFormationList = new List<TacticsFormation>();
        private List<Tactics> tacticsList = new List<Tactics>();
        private List<Team> teamList = new List<Team>();

        //form1
        //player
        //team
        //Formazione form
        //Giocatore form
        //transferPlayer Drag&Drop
        //remove fake team
        //fm form
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

        public List<Team> getListTeam()
        {
            return teamList;
        }

        public List<Ball> getListBall()
        {
            return ballList;
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
            //foreach (Player player in playerList)
            //{
                //if (k == positionList)
                    //return player;
                //k++;
            //}
            return null;
        }

        /*public Player getPlayerById(int positionInTeam, int team)
        {
            foreach (PlayerAssignment playerA in playerAssignmentList)
            {
                if (playerA.getTeamId() == team)
                    if (playerA.getOrder() == positionInTeam)
                        return getPlayerById(playerA.getPlayerId());
            }
            return null;
        }*/

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

        public void changePlayerNumber(long idPlayer, int idTeam, int shirtNumber)
        {
            foreach (PlayerAssignment temp in playerAssignmentList)
            {
                //if (idPlayer == temp.getPlayerId() && idTeam == temp.getTeamId())
                    //temp.setShirtNumber(shirtNumber);
            }
        }

        /*public void updatePlayerList(ListView l1)
        {
            l1.Items.Clear();
            foreach (Player x in getListPlayer())
            {
                l1.Items.Add(x.ToString());
            }
            l1.Items[0].Selected = true;
            l1.Select();
        }*/

        public void UpdateBallList(ListBox l1)
        {
            l1.Items.Clear();
            foreach (Ball x in getListBall())
            {
                l1.Items.Add(x);
            }
            l1.SelectedIndex = 0;
        }

        /*public string getStringClubTeamOfPlayer(long idPlayer, int type) {

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
        */
        public List<int> getNumberFormation(int idTeam) {
		    List<int> result = new List<int>();

            foreach (Tactics tactics in tacticsList)
            {
                if (idTeam == tactics.getTeamId())
                    result.Add(tactics.getTacticsId());  
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

        //Player
        /*public void changeNationalPlayer(Player temp, Country country)
        {
            temp.setNational(country.getId());
        }

        public void changeSecondNationalPlayer(Player temp, Country country)
        {
            temp.setNational2(country.getId());
        }*/

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

        /*
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
        */

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

        /*
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
        */

        public void changeShooters(Team temp, int capitainSelectedIndex, int penaltySelectedIndex,
            int longSelectedIndex, int leftSelectedIndex, int shortSelectedIndex, int rightSelectedIndex)
        {
            //save Captain, etc...
            foreach (PlayerAssignment x in playerAssignmentList)
            {
                /*if (x.getTeamId() == temp.getId())
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
                }*/
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

                    //if (x.getPlayerId() == playerID)
                        //x.setOrder(dropIndex);
                    //if (x.getPlayerId() == playerID2)
                        //x.setOrder(intselectedindex);
                }
            }
            //
            //UpdateForm(teamBox1, teamBox2);
        }

        private void setPlayerTrasfer(PlayerAssignment temp, int idTeamA, int order)
        {
            /*temp.setTeamId(idTeamA);
            temp.setShortFoulFk(false);
            temp.setRightCornerKick(false);
            temp.setPenaltyKick(false);
            temp.setOrder(order);
            temp.setLongShotLk(false);
            temp.setLeftCkTk(false);
            temp.setCaptain(false);*/
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
            //temp.setShirtNumber(numeroCasuale);
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
                        //temp.setEntryId(n);
                        return;
                    }
                }
            }
            return;
        }

        /*public void transferPlayerBtoA(int intselectedindexPlayer, Team teamA, Team teamB, int orderTeamA, ComboBox teamBox1, ComboBox teamBox2)
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
        */

        /*public void playerFromPlayerList(long player, int teamId, ComboBox teamBox1, ComboBox teamBox2)
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
        */
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
            //UpdateForm(teamBox1, teamBox2);
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
        /*public void removeFakePlayer()
        {
            foreach (Player temp in playerList)
            {
                if (temp.getId() == 263150)
                {
                    temp.setName("O. KAHN");
                    temp.setShirtName("KAHN");
                }
                if (temp.getId() == 263063)
                {
                    temp.setName("J. STAM");
                    temp.setShirtName("STAM");
                }
                if (temp.getId() == 263109)
                {
                    temp.setName("F. CANNAVARO");
                    temp.setShirtName("CANNAVARO");
                }
                if (temp.getId() == 263022)
                {
                    temp.setName("L. THURAM");
                    temp.setShirtName("THURAM");
                }
                if (temp.getId() == 263107)
                {
                    temp.setName("P. MALDINI");
                    temp.setShirtName("MALDINI");
                }
                if (temp.getId() == 263024)
                {
                    temp.setName("P. VIERA");
                    temp.setShirtName("VIERA");
                }
                if (temp.getId() == 263001)
                {
                    temp.setName("P. GUARDIOLA");
                    temp.setShirtName("GUARDIOLA");
                }
                if (temp.getId() == 262959)
                {
                    temp.setName("D. BECKHAM");
                    temp.setShirtName("BECKHAM");
                }
                if (temp.getId() == 262984)
                {
                    temp.setName("L. FIGO");
                    temp.setShirtName("FIGO");
                }
                if (temp.getId() == 263027)
                {
                    temp.setName("Z. ZIDANE");
                    temp.setShirtName("ZIDANE");
                }
                if (temp.getId() == 264272)
                {
                    temp.setName("VAN NISTELROOY");
                    temp.setShirtName("VAN NISTELROOY");
                }
                if (temp.getId() == 263172)
                {
                    temp.setName("P. SCHMEICHEL");
                    temp.setShirtName("SCHMEICHEL");
                }
                if (temp.getId() == 262997)
                {
                    temp.setName("F. HIERRO");
                    temp.setShirtName("HIERRO");
                }
                if (temp.getId() == 263019)
                {
                    temp.setName("M. DESAILLY");
                    temp.setShirtName("DESAILLY");
                }
                if (temp.getId() == 264275)
                {
                    temp.setName("L. BLANC");
                    temp.setShirtName("BLANC");
                }
                if (temp.getId() == 263021)
                {
                    temp.setName("B. LIZARAZU");
                    temp.setShirtName("LIZARAZU");
                }
                if (temp.getId() == 262869)
                {
                    temp.setName("ROY KEANE");
                    temp.setShirtName("ROY KEANE");
                }
                if (temp.getId() == 262960)
                {
                    temp.setName("P. SCHOLES");
                    temp.setShirtName("SCHOLES");
                }
                if (temp.getId() == 262981)
                {
                    temp.setName("RUI COSTA");
                    temp.setShirtName("RUI COSTA");
                }
                if (temp.getId() == 264303)
                {
                    temp.setName("Z. BOBAN");
                    temp.setShirtName("BOBAN");
                }
                if (temp.getId() == 263072)
                {
                    temp.setName("M. OVERMARS");
                    temp.setShirtName("OVERMARS");
                }
                if (temp.getId() == 264488)
                {
                    temp.setName("R. BAGGIO");
                    temp.setShirtName("BAGGIO");
                }
                if (temp.getId() == 263509)
                {
                    temp.setName("A. SHEVCHENKO");
                    temp.setShirtName("SHEVCHENKO");
                }
                if (temp.getId() == 263392)
                {
                    temp.setName("S. MIHAJLOVIC");
                    temp.setShirtName("MIHAJLOVIC");
                }
                if (temp.getId() == 263032)
                {
                    temp.setName("C. MAKELELE");
                    temp.setShirtName("MAKELELE");
                }
                if (temp.getId() == 263154)
                {
                    temp.setName("M. BALLACK");
                    temp.setShirtName("BALLACK");
                }
                if (temp.getId() == 263134)
                {
                    temp.setName("P. NEDVED");
                    temp.setShirtName("NEDVED");
                }
                if (temp.getId() == 263246)
                {
                    temp.setName("J. LITMANEN");
                    temp.setShirtName("LITMANEN");
                }
                if (temp.getId() == 264036)
                {
                    temp.setName("D. BERGKAMP");
                    temp.setShirtName("BERGKAMP");
                }
                if (temp.getId() == 262961)
                {
                    temp.setName("M. OWEN");
                    temp.setShirtName("OWEN");
                }
                if (temp.getId() == 263116)
                {
                    temp.setName("F. INZAGHI");
                    temp.setShirtName("INZAGHI");
                }
                if (temp.getId() == 264101)
                {
                    temp.setName("A. SHEARER");
                    temp.setShirtName("SHEARER");
                }

                if (temp.getId() == 263831)
                {
                    temp.setName("J. CHILAVERT");
                    temp.setShirtName("CHILAVERT");
                }
                if (temp.getId() == 263776)
                {
                    temp.setName("ALDAIR");
                    temp.setShirtName("ALDAIR");
                }
                if (temp.getId() == 263877)
                {
                    temp.setName("R. AYALA");
                    temp.setShirtName("AYALA");
                }
                if (temp.getId() == 263769)
                {
                    temp.setName("CAFU'");
                    temp.setShirtName("CAFU'");
                }
                if (temp.getId() == 263768)
                {
                    temp.setName("ROBERTO CARLOS");
                    temp.setShirtName("ROBERTO CARLOS");
                }
                if (temp.getId() == 264478)
                {
                    temp.setName("DUNGA");
                    temp.setShirtName("DUNGA");
                }
                if (temp.getId() == 263879)
                {
                    temp.setName("D. SIMEONE");
                    temp.setShirtName("SIMEONE");
                }
                if (temp.getId() == 264483)
                {
                    temp.setName("C. VALDERRAMA");
                    temp.setShirtName("VALDERRAMA");
                }
                if (temp.getId() == 263774)
                {
                    temp.setName("ROMARIO");
                    temp.setShirtName("ROMARIO");
                }
                if (temp.getId() == 263885)
                {
                    temp.setName("G. BATISTUTA");
                    temp.setShirtName("BATISTUTA");
                }
                if (temp.getId() == 264281)
                {
                    temp.setName("RONALDO");
                    temp.setShirtName("RONALDO");
                }
                if (temp.getId() == 264470)
                {
                    temp.setName("C. TAFFAREL");
                    temp.setShirtName("TAFFAREL");
                }
                if (temp.getId() == 263744)
                {
                    temp.setName("I. CORDOBA");
                    temp.setShirtName("CORDOBA");
                }
                if (temp.getId() == 263835)
                {
                    temp.setName("F. ARCE");
                    temp.setShirtName("ARCE");
                }
                if (temp.getId() == 325168)
                {
                    temp.setName("C. BABAYARO");
                    temp.setShirtName("BABAYARO");
                }
                if (temp.getId() == 264299)
                {
                    temp.setName("F. REDONDO");
                    temp.setShirtName("REDONDO");
                }
                if (temp.getId() == 263619)
                {
                    temp.setName("J. OKOCHA");
                    temp.setShirtName("OKOCHA");
                }
                if (temp.getId() == 263898)
                {
                    temp.setName("H. NAKATA");
                    temp.setShirtName("NAKATA");
                }
                if (temp.getId() == 325171)
                {
                    temp.setName("C. LOPEZ");
                    temp.setShirtName("LOPEZ");
                }
                if (temp.getId() == 325174)
                {
                    temp.setName("DENILSON");
                    temp.setShirtName("DENILSON");
                }
                if (temp.getId() == 325170)
                {
                    temp.setName("A. ORTEGA");
                    temp.setShirtName("ORTEGA");
                }
                if (temp.getId() == 263620)
                {
                    temp.setName("N. KANU");
                    temp.setShirtName("KANU");
                }
                if (temp.getId() == 263818)
                {
                    temp.setName("M. SALAS");
                    temp.setShirtName("SALAS");
                }
                if (temp.getId() == 263699)
                {
                    temp.setName("J. CAMPOS");
                    temp.setShirtName("CAMPOS");
                }
                if (temp.getId() == 262235)
                {
                    temp.setName("MYUNG-BO HONG");
                    temp.setShirtName("MYUNG-BO HONG");
                }
                if (temp.getId() == 263854)
                {
                    temp.setName("P. MONTERO");
                    temp.setShirtName("MONTERO");
                }
                if (temp.getId() == 263770)
                {
                    temp.setName("EMERSON");
                    temp.setShirtName("EMERSON");
                }
                if (temp.getId() == 263889)
                {
                    temp.setName("M. ALMEYDA");
                    temp.setShirtName("ALMEYDA");
                }
                if (temp.getId() == 325169)
                {
                    temp.setName("N. SOLANO");
                    temp.setShirtName("SOLANO");
                }
                if (temp.getId() == 263643)
                {
                    temp.setName("P. M'BOMA");
                    temp.setShirtName("M'BOMA");
                }
                if (temp.getId() == 263819)
                {
                    temp.setName("I. ZAMORANO");
                    temp.setShirtName("ZAMORANO");
                }
                if (temp.getId() == 264184)
                {
                    temp.setName("G. WEAH");
                    temp.setShirtName("WEAH");
                }
            }

            UpdateForm(Form1._Form1.teamBox1, Form1._Form1.teamBox2);
            //updatePlayerList(Form1._Form1.giocatoreView);
        }*/

        //fm form
        /*public Country getCountryFm(Fm temp2)
        {
            Country country = null;
            foreach (Country x in getListCountry())
            {
                if (x.getNationFm().ToUpper() == temp2.getNation().ToUpper())
                    country = x;
            }

            return country;
        }*/

    }
}
