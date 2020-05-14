using System;
using CharacterLib.Structures;

namespace CharacterLib
{
    public class Monster : Character
    {
        //Character Stats
        public int Level { get; set; }


        public Monster() : base()
        {
            Level = 1;
        }

        public Monster(string monsterName, StatProfile statProfile, int startingLevel) : this(statProfile, startingLevel)
        {
            this.CharacterStat.Name = monsterName;
        }

        public Monster(StatProfile baseMonsterStats, int startingLevel) : base(baseMonsterStats)
        {
            this.Level = startingLevel;
            this.IncreaseLevel(startingLevel-1);
            
        }

        



        public void IncreaseLevel(int increaseLevelBy)
        {
            AdjustStatProfileByLevel(increaseLevelBy);
        }

        private void AdjustStatProfileByLevel(int increaseLevelBy)
        {
            for (int i=0; i < increaseLevelBy; i++)
            {
                CharacterStat.HealthMax += (int)Math.Floor(CharacterStat.HealthPercentageGrowthPerLevel * CharacterStat.HealthMax);
                CharacterStat.EnergyMax += (int)Math.Floor(CharacterStat.EnergyPercentageGrowthPerLevel * CharacterStat.EnergyMax);
                CharacterStat.CritChance += CharacterStat.CritChancePercentageGrowthPerLevel * CharacterStat.CritChance;
                CharacterStat.CritMultiplier += CharacterStat.CritMultiplierPercentageGrowthPerLevel * CharacterStat.CritMultiplier;
                CharacterStat.AttackPower += CharacterStat.AttackPowerPercentageGrowthPerLevel * CharacterStat.AttackPower;
                CharacterStat.DodgeChance += CharacterStat.DodgeChancePercentageGrowthPerLevel * CharacterStat.DodgeChance;
                CharacterStat.Initiative += (int)Math.Floor(CharacterStat.InitiativePercentageGrowthPerLevel * CharacterStat.Initiative);
            }
            CharacterStat.HealthCurrent = CharacterStat.HealthMax;
            CharacterStat.EnergyCurrent = CharacterStat.EnergyMax;
        }

        
    }
}
