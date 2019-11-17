using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterLib
{
    public class PlayerCharacter : CharacterBase
    {
        /* Money is in reference, as of this comment (11/16/19) to refer to Chroma, which is used to both buy
         * items and to invest in Talents
         */

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
