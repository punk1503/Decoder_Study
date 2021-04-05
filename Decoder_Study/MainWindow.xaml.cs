using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace Decoder_Study
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cipher currentCipher = new Start();
        private string selectedCipher;
        private string currentDocString = null;

        //var x = myDictionary["BaseClass"]();
        private Dictionary<string, Func<Cipher>> nameToClass = new Dictionary<string, Func<Cipher>>
        {
            {"0: Начало", () => new Start()},
            {"1: Шифр Цезаря", () => new Caesar()},
            {"2: Шифр Виженера", () => new Vigenere()},
            {"3: HEX кодирование", () => new Hex() },
            {"4: XOR", () => new Xor() }
        };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(nameToClass.Keys.ToArray());
            CipherComboBox.ItemsSource = nameToClass.Keys.ToArray();
            CipherComboBox.SelectedIndex = 0;
            selectedCipher = nameToClass.Keys.ToArray()[0];
            currentCipher = nameToClass[selectedCipher]();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        // converts .xaml to FlowDocument
        private static FlowDocument SetRTF(string xamlString)
        {
            StringReader stringReader = new StringReader(xamlString);
            System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader);
            return XamlReader.Load(xmlReader) as FlowDocument;
        }

        private void ParameterSwitch(bool enabled = true, string parameterHintText = "Параметр")
        {
            parameter_TextBox.IsEnabled = enabled;
            parameter_TextBox.Visibility = enabled ? Visibility.Visible : Visibility.Hidden;
            MaterialDesignThemes.Wpf.HintAssist.SetHint(parameter_TextBox, parameterHintText);
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Output_TextBox.Text = currentCipher.Encode(Input_TextBox.Text.Trim(), parameter_TextBox.Text).Trim();
                Console.WriteLine("LOG: Encode");
            }
            catch { Console.WriteLine("LOG: exception occured in Encode_Click"); }
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Output_TextBox.Text = currentCipher.Decode(Input_TextBox.Text.Trim(), parameter_TextBox.Text).Trim();
                Console.WriteLine("LOG: Decode");
            }
            catch { Console.WriteLine("LOG: exception occured in Decode_Click"); }
        }

        private void Cipher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCipher = CipherComboBox.SelectedItem.ToString();
            currentCipher = nameToClass[selectedCipher]();
            ParameterSwitch(currentCipher.parameterRequired, currentCipher.parameterHintText);
            try
            {
                using (StreamReader reader = new StreamReader(currentCipher.docDir))
                {
                    currentDocString = reader.ReadToEnd();
                }
                DocView.Document = SetRTF(currentDocString);
            }
            catch
            {
                Console.WriteLine("LOG: No such paragraph file exception");
            }
        }
    }
}