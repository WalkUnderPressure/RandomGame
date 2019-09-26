using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Program
    {
        // write to console result of Attack 
        static string AttackMassage(string TypeOfAttack,string AttackingPlayerName, string DefendingPlayerName, int DamageSize) {
            return $"Player <{AttackingPlayerName}> attack Player <{DefendingPlayerName}>\n"+
                   $"{TypeOfAttack} Type of Attack with Damage ^{DamageSize}^";
        }

        // simple Function SWAP
        static void SWAP(int FirstValue, int SecondValue) {
            int TempValue = FirstValue;
            FirstValue = SecondValue;
            SecondValue = TempValue;
        }

        // write to console WINER
        static void ShowWiner(Player player) {
            Console.WriteLine("================================================");
            Console.WriteLine("*******************  W I N  *******************");
            player.ShowHealthPoints();
            Console.WriteLine("\t\tCongratulations!");
            Console.WriteLine("************************************************");
            Console.WriteLine("================================================");
        }

        // increase the likelihood of an increase in health points
        static int IncreasingChanceRestoreHP(Player player)
        {
            Random random = new Random();
            
            int probability = random.Next(0, 10);

            if (0 <= probability && probability < 2)
            {
                return 0;
            }
            else if (1 < probability && probability < 4)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        static void Main(string[] args)
        {
            int CountOfPlayers = 2;

            // Creating an array for two players
            Player[] Players = new Player[CountOfPlayers];
            
            // Create First Player
            Players[0] = new Player();
            Players[0].Name = "Computer";

            // Create Second Player
            Players[1] = new Player();
            Players[1].Name = "User";

            Random random = new Random();

            // index of Player Who Attacking
            int AttackingPlayer;

            // index of player Who Defending
            int DefendingPlayer;

            int Step = 1;
            while (true)
            {
                // the random choice which player makes a move
                if (random.Next(CountOfPlayers) == 0)
                {
                    AttackingPlayer = 0;
                    DefendingPlayer = 1;
                }
                else
                {
                    AttackingPlayer = 1;
                    DefendingPlayer = 0;
                }

                Console.WriteLine($"~~~~~~~~~~~~~~~~~~ S T E P {Step++} ~~~~~~~~~~~~~~~~~~");

                // start random select of type to attack
                int TypeOfAttack;
                // check the status of Computer HP and if they below  35%, increasing to chance to restore HP
                if (Players[0].HealthPoints < Players[0].GetPercentFromHP(35))
                {
                    TypeOfAttack = IncreasingChanceRestoreHP(Players[0]);
                }
                else
                {
                    TypeOfAttack = random.Next(0, 3);
                }
               
                int DamageSize;
                string AttackingPlayerName = Players[AttackingPlayer].Name;
                string DefendingPlayerName = Players[DefendingPlayer].Name;

                switch (TypeOfAttack)
                {
                    case 0:
                        // size of damage 
                        DamageSize = Players[AttackingPlayer].AverageDamage();

                        // tacking damage from enemy
                        Players[DefendingPlayer].DamageFromEnemy(DamageSize);

                        // write to console result of attack 
                        Console.WriteLine(AttackMassage("First", Players[AttackingPlayer].Name, Players[DefendingPlayer].Name, DamageSize));
                        break;
                    case 1:
                        // size of damage
                        DamageSize = Players[AttackingPlayer].WideSpreadDamage();

                        // tacking damage from enemy
                        Players[DefendingPlayer].DamageFromEnemy(DamageSize);

                        // write to console result of attack 
                        Console.WriteLine(AttackMassage("Second", AttackingPlayerName, DefendingPlayerName, DamageSize));
                        break;
                    case 2:
                        // remember status of HP before restore HP
                        int BeforeRestoreHP = Players[AttackingPlayer].HealthPoints;

                        // restore HP
                        Players[AttackingPlayer].RestoreHP();

                        // remember status of HP after restore HP
                        int AfterRestoreHP = Players[AttackingPlayer].HealthPoints;

                        // write to console result of HP restore
                        Console.WriteLine($"Player <{AttackingPlayerName}> Restore HP from *{BeforeRestoreHP}* to *{AfterRestoreHP}*");
                        break;
                    default:
                        Console.WriteLine("Something Wrong!");
                        break;
                }

                // write to console HP both of players
                for (int i = 0; i < CountOfPlayers; i++)
                {
                    Players[i].ShowHealthPoints();
                }
                Console.WriteLine("\n\n");

                // checking who WINed
               if (!Players[DefendingPlayer].StillAlive)
               {
                    ShowWiner(Players[AttackingPlayer]);
                    break;
               }
            }

            Console.ReadKey();
        }
    }
}
