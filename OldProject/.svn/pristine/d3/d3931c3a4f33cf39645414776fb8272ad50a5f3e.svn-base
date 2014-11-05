using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HeDiesAtTheEnd.Classes.Items;
using HeDiesAtTheEnd.Classes.Character;
using HeDiesAtTheEnd.Classes.Monster;
using HeDiesAtTheEnd.Classes.Combat;
namespace HeDiesAtTheEnd
{
    class Program
    {

        static void Main(string[] args)
        {
            Player test = new Player();

            test.DisplayPlayer();

            //test.levelUp();
            //test.levelUp();
            //test.levelUp();


            Weapon testWeapon = new Weapon(HeDiesAtTheEnd.Classes.Items.Type.Mithril, WeaponType.Sword, 9001, "Awesome sword used for testing.", "Super awesome sword of awesome");

            test.AddItemToInventory(testWeapon);

            test.EquipItem(test.weaponInventory[0]);
            Console.WriteLine(test.Name + " equipped a " + test.EquippedWeapon.ItemName);

            Console.WriteLine();

            test.EquipItem(test.weaponInventory[0]);
            Console.WriteLine(test.Name + " equipped a " + test.EquippedWeapon.ItemName);

            Console.WriteLine();


            Console.WriteLine();
            Armor testArmor = new Armor(Classes.Items.Type.Mithril, 9001, "Awesome armor used for testing.", "Super awesome armor of awesome");

            test.AddItemToInventory(testArmor);

            test.EquipItem(test.armorInventory[0]);
            Console.WriteLine(test.Name + " equipped a " + test.EquippedArmor.ItemName);

            Console.WriteLine();

            test.EquipItem(test.armorInventory[0]);
            Console.WriteLine(test.Name + " equipped a " + test.EquippedArmor.ItemName);

            Console.WriteLine();


            Console.WriteLine();
            Consumable testConsumable = new Consumable(0, Classes.Items.Type.Bronze, "A base potion for testing.", "Base potion of not quite awesome");

            test.AddItemToInventory(testConsumable);

            test.EquipItem(test.itemInventory[0]);


            Console.WriteLine();
            Console.WriteLine(test.Name + " health: " + test.HP);
            test.HP -= 9;
            Console.WriteLine(test.Name + " lost 9 health.");
            Console.WriteLine(test.Name + " health: " + test.HP);
            Console.WriteLine();

            Console.WriteLine(test.Name + " used a " + test.itemInventory[0].ItemName + " and gained " + test.itemInventory[0].HealthRegen + " health.");
            test.UseConsumable(test.itemInventory[0]);
            Console.WriteLine(test.Name + " health: " + test.HP);
        }
    }
}