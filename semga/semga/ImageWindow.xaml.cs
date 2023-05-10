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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace semga
{
    /// <summary>
    /// Логика взаимодействия для ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        private string filePath;
        private bool isTextChanged;
        public ImageWindow(string filePath)
        {

            InitializeComponent();
            
            var fs2 = new FileStream(filePath,
                   FileMode.Open, FileAccess.Read);
            StrokeCollection strokes = new StrokeCollection(fs2);
            IK1.Strokes = strokes;

            l1.Content = filePath;

        }
        public ImageWindow()
        {
            InitializeComponent();
        }

        private void Back_Bt_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Bt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "savedimage"; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

           


                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Create))
                {

                    IK1.Strokes.Save(fs);
                }

                

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IK1.EditingMode == InkCanvasEditingMode.Ink) IK1.EditingMode = InkCanvasEditingMode.EraseByPoint;
            else IK1.EditingMode = InkCanvasEditingMode.Ink;
        }
    }
    
    
}
