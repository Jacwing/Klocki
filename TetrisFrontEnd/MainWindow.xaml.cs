using System.Windows;
using Tetris;
using System.Windows.Input;

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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWLewo);
            }
            else if (e.Key == Key.Right)
            {
                p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWPrawo);
            }
            else if (e.Key == Key.Down)
            {
                p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWDół);
            }
            else if (e.Key == Key.Up)
            {
                p.PrzesuńlubObróć(f, TrybRuchu.Obróc);
            }
            else if (e.Key == Key.N)
            {
                f = Figura.LosujFigurę();
                p.RysujFigurę(f);
            }

        }
    }
}

