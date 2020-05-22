using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActorControllers;
using BattleController;
using CharacterLib;

namespace ControllerUnitTests
{
    [TestClass]
    public class BattleControllerUnitTests
    {
        
        

        public Battlefield Setup()
        {
            MonsterController genericMonster = new MonsterController();
            PlayerController player = new PlayerController("Player");
            player.Actor.CharacterStat.Initiative = 4;
            Battlefield testBattle = new Battlefield();
            testBattle.SpawnMonster(ref genericMonster);
            testBattle.SpawnPlayer(ref player);

            return testBattle;
        }

        [TestMethod]
        public void MonstersCanBeAddedToBatlefield()
        {
            Battlefield testBattle = Setup();
            int expectedMonsterCount = 1;

            Assert.AreEqual(expectedMonsterCount, testBattle.MonsterCount);
        }

        [TestMethod]
        public void PlayersCanBeAddedToBattlefield()
        {
            Battlefield testBattle = Setup();
            int expectedPlayerCount = 1;

            Assert.AreEqual(expectedPlayerCount, testBattle.PlayerCount);
        }

        [TestMethod]
        public void InitiativeNextToActCanBeCalled()
        {
            Battlefield testBattle = Setup();
            testBattle.AssignInitiativeOrder();

            string expectedName = "DefaultCharacter";

            Assert.AreEqual(expectedName, testBattle.NextToAct().Name);
        }

        
        [TestMethod]
        public void InitiativeOrderCanBeArranged()
        {
            Battlefield testBattle = Setup();

            string actualFirstTurnName = "DefaultCharacter";

            testBattle.AssignInitiativeOrder();

            Assert.AreEqual(actualFirstTurnName, testBattle.NextToAct().Name);
        }
        

        [TestMethod]
        public void ToHitChanceCanBeCalculated()
        {
            Battlefield testBattle = Setup();

            double expectedHitChance = .45; // Currently just Attacker BaseToHit + skill AttackChance - Defender DodgeChance

            double actualHitChance = testBattle.CalculateAttackChance("Player", "Strike", "DefaultCharacter");

            Assert.AreEqual(expectedHitChance, actualHitChance);
        }

        [TestMethod]
        public void HealthCanBeCalled()
        {
            Battlefield testBattle = Setup();

            int expectedHealth = 100;

            Assert.AreEqual(expectedHealth, testBattle.HealthOf("Player"));
        }
        
        [TestMethod]
        public void AttackThatIsASuccessCanDoDamage()
        {
            Battlefield testBattle = Setup();


            int expectedCurrentHealth = 95;

            testBattle.SuccessfulAttackDamage("Player", 5);

            Assert.AreEqual(expectedCurrentHealth, testBattle.HealthOf("Player"));
        }

        [TestMethod]
        public void StatOfAnyKindCanBeRetrieved()
        {
            Battlefield testBattle = Setup();

            double expectedAttackPower = 10;
            double expectedCritChance = .1;

            Assert.AreEqual(expectedAttackPower, testBattle.CharacterStat("Player", "AttackPower"));
            Assert.AreEqual(expectedCritChance, testBattle.CharacterStat("Player", "CritChance"));
        }

        [TestMethod]
        public void NextRoundAdvancesInitiatveToNextCharacterInInitiativeOrder()
        {
            Battlefield testBattle = Setup();

            testBattle.NewRound();

            testBattle.AdvanceTurn();

            string expectedNextToAct = "Player";
            int expectedInitiative = 4;

            Assert.AreEqual(expectedNextToAct, testBattle.NextToAct().Name);
            Assert.AreEqual(expectedInitiative, testBattle.CurrentInitiative);
        }
        
        [TestMethod]
        public void NextTurnWhenOutOfCharactersResetsToNewRound()
        {
            Battlefield testBattle = Setup();


            Player testPlayer = new Player("Player");

            testBattle.NewRound();

            testBattle.AdvanceTurn();
            testBattle.AdvanceTurn();

            string expectedNextToAct = "DefaultCharacter";
            int expectedInitiative = 10;

            Assert.AreEqual(expectedNextToAct, testBattle.NextToAct().Name);
            Assert.AreEqual(expectedInitiative, testBattle.CurrentInitiative);
        }

        [TestMethod]
        public void AttackReducesHealthBelow0RemovesCharacterFromBattlefield()
        {
            Battlefield testBattle = Setup();

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
            Battlefield testBattle = Setup();

            PlayerController testPlayer2 = new PlayerController("Player2");
            testPlayer2.Actor.CharacterStat.Initiative = 11;

            testBattle.SpawnPlayer(ref testPlayer2);

            testBattle.NewRound();

            testBattle.SuccessfulAttackDamage("DefaultCharacter", 9999);

            testBattle.AdvanceTurn();

            string expectedNextToActName = "Player";

            Assert.AreEqual(expectedNextToActName, testBattle.NextToAct().Name);
        }

        [TestMethod]
        public void AttackDamageCanTakeDameFromCharactersKnownAttacks()
        {
            Battlefield testBattle = Setup();

            int expectedDamage = 5;
            Assert.AreEqual(expectedDamage, testBattle.AttackDamage("Player", "Strike"));
        }

        
        [TestMethod]
        public void AttacksWithAttackPowerDoMoreThanBaseDamage()
        {

            Battlefield testBattle = Setup();
            
            int expectedDamage = 15;

            Assert.AreEqual(expectedDamage, testBattle.CalculateTotalDamage("Player", "Strike"));
            

        }

        [TestMethod]
        public void Rolld100ReturnsADoubleLessThan1AndMoreThan0()
        {
            Battlefield testBattle = Setup();

            double number = testBattle.Rolld100();

            Assert.IsTrue(number < 1 && number > 0);
        }
        
    }
}
