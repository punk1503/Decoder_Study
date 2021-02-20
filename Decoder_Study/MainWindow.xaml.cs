using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Collections.Generic;

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
        private string currentDocString = null;

        //var x = myDictionary["BaseClass"]();
        private Dictionary<string, Func<Cipher>> nameToClass = new Dictionary<string, Func<Cipher>>
        {
            {"0: Начало", () => new Start()},
            {"1: Шифр Цезаря", () => new Caesar()}
        };

        public MainWindow()
        {
            InitializeComponent();
            StartComboBoxItem.IsSelected = true;
            currentCipher = new Start();
            parameter = 0;
            selectedCipher = CipherComboBox.SelectedValue.ToString();
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
                Output_TextBox.Text = currentCipher.Encode(Input_TextBox.Text, parameter_TextBox.Text);
                Console.WriteLine("Encode");
            }
            catch { Console.WriteLine("LOG: exception occured in Encode_Click"); }
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Output_TextBox.Text = currentCipher.Decode(Input_TextBox.Text, parameter_TextBox.Text);
                Console.WriteLine("LOG: Decode");
            }
            catch { Console.WriteLine("LOG: exception occured in Decode_Click"); }
        }

        private void Cipher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCipher = CipherComboBox.SelectedValue.ToString();
            currentCipher = nameToClass[selectedCipher]();
            ParameterSwitch(currentCipher.parameterRequired, currentCipher.parameterHintText);
            using (StreamReader reader = new StreamReader(currentCipher.docDir))
            {
                currentDocString = reader.ReadToEnd();
            }
            DocView.Document = SetRTF(currentDocString);
        }
    }
}