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

        private Stack<Character> initiativeOrder;

        public Stack<Character> InitiativeOrder
        {
            get { return initiativeOrder; }
        }

        private List<Character> CharactersOnField = new List<Character>();
        
        public void SpawnMonster(Monster genericMonster)
        {
            CharactersOnField.Add(genericMonster);
            MonsterCount++;
        }

        public void SpawnPlayer(Player playerCharacter)
        {
            CharactersOnField.Add(playerCharacter);
            PlayerCount++;
        }

        public double CalculateAttackChance(AttackProfile attack, double dodgeChance)
        {
            return attack.HitChance - dodgeChance;
        }

        public Character NextToAct()
        {
            
            return initiativeOrder.Peek();
        }

        public void AssignInitiativeOrder()
        {
            var initiativeFromHighToLow = CharactersOnField.OrderBy(x => x.CharacterStat.Initiative).ToList();

            initiativeOrder = new Stack<Character>(initiativeFromHighToLow);
        }

        public int HealthOf(string characterName)
        {
            return (int)Participant(characterName).CharacterStat.HealthCurrent;
        }

        public void SuccessfulAttackDamage(string characterName, int damageTaken)
        {
            Participant(characterName).TakeDamage(damageTaken);
        }



        private Character Participant(string characterName)
        {
            return CharactersOnField.Where(x => x.CharacterStat.Name == characterName).First();
        }
    }
}
