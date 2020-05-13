using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Talent> InvestedTalents { get; set; } = new List<Talent>();

        private List<Talent> ApprovedTalents=null;

        public PlayerCharacter() : base()
        {

        }

        public PlayerCharacter(string characterName) : this()
        {
            this.CharacterStat.Name = characterName;
        }

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

        public void AddTalent(Talent newTalent)
        {
            if(!ApprovedTalents.Contains(newTalent))
            {
                throw new PlayerDoesNotHaveTalent(newTalent.Name);
            }
            else if(newTalent.TotalCost <= this.Money)
            {
                InvestMoney(newTalent.TotalCost);

                AddNewTalentOrIncreaseLevelOfExistingTalent(newTalent);
                
            }
            else
            {
                throw new NotEnoughMoneyToInvest(newTalent.Name + " costs " + newTalent.TotalCost);
            }
            
        }

        private void AddNewTalentOrIncreaseLevelOfExistingTalent(Talent newTalent)
        {

            if (InvestedTalents.Contains(newTalent))
            {
                InvestedTalents.Where(x => x == newTalent).First().CurrentLevel++;
            }else
            {
                InvestedTalents.Add(newTalent);
            }
        }

        public int NumberOfTalents()
        {
            return InvestedTalents.Count;
        }

        public int TalentLevel(string talentName)
        {
            Talent specificTalent = InvestedTalents.Where(x => x.Name == talentName).First();

            return specificTalent.CurrentLevel;
        }

        public void SetupTalents(List<Talent> possibleTalents)
        {
            ApprovedTalents = possibleTalents;
        }

        public List<Talent> CheckInvestedTalents()
        {
            return InvestedTalents;
        }
    }
}
