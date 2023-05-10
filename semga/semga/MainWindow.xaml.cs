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
using System.IO;
using Microsoft.Win32;

namespace semga
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string path = "C:\\Users\\popov.am1241\\Desktop\\Bloknot";
            string[] files = Directory.GetFiles(path, "*.txt");

            string path2 = "C:\\Users\\popov.am1241\\Desktop\\Bloknot";
            string[] files2 = Directory.GetFiles(path2, "*.jpg");

            TxtPro3000.ItemsSource = files;
            TxtPro3000_Copy.ItemsSource = files2;

        }

        private void Add_Bt_Click(object sender, RoutedEventArgs e)
        {
          
            Add_Bt.Visibility = Visibility.Hidden;
            AddImage_Bt.Visibility = Visibility.Visible;
            AddText_Bt.Visibility = Visibility.Visible;
        }

        private void AddText_Bt_Click(object sender, RoutedEventArgs e)
        {
            TextWindow text = new TextWindow();
            text.Show();
        }

        private void AddImage_Bt_Click(object sender, RoutedEventArgs e)
        {
            ImageWindow image = new ImageWindow();
            image.Show();
        }

        private void TxtPro3000_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string selectedFile = TxtPro3000.SelectedItem as string;
            if (selectedFile != null)
            {
                TextWindow textWindow = new TextWindow(selectedFile);
                textWindow.Show();
            }
        }

        private void Delete_Bt_Copy_Click(object sender, RoutedEventArgs e)
        {
            string path = "C:\\Users\\popov.am1241\\Desktop\\Bloknot";
            string[] files = Directory.GetFiles(path, "*.txt");

            string path2 = "C:\\Users\\popov.am1241\\Desktop\\Bloknot";
            string[] files2 = Directory.GetFiles(path, "*.jpg");

            TxtPro3000.ItemsSource = files;
            TxtPro3000_Copy.ItemsSource = files2;
        }

        private void Delete_Bt_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile2 = TxtPro3000_Copy.SelectedItem as string;
            string selectedFile = TxtPro3000.SelectedItem as string;

            if (selectedFile2 != null)
            {
                File.Delete($"{selectedFile2}");
            }
           
  

            if (selectedFile != null)
            {
                File.Delete($"{selectedFile}");
            }
          

            string path = "C:\\Users\\popov.am1241\\Desktop\\Bloknot";
            string[] files = Directory.GetFiles(path, "*.txt");

            string path2 = "C:\\Users\\popov.am1241\\Desktop\\Bloknot";
            string[] files2 = Directory.GetFiles(path2, "*.jpg");

            TxtPro3000.ItemsSource = files;
            TxtPro3000_Copy.ItemsSource = files2;
        }
        private void TxtPro3000_MouseDoubleClick2(object sender, MouseButtonEventArgs e)
        {
            string selectedFile = TxtPro3000_Copy.SelectedItem as string;
            if (selectedFile != null)
            {
                ImageWindow imageWindow = new ImageWindow(selectedFile);
                imageWindow.Show();
            }
        }
    }
}
