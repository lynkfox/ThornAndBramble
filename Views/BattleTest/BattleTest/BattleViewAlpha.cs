using System;
using BattleController;
using ActorControllers;
using System.Collections.Generic;

namespace BattleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var battlefield = new Battlefield();

            List<MonsterController> allMonsterControllers = new List<MonsterController>();
            bool runAway = false;


            Console.WriteLine("========= Thorn and Bramble Battlefield View - ver 0.0.1a =========\n\n");

            Console.WriteLine("What is your player's name?");
            string playerName = Console.ReadLine();

            var player = new PlayerController(playerName);
            battlefield.SpawnPlayer(ref player);

            Console.WriteLine("Welcome " + playerName + " to Thorn And Bramble Battle: 0.0.1a. How many monsters do you want to fight against? (1-5)");
            int numberOfMonsters = int.Parse(Console.ReadLine());

            Console.Write("Spawning Monsters ...");


            for (int i = 0; i < numberOfMonsters; i++)
            {
                Console.Write(".");
                string monsterName = "Monster " + (i + 1);
                var monster = new MonsterController();
                monster.Name = monsterName;
                allMonsterControllers.Add(monster);
                battlefield.SpawnMonster(ref monster);
            }

            Console.WriteLine(numberOfMonsters + " spawned!  Battle Begins in 3 ... 2 ... 1... Battle Start!");
            battlefield.NewRound();

            while (battlefield.MonsterCount > 0 && battlefield.PlayerCount > 0 || !runAway)
            {
                
                var actor = battlefield.NextToAct();
                string actingName = actor.Name;
                Console.WriteLine("\r\nCurrent Initiative Is: " + battlefield.CurrentInitiative + " and " + actingName + " is up!");
                if(battlefield.NextToAct().GetType() == typeof(MonsterController))
                {
                    double chanceToHit = battlefield.CalculateAttackChance(actor.Name, "Strike", player.Name)*100;
                    double damage = battlefield.CalculateTotalDamage(actor.Name, "Strike");
                    Console.WriteLine("\r\n"+ actingName + " attacks with Strike! There is a " +chanceToHit+ "% chance it will hit and do " +damage + " points of damage!" );


                    if (battlefield.Attack(actor.Name, "Strike", player.Name))
                    {
                        Console.WriteLine("\r\nThe attack succeded! You now have " + player.Stat("HealthCurrent") + " health left");
                    }
                    else
                    {
                        Console.WriteLine("\r\nThe Monster Missed! whew!");
                    }

                    battlefield.AdvanceTurn();

                }
                else
                {
                    Console.WriteLine("\r\nIt's your turn! What would you like to do?\r\n1. Attack \r\n2. Run away! ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.WriteLine("\r\nWhich Monster?");
                        int i = 1;
                        foreach (var monster in allMonsterControllers)
                        {
                            Console.WriteLine(i + ". " + monster.Name);
                            i++;
                        }
                        int monsterChoice = int.Parse(Console.ReadLine());

                        var attackedMonster = allMonsterControllers[monsterChoice - 1];

                        double chanceToHit = battlefield.CalculateAttackChance(actor.Name, "Strike", attackedMonster.Name) * 100;
                        double damage = battlefield.CalculateTotalDamage(actor.Name, "Strike");
                        Console.WriteLine("\r\n" + actingName + " attacks with Strike! There is a " + chanceToHit + "% chance it will hit and do " + damage + " points of damage!");


                        if (battlefield.Attack(actor.Name, "Strike", attackedMonster.Name))
                        {
                            Console.WriteLine("\r\nThe attack succeded! " + attackedMonster.Name + " has " + attackedMonster.Stat("HealthCurrent") + " health left!");
                            if(attackedMonster.Stat("HealthCurrent") == 0 )
                            {
                                Console.WriteLine("\r\nYou killed " + attackedMonster.Name + "!");
                                allMonsterControllers.Remove(attackedMonster);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\r\nAww! You missed!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("\r\nRun away!");
                        runAway = true;
                        break;
                    }

                    
                    battlefield.AdvanceTurn();
                }
            }


            if (battlefield.PlayerCount == 0)
            {
                Console.WriteLine("\r\nSo ends the journey of " + playerName);

            }else if (battlefield.MonsterCount == 0)
            {
                Console.WriteLine("\r\nHurray! You have defeated all the monsters! Well fought!");

            }
            else
            {
                Console.WriteLine("You got away safely... the shivers are in your blood now...");
            }


        }
    }
}
