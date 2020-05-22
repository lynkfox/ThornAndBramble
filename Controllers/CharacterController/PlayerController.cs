using System;
using System.Collections.Generic;
using System.Text;
using CharacterLib;

namespace ActorControllers
{
    public class PlayerController : CharacterController
    {
        public PlayerController()
        {
            this.Actor = new Player();
        }

        public PlayerController(string name) : this()
        {
            this.Name = name;
            this.Actor.CharacterStat.Name = name;
        }
    }
}
