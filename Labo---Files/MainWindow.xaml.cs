using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labo___Namenlijst;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    const string FileName = "personen.txt";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void readFileButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string[] line;
            firstNameListBox.Items.Clear();
            lastNameListBox.Items.Clear();
            using (StreamReader sr = new StreamReader(FileName))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine().Split(" ");
                    firstNameListBox.Items.Add(line[0]);
                    lastNameListBox.Items.Add(line[1]);
                }
            }
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("Bestand niet gevonden!");
        }
    }

    private void saveFileButton_Click(object sender, RoutedEventArgs e)
    {
        if (firstNameListBox.Items.Count == 0)
        {
            MessageBox.Show("Geen data om weg te schrijven!");
        }
        else
            using (StreamWriter sw = new StreamWriter(FileName, true))
            {
                for (int i = 0; i < firstNameListBox.Items.Count; i++)
                {
                    sw.WriteLine($"{firstNameListBox.Items[i]} {lastNameListBox.Items[i]}");
                }
            }
    }

    private void addButton_Click(object sender, RoutedEventArgs e)
    {
        firstNameListBox.Items.Add(firstNameTextBox.Text);
        lastNameListBox.Items.Add(lastNameTextBox.Text);
        firstNameTextBox.Clear();
        lastNameTextBox.Clear();
    }
}