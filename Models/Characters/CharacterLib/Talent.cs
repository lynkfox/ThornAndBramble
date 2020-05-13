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

        
        public Talent() : this(new int[]{5,10,15,20,25})
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
        public Talent(int[] cost) : this("DefaultTalent", cost)
        {
            Description = "This is a Default Talent";
        }

        public Talent(string name, int[] cost)
        {
            TotalCost = 0;
            Name = name;
            CurrentLevel = 0;
            LevelCap = 5;
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
