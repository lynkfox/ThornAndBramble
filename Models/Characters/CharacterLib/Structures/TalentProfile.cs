using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib.Structures
{
    public class TalentProfile
    {
        public string Name { get; set; } = "GenericTalent";
        public string Description { get; set; } = "This Talent does not have a proper entry.";
        public int CurrentLevel { get; set; } = 0;
        public int LevelCap { get; set; } = 5;
        public int TotalCost { get; set; } = 0;
        public int[] CostProgression { get; set; } = new int[] { 5, 10, 15, 20, 25 };
        public Dictionary<string, double[]> StatIncreases { get; set; } = new Dictionary<string, double[]>
        {
            {"HealthMax", new double[]{5,5,5,5,5 }  },
            {"EnergyMax", new double[]{2,2,2,2,2 } }
        };

        /* The StatIncreases are stored as the name of the Stat (must be identical to the property in StatProfile
         * and an array of Doubles, where each level of the talent is a position in the array. Only the increase for
         * taking that level of the talent is in that position of the array!
         * 
         * so a 5 level talent that increases HealthMax by 5 for each level taken would be 5,5,5,5,5
         * 
         * a 3 level talent that increases Energy Max by 2 for the first level, 4 for the second, and none for the 3rd would be
         * 2,4,0
         */
    }
}
