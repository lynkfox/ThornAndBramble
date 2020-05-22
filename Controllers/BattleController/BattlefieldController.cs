using System;
using System.Collections.Generic;
using ActorControllers;
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

        private List<CharacterController> deadCharacters = new List<CharacterController>();

        public List<CharacterController> DeadCharacters
        {
            get { return deadCharacters; }
        }


        private Stack<CharacterController> initiativeOrder;

        public Stack<CharacterController> InitiativeOrder
        {
            get { return initiativeOrder; }
        }

        private List<CharacterController> CharactersOnField = new List<CharacterController>();
        
        private Random random = new Random();


        /*Setup Methods.
         * 
         * Setup the field with these methods. 
         * 
         */
        public void SpawnMonster(ref MonsterController monsterCharacter)
        {
            CharactersOnField.Add(monsterCharacter);
            MonsterCount++;
        }

        public void SpawnPlayer(ref PlayerController playerCharacter)
        {
            CharactersOnField.Add(playerCharacter);
            PlayerCount++;
        }

       

        /* Information Methods
         * 
         * These methods get the various stat information from characters on the field.
         * 
         * For this reason Character.CharacterStat.Name Must Be Unique, though DisplayName can be duplicate.
         * 
         */


        private CharacterController Participant(string characterName)
        {
            return CharactersOnField.Where(x => x.Name == characterName).First();
        }

        public int HealthOf(string characterName)
        {
            return (int)Participant(characterName).Stat("HealthCurrent");
        }


        public double CharacterStat(string characterName, string statName)
        {
            return Participant(characterName).Stat(statName);
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
            var initiativeFromHighToLow = CharactersOnField.OrderBy(x => x.Stat("Initiative")).ToList();

            initiativeOrder = new Stack<CharacterController>(initiativeFromHighToLow);
        }

        public CharacterController NextToAct()
        {

            return initiativeOrder.Peek();
        }

        //Will eventually contain other Begining Of Turn commands.
        public void NewRound()
        {
            AssignInitiativeOrder();
            CurrentInitiative = (int)NextToAct().Stat("Initiative");
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
                CurrentInitiative = (int)NextToAct().Stat("Initiative");
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
            return Math.Round(random.NextDouble(),2);
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
            CharacterController attackedCharacter = Participant(characterName);
            attackedCharacter.TakeDamage(damageTaken);


            if(HealthOf(characterName) == 0 )
            {
                if(attackedCharacter.GetType() == typeof(PlayerController))
                {
                    PlayerCount--;
                }
                else if (attackedCharacter.GetType() == typeof(MonsterController))
                {
                    MonsterCount--;
                }

                deadCharacters.Add(attackedCharacter);
            }
        }

        
    }
}
