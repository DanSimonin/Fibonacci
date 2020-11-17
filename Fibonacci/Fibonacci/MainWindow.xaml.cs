using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Fibonacci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // regex that check if a string is only number
        private static readonly Regex _regex = new Regex("^[0-9]*$");

        public MainWindow() {
            InitializeComponent();
        }

        // Method that checks if the input is other than a number
        private void InputNumberTB_PreviewTextInput(object sender, TextCompositionEventArgs e)  {
            e.Handled = !_regex.IsMatch(e.Text);
        }

        // Click of the "Search Button"
        private void SearchBT_Click(object sender, RoutedEventArgs e) {
            Console.WriteLine("test");
        }

        // Method that checks if the input is correct and can be treated
        private void InputNumberTB_TextChanged(object sender, TextChangedEventArgs e) {
            if (InputNumberTB.Text != "" && Int32.Parse(InputNumberTB.Text) >= 2) {
                SearchBT.IsEnabled = true;
            } else {
                SearchBT.IsEnabled = false;
            }
        }
    }
}
