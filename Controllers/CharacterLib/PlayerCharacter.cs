using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class PlayerCharacter : CharacterBase
    {
        public int Money { get; set; } = 0;
        public int InvestedMoney { get; set; } = 0;

        public void SpendMoney(int moneySpent)
        {
            
            if (this.Money >= moneySpent)
            {
                this.Money -= moneySpent;
            }
        }

        public void EarnMoney(int moneyEarned)
        {
            this.Money += moneyEarned;
        }

        public void InvestMoney(int moneyInvested)
        {
            if(moneyInvested <= this.Money)
            {
                this.Money -= moneyInvested;
                this.InvestedMoney += moneyInvested;
            }
            
        }
    }
}
