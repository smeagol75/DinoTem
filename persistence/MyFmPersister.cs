using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DinoTem.model;

namespace DinoTem.persistence
{
    public class MyFmPersister : FmPersister
    {
        public List<Fm> load(string patch)
        {
            List<Fm> result = new List<Fm>();

            bool firstLine = false;
            foreach (string line in File.ReadLines(Application.StartupPath + @"\Data\" + patch, Encoding.UTF8))
            {
                string[] tokenizer = line.Split(new string[] { "," + '"' }, StringSplitOptions.None);
                //string[] tokenizer = line.Split("\t\r");
                if (tokenizer.Count() != 87)
                    throw new Exception("number of tokenizer isn't correct");
                if (!firstLine)
                    firstLine = true;
                else
                {
                    int id = parseInt(tokenizer[0].Trim());
                    Fm temp = new Fm(id);

                    temp.setFirstName(tokenizer[1].Trim('"').Trim());
                    temp.setFirstInitial(tokenizer[2].Trim('"').Trim());
                    if (tokenizer[3].Trim() == "")
                        throw new Exception("Surname isn't valid (id: " + id + ")");
                    temp.setSurname(tokenizer[3].Trim('"').Trim());
                    temp.setDateOfBirth(tokenizer[4].Trim('"').Trim());
                    if (tokenizer[5].Trim() == "")
                        throw new Exception("Nationality isn't valid (id: " + id + ")");
                    temp.setNation(tokenizer[5].Trim('"').Trim());
                    temp.setClub(tokenizer[6].Trim('"').Trim());
                    temp.setLeftFoot(parseInt(tokenizer[7].Trim()));
                    temp.setRightFoot(parseInt(tokenizer[8].Trim()));
                    if (tokenizer[9].Trim() == "")
                        throw new Exception("Position isn't valid (id: " + id + ")");
                    temp.setPosition(tokenizer[9].Trim('"').Trim());
                    temp.setGk(parseInt(tokenizer[10].Trim()));
                    temp.setSw(parseInt(tokenizer[11].Trim()));
                    temp.setRb(parseInt(tokenizer[12].Trim()));
                    temp.setLb(parseInt(tokenizer[13].Trim()));
                    temp.setCb(parseInt(tokenizer[14].Trim()));
                    temp.setWbr(parseInt(tokenizer[15].Trim()));
                    temp.setWbl(parseInt(tokenizer[16].Trim()));
                    temp.setDm(parseInt(tokenizer[17].Trim()));
                    temp.setRm(parseInt(tokenizer[18].Trim()));
                    temp.setLm(parseInt(tokenizer[19].Trim()));
                    temp.setCm(parseInt(tokenizer[20].Trim()));
                    temp.setAml(parseInt(tokenizer[21].Trim()));
                    temp.setAmr(parseInt(tokenizer[22].Trim()));
                    temp.setAmc(parseInt(tokenizer[23].Trim()));
                    temp.setSt(parseInt(tokenizer[24].Trim()));
                    temp.setAcceleration(parseInt(tokenizer[25].Trim()));
                    temp.setAdaptability(parseInt(tokenizer[26].Trim()));
                    temp.setAerialAbility(parseInt(tokenizer[27].Trim()));
                    temp.setAggression(parseInt(tokenizer[28].Trim()));
                    temp.setAgility(parseInt(tokenizer[29].Trim()));
                    temp.setAmbition(parseInt(tokenizer[30].Trim()));
                    temp.setAnticipation(parseInt(tokenizer[31].Trim()));
                    temp.setBalance(parseInt(tokenizer[32].Trim()));
                    temp.setBravery(parseInt(tokenizer[33].Trim()));
                    temp.setCommandOfArea(parseInt(tokenizer[34].Trim()));
                    temp.setCommunication(parseInt(tokenizer[35].Trim()));
                    temp.setComposure(parseInt(tokenizer[36].Trim()));
                    temp.setConcentration(parseInt(tokenizer[37].Trim()));
                    temp.setConsistency(parseInt(tokenizer[38].Trim()));
                    temp.setControversy(parseInt(tokenizer[39].Trim()));
                    temp.setCorners(parseInt(tokenizer[40].Trim()));
                    temp.setCrossing(parseInt(tokenizer[41].Trim()));
                    temp.setDecisions(parseInt(tokenizer[42].Trim()));
                    temp.setDetermination(parseInt(tokenizer[43].Trim()));
                    temp.setDirtiness(parseInt(tokenizer[44].Trim()));
                    temp.setDribbling(parseInt(tokenizer[45].Trim()));
                    temp.setEccentricity(parseInt(tokenizer[46].Trim()));
                    temp.setFinishing(parseInt(tokenizer[47].Trim()));
                    temp.setFirstTouch(parseInt(tokenizer[48].Trim()));
                    temp.setFlair(parseInt(tokenizer[49].Trim()));
                    temp.setFreeKicks(parseInt(tokenizer[50].Trim()));
                    temp.setHandling(parseInt(tokenizer[51].Trim()));
                    temp.setHeading(parseInt(tokenizer[52].Trim()));
                    temp.setImportantMatches(parseInt(tokenizer[53].Trim()));
                    temp.setInjuryProneness(parseInt(tokenizer[54].Trim()));
                    temp.setJumping(parseInt(tokenizer[55].Trim()));
                    temp.setKicking(parseInt(tokenizer[56].Trim()));
                    temp.setLeadership(parseInt(tokenizer[57].Trim()));
                    temp.setLongShots(parseInt(tokenizer[58].Trim()));
                    temp.setLongThrows(parseInt(tokenizer[59].Trim()));
                    temp.setLoyalty(parseInt(tokenizer[60].Trim()));
                    temp.setMarking(parseInt(tokenizer[61].Trim()));
                    temp.setNaturalFitness(parseInt(tokenizer[62].Trim()));
                    temp.setOffTheBall(parseInt(tokenizer[63].Trim()));
                    temp.setOneOnOnes(parseInt(tokenizer[64].Trim()));
                    temp.setPace(parseInt(tokenizer[65].Trim()));
                    temp.setPassing(parseInt(tokenizer[66].Trim()));
                    temp.setPenalties(parseInt(tokenizer[67].Trim()));
                    temp.setPositioning(parseInt(tokenizer[68].Trim()));
                    temp.setPressure(parseInt(tokenizer[69].Trim()));
                    temp.setProfessionalism(parseInt(tokenizer[70].Trim()));
                    temp.setReflexes(parseInt(tokenizer[71].Trim()));
                    temp.setRushingOut(parseInt(tokenizer[72].Trim()));
                    temp.setSportsmanship(parseInt(tokenizer[73].Trim()));
                    temp.setStamina(parseInt(tokenizer[74].Trim()));
                    temp.setStrength(parseInt(tokenizer[75].Trim()));
                    temp.setTackling(parseInt(tokenizer[76].Trim()));
                    temp.setTeamwork(parseInt(tokenizer[77].Trim()));
                    temp.setTechnique(parseInt(tokenizer[78].Trim()));
                    temp.setTemperament(parseInt(tokenizer[79].Trim()));
                    temp.setTendancyToPunch(parseInt(tokenizer[80].Trim()));
                    temp.setThrowing(parseInt(tokenizer[81].Trim()));
                    temp.setVersatility(parseInt(tokenizer[82].Trim()));
                    temp.setVision(parseInt(tokenizer[83].Trim()));
                    temp.setWorkRate(parseInt(tokenizer[84].Trim()));

                    result.Add(temp);
                }
            }

            return result;
        }

        private int parseInt(string s)
        {
            try
            {
                return int.Parse(s.Trim('"'));
            }
            catch
            {
                return -1;
            }
        }

        private string parseLocalDate(string s) 
        {
            parseInt(s.Substring(0, 2));
            if (s.Trim('"').Substring(2, 3) != "/")
                throw new Exception("Error parsing date - " + s);
            parseInt(s.Trim('"').Substring(3, 5));
            if (s.Substring(5, 6) != "/")
                throw new Exception("Error parsing date - " + s);
            parseInt(s.Trim('"').Substring(6));

            return s;
	    }

    }
}
