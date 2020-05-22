using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CharacterLib.Structures;
using System.Linq;

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
                BaseToHitBonus = 0,
                MovementRate = 5,
                ActionsPerTurn = 2,
                ActionsUsed = 0,
                Initiative = 10,
                OffensiveSkills = new List<AttackProfile>()
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
            TotalIncreasesToStats = new StatProfile();
            statIncreases = new List<StatIncrease>();
            
        }

        public double StatsTotalWithBonuses(string stat)
        {

            double baseValue;
            double increaseByValue;

            PropertyInfo propertyToCheck = this.CharacterStat.GetType().GetProperty(stat);

            if (propertyToCheck is null || propertyToCheck.GetValue(CharacterStat) is null)
            {
                baseValue = 0;
            }
            else
            {
                baseValue = (double)propertyToCheck.GetValue(CharacterStat);
            }

            if (propertyToCheck is null || propertyToCheck.GetValue(TotalIncreasesToStats) == default)
            {
                increaseByValue = 0;
            }
            else
            {
               increaseByValue = (double)propertyToCheck.GetValue(TotalIncreasesToStats);
            }
            return baseValue + increaseByValue;
            
        }

        /* MVC says that this model should have no idea about how turns work.
         * 
         * So this method has no idea when it should be called, it just "Readies" a character.
         * 
         * Eventually will be used to set once per turn attacks back to viable, or do automatic begining of turn 
         * (like gain an extra action point)
         * 
         */
        public void ReadyCharacter()
        {
            this.CharacterStat.ActionsUsed = 0;
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

        public void UseAction()
        {
            if(this.CharacterStat.ActionsUsed < this.CharacterStat.ActionsPerTurn)
            {
                this.CharacterStat.ActionsUsed++;
            } else
            {
                throw new CharacterDoesNotHaveEnoughActionPoint("Already Used" + this.CharacterStat.ActionsUsed + " of " + this.CharacterStat.ActionsPerTurn + " Action Points.");
            }
            
        }

        public int AttackDamage(string nameOfAttack)
        {
            return this.CharacterStat.OffensiveSkills.Where(x => x.Name == nameOfAttack).First().BaseDamage;
        }

        public double SkillToHitChance(string nameOfAttack)
        {
            return this.CharacterStat.OffensiveSkills.Where(x => x.Name == nameOfAttack).First().HitChance;
        }

        public double SkillBaseDamage(string nameOfAttack)
        {
            return this.CharacterStat.OffensiveSkills.Where(x => x.Name == nameOfAttack).First().BaseDamage;
        }
    }

}
