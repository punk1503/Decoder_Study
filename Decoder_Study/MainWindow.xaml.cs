using System;
using System.Windows;
using System.Windows.Controls;

namespace Decoder_Study
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cipher currentCipher = new Start();
        private int parameter = 0;
        private string selectedCipher;

        public MainWindow()
        {
            InitializeComponent();
            StartComboBoxItem.IsSelected = true;
            currentCipher = new Start();
            parameter = 0;
            selectedCipher = CipherComboBox.SelectedValue.ToString();
        }

        private void ShowParameter()
        {
            currentCipher = new Caesar();
            parameter_Label.Visibility = Visibility.Visible;
            parameter_Label.IsEnabled = true;
            parameter_TextBox.Visibility = Visibility.Visible;
            parameter_TextBox.IsEnabled = true;
        }

        private void HideParameter()
        {
            parameter_Label.Visibility = Visibility.Hidden;
            parameter_Label.IsEnabled = false;
            parameter_TextBox.Visibility = Visibility.Hidden;
            parameter_TextBox.IsEnabled = false;
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(parameter_TextBox.Text, out parameter);
            try
            {
                Output_TextBox.Text = currentCipher.Encode(Input_TextBox.Text, parameter);
                Console.WriteLine("Encode");
            }
            catch { Console.WriteLine("LOG: exception occured in Encode_Click"); }
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(parameter_TextBox.Text, out parameter);
            try
            {
                Output_TextBox.Text = currentCipher.Decode(Input_TextBox.Text, parameter);
                Console.WriteLine("LOG: Decode");
            }
            catch { Console.WriteLine("LOG: exception occured in Decode_Click"); }
        }

        private void Cipher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCipher = CipherComboBox.SelectedValue.ToString();
            if (selectedCipher == "0: Начало")
            {
                HideParameter();
                currentCipher = new Start();
            }
            if (selectedCipher == "1: Шифр Цезаря")
            {
                ShowParameter();
                currentCipher = new Caesar();
            }
            else
            {
                HideParameter();
            }
            Console.WriteLine(selectedCipher);
        }
    }
}