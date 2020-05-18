using System;
using System.Collections.Generic;
using CharacterLib;
using CharacterLib.Structures;
using System.Linq;

namespace BattleController
{
    public class Battlefield
    {
        public int MonsterCount { get; set; }
        public int PlayerCount { get; set; }
        public int CurrentInitiative { get; set; }

        private List<Character> deadCharacters = new List<Character>();

        public List<Character> DeadCharacters
        {
            get { return deadCharacters; }
        }


        private Stack<Character> initiativeOrder;

        public Stack<Character> InitiativeOrder
        {
            get { return initiativeOrder; }
        }

        private List<Character> CharactersOnField = new List<Character>();
        



        /*Setup Methods.
         * 
         * Setup the field with these methods. 
         * 
         */
        public void SpawnMonster(Monster genericMonster)
        {
            SpawnCharacter(genericMonster);
            MonsterCount++;
        }

        public void SpawnPlayer(Player playerCharacter)
        {
            SpawnCharacter(playerCharacter);
            PlayerCount++;
        }

        private void SpawnCharacter(Character genericCharacter)
        {
            CharactersOnField.Add(genericCharacter);
        }

        /* Information Methods
         * 
         * These methods get the various stat information from characters on the field.
         * 
         * For this reason Character.CharacterStat.Name Must Be Unique, though DisplayName can be duplicate.
         * 
         */


        private Character Participant(string characterName)
        {
            return CharactersOnField.Where(x => x.CharacterStat.Name == characterName).First();
        }

        public int HealthOf(string characterName)
        {
            return (int)Participant(characterName).CharacterStat.HealthCurrent;
        }


        public double CharacterStat(string characterName, string statName)
        {
            return Participant(characterName).StatsTotalWithBonuses(statName);
        }




        /* Turn Order/Round Methods
         * 
         * Initiative goes from Highest To Lowest - Higher goes first.
         * 
         * Each Round is all characters in CharactersOnField acting.
         * 
         * Each Turn is the next character in Initiative Order Acting.
         */

        public void AssignInitiativeOrder()
        {
            var initiativeFromHighToLow = CharactersOnField.OrderBy(x => x.CharacterStat.Initiative).ToList();

            initiativeOrder = new Stack<Character>(initiativeFromHighToLow);
        }

        public Character NextToAct()
        {

            return initiativeOrder.Peek();
        }

        //Will eventually contain other Begining Of Turn commands.
        public void NewRound()
        {
            AssignInitiativeOrder();
            CurrentInitiative = (int)NextToAct().CharacterStat.Initiative;
        }

        public void NextTurn()
        {
            initiativeOrder.Pop();
            if(initiativeOrder.Count == 0)
            {
                NewRound();
            }else
            {
                CurrentInitiative = (int)NextToAct().CharacterStat.Initiative;
            }
            
        }


        /* Combat Methods
         * 
         * Including attacks, buffs, debufs, heals
         * 
         */

        public double Attack(string attacker, string skill, string defender)
        {
            /*This is simplified but can be changed - if so don't forget to change the unit test values!
             * 
             * Currently Attacker.BaseToHit+Skill.HitChance - Defender.DodgeChance
             * 
             * Other ideas?
             */

            double attackerTotalHitChance = CharacterStat(attacker, "BaseToHit") + Participant(attacker).SkillToHitChance("Strike");
            double defenderDodgeChance = CharacterStat(defender, "DodgeChance");

            return CalculateAttackChance(attackerTotalHitChance, defenderDodgeChance);
        }

        private double CalculateAttackChance(double hitChance, double dodgeChance)
        {
            return hitChance - dodgeChance;
        }

        public void SuccessfulAttackDamage(string characterName, int damageTaken)
        {
            Character attackedCharacter = Participant(characterName);
            attackedCharacter.TakeDamage(damageTaken);


            if(HealthOf(characterName) == 0 )
            {
                if(attackedCharacter.GetType() == typeof(Player))
                {
                    PlayerCount--;
                }
                else if (attackedCharacter.GetType() == typeof(Monster))
                {
                    MonsterCount--;
                }
                CharactersOnField.Remove(attackedCharacter);
                deadCharacters.Add(attackedCharacter);
            }
        }




        

        
    }
}
