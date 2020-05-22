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

        public static List<Monster> ReadMonster()
        {
            List<Monster> monsters = new List<Monster>();
            string path = Path.Combine(Environment.CurrentDirectory, "Data", "Monsters.xml");
            if (File.Exists(path))
            {

                
                var allProfiles = XElement.Load(path).Elements("MonsterProfile");
                foreach (XElement monsterProfileNode in allProfiles)
                {
                    var statsNode = monsterProfileNode.Element("StartingStats");
                    var levelUpNode = monsterProfileNode.Element("LevelUpStats");
                    var offensiveSkills = monsterProfileNode.Element("OffensiveSkills").Elements();
                    
                    StatProfile profileToAdd = new StatProfile()
                    {
                        Name = monsterProfileNode.Attribute("Name").Value,
                        Description = monsterProfileNode.Attribute("Description").Value,
                        //LowLevel = monsterProfileNode.Attribute("LowestLevel").Value,
                        //HighLevel = monsterProfileNode.Attribute("HighestLevel").Value,
                        HealthCurrent = double.Parse(statsNode.Attribute("Health").Value),
                        HealthMax = double.Parse(statsNode.Attribute("Health").Value),
                        EnergyCurrent = double.Parse(statsNode.Attribute("Energy").Value),
                        EnergyMax = double.Parse(statsNode.Attribute("Energy").Value),
                        AttackPower = double.Parse(statsNode.Attribute("Attack").Value),
                        BaseToHitBonus = double.Parse(statsNode.Attribute("BaseHit").Value),
                        CritChance = double.Parse(statsNode.Attribute("CritChance").Value),
                        CritMultiplier = double.Parse(statsNode.Attribute("CritMult").Value),
                        DodgeChance = double.Parse(statsNode.Attribute("Dodge").Value),
                        MovementRate = double.Parse(statsNode.Attribute("Movement").Value),
                        Initiative = double.Parse(statsNode.Attribute("Init").Value),
                        ActionsPerTurn = double.Parse(statsNode.Attribute("Actions").Value),

                        HealthPercentageGrowthPerLevel = double.Parse(levelUpNode.Attribute("Health").Value),
                        EnergyPercentageGrowthPerLevel = double.Parse(levelUpNode.Attribute("Energy").Value),
                        AttackPowerPercentageGrowthPerLevel= double.Parse(levelUpNode.Attribute("Attack").Value),
                        //BaseHitChanceGrowthPerLevel = double.Parse(levelUpNode.Attribute("BaseHit").Value),
                        CritChancePercentageGrowthPerLevel = double.Parse(levelUpNode.Attribute("CritChance").Value),
                        CritMultiplierPercentageGrowthPerLevel = double.Parse(levelUpNode.Attribute("CritMult").Value),
                        DodgeChancePercentageGrowthPerLevel = double.Parse(levelUpNode.Attribute("Dodge").Value),
                        InitiativePercentageGrowthPerLevel = double.Parse(levelUpNode.Attribute("Init").Value),
                        //Actions?
                        //Movement?

                        OffensiveSkills = offensiveSkills.
                        Select(x => new AttackProfile()
                        {
                            Name = x.Attribute("Name").Value,
                            BaseDamage = int.Parse(x.Attribute("Damage").Value),
                            HitChance = double.Parse(x.Attribute("Hit").Value)
                        }).ToList()
                    };
                 
                    

                    monsters.Add(new Monster(profileToAdd, int.Parse(monsterProfileNode.Attribute("LowestLevel").Value)));
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            return monsters;
        }

        /*
         * var serializer = new XmlSerializer<List<TalentProfile>>();
            string xmlString = "";

            xmlString = serializer.Serialize(talentsList);

            System.IO.File.WriteAllText(@"C:\Users\Public\talents.xml", xmlString);
            */
    }
}
