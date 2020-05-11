using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleController;
using CharacterLib;

namespace BattleControllerUnitTests
{
    [TestClass]
    public class BattleControllerUnitTests
    {
        Battlefield testBattle = new Battlefield();
        MonsterCharacter genericMonster = new MonsterCharacter();

        [TestMethod]
        public void BattlefieldCanHaveMonstersAddedToIt()

        {
            testBattle.SpawnMonster(genericMonster);
            int expectedMonsterCount = 1;

            Assert.AreEqual(expectedMonsterCount, testBattle.MonsterCount);
        }
    }
}
