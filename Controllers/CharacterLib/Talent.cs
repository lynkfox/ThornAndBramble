using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class Talent
    {

        public string Name { get; set; }
        public int Cost { get; set; }

        public Talent() : this(5)
        {

        }
        public Talent(int cost) : this("DefaultTalent", cost)
        {
            
        }

        public Talent(string name, int cost)
        {
            Cost = cost;
            Name = name;
        }
    }
}
