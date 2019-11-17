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
    }
}
