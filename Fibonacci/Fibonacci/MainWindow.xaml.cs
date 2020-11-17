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

        /// <summary>
        /// Method that checks if the input is other than a number
        /// </summary>
        private void InputNumberTB_PreviewTextInput(object sender, TextCompositionEventArgs e)  {
            e.Handled = !_regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Click of the "Search Button"
        /// </summary>
        private void SearchBT_Click(object sender, RoutedEventArgs e) {
            FibonacciObject fibonacci = new FibonacciObject(ulong.Parse(InputNumberTB.Text));
            List<ulong> numbersList = fibonacci.GetList();
            DisplayList(numbersList);
        }

        /// <summary>
        /// Method that checks if the input is correct and can be treated
        /// </summary>
        private void InputNumberTB_TextChanged(object sender, TextChangedEventArgs e) {
            bool notTooBig = ulong.TryParse(InputNumberTB.Text, out ulong number);
            if (InputNumberTB.Text != "" && notTooBig && number >= 2) {
                SearchBT.IsEnabled = true;
            } else {
                SearchBT.IsEnabled = false;
            }
        }

        /// <summary>
        /// Display Numbers in a new grid
        /// </summary>
        /// <param name="numbersList">List of the fibonacci numbers</param>
        private void DisplayList(List<ulong> numbersList) {
            ContentGrid.Children.Clear(); // Clear last results
            ScrollViewer scrollViewer = new ScrollViewer(); // Creating a scrollViewer that will let us scroll through the results

            // Display list in console
            for (int i = 0; i < numbersList.Count; i++) {
                Console.WriteLine(i + ".\t" + numbersList[i]);
            }

            Grid displayGrid = new Grid(); // Create a new Grid

            // Set the basic style of the grid
            displayGrid.Margin = new Thickness(20);
            displayGrid.ShowGridLines = true;
            displayGrid.VerticalAlignment = VerticalAlignment.Top;

            // Adding Columns
            displayGrid.ColumnDefinitions.Add(new ColumnDefinition());
            displayGrid.ColumnDefinitions.Add(new ColumnDefinition());
            displayGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // Get the number of rows needed 
            double numberRows = Math.Ceiling(Convert.ToDouble(numbersList.Count()) / 3);

            int index = 0; // index of the numberList

            for(int row = 0; row < numberRows; row++) { // for each row
                // Create a new row
                RowDefinition basicRow = new RowDefinition();
                basicRow.Height = new GridLength(40);
                displayGrid.RowDefinitions.Add(basicRow);

                for (int column = 0; column < 3; column++) { // for each column                    
                    if (index < numbersList.Count) { // if there's more number to process
                        // Create a new label
                        Label numberLabel = new Label();
                        numberLabel.VerticalAlignment = VerticalAlignment.Center;
                        numberLabel.Padding = new Thickness(30, 0, 0, 0);
                        // Add the number
                        numberLabel.Content = (index+1) + ". " + numbersList[index];

                        // Place the label and add it into the grid
                        Grid.SetRow(numberLabel, row);
                        Grid.SetColumn(numberLabel, column);
                        displayGrid.Children.Add(numberLabel);

                        index++;
                    } else {
                        break;
                    }
                }
            }

            // Add the new grid into the scrollViewer then add the scrollViewer into the main Grid
            scrollViewer.Content = displayGrid;
            ContentGrid.Children.Add(scrollViewer);
        }
    }
}
