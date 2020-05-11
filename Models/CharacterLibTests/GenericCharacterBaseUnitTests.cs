using CharacterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterLibTests
{
    [TestClass]
    public class BaseCharacterUnitTests
    {
        [TestMethod]
        public void TakeDamageReducesHealthByAmount()
        {
            var npc = new CharacterBase();
            int expectedHealth = 99;
            int damage = 1;
            npc.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void TakeDamageWillNotReduceHealthBelowZero()
        {
            var npc = new CharacterBase();
            int expectedHealth = 0;
            int damage = 110;

            npc.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void HealDamageCanAddHealth()
        {
            var npc = new CharacterBase();
            int expectedHealth = 100;
            npc.TakeDamage(10);
            npc.HealDamage(10);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void HealDamageDoesNotIncreaseAboveMaxHealth()
        {
            var npc = new CharacterBase();
            int expectedHealth = 100;

            npc.HealDamage(10);

            Assert.AreEqual(expectedHealth, npc.HealthCurrent);
        }

        [TestMethod]
        public void SpendEnergyReducesCurrentEnergyTotal()
        {
            var npc = new CharacterBase();
            int expectedEnergy = 40;

            npc.SpendEnergy(10);

            Assert.AreEqual(expectedEnergy, npc.EnergyCurrent);
        }

        [TestMethod]
        public void SpendEnergyDoesNotReduceBelowZero()
        {
            var npc = new CharacterBase();
            int expectedEnergy = 0;

            npc.SpendEnergy(70);

            Assert.AreEqual(expectedEnergy, npc.EnergyCurrent);

        }

        [TestMethod]
        public void RestoreEnergyDoesNotGoAboveMaxEnergy()
        {
            var npc = new CharacterBase();
            int expectedEnergy = 50;

            npc.RestoreEnergy(10);

            Assert.AreEqual(expectedEnergy, npc.EnergyCurrent);
        }
    }
}
