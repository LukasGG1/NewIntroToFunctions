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
        int playerHealth = 10;
        int playerHitChance = 30;
        int playerDodgeChance = 30;
        int playerDamage = 0;
        Weapon playersWeapon;
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
            fist.Damage = 0;
            fist._HitChance += 2;
            //One-Handed Weapon
            Sword.Name = "Sword";
            Sword.Damage = 5;
            Sword._HitChance += 5;
            //Two-Handed Weapon
            BattleAxe.Name = "Battle Axe";
            BattleAxe.Damage = 10;
            BattleAxe._HitChance += 3;

            //Mage Weapon
            Stave.Name = "Stave";
            Stave.Damage = 7;
            Stave._HitChance = 10;
            //Rogue/Archer Weapon
            Bow.Name = "Bow";
            Bow.Damage = 6;
            Bow._HitChance += 12;

        }

        void Explore()
        {
            Console.WriteLine("You venture out to your next location");
            FlavorPrinter();

        }

        void SelectCharacter()
        {
            char input = ' ';
            //Loops until a valid option is choosen
            while (input != '1' && input != '2' && input != '3')
            {
                //Prints options
                Console.WriteLine("Welcome! Please select a character.");
                Console.WriteLine("1.Sir Kibble");
                Console.WriteLine("Sir Kibble is from noble house called Griffin for bodyguard of Royalty. Griffin's founder was legendary knight who");
                Console.WriteLine("protected his kingdom multiple and saved a lot Royalty's life. But, Griffin dislike politic and was exiled by greedy and arrogant Royalty");
                Console.WriteLine("");
                Console.WriteLine("2.Gnojoel");
                Console.WriteLine("Gnojoel is mage who bears blood magic from his family and running away from Templer, knight who kill or safeguard mage for fearing magic corruption. Gnojoel wasn't corrupted by blood magic. Gnojoel is such greedy mage. Not money. Not fame. Not glory. Just knowledge for sasifty his curiousity.");
                Console.WriteLine("");
                Console.WriteLine("3.Joedazz");
                Console.WriteLine("Joedazz's race is elves who were enslaved by human and now lower rank is commoner. Human looked down and treat elves as trash. Joedazz's bloodline was legendary Reavor, a warrior who devor blood and flesh for healing his flesh. Joedazz was declared crimenal by noble. because Joedazz killed noble's son. Joedazz killed noble's son for saving Joedazz's sister  because noble's son tried kill her for his pleasure. Joedazz has no place in this city and have no choice but leave city.");
                Console.WriteLine("");
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
                //Sets the players default stats based on which character was picked
                switch (input)
                {
                    case '1':
                        {
                            _playerName = "Sir Kibble";
                            playerHealth = 40;
                            playerDamage = 3;
                            playerHitChance = 5;
                            break;
                        }
                    case '2':
                        {
                            _playerName = "Gnojoel";
                            playerHealth = 30;
                            playerDamage = 1;
                            playerHitChance = 8;
                            break;
                        }
                    case '3':
                        {
                            _playerName = "Joedazz";
                            playerHealth = 50;
                            playerDamage = 5;
                            playerHitChance = 2;
                            break;
                        }
                    //If an invalid input is selected display and input message and input over again.
                    default:
                        {
                            Console.WriteLine("Invalid input. Press any key to continue.");
                            Console.Write("> ");
                            Console.ReadKey();
                            break;
                        }
                }
                Console.Clear();
            }
            PrintStats();
            Console.WriteLine("Press any key to continue.");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        void PrintStats()
        {
            Console.WriteLine("Name" + _playerName);
            Console.WriteLine("Health: " + playerHealth);
            Console.WriteLine("Damage: " + playerDamage + playersWeapon.Damage);
            Console.WriteLine("Hit Chance: " + playerHitChance);
            Console.WriteLine("Weapon: " + playersWeapon.Name);
            Console.ReadKey();
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
                        if (HitCheck(TotalHitChance(), enemy.DodgeChance))
                        {
                            Console.WriteLine("You throw your " + playersWeapon.Name + " and did whooping " + playersWeapon.Damage + " damage");
                            enemy.health -= playersWeapon.Damage;
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
                        if (HitCheck(enemy.HitChance, playerDodgeChance))
                        {
                            Console.WriteLine("Piccolo told you dodge the slime's attack. So, you did dodge.");
                            enemy.health -= 3;
                        }
                        else
                        {
                            Console.WriteLine("Did you dodge attack?");
                            playerHealth -= 0;
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
                WeaponInization();
                RequestName();
                EquipWeapon();
                SelectCharacter();
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
                Console.ReadKey();



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
                            PossessedSteelArmor PossessedBoi = new PossessedSteelArmor();
                            StartBattle(PossessedBoi);
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
            private void EquipWeapon()
            {
                Console.Clear();
                Console.WriteLine("What weapon would you like to have");
                Console.Write("");
                Console.WriteLine("1. fist");
                Console.WriteLine("2. Sword");
                Console.WriteLine("3. Battle Axe");
                Console.WriteLine("4. Stave");
                Console.WriteLine("5. Bow");
                //----------------------------
                string SelectedWeap = Console.ReadLine();
                switch (SelectedWeap)
                {
                    case ("1"):
                        {
                            playersWeapon = fist;
                            break;
                        }
                    case ("2"):
                        {
                            playersWeapon = Sword;
                            break;
                        }
                    case ("3"):
                        {
                            playersWeapon = BattleAxe;
                            break;
                        }
                    case ("4"):
                        {
                            playersWeapon = Stave;
                            break;
                        }
                    case ("5"):
                        {
                            playersWeapon = Bow;
                            break;
                        }
                    default:
                        {
                            playersWeapon = fist;
                            break;
                        }

                }
                Console.WriteLine("You picked " + playersWeapon.Name);
                Console.ReadKey();
            }
            private bool HitCheck(int hitChance ,int enemyDodgeChance)
            {
                int HitRoll = random.Next(0, 100);
                if (HitRoll > enemyDodgeChance - hitChance)
                {
                    return true;
                }
                return false;
            }
            private int TotalHitChance()
            {
                return playerHitChance + playersWeapon._HitChance;
            }
        }
    }
