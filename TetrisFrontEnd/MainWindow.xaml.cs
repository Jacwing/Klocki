using System.Windows;
using Tetris;
using System.Windows.Input;
using System.Windows.Threading;
using System;

namespace TetrisFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Plansza p = new Plansza();
        Figura f = new Figura();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            p.InicjalizujPlanszę();
            InitializeComponent();
            Klocki.ItemsSource = p.Klocki;
            p.RysujFigurę(f);
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bool czyMożnaPrzesunąćWDół = p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWDół);
            if (!czyMożnaPrzesunąćWDół)
            {
                p.UsuńPełneWiersze();
                f = new Figura();
                bool czyMożnaNarysowaćNowąFigurę = p.RysujFiguręZeSprawdzeniem(f);
                if (!czyMożnaNarysowaćNowąFigurę)
                    timer.Stop();
            }
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
        }
    }
}

