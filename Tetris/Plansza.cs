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

        public void PrzesuńlubObróć(Figura figura, TrybRuchu trybRuchu)
        {
            CzyśćFigurę(figura);
            switch (trybRuchu)
            {
                case TrybRuchu.PrzesuńWDół:
                    RysujFigurę(figura.PrzesuńWDół());
                    break;
                case TrybRuchu.PrzesuńWLewo:
                    RysujFigurę(figura.PrzesuńWLewo());
                    break;
                case TrybRuchu.PrzesuńWPrawo:
                    RysujFigurę(figura.PrzesuńWPrawo());
                    break;
                case TrybRuchu.Obróc:
                    RysujFigurę(figura.Obróc());
                    break;
            }
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

    public enum TrybRuchu
    {
        PrzesuńWDół,
        PrzesuńWLewo,
        PrzesuńWPrawo,
        Obróc
    }
}
