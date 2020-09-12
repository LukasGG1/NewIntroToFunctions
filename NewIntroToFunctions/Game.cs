using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Cache;
using System.Reflection.PortableExecutable;
using System.Text;

namespace NewIntroToFunctions
{
    struct Weapon
    {
        public string Name;
        public int Damage;
        public int _HitChance;
    }
    struct Item
    {
        //restore Mana/stamina and health
        public int playerHeal;
        //boost stat
        public int playerBoostDam;
        public int playerBoostDef;
    }

    struct Stat
    {
        public int Streght;
        public int Damage;
        public int Intellight;
        public int Willpower;
        public int Luck;
        public int Dexity;
    }
    struct Spell
    {
        //player
        public int playerHealSteal;
        public int playerHealRegan;
        public int playerContiPoison;
        //enemy
        public int enemyHealSteal;
        public int enemyHealRegan;
        public int enemyContiPoison;
    }

    struct Debuff
    {
        //player
        public int playerReduceDam;
        public int playerReduceHitChance;
        public int playerReduceDefense;
        //enemy
        public int enemyReduceDam;
        public int enemyReduceHitChance;
        public int enemyReduceDefense;
    }
    class Game
    {
        //Weapon list
        Weapon fist;
        Weapon Sword;
        Weapon BattleAxe;
        Weapon Stave;
        Weapon Bow;
        //-----------------------------------
        bool gameOver = false;
        string _playerName;
        int playerHealth = 100;
        int playerHitChance = 30;
        int playerDodgeChance = 30;
        //Plz Nerf random.
        Random random = new Random();
        //Type Name     Argument/Parameter list
        void RequestName()
        //body
        {
            //Initialize Order 34
            char input = ' ';
            while (input != '1')
            {
                Console.Clear();
                Console.WriteLine("Welcome! What is your name, stranger?");
                _playerName = Console.ReadLine();
                Console.WriteLine("Greeting, " + _playerName);
                input = GetInput("Yes", "No", "Is this name you want " + _playerName + "?");
                if (input == '2')
                {
                    Console.WriteLine("Yeah, You're right. It is not good name for you.");

                }
            }

        }

        void WeaponInization()
        {
            //Unarmed Weapon
            fist.Name = "Fist";
            fist.Damage = 1;
            playerHitChance += 2;
            //One-Handed Weapon
            Sword.Name = "Sword";
            Sword.Damage = 5;
            playerHitChance += 5;
            //Two-Handed Weapon
            BattleAxe.Name = "Battle Axe";
            BattleAxe.Damage = 10;
            playerHitChance += 3;

            //Mage Weapon
            Stave.Name = "Stave";
            Stave.Damage = 7;
            playerHitChance = 10;
            //Rogue/Archer Weapon
            Bow.Name = "Bow";
            Bow.Damage = 6;
            playerHitChance += 12;

        }

        void Explore()
        {
            Console.WriteLine("You venture out to your next location");
            FlavorPrinter();
        }

        void StartBattle(Enemy enemy)
        {
            char input = ' ';
            while (playerHealth > 0 && enemy.health > 0)
            {
                Console.WriteLine("Player health: " + playerHealth);
                Console.WriteLine(enemy.name + " health: " + enemy.health);
                input = GetInput("Attack", "Defend", "What will you do?");
                if (input == '1')
                {
                    int HitRoll = random.Next(0, 100);
                    if (HitRoll > playerHitChance)
                    {
                        Console.WriteLine("You yeeted rock and did whooping 5 damage");
                        enemy.health -= 5;
                    }
                    else
                    {
                        Console.WriteLine("Enemy dodged your attack.");
                    }
                    Console.WriteLine("The enemy did 5 damage will your feeling. ");
                    playerHealth -= 5;
                }
                else if (input == '2')
                {
                    int HitRoll = random.Next(0, 100);
                    if (HitRoll > playerDodgeChance)
                    {
                        Console.WriteLine("Piccolo told you dodge the slime's attack. So, you did dodge.");
                        enemy.health -= 5;
                    }
                    else
                    {
                        Console.WriteLine("The Slime prepare for attack you with Doom Guy's Theme and attacked you");
                        playerHealth -= 5;
                    }
                }
                else if (input == '3')
                {
                    if (enemy.weakness == "Fire")
                    {
                        Console.WriteLine("This" + enemy.name + " is weak to fire, you deal 40 damage!");
                        enemy.health -= 40;
                    }
                    else
                    {
                        Console.WriteLine("You yeeted a fireball that kinda work and it deal whooping 5 damage");
                        enemy.health -= 5;
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }

        }

        void ViewStats()
        {
            //Prints player stats to screen.
            Console.WriteLine(_playerName);
            Console.WriteLine("\nPress any to continue");
            Console.Write("> ");
            Console.ReadKey();
        }

        char GetInput(string option1, string option2, string query)
        {
            //initialize input value
            char input = ' ';
            //Loop until a valid input is received
            while (input != '1' && input != '2')
            {
                Console.WriteLine(query);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. View Stats");
                Console.WriteLine("> ");
                //Get input from user
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                //if the player input 3, call the view stats function
            }
            return input;
        }

        public void Run()
        {
            Start();
            RequestName();
            while (gameOver == false)
            {
                Update();
            }

            End();

        }
        //Used for initializing variable
        //also used for performing start up tasks that should only be done once
        public void Start()
        {
            Console.WriteLine("Welcome to my Shadow Game");


        }
        //Used for all game logic will repeat
        public void Update()
        {

            Explore();
            //EnterRoom(0);
        }
        //performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nThank you for playing my Shadow Game");
        }

        private void FlavorPrinter()
        {
            int SelecetedText = random.Next(0, 5);

            switch (SelecetedText)
            {
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine(" You decide to go left and you heard nearly squish. and you look around but nothing but realizes you look down at strange-moving water like as snop.");
                        Console.ReadKey();
                        Console.WriteLine(" Greater Slime ambushed, threw yourself to slime's liquid. and you are trapped forever until you are digested to death.");
                        Console.ReadKey();
                        Console.WriteLine(" Your body is reduced to atom or power for slime and you became forgetten and your exitence is no longer known to people.");
                        Console.ReadKey();
                        Console.WriteLine(" It is worse fate for unforturne mortal. But, there is many more worse fate than your fate.");
                        Console.ReadKey();

                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Help");
                        Console.Clear();
                        Console.WriteLine(" ");
                        break;
                    }
            }
        }
    }
}
