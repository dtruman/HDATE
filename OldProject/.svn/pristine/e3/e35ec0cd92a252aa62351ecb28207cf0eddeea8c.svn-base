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
using MapTest.MapElements;
using WpfAnimatedGif;
using System.Windows.Media.Animation;
using System.Threading;

namespace MapTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Map testMap;
        bool battleStart = false;

        public MainWindow()
        {
            InitializeComponent();
            generateMap();
            
        }

        public void generateMap()
        {
            testMap = new Map();
            FloorNumber.Content = testMap.currentFloor;
            display();
        }
        public void display()
        {
            playArea.ColumnDefinitions.Clear();
            playArea.RowDefinitions.Clear();
            ColumnDefinition[] colDefs = new ColumnDefinition[testMap.x];
            RowDefinition[] rowDefs = new RowDefinition[testMap.y];
            testMap.populate();

            for (int i = 0; i < testMap.x; i++)
            {
                colDefs[i] = new ColumnDefinition();
                playArea.ColumnDefinitions.Add(colDefs[i]);
            }
            for (int i = 0; i < testMap.y; i++)
            {
                rowDefs[i] = new RowDefinition();
                playArea.RowDefinitions.Add(rowDefs[i]);
            }

            for (int i = 0; i < testMap.x; i++)
            {
                for (int j = 0; j < testMap.y; j++)
                {
                    playArea.Children.Add(testMap.layout[i][j]);
                    Grid.SetRow(testMap.layout[i][j], j);
                    Grid.SetColumn(testMap.layout[i][j], i);
                }
            }
        }

        public void battle()
        {
            playArea.ColumnDefinitions.Clear();
            playArea.RowDefinitions.Clear();

            ColumnDefinition[] colDefs = new ColumnDefinition[1];
            RowDefinition[] rowDefs = new RowDefinition[2];

            if (!battleStart)
            {
                Image img = new Image();

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("Resources/Start_Battle.gif", UriKind.Relative);
                image.EndInit();
                img.Source = image;
                ImageBehavior.SetAnimatedSource(img, image);
                //ImageBehavior.SetRepeatBehavior(img, new RepeatBehavior());

                playArea.Children.Add(img);
                battleStart = true;
            }
            else if (battleStart)
            {
                showBattleArea();
                //playArea.Children.Clear();
                //BitmapImage enemy = new BitmapImage();
                //enemy.BeginInit();
                //enemy.UriSource = new Uri("Resources/monster_Test.jpg", UriKind.Relative);
                //enemy.EndInit();

                //Image enemyImage = new Image();

                //enemyImage.Source = enemy;

                //rowDefs[0] = new RowDefinition();
                //playArea.RowDefinitions.Add(rowDefs[0]);
                //Grid.SetRow(enemyImage, 0);
                //playArea.Children.Add(enemyImage);

                //StackPanel battleStack=new StackPanel();

                //Button attack = new Button();
                //attack.Content = "DO THINGS";
                //attack.Click += DoThings_Clicked;
                //battleStack.Children.Add(attack);

                //rowDefs[1] = new RowDefinition();
                //playArea.RowDefinitions.Add(rowDefs[1]);
                //Grid.SetRow(battleStack, 1);
                //playArea.Children.Add(battleStack);
            }
        }

        private void keyPressed(object sender, KeyEventArgs e)
        {
            if (!battleStart)
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
            }
            if (testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type == TileType.end)
                generateMap();
            else if (testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type == TileType.monster)
            {
                battle();
            }
        }

        private void DoThings_Clicked(object sender, RoutedEventArgs e)
        {
            playArea.Children.Clear();
            playArea.ColumnDefinitions.Clear();
            playArea.RowDefinitions.Clear();
            ColumnDefinition[] colDefs = new ColumnDefinition[testMap.x];
            RowDefinition[] rowDefs = new RowDefinition[testMap.y];

            for (int i = 0; i < testMap.x; i++)
            {
                colDefs[i] = new ColumnDefinition();
                playArea.ColumnDefinitions.Add(colDefs[i]);
            }
            for (int i = 0; i < testMap.y; i++)
            {
                rowDefs[i] = new RowDefinition();
                playArea.RowDefinitions.Add(rowDefs[i]);
            }

            for (int i = 0; i < testMap.x; i++)
            {
                for (int j = 0; j < testMap.y; j++)
                {
                    playArea.Children.Add(testMap.layout[i][j]);
                    Grid.SetRow(testMap.layout[i][j], j);
                    Grid.SetColumn(testMap.layout[i][j], i);
                }
            }
            testMap.layout[testMap.playerPosition.x][testMap.playerPosition.y].type = TileType.open;

            battleStart = false;
        }
        public void showBattleArea()
        {
            playArea.Children.Clear();
            CombatGUI cg = new CombatGUI();
            playArea.Children.Add(cg);
            
        }
    }
}
