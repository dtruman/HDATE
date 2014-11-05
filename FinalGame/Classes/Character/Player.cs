using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FinalGame.Classes.Items;
using FinalGame.MapElements;
using System.ComponentModel;
using System.Media;

namespace FinalGame.Classes.Character
{
    [Serializable]
    public class Player : INotifyPropertyChanged
    {

        
        int StartHp = 10;

        private String _EXPOutOfMax;
        private String _HpOutOfMax;
        private int _XPToLevel = 100;
        private int _CurrentGold = 100;
        private int _maxFloorReached = 0;
        private int _MaxHP;
        private string _Name;
        private int _HP;
        private int _level;
        private long _experience;
        private int _strength;
        private int _intelligence;
        private int _dexterity;
        private Weapon _equipedWeapon;
        private Armor _equipedArmor;
        private int _numUnusedStatPoints;

        public string EXPOutOfMax
        {
            get { return _EXPOutOfMax; }
            set
            {
                _EXPOutOfMax = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EXPOutOfMax"));
            }
        }
        public string HPOutofMax
        {
            get { return _HpOutOfMax; }
            set
            {
                _HpOutOfMax = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HPOutofMax"));
            }
        }
        public int XPToLevel
        {
            get { return _XPToLevel; }
            set
            {
                _XPToLevel = value;
                EXPOutOfMax = Experience + "/" + XPToLevel;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("XPToLevel"));
            }
        }
        public int CurrentGold
        {
            get { return _CurrentGold; }
            set
            {
                _CurrentGold = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentGold"));
            }
        }
        public int maxFloorReached
        {
            get { return _maxFloorReached; }
            set
            {
                _maxFloorReached = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("maxFloorReached"));
            }
        }
        public int MaxHP
        {
            get { return _MaxHP; }
            set
            {
                _MaxHP = value;

                HPOutofMax = HP + "/" + MaxHP;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MaxHP"));
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public int HP
        {
            get { return _HP; }
            set
            {
                _HP = value;
                HPOutofMax = HP + "/" + MaxHP;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HP"));
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Level"));
            }
        }
        public long Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;
                EXPOutOfMax = Experience + "/" + XPToLevel;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Experience"));
            }
        }
        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Strength"));
            }
        }
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Intelligence"));
            }
        }
        public int Dexterity 
        {
            get { return _dexterity; }
            set
            {
                _dexterity = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Dexterity"));
            }
        }
        public Weapon EquippedWeapon
        {
            get { return _equipedWeapon; }
            set
            {
                _equipedWeapon = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EquippedWeapon"));
            }
        }
        public Armor EquippedArmor
        {
            get { return _equipedArmor; }
            set
            {
                _equipedArmor = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EquippedArmor"));
            }
        }
        public int numUnusedStatPoints
        {
            get { return _numUnusedStatPoints; }
            set
            {
                _numUnusedStatPoints = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("numUnusedStatPoints"));
            }
        }
        public const int MAX_INVENTORY_SPACE = 50;

        public ObservableCollection<Consumable> itemInventory = new ObservableCollection<Consumable>();
        public ObservableCollection<Weapon> weaponInventory = new ObservableCollection<Weapon>();
        public ObservableCollection<Armor> armorInventory = new ObservableCollection<Armor>();

        public Player()
        {
            _CurrentGold = 0;
            Level = 1;
            MaxHP = StartHp;
            HP = MaxHP;
            HPOutofMax = HP + "/" + MaxHP;
            EXPOutOfMax = Experience + "/" + XPToLevel;
            Experience = 0;
            maxFloorReached = 0;
            numUnusedStatPoints = 10;
            Name = "Jamie";
            itemInventory = new ObservableCollection<Consumable>();
            weaponInventory = new ObservableCollection<Weapon>();
            armorInventory = new ObservableCollection<Armor>();

        }
        public void gainExperience(int xp)
        {
            Experience += xp;
            while (Experience >= XPToLevel)
            {
                levelUp();
            }
        }
        public void levelUp()
        {
            Level++;
            MaxHP +=  4;
            HP = MaxHP;
            numUnusedStatPoints += 2;
            Experience -= XPToLevel;
            XPToLevel += 25;
        }
        public void autoAssignStats()
        {
            Strength++;
            Intelligence++;
            Dexterity++;
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
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Sword, 0, "A starting sword.", "Basic Sword");
            }
            else if (Intelligence > Strength && Intelligence > Dexterity)
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Staff, 0, "A starting staff.", "Basic Staff");
            }
            else if (Dexterity > Intelligence && Dexterity > Strength)
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Bow, 0, "A starting bow.", "Basic Bow");
            }
            else
            {
                EquippedWeapon = new Weapon(Items.Type.Bronze, WeaponType.Sword, 0, "A starting sword.", "Basic S");
            }

            EquippedArmor = new Armor(Items.Type.Bronze, 0, "A starting set of armor.", "Basic Armor.");
        }
        public int Attack()
        {
            int damage;
            if (EquippedWeapon != null && EquippedWeapon.type == WeaponType.Sword)
            {
                damage=EquippedWeapon.StrengthModifier + ((int)(Strength * 0.5));
            }
            else if (EquippedWeapon != null && EquippedWeapon.type == WeaponType.Bow)
            {
                damage = EquippedWeapon.DexterityModifier + ((int)(Dexterity * 0.5));
            }
            else if (EquippedWeapon != null && EquippedWeapon.type == WeaponType.Staff)
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
                HP += ((Consumable)item).HealthRegen;
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
            }

            
        }
        public void EquipItem(Item item)
        {
            if (item.GetType().Equals(typeof(Weapon)))
            {
                EquippedWeapon = (Weapon)item;
            }
            else if (item.GetType().Equals(typeof(Armor)))
            {
                if (EquippedArmor != null)
                {
                    MaxHP -= EquippedArmor.HealthModifier;
                    HP -= EquippedArmor.HealthModifier;
                }
                EquippedArmor = (Armor)item;
                MaxHP += ((Armor)item).HealthModifier;
                HP += ((Armor)item).HealthModifier;
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}