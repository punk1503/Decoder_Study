﻿using System;
using System.IO;
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
        private int parameter = 0;
        private string selectedCipher;
        private string currentDocString = null;

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

        private void ShowParameter()
        {
            parameter_TextBox.Visibility = Visibility.Visible;
            parameter_TextBox.IsEnabled = true;
        }

        private void HideParameter()
        {
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
                using (StreamReader reader = new StreamReader(currentCipher.docDir))
                {
                    currentDocString = reader.ReadToEnd();
                }
                DocView.Document = SetRTF(currentDocString);
            }
            if (selectedCipher == "1: Шифр Цезаря")
            {
                ShowParameter();
                currentCipher = new Caesar();
                using (StreamReader reader = new StreamReader(currentCipher.docDir))
                {
                    currentDocString = reader.ReadToEnd();
                }
                DocView.Document = SetRTF(currentDocString);
            }
            else
            {
                HideParameter();
            }
            Console.WriteLine(selectedCipher);
        }
    }
}