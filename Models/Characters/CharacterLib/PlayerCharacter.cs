using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CharacterLib.Structures;

namespace CharacterLib
{
    public class Player : Character
    {
        /* Money is in reference to Chroma, which is used to both buy
         * items and to invest in Talents, as well as invest in combining weapon parts and character parts.
         */

        public int Money { get; set; } = 0;
        public int InvestedMoney { get; set; } = 0;


        public List<Talent> InvestedTalents { get; set; } = new List<Talent>();
        
        private List<Talent> ApprovedTalents=null;



        public Player() : base()
        {

        }

        public Player(string characterName) : this()
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

        public void AddTalent(Talent potentialTalent)
        {
            Talent playersTalent; 

            if(!ApprovedTalents.Contains(potentialTalent))
            {
                throw new PlayerDoesNotHaveTalent(potentialTalent.Profile.Name + " is not an approved talent for " + this.CharacterStat.Name);
            }
            else if(PlayerAlreadyHaveTalent(potentialTalent))
            {
                playersTalent = InvestedTalents.Where(x => x.Profile.Name == potentialTalent.Profile.Name).First();

            }
            else
            {
                playersTalent = potentialTalent;
            }


            if(PlayerCanAffordCost(playersTalent.CostsAtLevel(playersTalent.Profile.CurrentLevel +1)))
            {
                AddNewTalentOrIncreaseLevelOfExistingTalent(potentialTalent);
            }
            else
            {
                throw new NotEnoughMoneyToInvest(potentialTalent.Profile.Name + " costs " + potentialTalent.CostsAtLevel(playersTalent.Profile.CurrentLevel +1));
            }
            
        }

        private bool PlayerAlreadyHaveTalent(Talent potentialTalent)
        {
            return InvestedTalents.Contains(potentialTalent);
        }
        private bool PlayerCanAffordCost(int cost)
        {
            return cost <= this.Money;
        }

        private void AddNewTalentOrIncreaseLevelOfExistingTalent(Talent newTalent)
        {

            if (!InvestedTalents.Contains(newTalent))
            {
                InvestedTalents.Add(newTalent);
            }


            
            var nowInvestedTalent = InvestedTalents.Where(x => x.Profile.Name == newTalent.Profile.Name).First();
            nowInvestedTalent.LevelUp();

            foreach(var increase in nowInvestedTalent.GetStatIncreaseFor(nowInvestedTalent.Profile.CurrentLevel))
            {
                AddStatIncreaseToCharacterAndRecords(increase);
            }

            InvestMoney(newTalent.CostsAtLevel(newTalent.Profile.CurrentLevel));

            
        }

        private void AddStatIncreaseToCharacterAndRecords(StatIncrease increase)
        {
            statIncreases.Add(increase);

            try
            {
                PropertyInfo stat = TotalIncreasesToStats.GetType().GetProperty(increase.StatIncreased);
                stat.SetValue(TotalIncreasesToStats, increase.IncreasedBy, null);
            }
            catch (NullReferenceException e)
            {
                //Error Handling for StatNotFound
            }
            
            
            throw new NotImplementedException();
        }

        public int NumberOfTalents()
        {
            return InvestedTalents.Count;
        }

        public int TalentLevel(string talentName)
        {
            Talent specificTalent = InvestedTalents.Where(x => x.Profile.Name == talentName).First();

            return specificTalent.Profile.CurrentLevel;
        }

        public void SetupTalents(List<Talent> possibleTalents)
        {
            ApprovedTalents = possibleTalents;
        }

        public List<Talent> CheckInvestedTalents()
        {
            return InvestedTalents;
        }

        public void RemoveTalent(Talent talentToRemove)
        {
            if(PlayerAlreadyHaveTalent(talentToRemove))
            {
                var playersTalent = InvestedTalents.Where(x => x.Profile.Name == talentToRemove.Profile.Name).First();

                InvestMoney(-playersTalent.CostsAtLevel(playersTalent.Profile.CurrentLevel));
                playersTalent.LevelDown();
            }
            else
            {
                throw new PlayerDoesNotHaveTalent();
            }
            

        }
    }
}
