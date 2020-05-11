using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class CharacterBase
    {
        //Character Stats
        public int HealthCurrent { get; set; }
        public int HealthMax { get; set; }
        public int EnergyCurrent { get; set; }
        public int EnergyMax { get; set; }

        //CombatStats

        public double AttackPower { get; set; }
        public double CritChance { get; set; }
        public double CritMultiplier { get; set; }
        public double DodgeChance { get; set; }
        public int MovementRate { get; set; }
        public int Initiative { get; set; }
        public List<AttackProfile> AttackList { get; set; } = new List<AttackProfile>();

        public CharacterBase()
        {
            AttackList.Add(new AttackProfile());
            this.HealthCurrent = 100;
            this.HealthMax = 100;
            this.EnergyCurrent = 50;
            this.EnergyMax = 50;

        }

        public void TakeDamage(int damage)
        {
            this.HealthCurrent -= damage;

            if (this.HealthCurrent < 0)
            {
                this.HealthCurrent = 0;
            }
        }

        public void HealDamage(int heal)
        {
            this.HealthCurrent += heal;

            if (this.HealthCurrent > this.HealthMax)
            {
                this.HealthCurrent = this.HealthMax;
            }
        }


        public void SpendEnergy(int energySpent)
        {
            this.EnergyCurrent -= energySpent;
            if (this.EnergyCurrent < 0)
            {
                this.EnergyCurrent = 0;
            }
        }
        public void RestoreEnergy(int energyReturned)
        {
            this.EnergyCurrent += energyReturned;
            if (this.EnergyCurrent > EnergyMax)
            {
                this.EnergyCurrent = EnergyMax;
            }
        }
    }
}
