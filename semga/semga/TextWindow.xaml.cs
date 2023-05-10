using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace semga
{
    /// <summary>
    /// Логика взаимодействия для TextWindow.xaml
    /// </summary>
    public partial class TextWindow : Window
    {
        private string filePath;
        
        private bool isTextChanged;
        public TextWindow(string filePath)
        {

            InitializeComponent();
            string text = File.ReadAllText(filePath);
            TB1.Text = text;
            l1.Content = filePath;
        }
        public TextWindow()
        {

            InitializeComponent();
            Save_Bt2.Visibility = Visibility.Collapsed;
        }



        private void Back_Bt_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Bt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == true)
                {
                    filePath = saveFileDialog.FileName;
                }
            }
            File.WriteAllText($"{filePath}.txt", TB1.Text);
            isTextChanged = false;
            Save_Bt2.Visibility = Visibility.Visible;
            l1.Content = $"{filePath}.txt";
        }

        private void Save_Bt2_Click(object sender, RoutedEventArgs e)
        {
            filePath = l1.Content.ToString();
            File.WriteAllText($"{filePath}", TB1.Text);
            isTextChanged = false;

            MessageBox.Show("Успешно сохранено!");
            
            
        }
    }
}
