﻿using System;
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
        public List<Talent> Talents { get; set; } = new List<Talent>();


        private List<Talent> ApprovedTalents=null;


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
            else if(newTalent.Cost <= this.Money)
            {
                InvestMoney(newTalent.Cost);

                AddNewTalentOrIncreaseLevelOfExistingTalent(newTalent);
                
            }
            else
            {
                throw new NotEnoughMoneyToInvest(newTalent.Name + " costs " + newTalent.Cost);
            }
            
        }

        private void AddNewTalentOrIncreaseLevelOfExistingTalent(Talent newTalent)
        {

            if (Talents.Contains(newTalent))
            {
                Talents.Where(x => x == newTalent).First().Level++;
            }else
            {
                Talents.Add(newTalent);
            }
        }

        public int NumberOfTalents()
        {
            return Talents.Count;
        }

        public int TalentLevel(string talentName)
        {
            Talent specificTalent = Talents.Where(x => x.Name == talentName).First();

            return specificTalent.Level;
        }

        public void SetupTalents(List<Talent> possibleTalents)
        {
            ApprovedTalents = possibleTalents;
        }
    }
}