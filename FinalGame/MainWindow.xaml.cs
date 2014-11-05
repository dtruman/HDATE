using FinalGame.MapElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WpfAnimatedGif;
using System.Windows.Media.Animation;
using System.Threading;
using FinalGame.Classes.Character;
using FinalGame.Classes.Items;
using FinalGame.Classes.Game_Elements;
using System.Collections.ObjectModel;
using System.Media;

namespace FinalGame
{
    public partial class MainWindow : Window
    {
        public float trapDamagePercent = .1f;

        ObservableCollection<Weapon> shopWeaponInventory = new ObservableCollection<Weapon>();
        ObservableCollection<Armor> shopArmorInventory = new ObservableCollection<Armor>();
        ObservableCollection<Consumable> shopConsumableInventory = new ObservableCollection<Consumable>();

        Map testMap;
        public Player p1;
        public CombatGUI CombatGUI;
        public inGame inGameScreen;
        public StartScreen startScreen;
        public DeathScreen deathScreen;
        public CharacterCreation charCreation;
        Scenes currentScene;
        EndLevelWin ELW;
        MessageWindow MW;
        bool playSound = true;
        enum Scenes
        {
            Ingame,
            Battling,
            Start,
            Dead,
            CharacterCreation,
        }
        SoundPlayer sp = new SoundPlayer();

        public MainWindow()
        {
            InitializeComponent();
            p1 = new Player();
            hookUpInterface();

            
            startGame();
        }
        public void startGame()
        {
            screenArea.Children.Clear();
            currentScene = Scenes.Start;
            screenArea.Children.Add(startScreen);

            sp.SoundLocation = "Resources/HDATE Main Theme.wav";
            if (playSound)
            {
                sp.PlayLooping();
            }
        }
        public void hookUpInterface()
        {
            inGameScreen = new inGame(ref p1);
            charCreation = new CharacterCreation(ref p1);
            startScreen = new StartScreen();
            deathScreen = new DeathScreen();

            startScreen.NewGame.Click += NewGame_Click;
            startScreen.LoadGame.Click += loadGame_Click;

            deathScreen.StartScreen.Click += StartGame_Click;
            deathScreen.EndGame.Click+=EndGame_Click;

            charCreation.strUp.Click += plusStr_Click;
            charCreation.dexUp.Click += plusDex_Click;
            charCreation.intUp.Click += plusInt_Click;
            charCreation.strdwn.Click += strdwn_Click;
            charCreation.dexdwn.Click += dexdwn_Click;
            charCreation.intdwn.Click += intdwn_Click;
            charCreation.completeButton.Click += completeButton_Click;

            inGameScreen.muteButton.Click += muteSound_Click;

            inGameScreen.armorBox.SelectionChanged += armorBox_SelectionChanged;
            inGameScreen.weaponBox.SelectionChanged += weaponBox_SelectionChanged;
            inGameScreen.useConsumable.Click += useConsumable_Click;

            inGameScreen.plusDex.Click += plusDex_Click;
            inGameScreen.plusInt.Click += plusInt_Click;
            inGameScreen.plusStr.Click += plusStr_Click;

            inGameScreen.Shop1.sellWeapon.Click += sellWeapon_Click;
            inGameScreen.Shop1.sellArmor.Click += sellArmor_Click;
            inGameScreen.Shop1.sellConsumable.Click += sellConsumable_Click;

            inGameScreen.Shop1.buyWeapon.Click += buyWeapon_Click;
            inGameScreen.Shop1.buyArmor.Click += buyArmor_Click;
            inGameScreen.Shop1.buyConsumable.Click += buyConsumable_Click;

            inGameScreen.Shop1.weaponBox.ItemsSource = p1.weaponInventory;
            inGameScreen.Shop1.armorBox.ItemsSource = p1.armorInventory;
            inGameScreen.Shop1.consumeBox.ItemsSource = p1.itemInventory;

            inGameScreen.Shop1.weaponBox.SelectionChanged += storeWeaponBox_SelectionChanged;
            inGameScreen.Shop1.armorBox.SelectionChanged += storeArmorBox_SelectionChanged;
            inGameScreen.Shop1.consumeBox.SelectionChanged += storeConsumeBox_SelectionChanged;

            inGameScreen.Shop1.shopWeaponBox.SelectionChanged += shopWeaponBox_SelectionChanged;
            inGameScreen.Shop1.shopArmorBox.SelectionChanged += shopArmorBox_SelectionChanged;
            inGameScreen.Shop1.shopConsumeBox.SelectionChanged += shopConsumeBox_SelectionChanged;

            inGameScreen.Shop1.shopWeaponBox.ItemsSource = shopWeaponInventory;
            inGameScreen.Shop1.shopArmorBox.ItemsSource = shopArmorInventory;
            inGameScreen.Shop1.shopConsumeBox.ItemsSource = shopConsumableInventory;

            inGameScreen.Shop1.playerGold.DataContext = p1;

            inGameScreen.Shop1.Visibility = Visibility.Hidden;
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            startGame();
        }
        public void generateMap(int floorNumber)
        {
            testMap = new Map(floorNumber);
            testMap.populate();
            inGameScreen.FloorNumber.DataContext = testMap;
        }
        public void displayMap()
        {
            sp.SoundLocation = "Resources/HDATE Explore Theme.wav";
            if (playSound)
            {
                sp.PlayLooping();
            }
            inGameScreen.playArea.ColumnDefinitions.Clear();
            inGameScreen.playArea.RowDefinitions.Clear();
            ColumnDefinition[] colDefs = new ColumnDefinition[testMap.x];
            RowDefinition[] rowDefs = new RowDefinition[testMap.y];

            for (int i = 0; i < testMap.x; i++)
            {
                colDefs[i] = new ColumnDefinition();
                inGameScreen.playArea.ColumnDefinitions.Add(colDefs[i]);
            }
            for (int i = 0; i < testMap.y; i++)
            {
                rowDefs[i] = new RowDefinition();
                inGameScreen.playArea.RowDefinitions.Add(rowDefs[i]);
            }

            for (int i = 0; i < testMap.x; i++)
            {
                for (int j = 0; j < testMap.y; j++)
                {
                    inGameScreen.playArea.Children.Add(testMap.layout[i][j]);
                    Grid.SetRow(testMap.layout[i][j], j);
                    Grid.SetColumn(testMap.layout[i][j], i);
                }
            }
            currentScene = Scenes.Ingame;
        }
        public void battle()
        {
            if (playSound)
            {
                sp.Stop();
            }
            sp.SoundLocation = "Resources/HDATE Begin Battle Theme.wav";
            currentScene = Scenes.Battling;
            inGameScreen.armorBox.IsEnabled = false;
            inGameScreen.weaponBox.IsEnabled = false;

            clearPlayArea();
            CombatGUI = new CombatGUI(ref p1,testMap.currentFloor);
            CombatGUI.FleeButton.Click += new RoutedEventHandler(fleeButton_Click);
            CombatGUI.AtkButton.Click += new RoutedEventHandler(attkButton_Click);
            inGameScreen.playArea.Children.Add(CombatGUI);

            if (testMap.currentFloor % 5 == 0)
            {
                
                sp.Stop();
                sp.SoundLocation = "Resources/HDATE Boss Theme.wav";
                if (playSound)
                {
                    sp.PlayLooping();
                }
            }
            else
            {
                if (playSound)
                {
                    sp.PlaySync();
                }
                sp.Stop();
                sp.SoundLocation = "Resources/HDATE Battle Theme.wav";
                if (playSound)
                {
                    sp.PlayLooping();
                }
            }
        }
        private void endCombat(bool monsterDead)
        {
            inGameScreen.armorBox.IsEnabled = true;
            inGameScreen.weaponBox.IsEnabled = true;
            clearPlayArea();

            if (monsterDead)
            {
                sp.SoundLocation = "Resources/HDATE End Battle Theme.wav";
                if (playSound)
                {
                    sp.Stop();
                    sp.Play();
                }
                Item droppedItem = CombatGUI.m1.getDrop();
                string message = "You defeated a Monster! A " + droppedItem.ItemName + "\n\t has been added to your Inventory.";
                p1.gainExperience(CombatGUI.m1.experience);
                p1.AddItemToInventory(droppedItem);
                p1.CurrentGold += CombatGUI.m1.getGoldDrop();
                hookUpLootMW(message);
            }
            else
            {
                p1.HP -= (int)(p1.MaxHP * .1);
            }

            displayMap();
            currentScene = Scenes.Ingame;
        }
        private void hookUpLootMW(string message)
        {
            Image img = new Image();
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri("/Resources/LootChectImage.jpg", UriKind.Relative);
            imageSource.EndInit();
            img.Source = imageSource;
            MW = new MessageWindow(message, img);
            MW.Owner = this;
            MW.Show();
        }
        private void hookUpTrapMW(string message)
        {
            Image img = new Image();
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri("/Resources/TrapMessageImage.jpg", UriKind.Relative);
            imageSource.EndInit();
            img.Source = imageSource;
            MW = new MessageWindow(message, img);
            MW.Owner = this;
            MW.Show();
        }
        private void hookUpBasicMW(string message)
        {
            MW = new MessageWindow(message);
            MW.Owner = this;
            MW.Show();
        }
        private void hookUpELW()
        {
            ELW = new EndLevelWin();
            ELW.Owner = this;
            ELW.selectedLevel.Click += ELW_SelectedLevel_Click;
            ELW.saveButton.Click += ELW_SaveGame_Click;
            ELW.maxLevel.Click += ELW_MaxLevel_Click;
        }
        private void clearScreenArea()
        {
            screenArea.Children.Clear();
        }
        private void clearPlayArea()
        {
            inGameScreen.playArea.Children.Clear();
            inGameScreen.playArea.ColumnDefinitions.Clear();
            inGameScreen.playArea.RowDefinitions.Clear();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
            startNewGame();
        }
        private void loadGame_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
            p1 = loadPlayer();
            if(p1 != null)
                startLoadedGame();
        }

        public Player loadPlayer()
        {
            Player temp = null;

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            Stream myStream;
            dlg.Filter = "He Dies At The End (.hdate) | *.hdate";

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK == true)
            {
                if ((myStream = dlg.OpenFile()) != null)
                {
                    IFormatter formatter = new BinaryFormatter();
                    temp = (Player)formatter.Deserialize(myStream);
                    myStream.Close();
                }
            }
            return temp;
        }
        public void SavePlayer()
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            Stream myStream;
            dlg.Filter = "He Dies At The End (.hdate) | *.hdate";
            

            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK == true)
                if ((myStream = dlg.OpenFile()) != null)
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(myStream, p1);
                    myStream.Close();
                }
        }
        public void startNewGame()
        {
            sp.SoundLocation = "Resources/HDATE Main Theme.wav";
            if (playSound)
            {
                sp.PlayLooping();
            }
            currentScene = Scenes.CharacterCreation;

            p1 = new Player();
            hookUpInterface();


            clearPlayArea();
            screenArea.Children.Add(charCreation);
        }
        public void startLoadedGame()
        {
            sp.SoundLocation = "Resources/HDATE Main Theme.wav";
            if (playSound)
            {
                sp.PlayLooping();
            }
            inGameScreen = new inGame(ref p1);
            hookUpInterface();
            currentScene = Scenes.Ingame;

            clearPlayArea();
            generateMap(0);
            displayMap();
            screenArea.Children.Add(inGameScreen);
        }

        bool shopIsReadyToReset = true;
        //navigation logic
        private void keyPressed(object sender, KeyEventArgs e)
        {
            if (currentScene == Scenes.Ingame)
            {

                switch (e.Key)
                {
                    case Key.W:
                        testMap.playerMoveUp();
                        break;
                    case Key.A:
                        testMap.playerMoveLeft();
                        break;
                    case Key.S:
                        testMap.playerMoveDown();
                        break;
                    case Key.D:
                        testMap.playerMoveRight();
                        break;
                }

                if (testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type == TileType.monster)
                {
                    battle();
                    if (testMap.currentFloor % 5 != 0)
                        testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type = TileType.open;
                    else
                    {
                        testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y - 1].type = TileType.end;
                        testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type = TileType.open;
                    }
                           
                }

                if (testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type == TileType.end)
                {
                    shopIsReadyToReset = true;
                    if (p1.maxFloorReached != 0)
                    {
                        hookUpELW();
                        ELW.levelSlider.Maximum = p1.maxFloorReached;
                        ELW.Show();
                    }
                    else
                    {
                        p1.maxFloorReached = 1;
                        generateMap(1);
                        displayMap();
                    }
                }

                if (testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type == TileType.trap)
                {
                    testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type = TileType.triggeredTrap;
                    p1.HP -= (int)(p1.MaxHP * trapDamagePercent);

                    string message = "You stepped on a trap! \n\tHaha you fool! Take " + (int)(p1.MaxHP * trapDamagePercent) + " damage!";
                    hookUpTrapMW(message);
                }
                if (p1.HP <= 0)
                {
                    sp.Stop();
                    sp.SoundLocation = "Resources/Death Theme.wav";
                    if (playSound)
                    {
                        sp.PlayLooping();
                    }
                    clearScreenArea();

                    deathScreen.characterName.Content = inGameScreen.charName.Content;
                    screenArea.Children.Clear();
                    currentScene = Scenes.Dead;
                    screenArea.Children.Add(deathScreen);
                }

                if (testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type == TileType.store || testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type == TileType.npc)
                {

                    inGameScreen.Shop1.Visibility = Visibility.Visible;
 
                    if (shopIsReadyToReset)
                    {
                        shopIsReadyToReset = false;
                        int itemLevel = (p1.maxFloorReached < p1.Level ? p1.maxFloorReached : p1.Level);


                        clearShopItems();

                        if (itemLevel == 0)
                            itemLevel = 1;

                        if (itemLevel > 2)
                            assignShopItems(itemLevel - 2);
                        assignShopItems(itemLevel);
                        Random rGen = new Random();
                        if (rGen.Next(0, 15) > 12)
                        {
                            assignShopItems(itemLevel + 2);
                        }
                    }
                }
                else
                {
                    inGameScreen.Shop1.Visibility = Visibility.Hidden;
                    
                }
            }

        }
        private void clearShopItems()
        {
            shopArmorInventory.Clear();
            shopConsumableInventory.Clear();
            shopWeaponInventory.Clear();
        }
        private void assignShopItems(int lvl)
        {
            Classes.Items.Type itemType = (Classes.Items.Type)((lvl % 12) / 2 + ((lvl % 12) % 2) + ((lvl % 12 == 0) ? 6 : 0));
            int grade = 0;
            for (int i = 0; i < lvl; i += 12)
                grade = i / 12;
            
            assignShopArmor(grade, itemType);
            assignShopWeapons(grade, itemType);
            assignShopConsumables(grade, itemType);
        }
        private void assignShopArmor(int grade, Classes.Items.Type itemType)
        {
            shopArmorInventory.Add(new Armor(itemType, grade, "Some " + itemType + "+" + grade + " armor! Enjoy it!", (grade == 0 ? "" : "+" + grade + " ") + itemType + " armor"));
        }
        private void assignShopWeapons(int grade, Classes.Items.Type itemType)
        {
            Random rGen = new Random();
            WeaponType wepType = (Classes.Items.WeaponType)rGen.Next(1, 4);
            shopWeaponInventory.Add(new Weapon(itemType, wepType, grade, "A " + itemType + "+" + grade + " " + wepType + "! Enjoy it!", (grade == 0 ? "" : "+" + grade + " ") + itemType + " " + wepType));
        }
        private void assignShopConsumables(int grade, Classes.Items.Type itemType)
        {
            shopConsumableInventory.Add(new Consumable(grade, itemType, "A " + itemType + "+" + grade + " health potion! Enjoy it!", (grade == 0 ? "" : "+" + grade + " ") + itemType + " health potion"));
        }

        private void armorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (p1.armorInventory.Count > 0 && ((ComboBox)sender).SelectedIndex >= 0)
            {
                p1.EquipItem(p1.armorInventory[((ComboBox)sender).SelectedIndex]);
            }
            
        }
        private void weaponBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (p1.weaponInventory.Count > 0 && ((ComboBox)sender).SelectedIndex >= 0)
            {
                p1.EquipItem(p1.weaponInventory[((ComboBox)sender).SelectedIndex]);
            }
        }
        private void useConsumable_Click(object sender, RoutedEventArgs e)
        {
            if (inGameScreen.consumeBox.HasItems && inGameScreen.consumeBox.SelectedIndex >= 0)
            {
                int selectedIndex = inGameScreen.consumeBox.SelectedIndex;
                p1.UseConsumable(p1.itemInventory[selectedIndex]);
            }
            inGameScreen.consumeBox.SelectedIndex = 0;
        }

        private void fleeButton_Click(object sender, RoutedEventArgs e)
        {
            endCombat(false);
            if (p1.HP <= 0)
            {
                sp.Stop();
                sp.SoundLocation = "Resources/Death Theme.wav";
                if (playSound)
                {
                    sp.PlayLooping();
                }
                clearScreenArea();
                deathScreen.characterName.Content = inGameScreen.charName.Content;
                currentScene = Scenes.Dead;
                screenArea.Children.Add(deathScreen);
            }
        }
        private void attkButton_Click(object sender, RoutedEventArgs e)
        {
            int damage = 0;

            if (p1.EquippedWeapon != null && p1.EquippedWeapon.type == WeaponType.Staff)
            {
                float dmgmod = (float)((1 - (0.01 * (CombatGUI.m1.intellect/50))));
                if (dmgmod < .5)
                {
                    dmgmod = (float).5;
                }
                damage = (int)Math.Round(dmgmod * (p1.Attack()/2));

            }
            else if (p1.EquippedWeapon != null && p1.EquippedWeapon.type == WeaponType.Bow)
            {

                float dmgmod = (float)((1 - (0.01 * (CombatGUI.m1.dexterity / 50))));
                if (dmgmod < .5)
                {
                    dmgmod = (float).5;
                }
                damage = (int)Math.Round(dmgmod * (p1.Attack() / 2));

            }
            else if (p1.EquippedWeapon != null && p1.EquippedWeapon.type == WeaponType.Sword)
            {
                float dmgmod = (float)((1 - (0.01 * (CombatGUI.m1.strength / 50))));
                if (dmgmod < .5)
                {
                    dmgmod = (float).5;
                }
                damage = (int)Math.Round(dmgmod * (p1.Attack() / 2));

            }
            else
            {
                damage = p1.Attack()/2;
            }

            if (CombatGUI.m1.takeDamage(damage))
                endCombat(true);
            else
            {
                if (CombatGUI.m1.type == "dexMonster")
                {
                    float dmgmod=(float)(1 - (0.01 * (p1.Dexterity/50)));
                    if (dmgmod < .5)
                    {
                        dmgmod = (float).5;
                    }
                    damage = (int)Math.Round((dmgmod* (CombatGUI.m1.damage/2+(.01*CombatGUI.m1.Level))));
                    if (damage < 1)
                    {
                        damage = 1;
                    }
                }
                else if (CombatGUI.m1.type == "strMonster")
                {
                    float dmgmod = (float)(1 - (0.01 * (p1.Strength/50)));
                    if (dmgmod < .5)
                    {
                        dmgmod = (float).5;
                    }
                    damage = (int)Math.Round((dmgmod * (CombatGUI.m1.damage / 2 + (.01 * CombatGUI.m1.Level))));
                    if (damage < 1)
                    {
                        damage = 1;
                    }
                }
                else if (CombatGUI.m1.type == "intMonster")
                {
                    float dmgmod=(float)(1 - (0.01 * (p1.Intelligence/50)));
                    if (dmgmod < .5)
                    {
                        dmgmod = (float).5;
                    }
                    damage = (int)Math.Round((dmgmod * (CombatGUI.m1.damage / 2 + (.01 * CombatGUI.m1.Level))));
                    if (damage < 1)
                    {
                        damage = 1;
                    }
                }

                p1.HP -= damage;
            }

            if (p1.HP <= 0)
            {
                sp.Stop();
                sp.SoundLocation = "Resources/Death Theme.wav";
                if (playSound)
                {
                    sp.PlayLooping();
                }
                clearScreenArea();
                deathScreen.characterName.Content = inGameScreen.charName.Content;
                currentScene = Scenes.Dead;
                screenArea.Children.Add(deathScreen);
            }
        }

        private void plusStr_Click(object sender, RoutedEventArgs e)
        {
            if (p1.numUnusedStatPoints > 0)
            {
                p1.Strength += 1;
                p1.numUnusedStatPoints -= 1;
            }
        }
        private void plusInt_Click(object sender, RoutedEventArgs e)
        {
            if (p1.numUnusedStatPoints > 0)
            {
                p1.Intelligence += 1;
                p1.numUnusedStatPoints -= 1;
            }
        }
        private void plusDex_Click(object sender, RoutedEventArgs e)
        {

            if (p1.numUnusedStatPoints > 0)
            {
                p1.Dexterity += 1;
                p1.numUnusedStatPoints -= 1;
            }
        }
        private void intdwn_Click(object sender, RoutedEventArgs e)
        {
            if (p1.Intelligence != 0)
            {
                p1.numUnusedStatPoints++;
                p1.Intelligence -= 1;
            }
        }
        private void dexdwn_Click(object sender, RoutedEventArgs e)
        {
            if (p1.Dexterity != 0)
            {
                p1.numUnusedStatPoints++;
                p1.Dexterity -= 1;
            }
        }
        private void strdwn_Click(object sender, RoutedEventArgs e)
        {
            if (p1.Strength != 0)
            {
                p1.numUnusedStatPoints++;
                p1.Strength -= 1;
            }
        }

        private void muteSound_Click(object sender, RoutedEventArgs e)
        {
            playSound = !playSound;
            if (!playSound) sp.Stop();
            else
            {
                sp.PlayLooping();
            }
        }

        private void completeButton_Click(object sender, RoutedEventArgs e)
        {
            p1.AddItemToInventory(new Armor(Classes.Items.Type.Bronze, 0, "", "Bronze Armor"));

            if (p1.Strength > p1.Intelligence && p1.Strength > p1.Dexterity)
                p1.AddItemToInventory(new Weapon(Classes.Items.Type.Bronze, WeaponType.Sword, 0, "", "Bronze Sword"));
            else if(p1.Dexterity > p1.Strength && p1.Dexterity > p1.Intelligence)
                p1.AddItemToInventory(new Weapon(Classes.Items.Type.Bronze, WeaponType.Bow, 0, "", "Bronze Bow"));
            else if(p1.Intelligence > p1.Strength && p1.Intelligence > p1.Dexterity)
                p1.AddItemToInventory(new Weapon(Classes.Items.Type.Bronze, WeaponType.Staff, 0, "", "Bronze Staff"));
            else
                p1.AddItemToInventory(new Weapon(Classes.Items.Type.Bronze, WeaponType.Sword, 0, "", "Bronze Sword"));

            inGameScreen.charName.Content = p1.Name;
            currentScene = Scenes.Ingame;
            clearPlayArea();
            generateMap(0);
            displayMap();
            screenArea.Children.Add(inGameScreen);
        }

        private void ELW_SelectedLevel_Click(object sender, RoutedEventArgs e)
        {
            generateMap((int)ELW.levelSlider.Value);
            displayMap();
            ELW.Close();
        }
        private void ELW_SaveGame_Click(object sender, RoutedEventArgs e)
        {
            SavePlayer();
        }
        private void ELW_MaxLevel_Click(object sender, RoutedEventArgs e)
        {
            p1.maxFloorReached++;
            generateMap(p1.maxFloorReached);
            displayMap();
            ELW.Close();
        }

        private void sellWeapon_Click(object sender, RoutedEventArgs e)
        {
            if (inGameScreen.Shop1.weaponBox.HasItems && inGameScreen.Shop1.weaponBox.SelectedIndex >= 0)
            {
                int selectedIndex = inGameScreen.Shop1.weaponBox.SelectedIndex;
                Weapon item = new Weapon(p1.weaponInventory[selectedIndex].ItemType, p1.weaponInventory[selectedIndex].type, p1.weaponInventory[selectedIndex].Grade, p1.weaponInventory[selectedIndex].ItemDescription, p1.weaponInventory[selectedIndex].ItemName);
                int val = (int)(0.5 * ItemValue(item.Grade, item.ItemType));
                p1.CurrentGold += (int)(.5 * val);

                if(p1.weaponInventory[selectedIndex].Equals(p1.EquippedWeapon))
                {
                    p1.EquippedWeapon = new Weapon(0, 0, 0, "", "");
                }

                p1.RemoveItemFromInventory(p1.weaponInventory[selectedIndex]);
            }
            inGameScreen.Shop1.weaponBox.SelectedIndex = 0;
        }
        private void sellArmor_Click(object sender, RoutedEventArgs e)
        {
            if (inGameScreen.Shop1.armorBox.HasItems && inGameScreen.Shop1.armorBox.SelectedIndex >= 0)
            {
                int selectedIndex = inGameScreen.Shop1.armorBox.SelectedIndex;
                Armor item = new Armor(p1.armorInventory[selectedIndex].ItemType, p1.armorInventory[selectedIndex].Grade, p1.armorInventory[selectedIndex].ItemDescription, p1.armorInventory[selectedIndex].ItemName);
                int val = (int)(0.5 * ItemValue(item.Grade, item.ItemType));
                p1.CurrentGold += (int)(.5 * val);

                if (p1.armorInventory[selectedIndex].Equals(p1.EquippedArmor))
                {
                    p1.EquippedArmor = new Armor(0, 0, "", "");
                }

                p1.RemoveItemFromInventory(p1.armorInventory[selectedIndex]);
            }
            inGameScreen.Shop1.armorBox.SelectedIndex = 0;
        }
        private void sellConsumable_Click(object sender, RoutedEventArgs e)
        {
            if (inGameScreen.Shop1.consumeBox.HasItems && inGameScreen.Shop1.consumeBox.SelectedIndex >= 0)
            {
                int selectedIndex = inGameScreen.Shop1.consumeBox.SelectedIndex;
                Consumable item = new Consumable(p1.itemInventory[selectedIndex].Grade, p1.itemInventory[selectedIndex].ItemType, p1.weaponInventory[selectedIndex].ItemDescription, p1.weaponInventory[selectedIndex].ItemName);
                int val = (int)(0.5 * ItemValue(item.Grade, item.ItemType));
                p1.CurrentGold += (int)(.5 * val);
                p1.RemoveItemFromInventory(p1.itemInventory[selectedIndex]);
            }
            inGameScreen.Shop1.consumeBox.SelectedIndex = 0;
        }

        private void buyWeapon_Click(object sender, RoutedEventArgs e)
        {
            if (inGameScreen.Shop1.shopWeaponBox.HasItems && inGameScreen.Shop1.shopWeaponBox.SelectedIndex >= 0)
            {
                Item currItem = (Item)inGameScreen.Shop1.shopWeaponBox.SelectedItem;
                int itemValue = ItemValue(currItem.Grade, currItem.ItemType);
                if (p1.CurrentGold >= itemValue)
                {
                    if (p1.weaponInventory.Count < Player.MAX_INVENTORY_SPACE)
                    {
                        p1.CurrentGold -= itemValue;
                        p1.AddItemToInventory(currItem);
                    }
                    else
                    {
                        hookUpBasicMW("No Room in Inventory");

                    }
                }
                else
                {
                    hookUpBasicMW("You do not have enough gold.");
                }
            }
        }
        private void buyArmor_Click(object sender, RoutedEventArgs e)
        {
            if (inGameScreen.Shop1.shopArmorBox.HasItems && inGameScreen.Shop1.shopArmorBox.SelectedIndex >= 0)
            {
                Item currItem = (Item)inGameScreen.Shop1.shopArmorBox.SelectedItem;
                int itemValue = ItemValue(currItem.Grade, currItem.ItemType);
                if (p1.CurrentGold >= itemValue)
                {
                    if (p1.armorInventory.Count < Player.MAX_INVENTORY_SPACE)
                    {
                        p1.CurrentGold -= itemValue;
                        p1.AddItemToInventory(currItem);
                    }
                    else
                    {
                      
                        hookUpBasicMW("No Room in Inventory");

                    }
                }
                else
                {
                   
                    hookUpBasicMW("You do not have enough gold.");
                }
            }
        }
        private void buyConsumable_Click(object sender, RoutedEventArgs e)
        {
            if (inGameScreen.Shop1.shopConsumeBox.HasItems && inGameScreen.Shop1.shopConsumeBox.SelectedIndex >= 0)
            {
                Item currItem = (Item)inGameScreen.Shop1.shopConsumeBox.SelectedItem;
                int itemValue = ItemValue(currItem.Grade, currItem.ItemType);
                if (p1.CurrentGold >= itemValue)
                {
                    if (p1.itemInventory.Count < Player.MAX_INVENTORY_SPACE)
                    {
                        p1.CurrentGold -= itemValue;
                        p1.AddItemToInventory(currItem);
                    }
                    else
                    {
                        
                        hookUpBasicMW("No Room in Inventory");

                    }
                }
                else
                {
                    
                    hookUpBasicMW("You do not have enough gold.");
                }
            }
        }

        private void storeWeaponBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(inGameScreen.Shop1.weaponBox.SelectedIndex) == -1)
            {
                inGameScreen.Shop1.weaponSellCost.Content = "Sell for -  ";
            }
            else
            {
                int val = (int)(.5*ItemValue(((Item)inGameScreen.Shop1.weaponBox.SelectedItem).Grade, ((Item)inGameScreen.Shop1.weaponBox.SelectedItem).ItemType));
                inGameScreen.Shop1.weaponSellCost.Content = "Sell for -  " + val.ToString();
            }
        }
        private void storeArmorBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(inGameScreen.Shop1.armorBox.SelectedIndex) == -1)
            {
                inGameScreen.Shop1.armorSellCost.Content = "Sell for -  ";
            }
            else
            { 
                int val = (int)( .5 * ItemValue(((Item)inGameScreen.Shop1.armorBox.SelectedItem).Grade, ((Item)inGameScreen.Shop1.armorBox.SelectedItem).ItemType));
                inGameScreen.Shop1.armorSellCost.Content = "Sell for -  " + val.ToString();
            }
        }

        private void storeConsumeBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(inGameScreen.Shop1.consumeBox.SelectedIndex) == -1)
            {
                inGameScreen.Shop1.armorSellCost.Content = "Sell for -  ";
            }
            else
            {
                int val = (int)(.5 *ItemValue(((Item)inGameScreen.Shop1.consumeBox.SelectedItem).Grade, ((Item)inGameScreen.Shop1.consumeBox.SelectedItem).ItemType));
                inGameScreen.Shop1.consumableSellCost.Content = "Sell for -  " + val.ToString();
            }
        }
        private void shopWeaponBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0)
            {
                int val = ItemValue(((Item)inGameScreen.Shop1.shopWeaponBox.SelectedItem).Grade, ((Item)inGameScreen.Shop1.shopWeaponBox.SelectedItem).ItemType);
                inGameScreen.Shop1.weaponBuyCost.Content = "Buy for -  " + val.ToString();
            }
            else
            {
                inGameScreen.Shop1.weaponBuyCost.Content = "Buy for -  ";
            }
        }
        private void shopArmorBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0)
            {
                int val = ItemValue(((Item)inGameScreen.Shop1.shopArmorBox.SelectedItem).Grade, ((Item)inGameScreen.Shop1.shopArmorBox.SelectedItem).ItemType);
                inGameScreen.Shop1.armorBuyCost.Content = "Buy for -  " + val.ToString();
            }
            else
            {
                inGameScreen.Shop1.armorBuyCost.Content = "Buy for -  ";
            }
        }

        private void shopConsumeBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0)
            {
                int val = ItemValue(((Item)inGameScreen.Shop1.shopConsumeBox.SelectedItem).Grade, ((Item)inGameScreen.Shop1.shopConsumeBox.SelectedItem).ItemType);
                inGameScreen.Shop1.consumableBuyCost.Content = "Buy for -  " + val.ToString();
            }
            else
            {
                inGameScreen.Shop1.consumableBuyCost.Content = "Buy for -  ";
            }
        }

        private int ItemValue(int grade, Classes.Items.Type type)
        {
            int value = ((int)Classes.Items.Type.Dragon * 2 * grade) + (int)type * 2;

            return value;
        }
    }
}
