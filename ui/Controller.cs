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
        private MemoryStream unzlibCompetitionRegulation;
        private BinaryReader leggiCompetitionRegulation;
        private BinaryWriter scriviCompetitionRegulation;
        private MemoryStream unzlibStadiumOrder;
        private BinaryReader leggiStadiumOrder;
        private BinaryWriter scriviStadiumOrder;
        private MemoryStream unzlibStadiumOrderInConfederation;
        private BinaryReader leggiStadiumOrderInConfederation;
        private BinaryWriter scriviStadiumOrderInConfederation;
        private MemoryStream unzlibCompetitionEntry;
        private BinaryReader leggiCompetitionEntry;
        private BinaryWriter scriviCompetitionEntry;
        private MemoryStream unzlibPlayerApp;
        private BinaryReader leggiPlayerApp;
        private BinaryWriter scriviPlayerApp;
        private MemoryStream unzlibGloveList;
        private BinaryReader leggiGloveList;
        private BinaryWriter scriviGloveList;
        private MemoryStream unzlibBootList;
        private BinaryReader leggiBootList;
        private BinaryWriter scriviBootList;

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

            Form1._Form1.derbyTeam1.Items.Add("No Team Found");
            Form1._Form1.derbyTeam2.Items.Add("No Team Found");
            try
            {
                derbyReader.load(patch, bitRecognized, ref unzlibDerby, ref leggiDerby, ref scriviDerby);

                for (int i = 0; i < Form1._Form1.DataGridView_derby.RowCount; i++)
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

        public void readCompetitionRegulationPersister(string patch, int bitRecognized)
        {
            MyCompetitionRegulationPersister cReader = new MyCompetitionRegulationPersister();

            try
            {
                cReader.load(patch, bitRecognized, ref unzlibCompetitionRegulation, ref leggiCompetitionRegulation, ref scriviCompetitionRegulation);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readStadiumOrderPersister(string patch, int bitRecognized)
        {
            MyStadiumOrderPersister cReader = new MyStadiumOrderPersister();

            try
            {
                cReader.load(patch, bitRecognized, ref unzlibStadiumOrder, ref leggiStadiumOrder, ref scriviStadiumOrder);

                for (int i = 0; i < Form1._Form1.DataGridView_stadium_order.RowCount; i++)
                {
                    UInt16 id = ushort.Parse(Form1._Form1.DataGridView_stadium_order.Rows[i].Cells[2].Value.ToString());
                    int index = findStadium(id);
                    if (index != Form1._Form1.stadiumsBox.Items.Count)
                        Form1._Form1.DataGridView_stadium_order.Rows[i].Cells[0].Value = leggiStadium(index).getName();
                    else
                       Form1._Form1.DataGridView_stadium_order.Rows[i].Cells[0].Value = "No Stadium Found";
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readStadiumOrderInConfederationPersister(string patch, int bitRecognized)
        {
            MyStadiumOrderInConfederationPersister cReader = new MyStadiumOrderInConfederationPersister();

            try
            {
                cReader.load(patch, bitRecognized, ref unzlibStadiumOrderInConfederation, ref leggiStadiumOrderInConfederation, ref scriviStadiumOrderInConfederation);

                for (int i = 0; i < Form1._Form1.DataGridView_stadium_order_in_conf.RowCount; i++)
                {
                    UInt16 id = ushort.Parse(Form1._Form1.DataGridView_stadium_order_in_conf.Rows[i].Cells[2].Value.ToString());
                    int index = findStadium(id);
                    if (index != Form1._Form1.stadiumsBox.Items.Count)
                        Form1._Form1.DataGridView_stadium_order_in_conf.Rows[i].Cells[0].Value = leggiStadium(index).getName();
                    else
                        Form1._Form1.DataGridView_stadium_order_in_conf.Rows[i].Cells[0].Value = "No Stadium Found";
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readCompetitionEntryPersister(string patch, int bitRecognized)
        {
            MyCompetitionEntryPersister cReader = new MyCompetitionEntryPersister();

            try
            {
                cReader.load(patch, bitRecognized, ref unzlibCompetitionEntry, ref leggiCompetitionEntry, ref scriviCompetitionEntry);
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
                playerAppearanceReader.load(patch, bitRecognized, ref unzlibPlayerApp, ref leggiPlayerApp, ref scriviPlayerApp);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readGloveListPersister(string patch, int bitRecognized)
        {
            MyGloveListPersister gloveListReader = new MyGloveListPersister();

            try
            {
                gloveListReader.load(patch, bitRecognized, ref unzlibGloveList, ref leggiGloveList, ref scriviGloveList);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void readBootListPersister(string patch, int bitRecognized)
        {
            MyBootListPersister bootListReader = new MyBootListPersister();

            try
            {
                bootListReader.load(patch, bitRecognized, ref unzlibBootList, ref leggiBootList, ref scriviBootList);
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
                ballSave.save(patch, unzlibPalloni, bitRecognized);
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
                gloveSave.save(patch, unzlibGuanti, bitRecognized);
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
                bootSave.save(patch, unzlibScarpe, bitRecognized);
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
                stadiumSave.save(patch, unzlibStadi, bitRecognized);
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
                coachSave.save(patch, unzlibAllenatori, bitRecognized);
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
                playerSave.save(patch, unzlibGiocatori, bitRecognized);
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
                teamSave.save(patch, unzlibSquadre, bitRecognized);
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
                paSave.save(patch, unzlibPlayerAssign, bitRecognized);
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
                taSave.save(patch, unzlibTattiche, bitRecognized);
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
                tfSave.save(patch, unzlibTacticsFormation, bitRecognized);
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
                baSave.save(patch, unzlibBallCondition, bitRecognized);
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
                dSave.save(patch, unzlibDerby, bitRecognized);
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
                cSave.save(patch, unzlibCompetition, bitRecognized);
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
                cSave.save(patch, unzlibCompetitionKind, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved CompetitionKind.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveCompetitionRegulationPersister(string patch, Controller controller, int bitRecognized)
        {
            MyCompetitionRegulationPersister cSave = new MyCompetitionRegulationPersister();

            try
            {
                cSave.save(patch, unzlibCompetitionRegulation, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved CompetitionRegulation.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveCompetitionEntryPersister(string patch, Controller controller, int bitRecognized)
        {
            MyCompetitionEntryPersister dSave = new MyCompetitionEntryPersister();

            try
            {
                dSave.save(patch, unzlibCompetitionEntry, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved CompetitionEntry.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void savePlayerAppearancePersister(string patch, Controller controller, int bitRecognized)
        {
            MyPlayerAppearancePersister playerAppearanceSave = new MyPlayerAppearancePersister();

            try
            {
                playerAppearanceSave.save(patch, unzlibPlayerApp, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved PlayerAppearance.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveGloveListPersister(string patch, Controller controller, int bitRecognized)
        {
            MyGloveListPersister dSave = new MyGloveListPersister();

            try
            {
                dSave.save(patch, unzlibGloveList, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved GloveList.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveBootListPersister(string patch, Controller controller, int bitRecognized)
        {
            MyBootListPersister dSave = new MyBootListPersister();

            try
            {
                dSave.save(patch, unzlibBootList, bitRecognized);
            }
            catch
            {
                MessageBox.Show("Error saved BootList.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void applyPlayerAssignmentPersister(List<PlayerAssignment> pa)
        {
            MyPlayerAssignmentPersister playerA = new MyPlayerAssignmentPersister();

            try
            {
                playerA.applyPlayerA(unzlibPlayerAssign, leggiPlayerAssign, pa, ref scriviPlayerAssign);
            }
            catch
            {
                MessageBox.Show("Error apply transfer - id team: " + pa[0].getTeamId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyTacticsPersister(Tactics ta)
        {
            MyTacticsPersister playerA = new MyTacticsPersister();

            try
            {
                playerA.applyTactics(leggiTattiche ,unzlibTattiche, ta, ref scriviTattiche);
            }
            catch
            {
                MessageBox.Show("Error apply tactics - id team: " + ta.getTeamId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyTacticsFormationPersister(List<TacticsFormation> tf)
        {
            MyTacticsFormationPersister tacticF = new MyTacticsFormationPersister();

            try
            {
                tacticF.applyTacticsFormation(unzlibTacticsFormation, leggiTacticsFormation, tf, ref scriviTacticsFormation);
            }
            catch
            {
                MessageBox.Show("Error apply tactics formation - id tactic: " + tf[0].getTeamTacticId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void applyCompetitionRegulationPersister(int index, CompetitionRegulation c)
        {
            MyCompetitionRegulationPersister com = new MyCompetitionRegulationPersister();

            try
            {
                com.applyCompetitionRegulation(index, unzlibCompetitionRegulation, c, ref scriviCompetitionRegulation);
            }
            catch
            {
                MessageBox.Show("Error apply competition regulation", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyCompetitionEntryPersister(int index)
        {
            MyCompetitionEntryPersister com = new MyCompetitionEntryPersister();

            CompetitionRegulation r = leggiCompetizioneRegulation(index);
            //try
            //{
                com.applyCompetitionEntry(index, ref unzlibCompetitionEntry, r.getUNK5(), ref leggiCompetitionEntry, ref scriviCompetitionEntry);
            //}
            //catch
            //{
                //MessageBox.Show("Error apply competition entry", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        public void applyPlayerAppearancePersister(PlayerAppearance a)
        {
            MyPlayerAppearancePersister com = new MyPlayerAppearancePersister();

            try
            {
                com.applyPlayerAppearance(leggiPlayerApp, getBitRecognized(), unzlibPlayerApp, a, ref scriviPlayerApp);
            }
            catch
            {
                MessageBox.Show("Error apply appareance - id player: " + a.getId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyGloveListPersister(GloveList a)
        {
            MyGloveListPersister com = new MyGloveListPersister();

            try
            {
                com.applyGloveList(leggiGloveList, getBitRecognized(), unzlibGloveList, a, ref scriviGloveList);
            }
            catch
            {
                MessageBox.Show("Error apply glove list - id player: " + a.getPlayerId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void applyBootListPersister(BootList a)
        {
            MyBootListPersister com = new MyBootListPersister();

            try
            {
                com.applyBootList(leggiBootList, getBitRecognized(), unzlibBootList, a, ref scriviBootList);
            }
            catch
            {
                MessageBox.Show("Error apply boot list - id player: " + a.getPlayerId(), Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addGlovePersister()
        {
            MyGlovePersister glove = new MyGlovePersister();

            try
            {
                glove.addGlove(ref unzlibGuanti, ref leggiGuanti, ref scriviGuanti);

                Glove temp = new Glove(glove.findIndexGlove(unzlibGuanti, leggiGuanti));
                temp.setName("Glove " + Form1._Form1.glovesBox.Items.Count);
                temp.setOrder(20);
                temp.setColor("Test");
                applyGlovePersister(Form1._Form1.glovesBox.Items.Count, temp);

                Form1._Form1.glovesBox.Items.Add("Glove " + Form1._Form1.glovesBox.Items.Count);

                MessageBox.Show("New glove added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add new glove!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addBootPersister()
        {
            MyBootPersister boot = new MyBootPersister();

            try
            {
                boot.addBoot(ref unzlibScarpe, ref leggiScarpe, ref scriviScarpe);

                Boot temp = new Boot(boot.findIndexBoot(unzlibScarpe, leggiScarpe));
                temp.setName("Boot " + Form1._Form1.bootsBox.Items.Count);
                temp.setOrder(20);
                temp.setColor("Test");
                temp.setMaterial("Test");
                applyBootPersister(Form1._Form1.bootsBox.Items.Count, temp);

                Form1._Form1.bootsBox.Items.Add("Boot " + Form1._Form1.bootsBox.Items.Count);

                MessageBox.Show("New boot added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add new boot!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addBallPersister()
        {
            MyBallPersister ball = new MyBallPersister();

            try
            {
                ball.addBall(ref unzlibPalloni, ref leggiPalloni, ref scriviPalloni);

                UInt16 id = ball.findIndexBall(unzlibPalloni, leggiPalloni);
                Ball temp = new Ball(id);
                temp.setName("Ball " + Form1._Form1.ballsBox.Items.Count);
                temp.setOrder(20);
                applyBallPersister(Form1._Form1.ballsBox.Items.Count, temp);

                Form1._Form1.ballsBox.Items.Add("Ball " + Form1._Form1.ballsBox.Items.Count);

                MessageBox.Show("New ball added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add new ball!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addStadiumPersister()
        {
            MyStadiumPersister stadium = new MyStadiumPersister();

            try
            {
                stadium.addStadium(ref unzlibStadi, ref leggiStadi, ref scriviStadi);

                Stadium temp = new Stadium(stadium.findIndexStadium(unzlibStadi, leggiStadi));
                temp.setName("Stadium " + Form1._Form1.stadiumsBox.Items.Count);
                temp.setCapacity(1000);
                temp.setCountry(215);
                temp.setJapaneseName("Stadium " + Form1._Form1.stadiumsBox.Items.Count);
                temp.setKonamiName("Stadium");
                temp.setLicense(0);
                temp.setNa(0);
                temp.setZone(2);
                applyStadiumPersister(Form1._Form1.stadiumsBox.Items.Count, temp);

                Form1._Form1.stadiumsBox.Items.Add("Stadium " + Form1._Form1.stadiumsBox.Items.Count);
                Form1._Form1.teamStadium.Items.Add("Stadium " + Form1._Form1.stadiumsBox.Items.Count);

                MessageBox.Show("New stadium added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add new stadium!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addDerbyPersister()
        {
            MyDerbyPersister derby = new MyDerbyPersister();
            try
            {
                derby.addDerby(ref unzlibDerby, ref leggiDerby, ref scriviDerby);

                UInt32 New_order = Convert.ToUInt32(Form1._Form1.DataGridView_derby.Rows[(Form1._Form1.DataGridView_derby.Rows.Count - 1)].Cells[6].Value);
                New_order = (New_order + 1);
                UInt32 new_slot = Convert.ToUInt32(Form1._Form1.DataGridView_derby.Rows[(Form1._Form1.DataGridView_derby.Rows.Count - 1)].Cells[5].Value);
                UInt32 team1 = (uint)Form1._Form1.DataGridView_derby.Rows[(Form1._Form1.DataGridView_derby.Rows.Count - 1)].Cells[0].Value;
                UInt32 team2 = (uint)Form1._Form1.DataGridView_derby.Rows[(Form1._Form1.DataGridView_derby.Rows.Count - 1)].Cells[2].Value;
                string teamName1 = (string)Form1._Form1.DataGridView_derby.Rows[(Form1._Form1.DataGridView_derby.Rows.Count - 1)].Cells[1].Value;
                string teamName2 = (string)Form1._Form1.DataGridView_derby.Rows[(Form1._Form1.DataGridView_derby.Rows.Count - 1)].Cells[3].Value;
                if ((New_order > 127))
                {
                    new_slot = (new_slot + 1);
                    New_order = 0;
                    if ((new_slot > 3))
                        MessageBox.Show("Maximum slots are reached, please eidt, not add more", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Form1._Form1.DataGridView_derby.Rows.Add(team1, teamName1, team2, teamName2, 0, new_slot, New_order);
                }
                else
                    Form1._Form1.DataGridView_derby.Rows.Add(team1, teamName1, team2, teamName2, 0, new_slot, New_order);

                Derby temp = new Derby();
                temp.setTeam1DerbyId(team1);
                temp.setTeam2DerbyId(team2);
                temp.setFragVal2((ushort)0);
                temp.setFragVal3((ushort)new_slot);
                temp.setFragVal4((ushort)New_order);

                applyDerbyPersister(Form1._Form1.DataGridView_derby.Rows[Form1._Form1.DataGridView_derby.Rows.Count - 1].Index, temp);

                MessageBox.Show("New derby added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add new derby!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addCoachPersister()
        {
            MyCoachPersister coach = new MyCoachPersister();

            try
            {
                coach.addCoach(ref unzlibAllenatori, ref leggiAllenatori, ref scriviAllenatori);

                UInt32 id = coach.findIndexCoach(unzlibAllenatori, leggiAllenatori);
                Coach temp = new Coach(id);
                temp.setName("Coach " + Form1._Form1.coachBox.Items.Count);
                temp.setJapName("Coach " + Form1._Form1.coachBox.Items.Count);
                temp.setCountry(215);
                temp.setByteLic(0);

                applyCoachPersister(Form1._Form1.coachBox.Items.Count, temp);

                Form1._Form1.coachBox.Items.Add("Coach " + Form1._Form1.coachBox.Items.Count);
                Form1._Form1.teamCoach.Items.Add("Coach " + Form1._Form1.coachBox.Items.Count);

                MessageBox.Show("New coach added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add new coach!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addPlayerPersister()
        {
            MyPlayerPersister player = new MyPlayerPersister();

            try
            {
                player.addPlayer(ref unzlibGiocatori, ref leggiGiocatori, ref scriviGiocatori);

                UInt32 id = player.findIndexPlayer(unzlibGiocatori, leggiGiocatori);
                Player temp = leggiGiocatore(0);
                temp.setId(id);
                temp.setNational(215);
                temp.setName("Player " + Form1._Form1.playersBox.Items.Count);
                temp.setJapanese("Player " + Form1._Form1.playersBox.Items.Count);
                temp.setShirtName("Player " + Form1._Form1.playersBox.Items.Count);
                
                applyPlayerPersister(Form1._Form1.playersBox.Items.Count, temp);

                Form1._Form1.playersBox.Items.Add("Player " + Form1._Form1.playersBox.Items.Count);

                MessageBox.Show("New player added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add new player!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addTeamPersister()
        {
            MyTeamPersister team = new MyTeamPersister();

            try
            {
                team.addTeam(ref unzlibSquadre, ref leggiSquadre, ref scriviSquadre);

                UInt32 idTeam = team.findIndexTeam(unzlibSquadre, leggiSquadre);
                Team temp = leggiSquadra(0);
                temp.setId(idTeam);
                temp.setNational(0);
                temp.setCountry(215);
                string name = "Team " + Form1._Form1.teamsBox.Items.Count;
                temp.setEnglish(name);
                temp.setJapanese(name);
                applyTeamPersister(Form1._Form1.teamsBox.Items.Count, temp);
                
                Form1._Form1.teamsBox.Items.Add(name);
                Form1._Form1.derbyTeam1.Items.Add(name);
                Form1._Form1.derbyTeam2.Items.Add(name);
                Form1._Form1.teamBox1.Items.Add(name);
                Form1._Form1.teamBox2.Items.Add(name);
                Form1._Form1.competitionTeamList.Items.Add(name);
                
                Form1._Form1.teamBox1.SelectedIndex = Form1._Form1.teamBox1.Items.Count - 1;
                for (int i = 0; i < 11; i++)
                {
                    MyPlayerPersister player = new MyPlayerPersister();
                    player.addPlayer(ref unzlibGiocatori, ref leggiGiocatori, ref scriviGiocatori);

                    UInt32 idPlayer = player.findIndexPlayer(unzlibGiocatori, leggiGiocatori);
                    Player tempP = leggiGiocatore(0);
                    tempP.setId(idPlayer);
                    tempP.setNational(215);
                    tempP.setName("Player " + Form1._Form1.playersBox.Items.Count);
                    tempP.setJapanese("Player " + Form1._Form1.playersBox.Items.Count);
                    tempP.setShirtName("Player " + Form1._Form1.playersBox.Items.Count);

                    applyPlayerPersister(Form1._Form1.playersBox.Items.Count, tempP);

                    Form1._Form1.playersBox.Items.Add("Player " + Form1._Form1.playersBox.Items.Count);
                    playerFromPlayerList(idPlayer, idTeam, Form1._Form1.teamView1, leggiSquadra(Form1._Form1.teamBox2.SelectedIndex).getId(), Form1._Form1.teamView2);
                }
                transferPlayerAtoA(Form1._Form1.teamView1, idTeam);

                //colore sfondo
                int i5 = 0;
                int NumberOfRepetitions5 = Convert.ToInt32(10);
                for (i5 = 0; i5 <= NumberOfRepetitions5; i5++)
                {
                    Form1._Form1.teamView1.Items[i5].SubItems[0].BackColor = System.Drawing.Color.FromArgb(59, 177, 68);
                    Form1._Form1.teamView1.Items[i5].SubItems[1].BackColor = System.Drawing.Color.FromArgb(59, 177, 68);
                    Form1._Form1.teamView1.Items[i5].SubItems[2].BackColor = System.Drawing.Color.FromArgb(59, 177, 68);
                    Form1._Form1.teamView1.Items[i5].SubItems[3].BackColor = System.Drawing.Color.FromArgb(59, 177, 68);
                    Form1._Form1.teamView1.Items[0].UseItemStyleForSubItems = false;
                }

                MessageBox.Show("New team added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add new team!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addTactics(UInt32 idTeam)
        {
            MyTacticsPersister tact = new MyTacticsPersister();

            try
            {
                tact.addTactics(idTeam, ref unzlibTattiche, ref leggiTattiche, ref scriviTattiche);

                //MessageBox.Show("New tactics added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add tactics!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addTacticsFormation(UInt16 idTactics)
        {
            MyTacticsFormationPersister tact = new MyTacticsFormationPersister();

            try
            {
                tact.addTacticsFormation(idTactics, ref unzlibTacticsFormation, ref leggiTacticsFormation, ref scriviTacticsFormation);

                //MessageBox.Show("New tactics formation added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add tactics formation!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addBootListPersister(UInt32 idPlayer)
        {
            MyBootListPersister boot = new MyBootListPersister();

            try
            {
                boot.addBootList(idPlayer, ref unzlibBootList, ref leggiBootList, ref scriviBootList);

                BootList temp = new BootList(idPlayer);
                temp.setBootId(leggiScarpa(0).getId());

                applyBootListPersister(temp);

                MessageBox.Show("New boot's list added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add boot's list!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addGloveListPersister(UInt32 idPlayer)
        {
            MyGloveListPersister glove = new MyGloveListPersister();

            try
            {
                glove.addGloveList(idPlayer, ref unzlibGloveList, ref leggiGloveList, ref scriviGloveList);

                GloveList temp = new GloveList(idPlayer);
                temp.setGloveId(leggiGuanto(0).getId());

                applyGloveListPersister(temp);

                MessageBox.Show("New glove's list added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add glove's list!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addPlayerAppearancePersister(UInt32 idPlayer)
        {
            MyPlayerAppearancePersister player = new MyPlayerAppearancePersister();

            try
            {
                player.addPlayerAppearance(idPlayer, getBitRecognized(), ref unzlibPlayerApp, ref leggiPlayerApp, ref scriviPlayerApp);

                MessageBox.Show("New player's appearance added!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error add player's appearance!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void replacePlayerAppearancePersister(UInt32 idOldPlayer, UInt32 idNewPlayer)
        {
            MyPlayerAppearancePersister player = new MyPlayerAppearancePersister();

            try
            {
                player.replacePlayerAppearance(leggiPlayerApp, getBitRecognized(), unzlibPlayerApp, ref scriviPlayerApp, idOldPlayer, idNewPlayer);
            }
            catch
            {
                MessageBox.Show("Error replace player's appearance!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void replaceBootListPersister(UInt32 idOldPlayer, UInt32 idNewPlayer)
        {
            MyBootListPersister boot = new MyBootListPersister();

            try
            {
                boot.replaceBootList(leggiBootList, getBitRecognized(), unzlibBootList, ref scriviBootList, idOldPlayer, idNewPlayer);
            }
            catch
            {
                MessageBox.Show("Error replace boot's list!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void replaceGloveListPersister(UInt32 idOldPlayer, UInt32 idNewPlayer)
        {
            MyGloveListPersister glove = new MyGloveListPersister();

            try
            {
                glove.replaceGloveList(leggiGloveList, getBitRecognized(), unzlibGloveList, ref scriviGloveList, idOldPlayer, idNewPlayer);
            }
            catch
            {
                MessageBox.Show("Error replace glove's list!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void replacePlayerAssignmentPersister(UInt32 idOldPlayer, UInt32 idNewPlayer)
        {
            MyPlayerAssignmentPersister pA = new MyPlayerAssignmentPersister();

            try
            {
                pA.replacePlayerA(leggiPlayerAssign, unzlibPlayerAssign, ref scriviPlayerAssign, idOldPlayer, idNewPlayer);
            }
            catch
            {
                MessageBox.Show("Error replace player assignment!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                unzlibCompetitionRegulation.Close();
                leggiCompetitionRegulation.Close();
                scriviCompetitionRegulation.Close();
                unzlibStadiumOrder.Close();
                leggiStadiumOrder.Close();
                scriviStadiumOrder.Close();
                unzlibStadiumOrderInConfederation.Close();
                leggiStadiumOrderInConfederation.Close();
                scriviStadiumOrderInConfederation.Close();
                unzlibCompetitionEntry.Close();
                leggiCompetitionEntry.Close();
                scriviCompetitionEntry.Close();
                unzlibPlayerApp.Close();
                leggiPlayerApp.Close();
                scriviPlayerApp.Close();
                unzlibGloveList.Close();
                leggiGloveList.Close();
                scriviGloveList.Close();
                unzlibBootList.Close();
                leggiBootList.Close();
                scriviBootList.Close();
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

            byte[] file14 = File.ReadAllBytes(folder + @"\CompetitionRegulation.bin");
            MemoryStream memory14 = new MemoryStream(file14);
            BinaryReader reader14 = new BinaryReader(memory14);
            byteFirst += reader14.ReadByte();
            reader14.Close();

            byte[] file15 = File.ReadAllBytes(folder + @"\StadiumOrder.bin");
            MemoryStream memory15 = new MemoryStream(file15);
            BinaryReader reader15 = new BinaryReader(memory15);
            byteFirst += reader15.ReadByte();
            reader15.Close();

            byte[] file16 = File.ReadAllBytes(folder + @"\StadiumOrderInConfederation.bin");
            MemoryStream memory16 = new MemoryStream(file16);
            BinaryReader reader16 = new BinaryReader(memory16);
            byteFirst += reader16.ReadByte();
            reader16.Close();

            byte[] file17 = File.ReadAllBytes(folder + @"\CompetitionEntry.bin");
            MemoryStream memory17 = new MemoryStream(file17);
            BinaryReader reader17 = new BinaryReader(memory17);
            byteFirst += reader17.ReadByte();
            reader17.Close();

            byte[] file18 = File.ReadAllBytes(folder + @"\GloveList.bin");
            MemoryStream memory18 = new MemoryStream(file18);
            BinaryReader reader18 = new BinaryReader(memory18);
            byteFirst += reader18.ReadByte();
            reader18.Close();

            byte[] file19 = File.ReadAllBytes(folder + @"\BootsList.bin");
            MemoryStream memory19 = new MemoryStream(file19);
            BinaryReader reader19 = new BinaryReader(memory19);
            byteFirst += reader19.ReadByte();
            reader19.Close();

            if (byteFirst == 0 || byteFirst == 80)
                return 0;
            else if (byteFirst == 20)
                return 1;
            else if (byteFirst == 40)
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
            Form1._Form1.ListBox_comp_reg.Items.Clear();
            Form1._Form1.DataGridView_stadium_order.Rows.Clear();
            Form1._Form1.DataGridView_stadium_order_in_conf.Rows.Clear();
            Form1._Form1.DataGridView1.Rows.Clear();
            Form1._Form1.DataGridView1_orig.Rows.Clear();
            Form1._Form1.competitionEntryBox.Items.Clear();
            Form1._Form1.teamCoach.Items.Clear();
            Form1._Form1.teamStadium.Items.Clear();

            readCountryPersister(folder, bitRecognized);
            readTeamPersister(folder, bitRecognized);
            readPlayerPersister(folder, bitRecognized);
            readBootPersister(folder, bitRecognized);
            readBallPersister(folder, bitRecognized);
            readGlovePersister(folder, bitRecognized);
            readStadiumPersister(folder, bitRecognized);
            readCoachPersister(folder, bitRecognized);
            readTacticsPersister(folder, bitRecognized);
            readTacticsFormationPersister(folder, bitRecognized);
            readBallConditionPersister(folder, bitRecognized);
            readDerbyPersister(folder, bitRecognized);
            readCompetitionPersister(folder, bitRecognized);
            readCompetitionKindPersister(folder, bitRecognized);
            readCompetitionRegulationPersister(folder, bitRecognized);
            readStadiumOrderPersister(folder, bitRecognized);
            readStadiumOrderInConfederationPersister(folder, bitRecognized);
            readCompetitionEntryPersister(folder, bitRecognized);
            readGloveListPersister(folder, bitRecognized);
            readBootListPersister(folder, bitRecognized);
            readPlayerAppearancePersister(folder, bitRecognized);
            readPlayerAssignmentPersister(folder, bitRecognized);

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
            Form1._Form1.ListBox_comp_reg.SelectedIndex = 0;
            Form1._Form1.competitionsBox.SelectedIndex = 0;
            Form1._Form1.competitionEntryBox.SelectedIndex = 0;
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
            //quando si seleziona "No Glove" nel form giocatore
            Glove temp = new Glove(0);
            if (index == Form1._Form1.glovesBox.Items.Count)
                return temp;

            MyGlovePersister gloveReader = new MyGlovePersister();
            Glove guanto = gloveReader.loadGlove(index, leggiGuanti);

            return guanto;
        }

        public Boot leggiScarpa(int index)
        {
            //quando si seleziona "No Boot" nel form giocatore
            Boot temp = new Boot(0);
            if (index == Form1._Form1.bootsBox.Items.Count)
                return temp;

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
            //quando seleziono "No National" nel form giocatore
            Country temp = new Country(0);
            if (index == Form1._Form1.stadiumCountry.Items.Count)
                return temp;

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

        public Player leggiGiocatore(UInt32 playerId)
        {
            MyPlayerPersister playerReader = new MyPlayerPersister();
            int index = playerReader.loadPlayerById(unzlibGiocatori, leggiGiocatori, playerId);

            return leggiGiocatore(index);
        }

        public Team leggiSquadra(int index)
        {
            //quando seleziono "youth club" nel form giocatore
            Club temp = new Club(0);
            if (index == Form1._Form1.teamBox1.Items.Count)
                return temp;

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

        public CompetitionRegulation leggiCompetizioneRegulation(int index)
        {
            MyCompetitionRegulationPersister reader = new MyCompetitionRegulationPersister();
            CompetitionRegulation c = reader.loadCompetitionRegulation(index, unzlibCompetitionRegulation, leggiCompetitionRegulation);

            return c;
        }

        public void leggiCompetizioneEntry(UInt32 compId)
        {
            MyCompetitionEntryPersister reader = new MyCompetitionEntryPersister();
            reader.loadCompetitionEntry(compId, unzlibCompetitionEntry, leggiCompetitionEntry);
        }

        public PlayerAppearance leggiGiocatoreApparenza(UInt32 id)
        {
            MyPlayerAppearancePersister reader = new MyPlayerAppearancePersister();
            PlayerAppearance player = reader.loadPlayerAppearance(id, getBitRecognized(), unzlibPlayerApp, leggiPlayerApp);

            return player;
        }

        public GloveList leggiGuantiLista(UInt32 id)
        {
            MyGloveListPersister reader = new MyGloveListPersister();
            GloveList glove = reader.loadGloveList(id, getBitRecognized(), unzlibGloveList, leggiGloveList);

            return glove;
        }

        public BootList leggiScarpeLista(UInt32 id)
        {
            MyBootListPersister reader = new MyBootListPersister();
            BootList boot = reader.loadBootList(id, getBitRecognized(), unzlibBootList, leggiBootList);

            return boot;
        }

        public int findCountry(UInt32 idCountry)
        {
            MyCountryPersister countryReader = new MyCountryPersister();

            int index = countryReader.loadCountryById(unzlibPaesi, leggiPaesi, idCountry);

            //for "no country" 
            if (index == -1)
                index = Form1._Form1.stadiumCountry.Items.Count;

            return index;
        }

        public int findCountryFm(string name)
        {
            int index = -1;
            for (int i = 0; i < Form1._Form1.nationalityBox.Items.Count; i++)
            {
                if (name == Form1._Form1.nationalityBox.Items[i].ToString())
                    return i;
            }

            return index;
        }

        public int findStadium(UInt16 idStadium)
        {
            MyStadiumPersister stadiumReader = new MyStadiumPersister();

            int index = stadiumReader.loadStadiumById(unzlibStadi, leggiStadi, idStadium);

            //for "no stadium" 
            if (index == -1)
                index = Form1._Form1.stadiumsBox.Items.Count;

            return index;
        }

        public int findCoach(UInt32 idCoach)
        {
            MyCoachPersister coachReader = new MyCoachPersister();

            int index = coachReader.loadCoachById(unzlibAllenatori, leggiAllenatori, idCoach);

            return index;
        }

        public int findTeam(UInt32 idTeam)
        {
            MyTeamPersister teamReader = new MyTeamPersister();

            int index = teamReader.loadTeamById(unzlibSquadre, leggiSquadre, idTeam);

            //for "no team" 
            if (index == -1)
                index = Form1._Form1.teamsBox.Items.Count;

            return index;
        }

        public int findPlayer(UInt32 idPlayer)
        {
            MyPlayerPersister playerReader = new MyPlayerPersister();

            int index = playerReader.loadPlayerById(unzlibGiocatori, leggiGiocatori, idPlayer);

            //for "no player" 
            if (index == -1)
                index = Form1._Form1.playersBox.Items.Count;

            return index;
        }

        public void findCompetition(int selectedIndex)
        {
            Form1._Form1.DataGridView1.Rows.Clear();
            Form1._Form1.DataGridView1_orig.Rows.Clear();

            CompetitionRegulation r = leggiCompetizioneRegulation(selectedIndex);
            leggiCompetizioneEntry(r.getUNK5());

            for (int i = 0; i < Form1._Form1.DataGridView1.Rows.Count; i++)
            {
                int index = findTeam((uint)(Form1._Form1.DataGridView1.Rows[i].Cells[3].Value));
                if (index != Form1._Form1.teamsBox.Items.Count)
                    Form1._Form1.DataGridView1.Rows[i].Cells[1].Value = leggiSquadra(index).getEnglish();
                else
                    Form1._Form1.DataGridView1.Rows[i].Cells[1].Value = "No Team Found";
            }

            if (Form1._Form1.DataGridView1.Rows.Count > 0)
                Form1._Form1.DataGridView1.SelectedRows[0].Selected = true;

        }

        public int findGloveList(UInt32 idPlayer)
        {
            int index = Form1._Form1.glovesBox.Items.Count;

            GloveList c = leggiGuantiLista(idPlayer);

            //for "no glove"
            if (c == null)
                return index = Form1._Form1.glovesBox.Items.Count;

            for (int i = 0; i < Form1._Form1.glovesBox.Items.Count; i++)
            {
                if (c.getGloveId() == leggiGuanto(i).getId())
                    return i;
            }

            return index;
        }

        public int findBootList(UInt32 idPlayer)
        {
            int index = Form1._Form1.bootsBox.Items.Count;

            BootList c = leggiScarpeLista(idPlayer);

            //for "no glove" 
            if (c == null)
                return index = Form1._Form1.bootsBox.Items.Count;

            for (int i = 0; i < Form1._Form1.bootsBox.Items.Count; i++)
            {
                if (c.getBootId() == leggiScarpa(i).getId())
                    return i;
            }

            return index;
        }

        public int getSkinColour(UInt32 id)
        {
            PlayerAppearance pA = leggiGiocatoreApparenza(id);

            int output1 = 0;

            if (pA != null)
            {
                if (getBitRecognized() == 0)
                {
                    int skin = pA.getEyeskinColor();
                    string eye = skin.ToString("X2");
                    eye = Convert.ToString(Convert.ToInt32(eye.ToString(), 16), 2).PadLeft(8, '0');
                    eye = eye.Substring(5, 3);
                    output1 = Convert.ToInt32(eye, 2);
                }
                else
                {
                    int skin = pA.getEyeskinColor();
                    string eye = skin.ToString("X2");
                    eye = Convert.ToString(Convert.ToInt32(eye.ToString(), 16), 2).PadLeft(8, '0');
                    eye = eye.Substring(0, 3);
                    output1 = Convert.ToInt32(eye, 2);
                }

            }

            return output1;
        }

        public void changeSkinColour(UInt32 id, int value)
        {
            PlayerAppearance pA = leggiGiocatoreApparenza(id);
            if (getBitRecognized() == 0)
            {
                int skin = pA.getEyeskinColor();
                string eye = skin.ToString("X2");
                eye = Convert.ToString(Convert.ToInt32(eye.ToString(), 16), 2).PadLeft(8, '0');
                eye = eye.Substring(0, 5) + MyBinary.ToBinaryX(value, 3);
                pA.setEyeskinColor(Byte.Parse(MyBinary.BinaryToInt(eye).ToString()));
            }
            else
            {
                int skin = pA.getEyeskinColor();
                string eye = skin.ToString("X2");
                eye = Convert.ToString(Convert.ToInt32(eye.ToString(), 16), 2).PadLeft(8, '0');
                eye = MyBinary.ToBinaryX(value, 3) + eye.Substring(3, 5);
                pA.setEyeskinColor(Byte.Parse(MyBinary.BinaryToInt(eye).ToString()));
            }
            applyPlayerAppearancePersister(pA);
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

        public void UpdateForm(UInt32 idTeam, ListView l1)
        {
            if (leggiSquadra(Form1._Form1.teamBox1.SelectedIndex).getId() == idTeam)
            {
                for (int i = 0; i < Form1._Form1.teamView1.Items.Count; i++)
                {
                    Form1._Form1.teamView1.Items[i].SubItems[1].Text = l1.Items[i].SubItems[1].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[2].Text = l1.Items[i].SubItems[4].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[3].Text = l1.Items[i].SubItems[5].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[4].Text = l1.Items[i].SubItems[6].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[5].Text = l1.Items[i].SubItems[7].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[6].Text = l1.Items[i].SubItems[8].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[7].Text = l1.Items[i].SubItems[9].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[8].Text = l1.Items[i].SubItems[10].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[9].Text = l1.Items[i].SubItems[11].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[10].Text = l1.Items[i].SubItems[12].Text;
                    Form1._Form1.teamView1.Items[i].SubItems[11].Text = l1.Items[i].SubItems[13].Text;
                }
            }

            if (leggiSquadra(Form1._Form1.teamBox2.SelectedIndex).getId() == idTeam)
            {
                for (int i = 0; i < Form1._Form1.teamView2.Items.Count; i++)
                {
                    Form1._Form1.teamView2.Items[i].SubItems[1].Text = l1.Items[i].SubItems[1].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[2].Text = l1.Items[i].SubItems[4].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[3].Text = l1.Items[i].SubItems[5].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[4].Text = l1.Items[i].SubItems[6].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[5].Text = l1.Items[i].SubItems[7].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[6].Text = l1.Items[i].SubItems[8].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[7].Text = l1.Items[i].SubItems[9].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[8].Text = l1.Items[i].SubItems[10].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[9].Text = l1.Items[i].SubItems[11].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[10].Text = l1.Items[i].SubItems[12].Text;
                    Form1._Form1.teamView2.Items[i].SubItems[11].Text = l1.Items[i].SubItems[13].Text;
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
            player.setShirtName(Unidecoder.Unidecode(name));
            applyPlayerPersister(index, player);
        }

        public void changeNationalityPlayer(UInt32 id, int selecIndex)
        {
            int index = findPlayer(id);
            Player player = leggiGiocatore(index);
            player.setNational(leggiPaese(selecIndex).getId());
            applyPlayerPersister(index, player);
        }

        public void changePlayerNumber(UInt32 idPlayer, int team, string shirtNumber)
        {
            int intselectedindex = 0;
            if (team == 1) {

                for (int i = 0; (i <= (Form1._Form1.teamView1.Items.Count - 1)); i++)
                {
                    if (int.Parse(Form1._Form1.teamView1.Items[i].SubItems[3].Text) == int.Parse(shirtNumber))
                    {
                        MessageBox.Show("This number is already used", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                intselectedindex = Form1._Form1.teamView1.SelectedIndices[0];
                Form1._Form1.teamView1.Items[intselectedindex].SubItems[3].Text = shirtNumber;
                transferPlayerAtoA(Form1._Form1.teamView1, leggiSquadra(Form1._Form1.teamBox1.SelectedIndex).getId());

                if (intselectedindex + 1 < Form1._Form1.teamView1.Items.Count)
                {
                    Form1._Form1.teamView1.Items[intselectedindex + 1].Selected = true;
                    Form1._Form1.teamView1.Select();
                }
                else
                {
                    Form1._Form1.teamView1.Items[intselectedindex].Selected = true;
                    Form1._Form1.teamView1.Select();
                }

                //update
                if (Form1._Form1.teamBox1.SelectedIndex == Form1._Form1.teamBox2.SelectedIndex)
                    Form1._Form1.teamView2.Items[intselectedindex].SubItems[3].Text = shirtNumber;
            }
            else if (team == 2) {

                for (int i = 0; (i <= (Form1._Form1.teamView2.Items.Count - 1)); i++)
                {
                    if (int.Parse(Form1._Form1.teamView2.Items[i].SubItems[3].Text) == int.Parse(shirtNumber))
                    {
                        MessageBox.Show("This number is already used", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                intselectedindex = Form1._Form1.teamView2.SelectedIndices[0];
                Form1._Form1.teamView2.Items[intselectedindex].SubItems[3].Text = shirtNumber;
                transferPlayerAtoA(Form1._Form1.teamView2, leggiSquadra(Form1._Form1.teamBox2.SelectedIndex).getId());

                if (intselectedindex + 1 < Form1._Form1.teamView2.Items.Count)
                {
                    Form1._Form1.teamView2.Items[intselectedindex + 1].Selected = true;
                    Form1._Form1.teamView2.Select();
                }
                else
                {
                    Form1._Form1.teamView2.Items[intselectedindex].Selected = true;
                    Form1._Form1.teamView2.Select();
                }

                //update
                if (Form1._Form1.teamBox1.SelectedIndex == Form1._Form1.teamBox2.SelectedIndex)
                    Form1._Form1.teamView1.Items[intselectedindex].SubItems[3].Text = shirtNumber;
            }
        }
        
        public string getStringClubTeamOfPlayer(UInt32 idPlayer, int type) 
        {
            //club = 0; national = 1;

            MyPlayerAssignmentPersister ass = new MyPlayerAssignmentPersister();
            List<UInt32> b = ass.loadTeamId(idPlayer, unzlibPlayerAssign, leggiPlayerAssign);

            string finale = "";
            if (type == 0)
            {
                foreach (UInt32 i in b)
                {
                    int index = findTeam(i);
                    Team team = leggiSquadra(index);
                    if (team.getNational() == 0)
                        return team.getEnglish();
                }
            }
            else if (type == 1)
            {
                foreach (UInt32 i in b)
                {
                    int index = findTeam(i);
                    Team team = leggiSquadra(index);
                    if (team.getNational() == 1)
                        finale += team.getEnglish() + "+";
                }

                if (finale.EndsWith("+"))
                {
                    finale = finale.Substring(0, finale.LastIndexOf("+"));
                }
            }
		
            return finale;
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

        public void schemiPitch(ushort formationNumber, string nomeSchema, int typeSchema, Button player1, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11)
        {
            //typeSchema CUSTOM = 0, OFFENSIVE = 1, DEFENSIVE = 2;
            int k = 0;
            foreach (TacticsFormation temp in leggiFormazione(formationNumber))
            {
                if (nomeSchema == "Default")
                {
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

        public void changeFormation(ushort formation, int i, Button player2, Button player3, Button player4, Button player5, Button player6, Button player7, Button player8, Button player9, Button player10, Button player11,
            Button player13, Button player14, Button player15, Button player16, Button player17, Button player18, Button player19, Button player20, Button player21, Button player22,
            Button player24, Button player25, Button player26, Button player27, Button player28, Button player29, Button player30, Button player31, Button player32, Button player33, ListView teamView1)
        {
            //int i = 0 (CUSTOM), 1 (OFFENSIVE), 2 (DEFENSIVE)
            //CUSTOM
            int aa = -1;
            List<TacticsFormation> tacticsFormation = leggiFormazione(formation);
            foreach (TacticsFormation x in tacticsFormation)
            {
                    aa += 1;
                    if (aa == 1 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player2.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player2.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 2 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player3.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player3.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 3 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player4.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player4.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 4 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player5.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player5.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 5 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player6.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player6.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 6 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player7.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player7.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 7 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player8.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player8.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 8 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player9.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player9.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 9 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player10.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player10.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == 10 && i == 0)
                    {
                        //Posizione
                        byte X2 = (byte) ((player11.Location.X - 1) / 3);
                        byte Y2 = (byte) ((413 - player11.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    //OFFENSIVE
                    if (aa == (1 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player13.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player13.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (2 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player14.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player14.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (3 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player15.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player15.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (4 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player16.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player16.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (5 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player17.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player17.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (6 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player18.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player18.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (7 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player19.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player19.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (8 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player20.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player20.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (9 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player21.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player21.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (10 + 11) && i == 1)
                    {
                        //Posizione
                        byte X2 = (byte)((player22.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player22.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    //DEFENSIVE
                    if (aa == (1 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player24.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player24.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (2 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player25.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player25.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (3 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player26.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player26.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (4 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player27.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player27.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (5 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player28.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player28.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (6 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player29.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player29.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (7 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player30.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player30.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (8 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player31.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player31.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (9 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player32.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player32.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
                    if (aa == (10 + 22) && i == 2)
                    {
                        //Posizione
                        byte X2 = (byte)((player33.Location.X - 1) / 3);
                        byte Y2 = (byte)((413 - player33.Location.Y) / 9);
                        x.setPosition(getPosition(aa, i, teamView1));
                        x.setX(X2);
                        x.setY(Y2);
                    }
            }
            applyTacticsFormationPersister(tacticsFormation);
        }

        private byte getPosition(int k, int subItem, ListView teamView1)
        {
            //int subItem = 1 (CUSTOM), 2 (OFFENSIVE), 3 (DEFENSIVE)
            byte pos = 0;
            if (k >= 11 && k < 22)
                k = k - 11;

            if (k >= 22)
                k = k - 22;
            //Position
            subItem += 1;
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

        //transferPlayer Drag&Drop
        public void transferAtoA(ListView listview, int dropIndex, int intselectedindex)
        {
            string player1 = listview.Items[intselectedindex].SubItems[2].Text;
            string player2 = listview.Items[dropIndex].SubItems[2].Text;
            string number1 = listview.Items[intselectedindex].SubItems[3].Text;
            string number2 = listview.Items[dropIndex].SubItems[3].Text;
            string id1 = listview.Items[intselectedindex].SubItems[11].Text;
            string id2 = listview.Items[dropIndex].SubItems[11].Text;
            string pos1 = listview.Items[intselectedindex].SubItems[1].Text;
            string pos2 = listview.Items[dropIndex].SubItems[1].Text;
            listview.Items[intselectedindex].SubItems[1].Text = pos2;
            listview.Items[dropIndex].SubItems[1].Text = pos1;
            listview.Items[intselectedindex].SubItems[2].Text = player2;
            listview.Items[dropIndex].SubItems[2].Text = player1;
            listview.Items[intselectedindex].SubItems[3].Text = number2;
            listview.Items[dropIndex].SubItems[3].Text = number1;
            listview.Items[intselectedindex].SubItems[11].Text = id2;
            listview.Items[dropIndex].SubItems[11].Text = id1;
        }

        //applicare modifiche della squadra in transfer&team tab
        public void transferPlayerAtoA(ListView listview, uint teamId)
        {
            List<PlayerAssignment> pa = new List<PlayerAssignment>();
            for (int i = 0; i < listview.Items.Count; i++)
            {
                PlayerAssignment temp = new PlayerAssignment(uint.Parse(listview.Items[i].SubItems[11].Text), teamId);
                temp.setCaptain(ushort.Parse(listview.Items[i].SubItems[5].Text));
                temp.setEntryId(uint.Parse(listview.Items[i].SubItems[4].Text));
                temp.setLeftCkTk(ushort.Parse(listview.Items[i].SubItems[6].Text));
                temp.setLongShotLk(ushort.Parse(listview.Items[i].SubItems[7].Text));
                temp.setOrder((ushort)(ushort.Parse(listview.Items[i].SubItems[0].Text) - 1));
                temp.setPenaltyKick(ushort.Parse(listview.Items[i].SubItems[8].Text));
                temp.setRightCornerKick(ushort.Parse(listview.Items[i].SubItems[9].Text));
                temp.setShirtNumber(byte.Parse(listview.Items[i].SubItems[3].Text));
                temp.setShortFoulFk(ushort.Parse(listview.Items[i].SubItems[10].Text));

                pa.Add(temp);
            }
            applyPlayerAssignmentPersister(pa);
        }

        //form formazione
        public void transferPlayerFormatione(ListView listview, uint teamId)
        {
            List<PlayerAssignment> pa = new List<PlayerAssignment>();
            for (int i = 0; i < listview.Items.Count; i++)
            {
                PlayerAssignment temp = new PlayerAssignment(uint.Parse(listview.Items[i].SubItems[13].Text), teamId);
                temp.setCaptain(ushort.Parse(listview.Items[i].SubItems[7].Text));
                temp.setEntryId(ushort.Parse(listview.Items[i].SubItems[6].Text));
                temp.setLeftCkTk(ushort.Parse(listview.Items[i].SubItems[8].Text));
                temp.setLongShotLk(ushort.Parse(listview.Items[i].SubItems[9].Text));
                temp.setOrder((ushort) (ushort.Parse(listview.Items[i].SubItems[0].Text) - 1));
                temp.setPenaltyKick(ushort.Parse(listview.Items[i].SubItems[10].Text));
                temp.setRightCornerKick(ushort.Parse(listview.Items[i].SubItems[11].Text));
                temp.setShirtNumber(byte.Parse(listview.Items[i].SubItems[5].Text));
                temp.setShortFoulFk(ushort.Parse(listview.Items[i].SubItems[12].Text));

                pa.Add(temp);
            }
            applyPlayerAssignmentPersister(pa);
        }

        public void deletePlayerTeam(ListView l1, int selectIndex)
        {
            UInt32 Player_Ass_to_delete = uint.Parse(l1.Items[selectIndex].SubItems[4].Text);
            MemoryStream unzlib_player_Assignament_aux = new MemoryStream();
            BinaryWriter Grabar_Player_Assignament_aux = new BinaryWriter(unzlib_player_Assignament_aux);
            leggiPlayerAssign.BaseStream.Position = 0;
            UInt32 index_a_borrar = leggiPlayerAssign.ReadUInt32();

            // mirar si tienen algo de capitan o lanzador para ponerselo a otro y borrar la fila.
            if ((ushort.Parse(l1.Items[selectIndex].SubItems[5].Text) == 1))
            {
                if ((selectIndex == 0))
                    l1.Items[(selectIndex + 1)].SubItems[5].Text = "1";
                else
                    l1.Items[(selectIndex - 1)].SubItems[5].Text = "1";
            }

            if ((ushort.Parse(l1.Items[selectIndex].SubItems[8].Text) == 1))
            {
                if ((selectIndex == 0))
                    l1.Items[(selectIndex + 1)].SubItems[8].Text = "1";
                else
                    l1.Items[(selectIndex - 1)].SubItems[8].Text = "1";
            }

            if ((ushort.Parse(l1.Items[selectIndex].SubItems[7].Text) == 1))
            {
                if ((selectIndex == 0))
                    l1.Items[(selectIndex + 1)].SubItems[7].Text = "1";
                else
                    l1.Items[(selectIndex - 1)].SubItems[7].Text = "1";
            }

            if (ushort.Parse(l1.Items[selectIndex].SubItems[6].Text) == 1)
            {
                if ((selectIndex == 0))
                    l1.Items[(selectIndex + 1)].SubItems[6].Text = "1";
                else
                    l1.Items[(selectIndex - 1)].SubItems[6].Text = "1";
            }

            if ((ushort.Parse(l1.Items[selectIndex].SubItems[10].Text) == 1))
            {
                if ((selectIndex == 0))
                    l1.Items[(selectIndex + 1)].SubItems[10].Text = "1";
                else
                    l1.Items[(selectIndex - 1)].SubItems[10].Text = "1";
            }

            if ((ushort.Parse(l1.Items[selectIndex].SubItems[9].Text) == 1))
            {
                if ((selectIndex == 0))
                    l1.Items[(selectIndex + 1)].SubItems[9].Text = "1";
                else
                    l1.Items[(selectIndex - 1)].SubItems[9].Text = "1";
            }

            while ((index_a_borrar != Player_Ass_to_delete))
            {
                leggiPlayerAssign.BaseStream.Position += 12;
                index_a_borrar = leggiPlayerAssign.ReadUInt32();
            }

            UInt32 Posicion_a_borrar = (uint) (leggiPlayerAssign.BaseStream.Position - 4);
            leggiPlayerAssign.BaseStream.Position = 0;
            while ((unzlibPlayerAssign.Position < Posicion_a_borrar))
            {
                Grabar_Player_Assignament_aux.Write(leggiPlayerAssign.ReadByte());
            }

            leggiPlayerAssign.BaseStream.Position += 16;
            while ((leggiPlayerAssign.BaseStream.Position < unzlibPlayerAssign.Length))
            {
                Grabar_Player_Assignament_aux.Write(leggiPlayerAssign.ReadByte());
            }

            unzlibPlayerAssign.Close();
            unzlibPlayerAssign = new MemoryStream();
            unzlib_player_Assignament_aux.Position = 0;
            unzlib_player_Assignament_aux.CopyTo(unzlibPlayerAssign);
            unzlib_player_Assignament_aux.Close();
            leggiPlayerAssign = new BinaryReader(unzlibPlayerAssign);
            scriviPlayerAssign = new BinaryWriter(unzlibPlayerAssign);

            //aggiorno squadra
            Form1._Form1.giocatoreSquadra.Text = getStringClubTeamOfPlayer(uint.Parse(l1.Items[selectIndex].SubItems[11].Text), 0);
            Form1._Form1.giocatoreNazionale.Text = getStringClubTeamOfPlayer(uint.Parse(l1.Items[selectIndex].SubItems[11].Text), 1);

            l1.Items.RemoveAt(selectIndex);
            for (int i = 0; i < l1.Items.Count; i++)
            {
                l1.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        public void playerFromPlayerList(UInt32 playerId, UInt32 teamId, ListView l1, UInt32 teamSecondTeamId, ListView l2)
        {
            Team team = leggiSquadra(findTeam(teamId));
            Player player = leggiGiocatore(findPlayer(playerId));
            MyPlayerAssignmentPersister ass = new MyPlayerAssignmentPersister();

            //trovo se ha un club poichè è in una nazionale
            List<UInt32> b = ass.loadTeamId(playerId, unzlibPlayerAssign, leggiPlayerAssign);
            foreach (UInt32 i in b)
            {
                int index = findTeam(i);
                Team team2 = leggiSquadra(index);
                if (team2.getId() == team.getId())
                {
                    MessageBox.Show("Player already on Team", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            bool repetido = false;
            List<int> usados = new List<int>();
            int dorsal = 1;
            for (int i = 0; (i <= (l1.Items.Count - 1)); i++)
            {
                usados.Add(int.Parse(l1.Items[i].SubItems[3].Text));
                if (int.Parse(l1.Items[i].SubItems[3].Text) == dorsal)
                    repetido = true;
            }

            if ((repetido == true))
            {
                dorsal = 1;
                while (usados.Contains(dorsal))
                {
                    dorsal++;
                }
            }

            UInt32 assignId = ass.findIndexAssign(unzlibPlayerAssign, leggiPlayerAssign);

            if (team.getNational() == 1) //se il team di destinazione è una nazionale
            {
                if (l1.Items.Count >= 23)
                    MessageBox.Show("National is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (team.getNational() == 1 && team.getCountry() != player.getNational())
                        MessageBox.Show("Change Player's Nationality, to fit on his National Team first", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        ListViewItem item = new ListViewItem();
                        item = new ListViewItem((l1.Items.Count + 1).ToString());
                        item.SubItems.Add(player.getStringPosition());
                        item.SubItems.Add(player.getName());
                        item.SubItems.Add(dorsal.ToString());
                        item.SubItems.Add(assignId.ToString());
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add(player.getId().ToString());
                        l1.Items.Add(item);

                        //aggiorno squadra 2
                        if (teamSecondTeamId == teamId)
                            l2.Items.Add((ListViewItem)item.Clone());

                        ass.addPlayerAssign(ref unzlibPlayerAssign, ref leggiPlayerAssign, ref scriviPlayerAssign, assignId);
                        transferPlayerAtoA(l1, teamId);
                    }
                }
            }
            else //se è un club
            {
                if (l1.Items.Count >= 32)
                    MessageBox.Show("Club is full", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    int numberteam = 0;
                    foreach (UInt32 i in b)
                    {
                        int index = findTeam(i);
                        Team team2 = leggiSquadra(index);
                        if (team2.getNational() == 0)
                            numberteam = 1;
                    }

                    if (numberteam == 0) //se non ha una squadra
                    {
                        ListViewItem item = new ListViewItem();
                        item = new ListViewItem((l1.Items.Count + 1).ToString());
                        item.SubItems.Add(player.getStringPosition());
                        item.SubItems.Add(player.getName());
                        item.SubItems.Add(dorsal.ToString());
                        item.SubItems.Add(assignId.ToString());
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add(player.getId().ToString());
                        l1.Items.Add(item);

                        //aggiorno squadra 2
                        if (teamSecondTeamId == teamId)
                            l2.Items.Add((ListViewItem)item.Clone());

                        ass.addPlayerAssign(ref unzlibPlayerAssign, ref leggiPlayerAssign, ref scriviPlayerAssign, assignId);
                        transferPlayerAtoA(l1, teamId);
                    }
                    else  //se ha una squadra
                    {
                        List<PlayerAssignment> team2 = leggiGiocatoriSquadra(b[0]);
                        for (int i = 0; i < team2.Count - 1; i++)
                        {
                            if (team2[i].getPlayerId() == playerId)
                            {
                                ListViewItem item = new ListViewItem();
                                item = new ListViewItem((l1.Items.Count + 1).ToString());
                                item.SubItems.Add(player.getStringPosition());
                                item.SubItems.Add(player.getName());
                                item.SubItems.Add(dorsal.ToString());
                                item.SubItems.Add(team2[i].getEntryId().ToString());
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add(player.getId().ToString());
                                l1.Items.Add(item);

                                //aggiorno squadra 2
                                if (teamSecondTeamId == teamId)
                                    l2.Items.Add((ListViewItem)item.Clone());

                                // copio los datos del 1 al 2 poniendo 0 en lo de capitan y lanzador.
                                // mirar si tienen algo de capitan o lanzador para ponerselo a otro y borrar la fila.
                                if (team2[i].getCaptain() == 1)
                                {
                                    if (i == 0)
                                        team2[i + 1].setCaptain(1);
                                    else
                                        team2[i - 1].setCaptain(0);
                                }

                                if (team2[i].getPenaltyKick() == 1)
                                {
                                    if ((i == 0))
                                        team2[i + 1].setPenaltyKick(1);
                                    else
                                        team2[i - 1].setPenaltyKick(0);
                                }

                                if (team2[i].getLongShotLk() == 1)
                                {
                                    if ((i == 0))
                                        team2[i + 1].setLongShotLk(1);
                                    else
                                        team2[i - 1].setLongShotLk(0);
                                }

                                if (team2[i].getLeftCkTk() == 1)
                                {
                                    if ((i == 0))
                                        team2[i + 1].setLeftCkTk(1);
                                    else
                                        team2[i - 1].setLeftCkTk(0);
                                }

                                if (team2[i].getShortFoulFk() == 1)
                                {
                                    if ((i == 0))
                                        team2[i + 1].setShortFoulFk(1);
                                    else
                                        team2[i - 1].setShortFoulFk(0);
                                }

                                if (team2[i].getRightCornerKick() == 1)
                                {
                                    if ((i == 0))
                                        team2[i + 1].setRightCornerKick(1);
                                    else
                                        team2[i - 1].setRightCornerKick(0);
                                }
                                team2[i].setTeamId(team.getId());
                                team2[i].setOrder((ushort)(l1.Items.Count));
                                team2[i].setShirtNumber((byte)dorsal);
                                ass.applyPlayerA(unzlibPlayerAssign, leggiPlayerAssign, team2, ref scriviPlayerAssign);
                            }
                        }
                    }

                }
            }

        }

        public void transferPlayerBtoA(ListView toL, ListView fromL, ComboBox toC, ComboBox fromC, int selectIndex, int dropIndex)
        {
            int dorsal = int.Parse(fromL.Items[selectIndex].SubItems[3].Text);
            bool repetido = false;
            List<int> usados = new List<int>();
            Team teamB = leggiSquadra(fromC.SelectedIndex);
            UInt32 Team_Origen = teamB.getId();
            Team teamA = leggiSquadra(toC.SelectedIndex);
            UInt32 Team_destino = teamA.getId();
            for (int i = 0; i <= toL.Items.Count - 1; i++)
            {
                usados.Add(int.Parse(toL.Items[i].SubItems[3].Text));
                if (int.Parse(toL.Items[i].SubItems[3].Text) == dorsal)
                    repetido = true;
            }

            if ((repetido == true))
            {
                dorsal = 1;
                while (usados.Contains(dorsal))
                {
                    dorsal++;
                }
            }

            MyPlayerAssignmentPersister ass = new MyPlayerAssignmentPersister();
            UInt32 assignId = ass.findIndexAssign(unzlibPlayerAssign, leggiPlayerAssign);

            if (teamB.getNational() == 1) //squadra partenza é una nazionale
            {
                if (teamA.getNational() == 1) //se la squadra di destinazione è una nazionale
                {
                    if (toL.Items.Count < 23 && fromL.Items.Count > 16)
                    {
                        UInt32 Index_club_2_sel_player = uint.Parse(fromL.Items[selectIndex].SubItems[11].Text);
                        List<UInt32> List_players = new List<UInt32>();
                        for (int j = 0; (j <= (toL.Items.Count - 1)); j++)
                        {
                            List_players.Add(uint.Parse(toL.Items[j].SubItems[11].Text));
                        }

                        // comprobar que es un jugador de ese pais y que no est repetido
                        if (List_players.Contains(Index_club_2_sel_player))
                            MessageBox.Show("Player already on National Team", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            UInt32 id_player = uint.Parse(fromL.Items[selectIndex].SubItems[11].Text);
                            Player Player_check = leggiGiocatore(id_player);
                            if (Player_check.getNational() == leggiSquadra(toC.SelectedIndex).getCountry())
                            {
                                ListViewItem item = new ListViewItem();
                                item = new ListViewItem((toL.Items.Count + 1).ToString());
                                item.SubItems.Add(fromL.Items[selectIndex].SubItems[1].Text);
                                item.SubItems.Add(fromL.Items[selectIndex].SubItems[2].Text);
                                item.SubItems.Add(dorsal.ToString());
                                item.SubItems.Add(assignId.ToString());
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add(fromL.Items[selectIndex].SubItems[11].Text);
                                toL.Items.Add(item);

                                ass.addPlayerAssign(ref unzlibPlayerAssign, ref leggiPlayerAssign, ref scriviPlayerAssign, assignId);
                                transferPlayerAtoA(toL, teamA.getId());
                            }
                            else
                                MessageBox.Show("The player of team 2, doesn't belong to " + teamA.getEnglish() + " nationality", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Team Full, Please remove player before", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // se è un club
                {
                    if (toL.Items.Count < 32 && fromL.Items.Count > 16)
                    {
                        UInt32 Index_club_2_sel_player = uint.Parse(fromL.Items[selectIndex].SubItems[11].Text);
                        List<UInt32> List_players = new List<UInt32>();
                        for (int j = 0; (j <= (toL.Items.Count - 1)); j++)
                        {
                            List_players.Add(uint.Parse(toL.Items[j].SubItems[11].Text));
                        }

                        // comprobar que es un jugador de ese pais y que no est repetido
                        if (List_players.Contains(Index_club_2_sel_player))
                            MessageBox.Show("Player already on Club", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            //trovo se ha un club poichè è in una nazionale
                            List<UInt32> b = ass.loadTeamId(Index_club_2_sel_player, unzlibPlayerAssign, leggiPlayerAssign);
                            UInt32 idTeamFrom = 0;
                            foreach (UInt32 i in b)
                            {
                                int index = findTeam(i);
                                Team team = leggiSquadra(index);
                                if (team.getNational() == 0)
                                    idTeamFrom = team.getId();
                            }

                            //solo se ha una squadra
                            if (idTeamFrom != 0)
                            {
                                List<PlayerAssignment> list = leggiGiocatoriSquadra(idTeamFrom);

                                for (int i = 0; i < list.Count; i++ )
                                {
                                    if (list[i].getPlayerId() == Index_club_2_sel_player)
                                        assignId = list[i].getEntryId();

                                    // copio los datos del 1 al 2 poniendo 0 en lo de capitan y lanzador.
                                    // mirar si tienen algo de capitan o lanzador para ponerselo a otro y borrar la fila.
                                    if (list[i].getCaptain() == 1)
                                    {
                                        if ((i == 0))
                                            list[i + 1].setCaptain(1);
                                        else
                                            list[i - 1].setCaptain(1);
                                    }

                                    if (list[i].getPenaltyKick() == 1)
                                    {
                                        if ((i == 0))
                                            list[i + 1].setPenaltyKick(1);
                                        else
                                            list[i - 1].setPenaltyKick(1);
                                    }

                                    if (list[i].getLongShotLk() == 1)
                                    {
                                        if ((i == 0))
                                            list[i + 1].setLongShotLk(1);
                                        else
                                            list[i - 1].setLongShotLk(1);
                                    }

                                    if (list[i].getLeftCkTk() == 1)
                                    {
                                        if ((i == 0))
                                            list[i + 1].setLeftCkTk(1);
                                        else
                                            list[i - 1].setLeftCkTk(1);
                                    }

                                    if (list[i].getShortFoulFk() == 1)
                                    {
                                        if ((i == 0))
                                            list[i + 1].setShortFoulFk(1);
                                        else
                                            list[i - 1].setShortFoulFk(1);
                                    }

                                    if (list[i].getRightCornerKick() == 1)
                                    {
                                        if ((i == 0))
                                            list[i + 1].setRightCornerKick(1);
                                        else
                                            list[i - 1].setRightCornerKick(1);
                                    }
                                }
                            }

                            ListViewItem item = new ListViewItem();
                            item = new ListViewItem((toL.Items.Count + 1).ToString());
                            item.SubItems.Add(fromL.Items[selectIndex].SubItems[1].Text);
                            item.SubItems.Add(fromL.Items[selectIndex].SubItems[2].Text);
                            item.SubItems.Add(dorsal.ToString());
                            item.SubItems.Add(assignId.ToString());
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                            item.SubItems.Add("0");
                            item.SubItems.Add(fromL.Items[selectIndex].SubItems[11].Text);
                            toL.Items.Add(item);

                            ass.addPlayerAssign(ref unzlibPlayerAssign, ref leggiPlayerAssign, ref scriviPlayerAssign, assignId);
                            transferPlayerAtoA(toL, teamA.getId());
                        }
                    }
                    else
                        MessageBox.Show("Team Full, Please remove player before", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //squadra partenza é un club
            {
                if (teamA.getNational() == 1) //se la squadra di destinazione è una nazionale
                {
                    if (toL.Items.Count < 23 && fromL.Items.Count > 16)
                    {
                        UInt32 Index_club_2_sel_player = uint.Parse(fromL.Items[selectIndex].SubItems[11].Text);
                        List<UInt32> List_players = new List<UInt32>();
                        for (int j = 0; (j <= (toL.Items.Count - 1)); j++)
                        {
                            List_players.Add(uint.Parse(toL.Items[j].SubItems[11].Text));
                        }

                        // comprobar que es un jugador de ese pais y que no est repetido
                        if (List_players.Contains(Index_club_2_sel_player))
                            MessageBox.Show("Player already on National Team", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            UInt32 id_player = uint.Parse(fromL.Items[selectIndex].SubItems[11].Text);
                            Player Player_check = leggiGiocatore(id_player);
                            if (Player_check.getNational() == leggiSquadra(toC.SelectedIndex).getCountry())
                            {
                                ListViewItem item = new ListViewItem();
                                item = new ListViewItem((toL.Items.Count + 1).ToString());
                                item.SubItems.Add(fromL.Items[selectIndex].SubItems[1].Text);
                                item.SubItems.Add(fromL.Items[selectIndex].SubItems[2].Text);
                                item.SubItems.Add(dorsal.ToString());
                                item.SubItems.Add(assignId.ToString());
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add("0");
                                item.SubItems.Add(fromL.Items[selectIndex].SubItems[11].Text);
                                toL.Items.Add(item);

                                ass.addPlayerAssign(ref unzlibPlayerAssign, ref leggiPlayerAssign, ref scriviPlayerAssign, assignId);
                                transferPlayerAtoA(toL, teamA.getId());
                            }
                            else
                                MessageBox.Show("The player of team 2, doesn't belong to " + teamA.getEnglish() + " nationality", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Team Full, Please remove player before", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else  //o un club
                {
                    UInt32 Index_club_2_sel_player = uint.Parse(fromL.Items[selectIndex].SubItems[11].Text);
                    List<UInt32> List_players = new List<UInt32>();
                    for (int j = 0; (j <= (toL.Items.Count - 1)); j++)
                    {
                        List_players.Add(uint.Parse(toL.Items[j].SubItems[11].Text));
                    }

                    // comprobar que es un jugador de ese pais y que no est repetido
                    if (List_players.Contains(Index_club_2_sel_player))
                    {
                        MessageBox.Show("Player already on Club", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (toL.Items.Count < 32 && fromL.Items.Count > 16)
                    {
                        ListViewItem item = new ListViewItem();
                        item = new ListViewItem((toL.Items.Count + 1).ToString());
                        item.SubItems.Add(fromL.Items[selectIndex].SubItems[1].Text);
                        item.SubItems.Add(fromL.Items[selectIndex].SubItems[2].Text);
                        item.SubItems.Add(dorsal.ToString());
                        item.SubItems.Add(fromL.Items[selectIndex].SubItems[4].Text);
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        item.SubItems.Add(fromL.Items[selectIndex].SubItems[11].Text);
                        toL.Items.Add(item);

                        // copio los datos del 1 al 2 poniendo 0 en lo de capitan y lanzador.
                        // mirar si tienen algo de capitan o lanzador para ponerselo a otro y borrar la fila.
                        if ((ushort.Parse(fromL.Items[selectIndex].SubItems[5].Text) == 1))
                        {
                            if ((selectIndex == 0))
                                fromL.Items[(selectIndex + 1)].SubItems[5].Text = "1";
                            else
                                fromL.Items[(selectIndex - 1)].SubItems[5].Text = "1";
                        }

                        if ((ushort.Parse(fromL.Items[selectIndex].SubItems[8].Text) == 1))
                        {
                            if ((selectIndex == 0))
                                fromL.Items[(selectIndex + 1)].SubItems[8].Text = "1";
                            else
                                fromL.Items[(selectIndex - 1)].SubItems[8].Text = "1";
                        }

                        if ((ushort.Parse(fromL.Items[selectIndex].SubItems[7].Text) == 1))
                        {
                            if ((selectIndex == 0))
                                fromL.Items[(selectIndex + 1)].SubItems[7].Text = "1";
                            else
                                fromL.Items[(selectIndex - 1)].SubItems[7].Text = "1";
                        }

                        if (ushort.Parse(fromL.Items[selectIndex].SubItems[6].Text) == 1)
                        {
                            if ((selectIndex == 0))
                                fromL.Items[(selectIndex + 1)].SubItems[6].Text = "1";
                            else
                                fromL.Items[(selectIndex - 1)].SubItems[6].Text = "1";
                        }

                        if ((ushort.Parse(fromL.Items[selectIndex].SubItems[10].Text) == 1))
                        {
                            if ((selectIndex == 0))
                                fromL.Items[(selectIndex + 1)].SubItems[10].Text = "1";
                            else
                                fromL.Items[(selectIndex - 1)].SubItems[10].Text = "1";
                        }

                        if ((ushort.Parse(fromL.Items[selectIndex].SubItems[9].Text) == 1))
                        {
                            if ((selectIndex == 0))
                                fromL.Items[(selectIndex + 1)].SubItems[9].Text = "1";
                            else
                                fromL.Items[(selectIndex - 1)].SubItems[9].Text = "1";
                        }

                        int fila_actual = selectIndex;
                        fromL.Items.RemoveAt(selectIndex);
                        for (int i = fila_actual; i <= fromL.Items.Count - 1; i++)
                        {
                            fromL.Items[i].SubItems[0].Text = (int.Parse(fromL.Items[i].SubItems[0].Text) - 1).ToString();
                        }

                        transferPlayerAtoA(toL, teamA.getId());
                    }
                    else
                        MessageBox.Show("Team Full, Please remove player before", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        //remove fake team
        public void removeFakeTeam()
        {
            for (int i = 0; i < Form1._Form1.teamBox1.Items.Count - 1; i++)
            {
                Team temp = leggiSquadra(i);
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
                applyTeamPersister(i, temp);
                Form1._Form1.teamsBox.Items[i] = temp.getEnglish();
                Form1._Form1.teamBox1.Items[i] = temp.getEnglish();
                Form1._Form1.teamBox2.Items[i] = temp.getEnglish();
                Form1._Form1.derbyTeam1.Items[i] = temp.getEnglish();
                Form1._Form1.derbyTeam2.Items[i] = temp.getEnglish();
                for (int i1 = 0; i1 < Form1._Form1.DataGridView_derby.RowCount; i1++)
                {
                    if (Form1._Form1.DataGridView_derby.Rows[i1].Cells[0].Value.ToString() == temp.getId().ToString())
                        Form1._Form1.DataGridView_derby.Rows[i1].Cells[1].Value = temp.getEnglish();
                    if (Form1._Form1.DataGridView_derby.Rows[i1].Cells[2].Value.ToString() == temp.getId().ToString())
                        Form1._Form1.DataGridView_derby.Rows[i1].Cells[3].Value = temp.getEnglish();
                }
            }
            //
        }

        //remove fake player
        public void removeFakePlayer()
        {
            for (int i = 0; i < Form1._Form1.playersBox.Items.Count - 1; i++)
            {
                Player temp = leggiGiocatore(i);
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
                applyPlayerPersister(i, temp);
                UpdateTeamView(temp.getId(), temp.getName());
                UpdateFormPlayer(i, temp.getName());
            }
        }

        public void ExportPlayer(ushort id, string shirtName)
        {
            int block = 192;

            byte[] Byte_array_Export;
            leggiGiocatori.BaseStream.Position = (Form1._Form1.playersBox.SelectedIndex * block);
            Byte_array_Export = leggiGiocatori.ReadBytes(block);
            string Nombre_archivo = (id + ("_"
                        + (shirtName + ".exported")));

            //Setup OpenFileDialog
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream Stream_a_exportar = new FileStream(ofd.SelectedPath + @"\" + Nombre_archivo, FileMode.OpenOrCreate);
                Stream_a_exportar.Write(Byte_array_Export, 0, Byte_array_Export.Length);
                Stream_a_exportar.Close();
                MessageBox.Show(shirtName + " Succesfully Exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ImportPlayer()
        {
            int block = 192;
            UInt32 player_check = 0;

            OpenFileDialog OpenPes = new OpenFileDialog();
            OpenPes.Title = "Open Exported Player";
            OpenPes.Filter = "*.exported (*.exported)|*.exported";
            OpenPes.Multiselect = true;

            if (OpenPes.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                int number_of_files = OpenPes.FileNames.Count();
                foreach (string archivo in OpenPes.FileNames) 
                {
                    string NombreSinPath = Path.GetFileNameWithoutExtension(archivo);
                    string Id = "";
                    foreach (char val in NombreSinPath.ToCharArray()) {
                        if ((val == '_')) {
                            break;
                        }
                        else {
                            Id = (Id + val);
                        }
            
                    }
        
                    UInt32 ID_A_IMPORTAR = Convert.ToUInt32(Id);
                    FileStream stream_a_importar = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                    BinaryReader Leer_archivo = new BinaryReader(stream_a_importar);
                    leggiGiocatori.BaseStream.Position = 0;
                    for (int i = 0; (i  <= ((unzlibGiocatori.Length / block) - 1)); i++) 
                    {
                        leggiGiocatori.BaseStream.Position += 8;

                        if (bitRecognized == 0)
                            player_check = leggiGiocatori.ReadUInt32();
                        else if (bitRecognized == 1 || bitRecognized == 2)
                            player_check = UnzlibZlibConsole.swaps.swap32(leggiGiocatori.ReadUInt32());

                        if ((player_check == ID_A_IMPORTAR)) {
                            leggiGiocatori.BaseStream.Position -= 12;
                            byte[] Byte_array = Leer_archivo.ReadBytes(block);
                            scriviGiocatori.Write(Byte_array, 0, Byte_array.Length);
                            Form1._Form1.playersBox.SelectedIndex = i;
                            break;
                        }
                        leggiGiocatori.BaseStream.Position -= 12;
                        leggiGiocatori.BaseStream.Position = (leggiGiocatori.BaseStream.Position + block);
                    }
                }
                MessageBox.Show("Player(s) imported succesfully", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void exportPlayerApp(ushort id, string shirtName)
        {
            byte[] Byte_array_Export;
            leggiPlayerApp.BaseStream.Position = 0;

            UInt32 player_check = 0;
            if (bitRecognized == 0)
                player_check = leggiPlayerApp.ReadUInt32();
            else if (bitRecognized == 1 || bitRecognized == 2)
                player_check = UnzlibZlibConsole.swaps.swap32(leggiPlayerApp.ReadUInt32());

            while (player_check != id)
            {
                if (leggiPlayerApp.BaseStream.Position == unzlibPlayerApp.Length - 56)
                {
                    MessageBox.Show("No playerAppearance present in the file", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    leggiPlayerApp.BaseStream.Position += 56;

                if (bitRecognized == 0)
                    player_check = leggiPlayerApp.ReadUInt32();
                else if (bitRecognized == 1 || bitRecognized == 2)
                    player_check = UnzlibZlibConsole.swaps.swap32(leggiPlayerApp.ReadUInt32());
            }

            leggiPlayerApp.BaseStream.Position -= 4;
            Byte_array_Export = leggiPlayerApp.ReadBytes(60);
            string Nombre_archivo = id + "_" + shirtName + "_appareance" + ".exported_app";

            //Setup OpenFileDialog
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            //Run open file dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream Stream_a_exportar = new FileStream(ofd.SelectedPath + @"\" + Nombre_archivo, FileMode.OpenOrCreate);
                Stream_a_exportar.Write(Byte_array_Export, 0, Byte_array_Export.Length);
                Stream_a_exportar.Close();
                MessageBox.Show(shirtName + " Succesfully Exported", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void importPlayerApp()
        {
            UInt32 player_check = 0;

            OpenFileDialog OpenPes = new OpenFileDialog();
            OpenPes.Title = "Open A Exported Player Appareance";
            OpenPes.Filter = "*.exported_app (*.exported_app)|*.exported_app";
            OpenPes.Multiselect = true;

            if ((OpenPes.ShowDialog() == System.Windows.Forms.DialogResult.OK))
            {
                int number_of_files = OpenPes.FileNames.Count();
                foreach (string archivo in OpenPes.FileNames) {
                    string NombreSinPath = Path.GetFileNameWithoutExtension(archivo);
                    string Id = "";
                    foreach (char val in NombreSinPath.ToCharArray()) {
                        if ((val == '_')) {
                            break;
                        }
                        else {
                            Id = (Id + val);
                        }
            
                    }
        
                    UInt32 ID_A_IMPORTAR = Convert.ToUInt32(Id);
                    FileStream stream_a_importar = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                    BinaryReader Leer_archivo = new BinaryReader(stream_a_importar);
                    leggiPlayerApp.BaseStream.Position = 0;
                    for (int i = 0; i  <= unzlibPlayerApp.Length / 60 - 1; i++) {

                        if (bitRecognized == 0)
                            player_check = leggiGiocatori.ReadUInt32();
                        else if (bitRecognized == 1 || bitRecognized == 2)
                            player_check = UnzlibZlibConsole.swaps.swap32(leggiPlayerApp.ReadUInt32());

                        if ((player_check == ID_A_IMPORTAR)) {
                            leggiPlayerApp.BaseStream.Position -= 4;
                            byte[] Byte_array = Leer_archivo.ReadBytes(60);
                            scriviPlayerApp.Write(Byte_array, 0, Byte_array.Length);
                            Form1._Form1.playersBox.SelectedIndex = i;
                            break;
                        }

                        leggiPlayerApp.BaseStream.Position += 56;
                    }
        
                }

                MessageBox.Show("Player(s) imported succesfully", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        int lastItm2 = 0;
        public void listBoxSearchById(ListBox listbox, TextBox search)
        {
            try
            {
                Convert.ToInt32(search.Text);
            }
            catch
            {
                MessageBox.Show("There is no number in the textBox", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int col = 0;
            int colCount = col + 1;
            bool find = false;
            
            for (int colAll = col; colAll < colCount; colAll++)
            {
                for (int lst12 = lastItm2; lst12 < listbox.Items.Count; lst12++)
                {
                    Player player = leggiGiocatore(lst12);
                    if (player.getId() == uint.Parse(search.Text))
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
                DialogResult dialogResult = MessageBox.Show("Id not found, do you want restart research?", Application.ProductName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    lastItm2 = 0;
                    listbox.SelectedIndex = 0;
                    listbox.Select();
                }
            }
        }

        public void generateCPK(string patch)
        {
            MessageBox.Show("Remember to save to apply the changes!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                string[] f = patch.Split('\\');

                if (Directory.Exists(patch + @"\" + f[f.Count() - 1]) == true)
                    Directory.Delete(patch + @"\" + f[f.Count() - 1], true);
                //creazione cartelle innestate
                DirectoryInfo di = Directory.CreateDirectory(patch + @"\" + f[f.Count() - 1] + @"\common\etc\pesdb");
                DirectoryInfo di2 = Directory.CreateDirectory(patch + @"\" + f[f.Count() - 1] + @"\common\character0\model\character\appearance");
                DirectoryInfo di3 = Directory.CreateDirectory(patch + @"\" + f[f.Count() - 1] + @"\common\character0\model\character\boots");
                DirectoryInfo di4 = Directory.CreateDirectory(patch + @"\" + f[f.Count() - 1] + @"\common\character0\model\character\glove");
                File.Copy(patch + @"\Ball.bin", di.FullName + @"\Ball.bin", true);
                File.Copy(patch + @"\BallCondition.bin", di.FullName + @"\BallCondition.bin", true);
                File.Copy(patch + @"\Boots.bin", di.FullName + @"\Boots.bin", true);
                File.Copy(patch + @"\Boots3.bin", di.FullName + @"\Boots3.bin", true);
                File.Copy(patch + @"\Coach.bin", di.FullName + @"\Coach.bin", true);
                File.Copy(patch + @"\Competition.bin", di.FullName + @"\Competition.bin", true);
                File.Copy(patch + @"\CompetitionEntry.bin", di.FullName + @"\CompetitionEntry.bin", true);
                File.Copy(patch + @"\CompetitionKind.bin", di.FullName + @"\CompetitionKind.bin", true);
                File.Copy(patch + @"\CompetitionRegulation.bin", di.FullName + @"\CompetitionRegulation.bin", true);
                File.Copy(patch + @"\Country.bin", di.FullName + @"\Country.bin", true);
                File.Copy(patch + @"\Derby.bin", di.FullName + @"\Derby.bin", true);
                File.Copy(patch + @"\Glove.bin", di.FullName + @"\Glove.bin", true);
                File.Copy(patch + @"\Player.bin", di.FullName + @"\Player.bin", true);
                File.Copy(patch + @"\PlayerAssignment.bin", di.FullName + @"\PlayerAssignment.bin", true);
                File.Copy(patch + @"\Stadium.bin", di.FullName + @"\Stadium.bin", true);
                File.Copy(patch + @"\StadiumOrder.bin", di.FullName + @"\StadiumOrder.bin", true);
                File.Copy(patch + @"\StadiumOrderInConfederation.bin", di.FullName + @"\StadiumOrderInConfederation.bin", true);
                File.Copy(patch + @"\Tactics.bin", di.FullName + @"\Tactics.bin", true);
                File.Copy(patch + @"\TacticsFormation.bin", di.FullName + @"\TacticsFormation.bin", true);
                File.Copy(patch + @"\Team.bin", di.FullName + @"\Team.bin", true);
                File.Copy(patch + @"\PlayerAppearance.bin", di2.FullName + @"\PlayerAppearance.bin", true);
                File.Copy(patch + @"\BootsList.bin", di3.FullName + @"\BootsList.bin", true);
                File.Copy(patch + @"\GloveList.bin", di4.FullName + @"\GloveList.bin", true);
                File.SetAttributes(patch + @"\" + f[f.Count() - 1], FileAttributes.Hidden | FileAttributes.System);
                MustafaUğuz.PES2017.Common.CPK cpk = new MustafaUğuz.PES2017.Common.CPK(patch);
                List<MustafaUğuz.PES2017.Common.CRIArchiveFile> temp = cpk.GetFilesFromFolder(patch + @"\" + f[f.Count() - 1], "*.bin", SearchOption.AllDirectories);
                cpk.Build(temp);
                if (Directory.Exists(patch + @"\" + f[f.Count() - 1]) == true)
                    Directory.Delete(patch + @"\" + f[f.Count() - 1], true);
                MessageBox.Show("Cpk created correctly!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Cpk Saved at:" + Environment.NewLine + patch + ".cpk", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                string[] f = patch.Split('\\');
                if (Directory.Exists(patch + @"\" + f[f.Count() - 1]) == true)
                    Directory.Delete(patch + @"\" + f[f.Count() - 1], true);

                MessageBox.Show("Check if files are present!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
