using System;
using System.Collections.Generic;
using CharacterLib;

namespace BattleController
{
    public class Battlefield
    {
        public int MonsterCount { get; set; }
        public int PlayerCount { get; set; }

        private List<MonsterCharacter> MonstersOnField = new List<MonsterCharacter>();
        private List<PlayerCharacter> PlayersOnField = new List<PlayerCharacter>();
        public void SpawnMonster(MonsterCharacter genericMonster)
        {
            MonstersOnField.Add(genericMonster);
            MonsterCount = MonstersOnField.Count;
        }

        public void SpawnPlayer(PlayerCharacter playerCharacter)
        {
            PlayersOnField.Add(playerCharacter);
            PlayerCount = PlayersOnField.Count;
        }

        public double CalculateAttackChance(AttackProfile attack, double dodgeChance)
        {
            return attack.HitChance - dodgeChance;
        }
    }
}
