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
        

    }
}
