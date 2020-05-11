using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class CharacterBase
    {
        public StatProfile CharacterStat { get; set; }

        public CharacterBase() : this(new StatProfile())
        {

        }
        public CharacterBase(StatProfile baseProfileStats)
        {
            CharacterStat = baseProfileStats;

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
