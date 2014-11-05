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

namespace FinalGame.Classes.Game_Elements
{
    /// <summary>
    /// Interaction logic for inGame.xaml
    /// </summary>
    public partial class inGame : UserControl
    {
        public inGame(ref FinalGame.Classes.Character.Player p1)
        {
            InitializeComponent();

            playerStats.DataContext = p1;
            HP_XP.DataContext = p1;
            unUsedTalentPoints.DataContext = p1;
            charName.DataContext = p1;
            GoldAmount.DataContext = p1;

            armorBox.ItemsSource = p1.armorInventory;
            weaponBox.ItemsSource = p1.weaponInventory;
            consumeBox.ItemsSource = p1.itemInventory;
        }
        private void mute_Click(object sender, RoutedEventArgs e)
        {

        }
        private void plusStr_Click(object sender, RoutedEventArgs e)
        {

        }
        private void plusInt_Click(object sender, RoutedEventArgs e)
        {

        }
        private void plusDex_Click(object sender, RoutedEventArgs e)
        {

        }
        private void armorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void weaponBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void consumeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void useConsumable_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
