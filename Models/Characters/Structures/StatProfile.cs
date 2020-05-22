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
        public double ActionsPerTurn { get; set; }
        public double ActionsUsed { get; set; }
        public double Initiative { get; set; }
        public double BaseToHitBonus { get; set; }
        public List<AttackProfile> OffensiveSkills { get; set; }

        //Level Gain Values
        /* These are all PERCENTAGE GROWTH - so each level gains .1 of the CURRENT value (resulting in a logmarithmic growth)
         */

        public double HealthPercentageGrowthPerLevel { get; set; }
        public double EnergyPercentageGrowthPerLevel { get; set; }
        public double AttackPowerPercentageGrowthPerLevel { get; set; }
        public double CritChancePercentageGrowthPerLevel { get; set; }
        public double CritMultiplierPercentageGrowthPerLevel { get; set; }
        public double DodgeChancePercentageGrowthPerLevel { get; set; }
        public double InitiativePercentageGrowthPerLevel { get; set; }
        public double BaseHitChanceGrowthPerLevel { get; set; }
    }
}
