using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Player
    {
        private int PlayerHealthPoints;
        private string PlayerName;

        public int HealthPoints {
            get
            {
                return PlayerHealthPoints;
            }
        }
        public string Name {
            get
            {
                return PlayerName;
            }
            set
            {
                if (value != String.Empty)
                {
                    PlayerName = value;
                }
                else {
                    PlayerName = "NoName";
                }
            }
        }

        // Small Range 
        private int MinValueOfSmallRange;
        private int MaxValueOfSmallRange;

        // Large Range
        private int MinValueOfLargeRange;
        private int MaxValueOfLargeRange;

        // Health Points Range
        private int MinHealthPointsValue;
        private int MaxHealthPointsValue;

        
        public Player() {
            // set diapason of health points value  
            MinHealthPointsValue = 0;
            MaxHealthPointsValue = 100;

            // Start health point for player
            PlayerHealthPoints = MaxHealthPointsValue;

            // default small range 
            MinValueOfSmallRange = 18;
            MaxValueOfSmallRange = 25;

            // default large range
            MinValueOfLargeRange = 10;
            MaxValueOfLargeRange = 35;
        }

        // value of the first type of attack
        public int AverageDamage() {
            Random random = new Random();
            return random.Next(MinValueOfSmallRange, MaxValueOfSmallRange);
        }

        // value of the second type of attack
        public int WideSpreadDamage() {
            Random random = new Random();
            return random.Next(MinValueOfLargeRange,MaxValueOfLargeRange);
        }

        // restore health points 
        public void RestoreHP()
        {
            Random random = new Random();
            int AddHealthPoints = random.Next(MinValueOfSmallRange, MaxValueOfSmallRange);
            if ((AddHealthPoints + PlayerHealthPoints) <= MaxHealthPointsValue)
            {
                PlayerHealthPoints += AddHealthPoints;
            }
            else
            {
                PlayerHealthPoints = MaxHealthPointsValue;
            }
        }
        
        // taking damage from an enemy
        public void DamageFromEnemy(int damage) {
            if (HealthPoints>= damage)
            {
                PlayerHealthPoints -= damage;
            }
            else
            {
                PlayerHealthPoints = 0;
            }
        }

        // return check status of player (dead or alive)
        public bool StillAlive
        {
            get
            {
                if (HealthPoints > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // get some percent from health points
        public int GetPercentFromHP(int Percent) {
            return (MaxHealthPointsValue*Percent)/ 100;
        }

        // out status Health Points 
        public void ShowHealthPoints(){
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Player : " + Name);
            Console.WriteLine("Health Points : " + HealthPoints);
            Console.WriteLine("------------------------------------------------");
        }
    }
}
