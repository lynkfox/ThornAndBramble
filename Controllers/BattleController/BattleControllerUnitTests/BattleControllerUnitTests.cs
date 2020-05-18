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

            double expectedHitChance = .45; // Currently just Attacker BaseToHit + skill AttackChance - Defender DodgeChance

            double actualHitChance = testBattle.Attack("Player", "Strike", "DefaultCharacter");

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

        [TestMethod]
        public void StatOfAnyKindCanBeRetrieved()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);

            double expectedAttackPower = 10;
            double expectedCritChance = .1;

            Assert.AreEqual(expectedAttackPower, testBattle.CharacterStat("Player", "AttackPower"));
            Assert.AreEqual(expectedCritChance, testBattle.CharacterStat("Player", "CritChance"));
        }

        [TestMethod]
        public void NextRoundAdvancesInitiatveToNextCharacterInInitiativeOrder()
        {
            Battlefield testBattle = new Battlefield();
            Player testPlayer = new Player("Player");
            testPlayer.CharacterStat.Initiative = 4;

            testBattle.SpawnPlayer(testPlayer);
            testBattle.SpawnMonster(genericMonster);

            testBattle.NewRound();

            testBattle.AdvanceTurn();

            string expectedNextToAct = "Player";
            int expectedInitiative = 4;

            Assert.AreEqual(expectedNextToAct, testBattle.NextToAct().CharacterStat.Name);
            Assert.AreEqual(expectedInitiative, testBattle.CurrentInitiative);
        }
        
        [TestMethod]
        public void NextTurnWhenOutOfCharactersResetsToNewRound()
        {
            Battlefield testBattle = new Battlefield();
            Player testPlayer = new Player("Player");
            testPlayer.CharacterStat.Initiative = 4;

            testBattle.SpawnPlayer(testPlayer);
            testBattle.SpawnMonster(genericMonster);

            testBattle.NewRound();

            testBattle.AdvanceTurn();
            testBattle.AdvanceTurn();

            string expectedNextToAct = "DefaultCharacter";
            int expectedInitiative = 10;

            Assert.AreEqual(expectedNextToAct, testBattle.NextToAct().CharacterStat.Name);
            Assert.AreEqual(expectedInitiative, testBattle.CurrentInitiative);
        }

        [TestMethod]
        public void AttackReducesHealthBelow0RemovesCharacterFromBattlefield()
        {
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnPlayer(player);
            testBattle.SpawnMonster(genericMonster);

            testBattle.NewRound();

            testBattle.SuccessfulAttackDamage("Player", 105);

            int expectedPlayerCount = 0;
            int expectedDeadCharacterCount = 1;

            Assert.AreEqual(expectedPlayerCount, testBattle.PlayerCount);
            Assert.AreEqual(expectedDeadCharacterCount, testBattle.DeadCharacters.Count);
        }

        [TestMethod]
        public void DeadCharactersAreSkippedInInitiatveOrder()
        {
            Battlefield testBattle = new Battlefield();
            Player testPlayer = new Player("Player");
            testPlayer.CharacterStat.Initiative = 4;

            Player testPlayer2 = new Player("Player2");
            testPlayer2.CharacterStat.Initiative = 11;

            testBattle.SpawnPlayer(testPlayer);
            testBattle.SpawnPlayer(testPlayer2);
            testBattle.SpawnMonster(genericMonster);

            testBattle.NewRound();

            testBattle.SuccessfulAttackDamage("DefaultCharacter", 9999);

            testBattle.AdvanceTurn();

            string expectedNextToActName = "Player";

            Assert.AreEqual(expectedNextToActName, testBattle.NextToAct().CharacterStat.Name);
        }
    }
}
