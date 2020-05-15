using CharacterLib.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XSerializer;

namespace CharacterLib
{
    public static class ProfileReader
    {
        public static List<Talent> ReadTalent()
        {
            List<Talent> talents = new List<Talent>();
            string path = Path.Combine(Environment.CurrentDirectory,"Data", "Talents.xml");
            if (File.Exists(path))
            {

                StringBuilder result = new StringBuilder();
                var allProfiles = XElement.Load(path).Elements("TalentProfile");
                foreach (XElement talentProfileNode in allProfiles)
                {
                    TalentProfile profileToAdd = new TalentProfile();

                    profileToAdd.Name = talentProfileNode.Attribute("Name").Value;
                    profileToAdd.Description = talentProfileNode.Attribute("Description").Value;
                    profileToAdd.LevelCap = int.Parse(talentProfileNode.Attribute("LevelCap").Value);
                    profileToAdd.TotalCost = 0;
                    profileToAdd.CurrentLevel = 0;

                    //Error Handlingneeded if Cost Progression and Level Cap are not the same
                    profileToAdd.CostProgression = talentProfileNode.Element("CostProgression").Attributes().Select(x=>int.Parse(x.Value)).ToArray();

                    //Error handling needed if stat boosts per level and level cap are not the same

                    var statIncreasesToAddToDictionary = talentProfileNode.Element("StatIncreases").Elements();

                    profileToAdd.StatIncreases = statIncreasesToAddToDictionary
                        .ToDictionary(x => x.Attribute("Stat").Value, 
                                      y => y.Attributes()
                                            .Where(x => x.Name.ToString() != "Stat")
                                            .Select(z =>double.Parse(z.Value))
                                            .ToArray());

                    


                    talents.Add(new Talent(profileToAdd));
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            return talents;
        }

        /*
         * var serializer = new XmlSerializer<List<TalentProfile>>();
            string xmlString = "";

            xmlString = serializer.Serialize(talentsList);

            System.IO.File.WriteAllText(@"C:\Users\Public\talents.xml", xmlString);
            */
    }
}
