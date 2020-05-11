using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class StatProfile
    {


        //Default Level Gain Values


        public int HealthCurrent { get; set; } = 100;
        public int HealthMax { get; set; } = 100;
        public int EnergyCurrent { get; set; } = 50;
        public int EnergyMax { get; set; } = 50;

        //CombatStats

        public double AttackPower { get; set; } = 10;
        public double CritChance { get; set; } = .1;
        public double CritMultiplier { get; set; } = 1.5;
        public double DodgeChance { get; set; } = .3;
        public int MovementRate { get; set; } = 5;
        public int Initiative { get; set; } = 10;
        public List<AttackProfile> AttackList { get; set; } = new List<AttackProfile>() { new AttackProfile() };

        //Level Gain Values

        public double HealthPercentageGrowthPerLevel { get; set; } = .1;
        public double EnergyPercentageGrowthPerLevel { get; set; } = .1;
        public double AttackPowerPercentageGrowthPerLevel { get; set; } = .1;
        public double CritChancePercentageGrowthPerLevel { get; set; } = .01;
        public double CritMultiplierPercentageGrowthPerLevel { get; set; } = 0;
        public double DodgeChancePercentageGrowthPerLevel { get; set; } = .05;
        public double InitiativePercentageGrowthPerLevel { get; set; } = .1;
    }
}
