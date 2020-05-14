using System;
using System.Collections.Generic;
using System.Text;
using CharacterLib.Structures;

namespace CharacterLib
{
    public class Talent
    {

        public TalentProfile Profile { get; set; }


        public Talent() : this(new TalentProfile())
        {

        }
        
        public Talent(TalentProfile profile)
        {
            this.Profile = profile;
        }
        public Talent(int[] costProgression) : this(new TalentProfile())
        {
            this.Profile.CostProgression = costProgression;
        }

        public Talent(string name, int[] cost) : this(new TalentProfile())
        {
            this.Profile.Name = name;
            this.Profile.CostProgression = cost;
        }

        public void LevelUp()
        {

            
            if(this.Profile.CurrentLevel < this.Profile.LevelCap)
            {
                this.Profile.CurrentLevel++;
                this.Profile.TotalCost += this.Profile.CostProgression[this.Profile.CurrentLevel - 1];
            }
            else
            {
                throw new TalentCannotLevelUpAboveLevelCap(this.Profile.Name + " has a max level of " + this.Profile.LevelCap);
            }
            
        }

        public void LevelDown()
        {
            this.Profile.CurrentLevel--;
            

            if (this.Profile.CurrentLevel <= 0)
            {
                this.Profile.CurrentLevel = 0;
                this.Profile.TotalCost = 0;
            }
            else
            {
                //Did you forget Arrays start at 0? xD
                this.Profile.TotalCost -= this.Profile.CostProgression[this.Profile.CurrentLevel]; 
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
                return this.Profile.CostProgression[level - 1];
            }
            
        }

        public List<StatIncrease> GetStatIncreaseForLevel(int level)
        {
            List<StatIncrease> statsToIncrease = new List<StatIncrease>();
            foreach(var item in Profile.StatIncreases)
            {
                StatIncrease individualIncrease = new StatIncrease();
                individualIncrease.Source = this;
                individualIncrease.SourceName = this.Profile.Name + "-lvl-"+level;
                individualIncrease.StatIncreased = item.Key;
                individualIncrease.IncreasedBy = item.Value[level - 1];

                statsToIncrease.Add(individualIncrease);
            }

            return statsToIncrease;
        }
    }
}
