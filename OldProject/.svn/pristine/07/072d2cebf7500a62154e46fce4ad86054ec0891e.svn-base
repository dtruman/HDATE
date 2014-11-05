using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeDiesAtTheEnd.Classes.Items;
using HeDiesAtTheEnd.Classes.Monster;
using System.Collections.ObjectModel;

namespace HeDiesAtTheEnd.Classes.Character
{
    class Player
    {
        int StartHp = 10;
        int XPToLevel = 100;

        public int MaxHP { get; private set; }

        public string Name { get; private set; }

        public int HP { get; set; }

        public int Level { get; private set; }

        public long Experience { get; private set; }

        public int Strength { get; private set; }

        public int Intelligence { get; private set; }

        public int Dexterity { get; private set; }

        public Weapon EquippedWeapon { get; private set; }

        public Armor EquippedArmor { get; private set; }

        public int numUnusedStatPoints { get; private set; }

        const int MAX_INVENTORY_SPACE = 50;

        public ObservableCollection<Consumable> itemInventory = new ObservableCollection<Consumable>();
        public ObservableCollection<Weapon> weaponInventory = new ObservableCollection<Weapon>();
        public ObservableCollection<Armor> armorInventory = new ObservableCollection<Armor>();

        public Player()
        {
            CharacterCreation();
            Level = 1;
            MaxHP = StartHp;
            HP = MaxHP;
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
            MaxHP = (StartHp) + (int)Math.Round(3.5 * Level);
            HP = MaxHP;
            numUnusedStatPoints += 2;
            Experience -= XPToLevel;
            XPToLevel += 25;

            assignStats();
        }

        public void assignStats()
        {
            while (numUnusedStatPoints > 0)
            {
                Console.WriteLine(Name + "'s Remaining Stat Points: " + numUnusedStatPoints);
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
                        numUnusedStatPoints--;
                    }
                    else if (choice == 2)
                    {
                        Intelligence += 1;
                        numUnusedStatPoints--;
                    }
                    else if (choice == 3)
                    {
                        Dexterity += 1;
                        numUnusedStatPoints--;
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
            numUnusedStatPoints = 10;

            Console.Write("Enter your character's name: ");
            Name = Console.ReadLine();

            assignStats();

            if (Strength > Intelligence && Strength > Dexterity)
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Sword, 0, "A starting sword.", "Base Sword or normalness.");
            }
            else if (Intelligence > Strength && Intelligence > Dexterity)
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Staff, 0, "A starting staff.", "Base Staff or normalness.");
            }
            else if (Dexterity > Intelligence && Dexterity > Strength)
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Bow, 0, "A starting bow.", "Base Bow or normalness.");
            }
            else
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Sword, 0, "A starting sword.", "Base Sword or normalness.");
            }

            EquippedArmor = new Armor(Items.Type.Bronze, 0, "A starting set of armor.", "Base sword or normalness.");
        }
        
        public int Attack()
        {
            int damage;
            if (EquippedWeapon.type == WeaponType.Sword)
            {
                damage=EquippedWeapon.StrengthModifier + ((int)(Strength * 0.5));
            }
            else if (EquippedWeapon.type == WeaponType.Bow)
            {
                damage = EquippedWeapon.DexterityModifier + ((int)(Dexterity * 0.5));
            }
            else if (EquippedWeapon.type == WeaponType.Staff)
            {
                damage = EquippedWeapon.IntelligenceModifier + ((int)(Intelligence * 0.5));
            }
            else
            {
                damage = (int)(Strength * 0.5);
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

        public void AddItemToInventory(Item item)
        {
            if (item.GetType().Equals(typeof(Weapon)))
            {
                if (weaponInventory.Count < MAX_INVENTORY_SPACE)
                {
                    weaponInventory.Add((Weapon)item);
                }
            }
            else if (item.GetType().Equals(typeof(Armor)))
            {
                if (armorInventory.Count < MAX_INVENTORY_SPACE)
                {
                    armorInventory.Add((Armor)item);
                }
            }
            else if (item.GetType().Equals(typeof(Consumable)))
            {
                if (itemInventory.Count < MAX_INVENTORY_SPACE)
                {
                    itemInventory.Add((Consumable)item);
                }
            }
        }

        public void UseConsumable(Item item)
        {
            if (item.GetType() == typeof(Consumable))
            {
                Consumable newConsume = (Consumable)item;
                HP += newConsume.HealthRegen;
                if (HP > MaxHP)
                {
                    HP = MaxHP;
                }
                RemoveItemFromInventory(item);
            }
        }

        public void RemoveItemFromInventory(Item item)
        {
            if(item.GetType() == typeof(Weapon))
            {
                weaponInventory.Remove((Weapon)item);
            }
            else if (item.GetType() == typeof(Armor))
            {
                armorInventory.Remove((Armor)item);
            }
            else if (item.GetType() == typeof(Consumable))
            {
                itemInventory.Remove((Consumable)item);
                //bool hasRemovedItem = false;
                //for (int i = 0; i < itemInventory.Count; i++)
                //{
                //    if (item.CompareTo(itemInventory[i]) == 0)
                //    {
                //        itemInventory.Remove(itemInventory[i]);
                //        hasRemovedItem = true;
                //    }
                //}
                //if(!hasRemovedItem)
                //{
                // Console.WriteLine("That item does not exist in inventory.");
                //}
            }

            
        }

        public void EquipItem(Item item)
        {
            if (item.GetType().Equals(typeof(Weapon)))
            {
                Weapon temp = EquippedWeapon;
                EquippedWeapon = (Weapon)item;
                RemoveItemFromInventory(item);
                AddItemToInventory(temp);
            }
            else if (item.GetType().Equals(typeof(Armor)))
            {
                Armor temp = EquippedArmor;
                EquippedArmor = (Armor)item;
                RemoveItemFromInventory(item);
                AddItemToInventory(temp);
            }
            else
            {
                Console.WriteLine("You cannot equip this item.");
            }
        }
    }
}