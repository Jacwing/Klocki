using Tetris;
using System.Windows.Input;
using System.Windows.Threading;
using System;
using System.Collections.Generic;
using MahApps.Metro.Controls;

namespace TetrisFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Plansza planszaDuża = new Plansza(10, 20);
        Plansza planszaMała = new Plansza(5, 6);
        Figura figuraPlanszaDuża, figuraPlanszaMała ;
        DispatcherTimer timer = new DispatcherTimer();
        int punktacja = 0;
        Random random = new Random();
        Array listaKszałtów = Enum.GetValues(typeof(KszałtFigury));
        List<KszałtFigury> listaWylosowanychKszałtów = new List<KszałtFigury>();

        public MainWindow()
        {            
            InitializeComponent();
            PlanszaDuża.ItemsSource = planszaDuża.Klocki;
            PlanszaMała.ItemsSource = planszaMała.Klocki;
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_Tick;
            Punktacja.Content = "Punktacja : " + (punktacja * 10).ToString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bool czyMożnaPrzesunąćWDół = planszaDuża.PrzesuńlubObróć(figuraPlanszaDuża, TrybRuchu.PrzesuńWDół);
            if (!czyMożnaPrzesunąćWDół)
            {
                punktacja += planszaDuża.UsuńPełneWiersze();
                Punktacja.Content = "Punktacja : " + (punktacja *10).ToString();
                planszaMała.CzyśćFigurę(figuraPlanszaMała);
                listaWylosowanychKszałtów.RemoveAt(1);
                listaWylosowanychKszałtów.Insert(0, (KszałtFigury)listaKszałtów.GetValue(random.Next(listaKszałtów.Length)));
                figuraPlanszaMała = new Figura(listaWylosowanychKszałtów[0], new Klocek(1, 1));
                figuraPlanszaDuża = new Figura(listaWylosowanychKszałtów[1], new Klocek(4, 0));
                planszaMała.RysujFigurę(figuraPlanszaMała);
                bool czyMożnaNarysowaćNowąFigurę = planszaDuża.RysujFiguręZeSprawdzeniem(figuraPlanszaDuża);
                if (!czyMożnaNarysowaćNowąFigurę)
                    timer.Stop();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            planszaDuża.CzyśćPlanszę();
            planszaMała.CzyśćPlanszę();
            listaWylosowanychKszałtów.Clear();
            punktacja = 0;
            Punktacja.Content = "Punktacja : " + punktacja;
            listaWylosowanychKszałtów.Add((KszałtFigury)listaKszałtów.GetValue(random.Next(listaKszałtów.Length)));
            listaWylosowanychKszałtów.Add((KszałtFigury)listaKszałtów.GetValue(random.Next(listaKszałtów.Length)));
            figuraPlanszaMała = new Figura(listaWylosowanychKszałtów[0], new Klocek(1, 1));
            figuraPlanszaDuża = new Figura(listaWylosowanychKszałtów[1], new Klocek(4, 0));
            planszaMała.RysujFigurę(figuraPlanszaMała);
            planszaDuża.RysujFigurę(figuraPlanszaDuża);
            timer.Start();

        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (timer.IsEnabled)
                timer.Stop();
            else
                timer.Start();
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                planszaDuża.PrzesuńlubObróć(figuraPlanszaDuża, TrybRuchu.PrzesuńWLewo);
            }
            else if (e.Key == Key.Right)
            {
                planszaDuża.PrzesuńlubObróć(figuraPlanszaDuża, TrybRuchu.PrzesuńWPrawo);
            }
            else if (e.Key == Key.Down)
            {
                planszaDuża.PrzesuńlubObróć(figuraPlanszaDuża, TrybRuchu.PrzesuńWDół);
            }
            else if (e.Key == Key.Up)
            {
                planszaDuża.PrzesuńlubObróć(figuraPlanszaDuża, TrybRuchu.Obróc);
            }
        }

    }
}

