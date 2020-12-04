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

namespace Decoder_Study
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cipher currentCipher;
        private int parametr;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(Parametr_TextBox.Text, out parametr);
            Output_TextBox.Text = currentCipher.Encode(Input_TextBox.Text, parametr);
            Console.WriteLine("Encode");
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(Parametr_TextBox.Text, out parametr);
            Output_TextBox.Text = currentCipher.Decode(Input_TextBox.Text, parametr);
            Console.WriteLine("Decode");
        }

        private void Cipher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCipher = (sender as ComboBox).SelectedItem.ToString();
            if (selectedCipher == "System.Windows.Controls.ComboBoxItem: 1: Шифр Цезаря")
            {
                currentCipher = new Caesar();
                Parametr_Label.Visibility = Visibility.Visible;
                Parametr_Label.IsEnabled = true;
                Parametr_TextBox.Visibility = Visibility.Visible;
                Parametr_TextBox.IsEnabled = true;
            }
            else
            {
                Parametr_Label.Visibility = Visibility.Hidden;
                Parametr_Label.IsEnabled = false;
                Parametr_TextBox.Visibility = Visibility.Hidden;
                Parametr_TextBox.IsEnabled = false;
            }
            Console.WriteLine(selectedCipher);
        }
    }
}