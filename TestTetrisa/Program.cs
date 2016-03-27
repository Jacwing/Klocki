using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;

namespace TestTetrisa
{
    class Program
    {
        static void Main(string[] args)
        {
            Plansza p = new Plansza();
            p.InicjalizujPlanszę();
            Figura f = Figura.LosujFigurę();
            p.RysujFigurę(f);
            p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWDół);
            p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWLewo);
            p.PrzesuńlubObróć(f, TrybRuchu.PrzesuńWPrawo);
            p.PrzesuńlubObróć(f, TrybRuchu.Obróc);


        }
    }
}
