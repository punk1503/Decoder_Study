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
        private Cipher currentCipher;
        private int parameter;
        private string selectedCipher = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
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
            try
            {
                selectedCipher = (sender as ComboBox).SelectedItem.ToString();
            }
            catch
            {
                Console.WriteLine("LOG: exception occured while selecting cipher ");
            }
            if (selectedCipher == "System.Windows.Controls.ComboBoxItem: 1: Шифр Цезаря")
            {
                currentCipher = new Caesar();
                parameter_Label.Visibility = Visibility.Visible;
                parameter_Label.IsEnabled = true;
                parameter_TextBox.Visibility = Visibility.Visible;
                parameter_TextBox.IsEnabled = true;
            }
            else
            {
                parameter_Label.Visibility = Visibility.Hidden;
                parameter_Label.IsEnabled = false;
                parameter_TextBox.Visibility = Visibility.Hidden;
                parameter_TextBox.IsEnabled = false;
            }
            Console.WriteLine(selectedCipher);
        }
    }
}