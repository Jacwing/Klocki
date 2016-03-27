using System.Drawing;

namespace Tetris
{
    public class Plansza
    {
        public Klocek[,] plansza = new Klocek[10, 20];
        
        public void InicjalizujPlanszę()
        {
            for (int i = 0; i < plansza.GetLength(0); i++)
            {
                for (int j = 0; j < plansza.GetLength(1); j++)
                {
                    plansza[i, j] = new Klocek(i, j);
                }
            }
        }

        public void RysujFigurę(Figura figura)
        {
            foreach (Klocek klocek in figura.ListaKlocków)
            {
                plansza[klocek.X, klocek.Y].Kolor = figura.Kolor;
            }
        }

        public void CzyśćFigurę(Figura figura)
        {
            foreach (Klocek klocek in figura.ListaKlocków)
            {
                plansza[klocek.X, klocek.Y].Kolor = Color.Transparent;
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

            if ((różnicaPomiędzyOryginalnąAPrzesuniętą.MaxX > 9) || (różnicaPomiędzyOryginalnąAPrzesuniętą.MinX < 0) || (różnicaPomiędzyOryginalnąAPrzesuniętą.MinY < 0) || (różnicaPomiędzyOryginalnąAPrzesuniętą.MinY > 19))
                return false;
            else
            {
                foreach (Klocek klocek in różnicaPomiędzyOryginalnąAPrzesuniętą.ListaKlocków)
                {
                    if (plansza[klocek.X, klocek.Y].Kolor != Color.Transparent)
                        return false;
                }
                return true;
            }
        }
    }
}
