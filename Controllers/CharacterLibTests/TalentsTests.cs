using CharacterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterLibTests
{
    [TestClass]
    public class TalentTests
    {
        [TestMethod]
        public void TalentStoresCostToInvest()
        {
            var talent = new Talents();
            int expectedCost = 5;

            talent.Cost = 5;

            Assert.AreEqual(expectedCost, talent.Cost);
        }
    }
}
