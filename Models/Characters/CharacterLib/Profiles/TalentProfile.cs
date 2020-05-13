using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib.Profiles
{
    public class TalentProfile
    {
        public string Name { get; set; } = "GenericTalent";
        public string Description { get; set; } = "This Talent does not have a Description set.";
        public int CurrentLevel { get; set; } = 1;
        public int LevelCap { get; set; } = 5;
        public int TotalCost { get; set; } = 0;
        public int[] CostProgression { get; set; } = new int[] { 5, 10, 15, 20, 25 };


    }
}
