using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib.Structures
{
    public struct StatIncrease
    {
        public string StatIncreased { get; set; }
        public double IncreasedBy { get; set; }
        public object Source { get; set; }
    }
}
