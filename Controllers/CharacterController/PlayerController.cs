using System;
using System.Collections.Generic;
using System.Text;
using CharacterLib;

namespace CharacterController
{
    class PlayerController : CharacterController
    {
        public PlayerController()
        {
            this.Actor = new Player();
        }
    }
}
