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

        [TestMethod]
        public void PlayerMoneyRemainsUnchangedIfAttemptingToSpendMoreThanHave()
        {
            var player = new PlayerCharacter();
            int expectedMoney = 10;
            player.Money = 10;

            player.SpendMoney(15);

            Assert.AreEqual(expectedMoney, player.Money);
        }

        [TestMethod]
        public void PlayerCanEarnMoney()
        {
            var player = new PlayerCharacter();
            int expectedMoney = 5;

            player.EarnMoney(5);

            Assert.AreEqual(expectedMoney, player.Money);
        }

        [TestMethod]
        public void PlayerCanInvestMoneyFromTotalMoney()
        {
            var player = new PlayerCharacter();
            int expectedMoney = 5;
            int expectInvestedMoney = 5;
            player.EarnMoney(10);

            player.InvestMoney(5);

            Assert.AreEqual(expectedMoney, player.Money);
            Assert.AreEqual(expectInvestedMoney, player.InvestedMoney);
        }

        [TestMethod]
        public void PlayerCannotInvestMoretThanTotalMoney()
        {
            var player = new PlayerCharacter();
            int expectedMoney = 7;
            int expectedInvestedMoney = 0;
            player.EarnMoney(7);

            player.InvestMoney(10);

            Assert.AreEqual(expectedMoney, player.Money);
            Assert.AreEqual(expectedInvestedMoney, player.InvestedMoney);
        }
    }
}
