using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CharacterLib.Structures;

namespace CharacterLib
{
    public class Character
    {
        public StatProfile CharacterStat { get; set; }

        public StatProfile TotalIncreasesToStats { get; set; }

        private protected List<StatIncrease> statIncreases;

        public List<StatIncrease> StatIncrease
        {
            get { return statIncreases; }
        }
        public Character() : this(
            new StatProfile()
            {
                Name = "DefaultCharacter",
                Description = "This Character Object Has No Description Set",
                HealthCurrent = 100,
                HealthMax = 100,
                EnergyCurrent = 50,
                EnergyMax = 50,
                AttackPower = 10,
                CritChance = .1,
                CritMultiplier = 1.5,
                DodgeChance = .3,
                MovementRate = 5,
                Initiative = 10,
                AttackList = new List<AttackProfile>()
                    {
                        new AttackProfile()
                        {
                            Name = "Strike",
                            HitChance = .75,
                            BaseDamage = 5
                        }
                    },
                HealthPercentageGrowthPerLevel = .1,
                EnergyPercentageGrowthPerLevel = .1,
                AttackPowerPercentageGrowthPerLevel = .1,
                CritChancePercentageGrowthPerLevel = .01,
                CritMultiplierPercentageGrowthPerLevel = 0,
                DodgeChancePercentageGrowthPerLevel = .05,
                InitiativePercentageGrowthPerLevel = .1
            })
        {
            //no body
        }



        public Character(StatProfile baseProfileStats)
        {
            CharacterStat = baseProfileStats;
            statIncreases = new List<StatIncrease>();
            
        }

        public double GetTotalStat(string stat)
        {

            double baseValue;
            double increaseByValue;

            PropertyInfo baseProperty = this.CharacterStat.GetType().GetProperty(stat);
            PropertyInfo increaseProperty = this.statIncreases.GetType().GetProperty(stat);

            if (baseProperty is null || baseProperty.GetValue(CharacterStat) is null)
            {
                baseValue = 0;
            }
            else
            {
                baseValue = (double)baseProperty.GetValue(CharacterStat);
            }



            if (increaseProperty is null || increaseProperty.GetValue(TotalIncreasesToStats) == default)
            {
                increaseByValue = 0;
            }
            else
            {
               increaseByValue = (double)increaseProperty.GetValue(TotalIncreasesToStats);
            }
                
            return baseValue + increaseByValue;
            
            
        }

        public void TakeDamage(int damage)
        {
            CharacterStat.HealthCurrent -= damage;

            if (CharacterStat.HealthCurrent < 0)
            {
                CharacterStat.HealthCurrent = 0;
            }
        }

        public void HealDamage(int heal)
        {
            CharacterStat.HealthCurrent += heal;

            if (CharacterStat.HealthCurrent > CharacterStat.HealthMax)
            {
                CharacterStat.HealthCurrent = CharacterStat.HealthMax;
            }
        }


        public void SpendEnergy(int energySpent)
        {
            CharacterStat.EnergyCurrent -= energySpent;
            if (CharacterStat.EnergyCurrent < 0)
            {
                CharacterStat.EnergyCurrent = 0;
            }
        }
        public void RestoreEnergy(int energyReturned)
        {
            CharacterStat.EnergyCurrent += energyReturned;
            if (CharacterStat.EnergyCurrent > CharacterStat.EnergyMax)
            {
                CharacterStat.EnergyCurrent = CharacterStat.EnergyMax;
            }
        }
    }
}
