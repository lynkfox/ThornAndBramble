using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleController;
using CharacterLib;

namespace BattleControllerUnitTests
{
    [TestClass]
    public class BattleControllerUnitTests
    {
        
        MonsterCharacter genericMonster = new MonsterCharacter();
        PlayerCharacter player = new PlayerCharacter();

        [TestMethod]
        public void BattlefieldCanHaveMonstersAddedToIt()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnMonster(genericMonster);
            int expectedMonsterCount = 1;

            Assert.AreEqual(expectedMonsterCount, testBattle.MonsterCount);
        }

        [TestMethod]
        public void BattlefieldCanHavePlayersAddedToIt()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);
            int expectedPlayerCount = 1;

            Assert.AreEqual(expectedPlayerCount, testBattle.PlayerCount);
        }

        [TestMethod]
        public void BattlefieldCalculatesHitChanceForAttack()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);
            testBattle.SpawnMonster(genericMonster);

            double expectedHitChance = .45; //Current Calculations are just HitChance-DodgeChance

            double actualHitChance = testBattle.CalculateAttackChance(player.AttackList[0], genericMonster.DodgeChance);

            Assert.AreEqual(expectedHitChance, actualHitChance);
        }
    }
}
