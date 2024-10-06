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

namespace Calc
{
    /// <summary> Привет Пока Привет Пока
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "1";
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "2";
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "3";
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "4";
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "5";
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "6";
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "7";
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "8";
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "9";
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "0";
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "+";
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "-";
        }

        private void Mult_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "*";
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content += "/";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            string example = Convert.ToString(example_label.Content);
            example_label.Content = Calculate(example);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            example_label.Content = "";
        }

        private static string Calculate(string example)
        {
            List<string> numbers = new List<string>();
            List<char> operators = new List<char>();

            string currentNumber = "";
            foreach (var symbol in example)
            {
                if ("1234567890".Contains(symbol))
                {
                    currentNumber += symbol;
                }
                else
                {
                    numbers.Add(currentNumber);
                    operators.Add(symbol);
                    currentNumber = "";
                }
            }
            numbers.Add(currentNumber);

            while(operators.Count != 0)
            {
                bool containsMulOrDiv = operators.Contains('*') || operators.Contains('/');
                
                for (int i = 0; i < operators.Count; i++)
                {                
                    int num1 = Convert.ToInt32(numbers[i]);
                    int num2 = Convert.ToInt32(numbers[i + 1]);
                    int ans;

                    if (!containsMulOrDiv)
                    {
                        if (operators[i] == '+')
                            ans = num1 + num2;
                        else
                            ans = num1 - num2;

                        numbers[i] = Convert.ToString(ans);
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                    }
                    else
                    {
                        if (operators[i] == '*')
                        {
                            ans = num1 * num2;

                            numbers[i] = Convert.ToString(ans);
                            numbers.RemoveAt(i + 1);
                            operators.RemoveAt(i);
                        }
                        else if (operators[i] == '/')
                        {
                            ans = num1 / num2;

                            numbers[i] = Convert.ToString(ans);
                            numbers.RemoveAt(i + 1);
                            operators.RemoveAt(i);
                        }
                    }
                }                
            }

            return numbers[0];
        }
    }
}
