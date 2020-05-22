using System;
using CharacterLib;

namespace ActorControllers
{
    public class CharacterController

    {
        public Character Actor { get; set; } = new Character();

        public double Stat(string statName)
        {
            return this.Actor.StatsTotalWithBonuses(statName);
        }
    }
}
