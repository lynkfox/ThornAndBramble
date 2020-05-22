using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleController;
using ActorControllers;
using CharacterLib;

namespace ControllerUnitTests
{
    [TestClass]
    public class CharacterControllerUnitTests
    {
        
        [TestMethod]
        public void StatsCanBeCalled()
        {
            CharacterController test = new CharacterController();

            int expectedHealth = 100;

            Assert.AreEqual(expectedHealth, test.Stat("HealthCurrent"));

        }

        [TestMethod]
        public void NameCanBeRecalled()
        {
            CharacterController test = new CharacterController();

            string expectedName = "DefaultCharacter";

            Assert.AreEqual(expectedName, test.Name);
        }

        [TestMethod]
        public void SkillToHitWithAttackCanBeRecalled()
        {
            CharacterController test = new CharacterController();

            double expectedHitChance = .75;


            Assert.AreEqual(expectedHitChance, test.SkillToHitChance("Strike"));
        }

        [TestMethod]
        public void AttackBaseDamageReturnsTheBaseDamageOfAnAttack()
        {

            CharacterController test = new CharacterController();

            double expectedHitChance = 5;



            Assert.AreEqual(expectedHitChance, test.AttackDamage("Strike"));
        }


        [TestMethod]
        public void TakeDamageReducesHealthCurrent()
        {
            CharacterController test = new CharacterController();
            test.TakeDamage(5);

            double expectedHealth = 95;

            Assert.AreEqual(expectedHealth, test.Stat("HealthCurrent"));
        }

    }
}
