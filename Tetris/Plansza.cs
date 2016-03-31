using System.Collections.Generic;
using System.Windows.Media;

namespace Tetris
{
    public class Plansza
    {
        public List<List<Klocek>> Klocki = new List<List<Klocek>>();


        public void InicjalizujPlanszę()
        {
            for (int i = 0; i < 20; i++)
            {
                Klocki.Add(new List<Klocek>());
                for (int j = 0; j < 10; j++)
                {
                    Klocki[i].Add(new Klocek(i, j));
                }
            }
        }

        public void RysujFigurę(Figura figura)
        {
            foreach (Klocek klocek in figura.ListaKlocków)
            {
                Klocki[klocek.Y][klocek.X].Kolor = figura.Kolor;
            }
        }

        public void CzyśćFigurę(Figura figura)
        {
            foreach (Klocek klocek in figura.ListaKlocków)
            {
                Klocki[klocek.Y][klocek.X].Kolor = Brushes.Transparent;
            }
        }

        public bool PrzesuńlubObróć(Figura figura, TrybRuchu trybRuchu)
        {
            bool wynik = false;
            switch (trybRuchu)
            {
                case TrybRuchu.PrzesuńWDół:
                    if (CzyMożnaObrócićLubPrzesunąć(figura, trybRuchu))
                    {
                        CzyśćFigurę(figura);
                        RysujFigurę(figura.PrzesuńWDół());
                        wynik = true;
                    }
                    break;
                case TrybRuchu.PrzesuńWLewo:
                    if (CzyMożnaObrócićLubPrzesunąć(figura, trybRuchu))
                    {
                        CzyśćFigurę(figura);
                        RysujFigurę(figura.PrzesuńWLewo());
                        wynik = true;
                    }
                    break;
                case TrybRuchu.PrzesuńWPrawo:
                    if (CzyMożnaObrócićLubPrzesunąć(figura, trybRuchu))
                    {
                        CzyśćFigurę(figura);
                        RysujFigurę(figura.PrzesuńWPrawo());
                        wynik = true;
                    }
                    break;
                case TrybRuchu.Obróc:
                    if (CzyMożnaObrócićLubPrzesunąć(figura, trybRuchu))
                    {
                        CzyśćFigurę(figura);
                        RysujFigurę(figura.Obróc());
                        wynik = true;
                    }
                    break;
            }
            return wynik;
        }

        public bool CzyMożnaObrócićLubPrzesunąć(Figura figura, TrybRuchu trybRuchu)
        {
            Figura kopia = (Figura)figura.Clone();
            switch (trybRuchu)
            {
                case TrybRuchu.PrzesuńWDół:
                    kopia.PrzesuńWDół();
                    break;
                case TrybRuchu.PrzesuńWLewo:
                    kopia.PrzesuńWLewo();
                    break;
                case TrybRuchu.PrzesuńWPrawo:
                    kopia.PrzesuńWPrawo();
                    break;
                case TrybRuchu.Obróc:
                    kopia.Obróc();
                    break;
            }
            Figura różnicaPomiędzyOryginalnąAPrzesuniętą = figura.RóżnicaPomiędzyFigurami(kopia);

            if ((różnicaPomiędzyOryginalnąAPrzesuniętą.MaxX > 9) || (różnicaPomiędzyOryginalnąAPrzesuniętą.MinX < 0) || (różnicaPomiędzyOryginalnąAPrzesuniętą.MinY < 0) || (różnicaPomiędzyOryginalnąAPrzesuniętą.MaxY > 19))
                return false;
            else
            {
                foreach (Klocek klocek in różnicaPomiędzyOryginalnąAPrzesuniętą.ListaKlocków)
                {
                    if (Klocki[klocek.Y][klocek.X].Kolor != Brushes.Transparent)
                        return false;
                }
                return true;
            }
        }
    }
}
