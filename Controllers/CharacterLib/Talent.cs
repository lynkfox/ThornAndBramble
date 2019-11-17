using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class Talent
    {
        

        public int Cost { get; set; }

        public Talent() : this(5)
        {

        }
        public Talent(int cost)
        {
            Cost = cost;
        }
    }
}
