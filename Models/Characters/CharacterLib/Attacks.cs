using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class AttackProfile
    {
        public string Name { get; set; }
        public double HitChance { get; set; }
        public int BaseDamage { get; set; }

        public AttackProfile() : this("Strike", .75, 5)
        {

        }
        public AttackProfile(string name, double hitChance, int baseDmg)
        {
            Name = name;
            HitChance = hitChance;
            BaseDamage = baseDmg;
        }
    }
}
