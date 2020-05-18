using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleController;
using CharacterLib;

namespace BattleControllerUnitTests
{
    [TestClass]
    public class BattleControllerUnitTests
    {
        
        Monster genericMonster = new Monster();
        Player player = new Player("Player");



        [TestMethod]
        public void MonstersCanBeAddedToBatlefield()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnMonster(genericMonster);
            int expectedMonsterCount = 1;

            Assert.AreEqual(expectedMonsterCount, testBattle.MonsterCount);
        }

        [TestMethod]
        public void PlayersCanBeAddedToBattlefield()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);
            int expectedPlayerCount = 1;

            Assert.AreEqual(expectedPlayerCount, testBattle.PlayerCount);
        }

        [TestMethod]
        public void InitiativeNextToActCanBeCalled()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);
            testBattle.AssignInitiativeOrder();

            string expectedName = "Player";

            Assert.AreEqual(expectedName, testBattle.NextToAct().CharacterStat.Name);
        }

        
        [TestMethod]
        public void InitiativeOrderCanBeArranged()
        {
            Player testPlayer = new Player("Player");
            testPlayer.CharacterStat.Initiative = 4;

            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(testPlayer);
            testBattle.SpawnMonster(genericMonster);

            string actualFirstTurnName = "DefaultCharacter";

            testBattle.AssignInitiativeOrder();

            Assert.AreEqual(actualFirstTurnName, testBattle.NextToAct().CharacterStat.Name);
        }
        

        [TestMethod]
        public void ToHitChanceCanBeCalculated()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);
            testBattle.SpawnMonster(genericMonster);

            double expectedHitChance = .45; //Current Calculations are just HitChance-DodgeChance

            double actualHitChance = testBattle.CalculateAttackChance(player.CharacterStat.AttackList[0], genericMonster.CharacterStat.DodgeChance);

            Assert.AreEqual(expectedHitChance, actualHitChance);
        }

        [TestMethod]
        public void HealthCanBeCalled()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);

            int expectedHealth = 100;

            Assert.AreEqual(expectedHealth, testBattle.HealthOf("Player"));
        }
        
        [TestMethod]
        public void AttackThatIsASuccessCanDoDamage()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);
            

            int expectedCurrentHealth = 95;

            testBattle.SuccessfulAttackDamage("Player", 5);

            Assert.AreEqual(expectedCurrentHealth, testBattle.HealthOf("Player"));
        }
        
    }
}
