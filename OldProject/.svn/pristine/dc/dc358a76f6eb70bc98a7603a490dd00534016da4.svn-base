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
using FinalGame.Classes.Character;
namespace FinalGame.Classes.Game_Elements
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : UserControl
    {
        Player p1;
        public CharacterCreation(ref Player p1)
        {
            InitializeComponent();
            this.p1 = p1;
            playerStats.DataContext = p1;
            characterName.DataContext = p1;
            completeButton.IsEnabled = false;
        }

        private void mage_Click(object sender, RoutedEventArgs e)
        {
            p1.numUnusedStatPoints = 0;
            p1.Intelligence = 6;
            p1.Strength = 2;
            p1.Dexterity = 2;
        }
        private void archer_Click(object sender, RoutedEventArgs e)
        {
            p1.numUnusedStatPoints = 0;
            p1.Intelligence = 2;
            p1.Strength = 2;
            p1.Dexterity = 6;
        }
        private void warrior_Click(object sender, RoutedEventArgs e)
        {
            p1.numUnusedStatPoints = 0;
            p1.Intelligence = 2;
            p1.Strength = 6;
            p1.Dexterity = 2;
        }

        private void characterName_TextChanged(object sender, TextChangedEventArgs e)
        {
            p1.Name = characterName.Text;
            if (characterName.Text != "")
                completeButton.IsEnabled = true;
        }
    }
}
