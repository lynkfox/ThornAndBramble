using System;
using System.Collections.Generic;
using System.Text;
using CharacterLib.Profiles;

namespace CharacterLib
{
    public class Talent
    {

        public string Name { get; set; }
        public int TotalCost { get; set; }
        public int CurrentLevel { get; set; }
        public int LevelCap { get; set; }
        public int[] UpgradeCostProgression { get; set; }
        public string Description { get; set; }


        public Talent() : this(new TalentProfile())
        {

        }
        
        public Talent(TalentProfile profile)
        {
            this.Name = profile.Name;
            this.TotalCost = 0;
            this.CurrentLevel = 0;
            this.LevelCap = profile.LevelCap;
            this.UpgradeCostProgression = profile.CostProgression;
            this.Description = profile.Description;
        }
        public Talent(int[] costProgression) : this(new TalentProfile())
        {
            this.UpgradeCostProgression = costProgression;
        }

        public Talent(string name, int[] cost) : this(new TalentProfile())
        {
            Name = name;
            UpgradeCostProgression = cost;
        }

        public void LevelUp()
        {
            
            this.CurrentLevel++;
            TotalCost += UpgradeCostProgression[CurrentLevel-1];
        }

        public void LevelDown()
        {
            this.CurrentLevel--;
            

            if (this.CurrentLevel <= 0)
            {
                this.CurrentLevel = 0;
                this.TotalCost = 0;
            }
            else
            {
                //Did you forget Arrays start at 0? xD
                TotalCost -= UpgradeCostProgression[CurrentLevel]; 
            }
        }

        public int CostsAtLevel(int level)
        {
            if (level == 0)
            {
                throw new TalentDoesNotHaveACostAtLevelZero();
            }
            else
            {
                return UpgradeCostProgression[level - 1];
            }
            
        }
    }
}
