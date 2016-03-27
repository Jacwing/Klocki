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
            if (p.CzyMożnaPrzesunąćWDół(f))
                p.PrzesuńWDół(f);
            if (p.CzyMożnaObrócić(f))
                p.Obróć(f);
            if (p.CzyMożnaPrzesunąćWLewo(f))
                p.PrzesuńWLewo(f);
            if (p.CzyMożnaObrócić(f))
                p.Obróć(f);

        }
    }
}
