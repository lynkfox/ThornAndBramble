using System;

namespace CharacterLib
{
    public class Character
    {
        public int Health { get; set; }
        public void TakeDamage(int damage)
        {
            this.Health = 99;
        }
    }
}
