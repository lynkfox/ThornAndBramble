using CharacterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterLibTests
{
    [TestClass]
    public class PlayerCharacterTests
    {

        Talent genericTalent = new Talent();

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

        [TestMethod]
        public void PlayerCharacterStoresTalents()
        {
            var player = new PlayerCharacter();
            player.EarnMoney(10);

            player.AddTalent(genericTalent);

            Assert.IsTrue(player.NumberOfTalents() > 0);
            
        }

        [TestMethod]
        public void AddingTalentInvestsTheCostFromMoney()
        {
            var player = new PlayerCharacter();
            player.EarnMoney(10);
            int expectedMoney = 5;
            int expectedInvested = 5;

            player.AddTalent(genericTalent);

            Assert.AreEqual(expectedMoney, player.Money);
            Assert.AreEqual(expectedInvested, player.InvestedMoney);
        }

        [TestMethod]
        public void TalentIsNotAddedIfCostIsMoreThanCurrentMoney()
        {
            var player = new PlayerCharacter();
            player.EarnMoney(1);
            int expectedTalentCount = 0;

            player.AddTalent(genericTalent);

            Assert.AreEqual(expectedTalentCount, player.NumberOfTalents());
        }

        [TestMethod]
        public void TalentAddWillNotAddDuplicateTalents()
        {
            var player = new PlayerCharacter();
            player.EarnMoney(20);
            int expectedTalentCount = 1;

            player.AddTalent(genericTalent);
            player.AddTalent(genericTalent);

            Assert.AreEqual(expectedTalentCount, player.NumberOfTalents());
        }

        [TestMethod]
        public void IfTalentAlreadyExistsIncreaseTalentLevel()
        {
            var player = new PlayerCharacter();
            player.EarnMoney(20);
            int expectedTalentLevel = 2;

            player.AddTalent(genericTalent);
            player.AddTalent(genericTalent);

            Assert.AreEqual(expectedTalentLevel, player.TalentLevel("DefaultTalent"));

        }

        

        /* Exceptions that will have to be added for a Test
         * 
         * TalentDoesNotExist - for TalentLevel
         * NotEnoughMoney - for Investing or Spending money
         */

        

    }
}
