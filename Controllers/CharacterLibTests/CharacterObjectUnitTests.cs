using CharacterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterLibTests
{
    [TestClass]
    public class CharacterObjectUnitTests
    {
        [TestMethod]
        public void TakeDamageReducesHealthByAmount()
        {
            var npc = new Character();
            int expectedHealth = 99;
            int damage = 1;
            npc.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void TakeDamageWillNotReduceHealthBelowZero()
        {
            var npc = new Character();
            int expectedHealth = 0;
            int damage = 110;

            npc.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void HealDamageCanAddHealth()
        {
            var npc = new Character();
            int expectedHealth = 100;
            npc.TakeDamage(10);
            npc.HealDamage(10);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void HealthGrowsWithLevelDefaultTo10PercentPerLevel()
        {
            var npc = new Character();
            int expectedHealth = 110;
            npc.IncreaseLevel(1);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);

        }

        [TestMethod]
        public void NewCharacterWithLevelHasAppropriateHealth()
        {
            var npc = new Character(5);
            int expectedHealth = 140;

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }
    }
}
