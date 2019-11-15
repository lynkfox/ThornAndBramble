using System;

namespace CharacterLib
{
    public class Character
    {
        //Character Stats
        public int Level { get; set; }
        public int HealthCurrent { get; set; }



        public Character() : this(1)
        {
            
        }
        public Character(int startingLevel)
        {
            this.HealthCurrent = 100;
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
        }

        public void IncreaseLevel(int increaseLevelBy)
        {
            double increaseMaxHealth = .1 * increaseLevelBy * this.HealthCurrent;
            this.HealthCurrent += (int)increaseMaxHealth;
        }
    }
}
