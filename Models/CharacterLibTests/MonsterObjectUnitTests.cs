using CharacterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterLibTests
{
    [TestClass]
    public class MonsterObjectUnitTests
    {
        

        [TestMethod]
        public void HealthGrowsWithLevelDefaultTo10PercentPerLevel()
        {
            var npc = new MonsterCharacter();
            int expectedHealth = 121; // 100+10 ==110, 10% is 11, so 121 for level 2

            npc.IncreaseLevel(2);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);

        }

        [TestMethod]
        public void NewCharacterWithLevelHasAppropriateHealth()
        {
            var npc = new MonsterCharacter(5);
            int expectedHealth = 146; //100,110,121,133,146 (round down)

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        

        [TestMethod]
        public void IncreaseLevelIncreasesCombatStats()
        {
            var npc = new MonsterCharacter();
            double expectedCritChance = .16;
            double expectedCritMultiplier = 1.6;
            double expectedAttackPower = 15;
            double expectedDodgeChance = .35;
            int expectedInit = 7;

            npc.IncreaseLevel(1);

            Assert.AreEqual(expectedCritChance, npc.CritChance);
            Assert.AreEqual(expectedCritMultiplier, npc.CritMultiplier);
            Assert.AreEqual(expectedAttackPower, npc.AttackPower);
            Assert.AreEqual(expectedDodgeChance, npc.DodgeChance);
            Assert.AreEqual(expectedInit, npc.Initiative);

        }

        
    }
}
