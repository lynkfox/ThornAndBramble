using System;
using System.Collections.Generic;
using System.Text;
using CharacterLib;

namespace ActorControllers
{
    class PlayerController : CharacterController
    {
        public PlayerController()
        {
            this.Actor = new Player();
        }
    }
}
