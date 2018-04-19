using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EC402
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calc = new Calculator();
        double res;
        int index, people;
        float dollar, euro, arCons, maxCons;
        long rooms;
        public MainWindow()
        {
            InitializeComponent();
            radioButtonPeople.IsChecked = true;
        }

        private void buttonBegining_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPageRate;
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPageConsumption;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPageRegion;
        }

        private void buttonBacktoRates_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPageRate;
        }

        private void radioButtonPeople_Checked(object sender, RoutedEventArgs e)
        {
            textBoxPeople.IsEnabled = true;
            textBoxAverageConsumption.IsEnabled = false;
            textBoxMaxConsumption.IsEnabled = false;
            textBoxRooms.IsEnabled = false;
        }

        private void radioButtonRooms_Checked(object sender, RoutedEventArgs e)
        {
            textBoxPeople.IsEnabled = false;
            textBoxAverageConsumption.IsEnabled = false;
            textBoxMaxConsumption.IsEnabled = false;
            textBoxRooms.IsEnabled = true;
        }

        private void radioButtonConsumption_Checked(object sender, RoutedEventArgs e)
        {
            textBoxPeople.IsEnabled = false;
            textBoxAverageConsumption.IsEnabled = true;
            textBoxMaxConsumption.IsEnabled = true;
            textBoxRooms.IsEnabled = false;
        }

        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            index = comboBoxRegions.SelectedIndex;
            dollar = float.Parse(textBoxExchangeRate.Text);
            euro = float.Parse(textBoxEuro.Text);
            if (radioButtonConsumption.IsChecked == true)
            {
                maxCons = float.Parse(textBoxMaxConsumption.Text);
                arCons = float.Parse(textBoxAverageConsumption.Text);
                calc.Create(index, dollar, euro, maxCons, arCons);
            }
            else if (radioButtonPeople.IsChecked == true)
            {
                people = int.Parse(textBoxPeople.Text);
                calc.Create(index, dollar, euro, people);
            }
            else
            {
                rooms = long.Parse(textBoxRooms.Text);
                calc.Create(index, dollar, euro, rooms);
            }

            res = calc.Calc();
            MessageBox.Show($"Ваша покупка окупится через {res} лет", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
