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
        public void BattlfieldCanHavePlayersAddedToIt()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);
            int expectedPlayerCount = 1;

            Assert.AreEqual(expectedPlayerCount, testBattle.PlayerCount);
        }
    }
}
