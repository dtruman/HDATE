using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeDiesAtTheEnd.Classes;
using HeDiesAtTheEnd.Classes.Character;
using HeDiesAtTheEnd.Classes.Monster;
using HeDiesAtTheEnd.Classes.Items;
namespace HeDiesAtTheEnd.Classes.Combat
{
    class CombatSystem
    {

        public void Battle(Player player1, Monster.Monster Monster1)
        {
            bool ValidInput = false;
            bool Flee = false;
            bool monsterdead = false;
            int damage = 0;
            while (!Flee && (player1.HP > 0 && !monsterdead))
            {
                Console.WriteLine("New Round");
                Console.WriteLine("Monster is dead: " + monsterdead);

                while (!ValidInput)
                {
                    Console.WriteLine(" Its your turn what do you want to do /n 1) Fight /n 2) Use Item /n 3)Flee");
                    string input = Console.ReadLine();
                    int choice;
                    if (int.TryParse(input, out choice))
                    {

                        if (choice == 1)
                        {
                            if (player1.EquippedWeapon.type == WeaponType.Staff)
                            {
                          
                                    damage = (int)Math.Round((1 - (0.01 * (player1.Intelligence - Monster1.intellect))) * player1.Attack());

                            }
                            else if (player1.EquippedWeapon.type == WeaponType.Bow)
                            {
                                    damage = (int)Math.Round((1 - (0.01 * (player1.Dexterity - Monster1.dexterity))) * player1.Attack());

                            }
                            else if (player1.EquippedWeapon.type == WeaponType.Sword)
                            {
                                    damage = (int)Math.Round((1 + (0.01 * (player1.Strength - Monster1.strength))) * player1.Attack());
                            }
             
                            monsterdead = Monster1.takeDamage(damage);
                            Console.WriteLine("You swing and hit the " + Monster1.type + " for " + damage + " Damage. Remaining hp: " + Monster1.hp);

                        }
                        if (choice == 2)
                        {
                            Classes.Items.Type conType = (Classes.Items.Type)((player1.Level % 12) / 2 + (player1.Level % 12) % 2);
                            int grade = player1.Level / 12;
                            Item consume = new Consumable(grade, conType , "uncreative", "Name");
                            player1.UseConsumable(consume);
                            Console.WriteLine(conType+"+"+ grade +" type consumable restored "+((Consumable)consume).HealthRegen+" hp. Hp is now "+player1.HP);
                        }
                        if (choice == 3)
                        {
                            Random rand = new Random();
                            int FleeTry = rand.Next(0, 11);
                            Console.WriteLine(FleeTry);
                            if (Monster1.Level > player1.Level)
                            {
                                if (FleeTry > 6)
                                {
                                    Flee = true;
                                }
                            }
                            if (Monster1.Level < player1.Level)
                            {
                                if (FleeTry > 3)
                                {
                                    Flee = true;
                                }
                            }
                            if (Monster1.Level == player1.Level)
                            {
                                if (FleeTry > 4)
                                {
                                    Flee = true;
                                }
                            }
                            Console.WriteLine(Flee);
                        }
                        ValidInput = true;
                        if (choice > 3)
                        {
                            ValidInput = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not valid input");
                    }
                }
                if (!monsterdead)
                {
                    if (Monster1.type == "Goblin")
                    {  
                            damage = (int)Math.Round((1 + (0.01 * (Monster1.dexterity - player1.Dexterity) / 10)) * Monster1.damage);
                    }
                    else if (Monster1.type == "Orc")
                    {
                        
                            damage = (int)Math.Round((1 + (0.01 * (Monster1.strength - player1.Strength) / 10)) * Monster1.damage);
                        
                    }
                    else if (Monster1.type == "Witch")
                    {
                            damage = (int)Math.Round((1 + (0.01 * (Monster1.intellect - player1.Intelligence)/10)) * Monster1.damage);
                    }
                    
                    player1.HP -= damage;
                    Console.WriteLine("The " + Monster1.type + " Swings and hits you for " + damage + " Damage. Remaining hp: " + player1.HP);
                    Console.WriteLine();
                }

                ValidInput = false;
            }
            if (!Flee)
            {
                if (monsterdead)
                {
                    player1.gainExperience(Monster1.experience);
                    Console.WriteLine("You have slain the enemy");

                }
                if (player1.HP <= 0)
                {
                    Console.WriteLine("The monster Has killed you. Told you he died at the end!");
                }
            }
        }
    }
}
