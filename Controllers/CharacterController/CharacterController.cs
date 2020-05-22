using System;
using CharacterLib;

namespace ActorControllers
{
    public class CharacterController

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Character Actor { get; set; } = new Character();

        public CharacterController()
        {
            this.Name = Actor.CharacterStat.Name;
            this.Description = Actor.CharacterStat.Description;
        }
        public double Stat(string statName)
        {
            return this.Actor.StatsTotalWithBonuses(statName);
        }

        public double SkillToHitChance(string attackName)
        {
            return Actor.SkillToHitChance(attackName);
        }

        public int AttackDamage(string attackName)
        {
            return Actor.AttackDamage(attackName);
        }

        public void TakeDamage(int damageTaken)
        {
            this.Actor.TakeDamage(damageTaken);
        }
    }
}
