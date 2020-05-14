using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib.Structures
{
    public class StatProfile
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double HealthCurrent { get; set; }
        public double HealthMax { get; set; }
        public double EnergyCurrent { get; set; }
        public double EnergyMax { get; set; }

        //CombatStats

        public double AttackPower { get; set; }
        public double CritChance { get; set; }
        public double CritMultiplier { get; set; }
        public double DodgeChance { get; set; }
        public double MovementRate { get; set; }
        public double Initiative { get; set; }
        public List<AttackProfile> AttackList { get; set; }

        //Level Gain Values

        public double HealthPercentageGrowthPerLevel { get; set; }
        public double EnergyPercentageGrowthPerLevel { get; set; }
        public double AttackPowerPercentageGrowthPerLevel { get; set; }
        public double CritChancePercentageGrowthPerLevel { get; set; }
        public double CritMultiplierPercentageGrowthPerLevel { get; set; }
        public double DodgeChancePercentageGrowthPerLevel { get; set; }
        public double InitiativePercentageGrowthPerLevel { get; set; }
    }
}
