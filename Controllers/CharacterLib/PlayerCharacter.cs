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
            this.Money -= moneySpent;
            if (this.Money < 0)
            {
                this.Money = 0;
            }
        }

        public void EarnMoney(int moneyEarned)
        {
            this.Money += moneyEarned;
        }

        public void InvestMoney(int moneyInvested)
        {
            this.Money -= moneyInvested;
            this.InvestedMoney += moneyInvested;
        }
    }
}
