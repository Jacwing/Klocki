using System.Windows;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Media;
using Tetris;

namespace TetrisFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Plansza p = new Plansza();
        Figura f = Figura.LosujFigurę();

        public MainWindow()
        {
            p.InicjalizujPlanszę();
            InitializeComponent();
            Klocki.ItemsSource = p.Klocki;
            p.RysujFigurę(f);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWDół);
            p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWDół);
            p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWLewo);
        }
    }
}

