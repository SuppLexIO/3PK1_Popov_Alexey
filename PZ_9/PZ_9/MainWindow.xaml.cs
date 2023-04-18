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

namespace PZ_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
{
    private Client client;
    public MainWindow()
    {
        InitializeComponent();
        client = new Client();
    }
    public void ShowMessage(string message)
    {
        MessageBox.Show(message);
    }
    public void ShowDouble(double d)
    {
        OutputTextBox.Text += d + "\n";
    }
    public void ShowInt(int i)
    {
        OutputTextBox.Text += i + "\n";
    }
    public void ShowChar(char c)
    {
        OutputTextBox.Text += c + "\n";
    }
    private void DoubleButton_Click(object sender, RoutedEventArgs e)
    {
        double d;
        if (double.TryParse(InputTextBox.Text, out d))
        {
            client.ClientDouble(d);
            ShowDouble(d);
        }
        else
        {
            ShowMessage("ошибка");
        }
    }
    private void IntButton_Click(object sender, RoutedEventArgs e)
    {
        int i;
        if (int.TryParse(InputTextBox.Text, out i))
        {
            client.ClientInt(i);
            ShowInt(i);
        }
        else
        {
            ShowMessage("ошибка");
        }
    }
    private void CharButton_Click(object sender, RoutedEventArgs e)
    {
        char c;
        if (char.TryParse(InputTextBox.Text, out c))
        {
            client.ClientChar(c);
            ShowChar(c);
        }
        else
        {
            ShowMessage("ошибка");
        }
    }
}
}
