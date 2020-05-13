using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib.Profiles
{
    public class TalentProfile
    {
        public string Name { get; set; } = "GenericTalent";
        public string Description { get; set; } = "This Talent does not have a proper entry.";
        public int CurrentLevel { get; set; } = 0;
        public int LevelCap { get; set; } = 5;
        public int TotalCost { get; set; } = 0;
        public int[] CostProgression { get; set; } = new int[] { 5, 10, 15, 20, 25 };
        public Dictionary<string, double> StatIncreases { get; set; } = new Dictionary<string, double>
        {
            {"health", 5  },
            {"energy", 5 }
        };

    }
}
