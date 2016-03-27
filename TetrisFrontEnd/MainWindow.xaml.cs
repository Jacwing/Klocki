using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TetrisFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<List<string>> Kolekcja =  new ObservableCollection<List<string>>();

        public MainWindow()
        {
            InitializeComponent();
            Kolekcja.Add(new List<string>(new string[] { "2", "3", "5" }));
            Kolekcja.Add(new List<string>(new string[] { "2", "3", "5" }));
            Plansza.DataContext = Kolekcja;
        }
    }
}
