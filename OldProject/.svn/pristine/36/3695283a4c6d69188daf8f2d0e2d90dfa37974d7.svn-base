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
            
            //testCombat(1);
            //testCombat(5);
            testCombat(10);
            //testCombat(15);
            //testCombat(25);
            //testCombat(50);
            //testCombat(85);

            
        }
        private static int killCount = 0;
        private static void testCombat(int lvl)
        {
            Player p1 = new Player();
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Case: "+i);
                p1.testBalance(lvl, i);
                int totalKillCount = 0;
                for (int j = 0; j < 1000; j++)
                {
                    while (p1.HP > 0)
                    {
                        Monster monster = makeMonster(p1.Level);

                        battleTest(p1, monster);
                    }
                    p1.HP = p1.MaxHP;
                    totalKillCount += killCount;
                    killCount = 0;
                }
                p1.DisplayPlayer();
                Console.WriteLine("Total Kill Count: "+totalKillCount);
                Console.WriteLine("KDR: "+(totalKillCount/1000.0));
                Console.WriteLine();
            }
             
        }

        private static void battleTest(Player player1, Monster Monster1)
        {
            bool monsterdead = false;
            int damage = 0;
            while ((player1.HP > 0 && !monsterdead))
            {
                if (player1.EquippedWeapon.type == WeaponType.Staff)
                    {
                    
                            damage = (int)Math.Round((1 + (0.01 * (player1.Intelligence - Monster1.intellect))) * player1.Attack());
                    
                    }
                    else if (player1.EquippedWeapon.type == WeaponType.Bow)
                    {
                            damage = (int)Math.Round((1 + (0.01 * (player1.Dexterity - Monster1.dexterity))) * player1.Attack());
                    
                    }
                    else if (player1.EquippedWeapon.type == WeaponType.Sword)
                    {
                            damage = (int)Math.Round((1 + (0.01 * (player1.Strength - Monster1.strength))) * player1.Attack());
                    }
                    
                    monsterdead = Monster1.takeDamage(damage);

                if (!monsterdead)
                {
                    if (Monster1.type == "Goblin")
                    {  
                            damage = (int)Math.Round((1 + (0.02 * (Monster1.dexterity - player1.Dexterity))) * Monster1.damage);
                    }
                    else if (Monster1.type == "Orc")
                    {
                        
                            damage = (int)Math.Round((1 + (0.02 * (Monster1.strength - player1.Strength))) * Monster1.damage);
                        
                    }
                    else if (Monster1.type == "Witch")
                    {
                            damage = (int)Math.Round((1 + (0.02 * (Monster1.intellect - player1.Intelligence))) * Monster1.damage);
                    }
                    
                    player1.HP -= damage;
                
                }
            }
            if (monsterdead)
            {
                //player1.gainExperience(Monster1.experience);
                //Console.WriteLine("You have slain the enemy");
                killCount++;

            }
            if (player1.HP <= 0)
            {
                //Console.WriteLine("The "+ Monster1.type +" monster Has killed you. Told you he died at the end!");
                //Console.WriteLine("Dead! Kill Count: " +killCount);
            }
        }

        private static Monster makeMonster(int lvl){

            Random rGen = new Random();
            Monster newMon = new Goblin(lvl);
            switch (rGen.Next(0, 3))
            {
                case 0:
                    newMon = new Goblin(lvl);
                    break;
                case 1:
                    newMon = new Witch(lvl);
                    break;
                case 2:
                    newMon = new Orc(lvl);
                    break;
            }
            return newMon;
        }
    }
}