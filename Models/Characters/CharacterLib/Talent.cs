using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class Talent
    {

        public string Name { get; set; }
        public int Cost { get; set; }
        public int Level { get; set; }
        public int LevelCap { get; set; }
        public int[] UpgradeCostProgression { get; set; }
        public string Description { get; set; }

        public Talent() : this(5)
        {

        }
        public Talent(int cost) : this("DefaultTalent", cost)
        {
            Description = "This is a Default Talent";
        }

        public Talent(string name, int cost)
        {
            Cost = cost;
            Name = name;
            Level = 1;
            LevelCap = 5;
            UpgradeCostProgression = new int[]{ 5, 10, 15, 20, 25};
        }

        public void LevelUp()
        {
            this.Level++;
        }

        public void LevelDown()
        {
            this.Level--;

            if(this.Level < 0)
            {
                this.Level = 0;
            }
        }
    }
}
