using CharacterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterLibTests
{
    [TestClass]
    public class MonsterObjectUnitTests
    {
        [TestMethod]
        public void TakeDamageReducesHealthByAmount()
        {
            var npc = new MonsterCharacter();
            int expectedHealth = 99;
            int damage = 1;
            npc.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void TakeDamageWillNotReduceHealthBelowZero()
        {
            var npc = new MonsterCharacter();
            int expectedHealth = 0;
            int damage = 110;

            npc.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void HealDamageCanAddHealth()
        {
            var npc = new MonsterCharacter();
            int expectedHealth = 100;
            npc.TakeDamage(10);
            npc.HealDamage(10);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void HealthGrowsWithLevelDefaultTo10PercentPerLevel()
        {
            var npc = new MonsterCharacter();
            int expectedHealth = 110;
            npc.IncreaseLevel(1);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);

        }

        [TestMethod]
        public void NewCharacterWithLevelHasAppropriateHealth()
        {
            var npc = new MonsterCharacter(5);
            int expectedHealth = 140;

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void HealDamageDoesNotIncreaseAboveMaxHealth()
        {
            var npc = new MonsterCharacter();
            int expectedHealth = 100;

            npc.HealDamage(10);

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
