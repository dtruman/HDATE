using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeDiesAtTheEnd.Classes.Items;
using HeDiesAtTheEnd.Classes.Monster;

namespace HeDiesAtTheEnd.Classes.Character
{
    class Player
    {
        int StartHp = 10;
        int XPToLevel = 100;

        public string Name { get; private set; }

        public int HP { get; private set; }

        public int Level { get; private set; }

        public long Experience { get; private set; }

        public int Strength { get; private set; }

        public int Intelligence { get; private set; }

        public int Dexterity { get; private set; }

        public Weapon EquippedWeapon { get; private set; }

        public Armor EquippedArmor { get; private set; }

        public int numUnusedStatPoints { get; private set; }

        Item[] inventory=new Item[50];

        public Player()
        {
            CharacterCreation();
            Level = 1;
            HP = StartHp;
            Experience = 0;
        }

        public void gainExperience(int xp)
        {
            Experience += xp;
            if (Experience >= XPToLevel)
            {
                levelUp();
            }
        }

        public void levelUp()
        {
            Console.WriteLine();
            Console.WriteLine("You have leveled up! Please choose new stat points!");
            Console.WriteLine();
            Level++;
            HP = (StartHp) + (3 * Level);
            numUnusedStatPoints += 2;
            Experience -= XPToLevel;
            XPToLevel += 25;

            assignStats(numUnusedStatPoints);
        }

        public void assignStats(int numStats)
        {
            while (numStats > 0)
            {
                Console.WriteLine(Name + "'s Remaining Stat Points: " + numStats);
                Console.WriteLine("Current Stats: ");
                Console.WriteLine("1) Strength : " + Strength);
                Console.WriteLine("2) Intelligence : " + Intelligence);
                Console.WriteLine("3) Dexterity : " + Dexterity);
                Console.WriteLine("Which would you like to imcrement?");

                string choiceString = Console.ReadLine();

                int choice = 1;

                if (int.TryParse(choiceString, out choice))
                {
                    if (choice == 1)
                    {
                        Strength += 1;
                        numStats--;
                    }
                    else if (choice == 2)
                    {
                        Intelligence += 1;
                        numStats--;
                    }
                    else if (choice == 3)
                    {
                        Dexterity += 1;
                        numStats--;
                    }
                    else
                    {
                        Console.WriteLine("You have selected an invalid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        public void CharacterCreation()
        {
            int numStats = 10;

            Console.Write("Enter your character's name: ");
            Name = Console.ReadLine();

            assignStats(numStats);

            if (Strength > Intelligence && Strength > Dexterity)
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Sword, 1);
            }
            else if (Intelligence > Strength && Intelligence > Dexterity)
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Staff, 1);
            }
            else if (Dexterity > Intelligence && Dexterity > Strength)
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Bow, 1);
            }
            else
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Sword, 1);
            }
        }
        
        public int Attack(Monster.Monster monster)
        {
            int damage;
            if (EquippedWeapon.type == WeaponType.Sword)
            {
                damage=EquippedWeapon.StrengthModifier + (int)(Strength * 0.25);
            }
            else if (EquippedWeapon.type == WeaponType.Bow)
            {
                damage = EquippedWeapon.DexterityModifier + (int)(Dexterity * 0.25);
            }
            else if (EquippedWeapon.type == WeaponType.Staff)
            {
                damage = EquippedWeapon.IntelligenceModifier + (int)(Intelligence * 0.25);
            }
            else
            {
                damage = (int)(Strength * 0.25);
            }
            return damage;
        }

        public void DisplayPlayer()
        {
            Console.WriteLine();
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("Experience: " + Experience);
            Console.WriteLine("To Next Level: " + XPToLevel);
            Console.WriteLine("Strength: " + Strength);
            Console.WriteLine("Intelligence: " + Intelligence);
            Console.WriteLine("Dexterity: " + Dexterity);
            Console.WriteLine();
        }
    }
}
