using CharacterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterLibTests
{
    [TestClass]
    public class PlayerCharacterTests
    {
        [TestMethod]
        public void PlayerCharacterCanReturnItsTotalMoney()
        { 
            var player = new PlayerCharacter();
            int expectedMoney = 0;

            Assert.AreEqual(expectedMoney, player.Money);
        }

        [TestMethod]
        public void PlayerCanSpendMoneyAndReduceTotal()
        {
            var player = new PlayerCharacter();
            int expectedMoney = 10;
            player.Money = 20;

            player.SpendMoney(10);

            Assert.AreEqual(expectedMoney, player.Money);
        }
    }
}
