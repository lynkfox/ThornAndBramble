using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class PlayerCharacter : CharacterBase
    {
        public int Money { get; set; } = 0;

        public void SpendMoney(int moneySpent)
        {
            this.Money = 10;
        }
    }
}
