using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows;

namespace pr_24._106_pavlenko_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string sentence = InputTextBox.Text;
            if (string.IsNullOrWhiteSpace(sentence))
            {
                MessageBox.Show("Введите предложение.");
                return;
            }
            else if (Regex.IsMatch(sentence, @"[а-яА-ЯеЁ]"))
            {
                MessageBox.Show("На английском!");
                return;
            }

         
            
            string lower = sentence.ToLower();
            int vowelCount = lower.Count(c => "aeiou".Contains(c));
            VowelCountTextBlock.Text = vowelCount.ToString();

            
            string cleaned = new string(sentence.Select(c => char.IsLetter(c) ? c : ' ').ToArray());
            string[] words = cleaned.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                LongestWordTextBlock.Text = "нет слов";
                return;
            }

            string longest = words.OrderByDescending(w => w.Length).First();
            LongestWordTextBlock.Text = longest;
        }
    }
}