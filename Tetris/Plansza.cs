using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Tetris
{
    public class Plansza
    {
        public List<List<Klocek>> Klocki = new List<List<Klocek>>();

        public Plansza(int szerokość, int wysokość)
        {
            for (int i = 0; i < wysokość; i++)
            {
                Klocki.Add(new List<Klocek>());
                for (int j = 0; j < szerokość; j++)
                {
                    Klocki[i].Add(new Klocek(i, j));
                }
            }
        }

        public void CzyśćPlanszę()
        {
            foreach (List<Klocek> listaKlocków in Klocki)
            {
                foreach (Klocek klocek in listaKlocków)
                {
                    klocek.Kolor = Brushes.Transparent;
                }
            }
        }

        public bool RysujFiguręZeSprawdzeniem(Figura figura)
        {
            bool wynik = true;
            foreach (Klocek klocek in figura.ListaKlocków)
            {
                if (Klocki[klocek.Y][klocek.X].Kolor != Brushes.Transparent)
                    wynik = false;
                Klocki[klocek.Y][klocek.X].Kolor = klocek.Kolor;
            }
            return wynik;
        }

        public void RysujFigurę(Figura figura)
        {
            foreach (Klocek klocek in figura.ListaKlocków)
            {
                Klocki[klocek.Y][klocek.X].Kolor = klocek.Kolor;
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

        public int UsuńPełneWiersze()
        {
            int wynik = 0;
            foreach (List<Klocek> wierszKlocków in Klocki)
            {
                if (CzyWierszKlockówJestPełny(wierszKlocków))
                //if (CzyWierszKlockówJestPełnyOpróczJedengo(wierszKlocków))
                {
                    PresuńWierszePoniżej(Klocki.IndexOf(wierszKlocków));
                    wynik++;
                }
            }
            return wynik;
        }

        private void PresuńWierszePoniżej(int numerWiersza)
        {
            for (int i  = numerWiersza; i > 0; i--)
            {
                foreach (Klocek klocek in Klocki[i])
                {
                    klocek.Kolor = Klocki[i - 1][klocek.Y].Kolor;
                }
            }
        }

        private bool CzyWierszKlockówJestPełny(List<Klocek> wierszKlocków)
        {
            bool wynik = true;
            foreach (Klocek klocek in wierszKlocków)
            {
                if (klocek.Kolor == Brushes.Transparent)
                    wynik = false;
            }

            return wynik;
        }

        private bool CzyWierszKlockówJestPełnyOpróczJedengo(List<Klocek> wierszKlocków)
        {
            int ilośćPustychKlocków = 0;
            foreach (Klocek klocek in wierszKlocków)
            {
                if (klocek.Kolor == Brushes.Transparent)
                    ilośćPustychKlocków++;
            }

            if (ilośćPustychKlocków < 2)
                return true;
            else
                return false;
        }

    }
}
