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
using System.Windows.Shapes;

namespace FinalGame.Classes.Game_Elements
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(string message = "Default Message!")
        {
            InitializeComponent();
            messageLabel.Content = message;
        }
        public MessageWindow(string message, Image img)
        {
            InitializeComponent();
            messageLabel.Content = message;
            messageImage.Children.Add(img);
        }
        private void exit_Click(object sender, RoutedEventArgs e){
            this.Close();
        }
    }
}
