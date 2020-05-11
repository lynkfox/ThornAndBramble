﻿using CharacterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterLibTests
{
    [TestClass]
    public class TalentTests
    {
        [TestMethod]
        public void TalentStoresCostToInvest()
        {
            var talent = new Talent();
            int expectedCost = 5;

            talent.Cost = 5;

            Assert.AreEqual(expectedCost, talent.Cost);
        }

        [TestMethod]
        public void TalentCanBeConstructedWithVariableCost()
        {
            int cost = 10;
            var talent = new Talent(cost);

            Assert.AreEqual(cost, talent.Cost);
        }

        [TestMethod]
        public void TalentLevelCanBeIncreased()
        {
            var talent = new Talent();
            int expectedLevel = 2;

            talent.LevelUp();

            Assert.AreEqual(expectedLevel, talent.Level);
            
        }

        [TestMethod]
        public void TalentLevelCanBeDecreased()
        {
            var talent = new Talent();
            int expectedLevel = 0;

            talent.LevelDown();

            Assert.AreEqual(expectedLevel, talent.Level);

        }

        [TestMethod]
        public void TalentLevelCannotBeLoweredBelow0()
        {
            var talent = new Talent();
            int expectedLevel = 0;

            talent.LevelDown();
            talent.LevelDown();

            Assert.AreEqual(expectedLevel, talent.Level);
        }

    }
}