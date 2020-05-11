using System;
using System.Collections.Generic;
using CharacterLib;

namespace BattleController
{
    public class Battlefield
    {
        public int MonsterCount { get; set; }

        private List<MonsterCharacter> MonstersOnField = new List<MonsterCharacter>();
        public void SpawnMonster(MonsterCharacter genericMonster)
        {
            MonstersOnField.Add(genericMonster);
            MonsterCount = MonstersOnField.Count;
        }
    }
}
