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
