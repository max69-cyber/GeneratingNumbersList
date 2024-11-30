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

namespace GeneratingNumbersList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartGeneration(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(FirstNumber.Text, out int start) && int.TryParse(SecondNumber.Text, out int end) && start <= end)
            {
                NumbersList.Items.Clear();
                NumbersProgress.Value = 0;

                NumbersGenerator generator = new NumbersGenerator();
                IEnumerable<int> numbers = generator.GenerateNumbers(start, end);

                double totalCount = end - start + 1;
                int count = 0;

                foreach (var number in numbers)
                {
                    NumbersList.Items.Add(number);
                    count++;
                    NumbersProgress.Value = count / totalCount * 100;
                    await Task.Delay(500);
                }
                MessageBox.Show("Генерация завершена!");

            }
            else
            {
                MessageBox.Show("Введены некорректные числа!");
            }
        }
    }
}
