using System;

namespace CharacterLib
{
    public class Character
    {
        //Character Stats
        public int Level { get; set; }
        public int HealthCurrent { get; set; }
        public int HealthMax { get; set; }


        private const double HEALTHgainPERlevel  = .1;
        private const int STARTINGhealth = 100;


        public Character() : this(1)
        {
            
        }

        public Character(int startingLevel)
        {
            this.HealthCurrent = STARTINGhealth;
            this.HealthMax = STARTINGhealth;
            this.Level = startingLevel;
            this.IncreaseLevel(startingLevel-1);
            
        }

        public void TakeDamage(int damage)
        {
            this.HealthCurrent -= damage;

            if(this.HealthCurrent <0)
            {
                this.HealthCurrent = 0;
            }
        }

        public void HealDamage(int heal)
        {
            this.HealthCurrent += heal;

            if(this.HealthCurrent > this.HealthMax)
            {
                this.HealthCurrent = this.HealthMax;
            }
        }

        public void IncreaseLevel(int increaseLevelBy)
        {
            double increaseMaxHealth = HEALTHgainPERlevel * increaseLevelBy * this.HealthCurrent;
            this.HealthMax += (int)increaseMaxHealth;
            this.HealthCurrent = this.HealthMax;
        }
    }
}
