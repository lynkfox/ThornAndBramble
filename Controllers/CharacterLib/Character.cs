using System;

namespace CharacterLib
{
    public class Character
    {
        //Character Stats
        public int Health { get; set; }


        public Character()
        {
            this.Health = 100;
        }


        public void TakeDamage(int damage)
        {
            this.Health -= damage;

            if(this.Health <0)
            {
                this.Health = 0;
            }
        }

    }
}
