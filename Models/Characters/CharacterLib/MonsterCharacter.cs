using System;

namespace CharacterLib
{
    public class MonsterCharacter : CharacterBase
    {
        //Character Stats
        public int Level { get; set; }


        public MonsterCharacter() : this(new StatProfile(), 1)
        {

        }

        public MonsterCharacter(string monsterName, StatProfile statProfile, int startingLevel) : this(statProfile, 1)
        {
            this.CharacterStat.Name = monsterName;
        }

        public MonsterCharacter(StatProfile baseMonsterStats, int startingLevel) : base(baseMonsterStats)
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
