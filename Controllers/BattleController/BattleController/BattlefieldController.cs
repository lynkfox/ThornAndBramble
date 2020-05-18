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
        
        private Random random = new Random();


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

        public void AdvanceTurn()
        {
            initiativeOrder.Pop();
            if(initiativeOrder.Count == 0)
            {
                NewRound();
            }else if(deadCharacters.Contains(NextToAct()))
            {
                AdvanceTurn();

            } else
            {
                CurrentInitiative = (int)NextToAct().CharacterStat.Initiative;
            }
            
        }


        /* Combat Methods
         * 
         * Including attacks, buffs, debufs, heals
         * 
         */

        public bool Attack(string attacker, string skill, string defender)
        {
           double toHit = CalculateAttackChance(attacker, skill, defender);

            double dieRoll = Rolld100();

            if(dieRoll < toHit)
            {
                int totalAttackDamage = CalculateTotalDamage(attacker, skill);
                SuccessfulAttackDamage(defender, totalAttackDamage);
                return true;
            }
            else
            {
                //fail
                return false;
            }
        }

        public int CalculateTotalDamage(string attacker, string skill)
        {
            return AttackDamage(attacker, skill) + (int)this.CharacterStat(attacker, "AttackPower");
        }

        public double Rolld100()
        {
            return random.NextDouble();
        }

        //Overload for easier to read implimentation
        public double CalculateAttackChance(string attacker, string skill, string defender)
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

        public int AttackDamage(string characterName, string attackName)
        {
            return Participant(characterName).AttackDamage(attackName);
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

                deadCharacters.Add(attackedCharacter);
            }
        }

        
    }
}
