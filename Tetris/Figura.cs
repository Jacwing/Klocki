using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Tetris
{
    public class Figura : ICloneable
    {
        public Brush Kolor { get; set; }
        public List<Klocek> ListaKlocków { get; set; }
        private Dictionary<string, int> obszarOgraniczający = new Dictionary<string, int>();




        static public Figura LosujFigurę()
        {
            Array listaKszałtów = Enum.GetValues(typeof(KszałtFigury));
            Random random = new Random(DateTime.Now.Millisecond);
            KszałtFigury wylosowanyKształt = (KszałtFigury)listaKszałtów.GetValue(random.Next(listaKszałtów.Length));

            Figura figura = new Figura();
            figura.obszarOgraniczający.Add("MaxX", 0);
            figura.obszarOgraniczający.Add("MaxY", 0);
            figura.obszarOgraniczający.Add("MinX", 0);
            figura.obszarOgraniczający.Add("MinY", 0);
            List<Klocek> kształt = null;
            switch (wylosowanyKształt)
            {
                case KszałtFigury.TetriminoI:
                    figura.Kolor = Brushes.Aqua;
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(5, 0, figura.Kolor),
                                                            new Klocek(5, 1, figura.Kolor),
                                                            new Klocek(5, 2, figura.Kolor),
                                                            new Klocek(5, 3, figura.Kolor)});
                    figura.obszarOgraniczający["MaxX"] = 5;
                    figura.obszarOgraniczający["MinX"] = 4;
                    figura.obszarOgraniczający["MaxY"] = 3;
                    figura.obszarOgraniczający["MinY"] = 0;


                    break;
                case KszałtFigury.TetriminoT:
                    figura.Kolor = Brushes.Tomato;
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(4, 0, figura.Kolor),
                                                            new Klocek(5, 0, figura.Kolor),
                                                            new Klocek(6, 0, figura.Kolor),
                                                            new Klocek(5, 1, figura.Kolor)});
                    figura.obszarOgraniczający["MaxX"] = 5;
                    figura.obszarOgraniczający["MinX"] = 4;
                    figura.obszarOgraniczający["MaxY"] = 1;
                    figura.obszarOgraniczający["MinY"] = 0;
                    break;
                case KszałtFigury.TetriminoO:
                    figura.Kolor = Brushes.Yellow;
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(4, 0, figura.Kolor),
                                                            new Klocek(4, 1, figura.Kolor),
                                                            new Klocek(5, 0, figura.Kolor),
                                                            new Klocek(5, 1, figura.Kolor)});
                    figura.obszarOgraniczający["MaxX"] = 5;
                    figura.obszarOgraniczający["MinX"] = 4;
                    figura.obszarOgraniczający["MaxY"] = 1;
                    figura.obszarOgraniczający["MinY"] = 0;
                    break;
                case KszałtFigury.TetriminoL:
                    figura.Kolor = Brushes.Violet;
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(4, 0, figura.Kolor),
                                                            new Klocek(4, 1, figura.Kolor),
                                                            new Klocek(4, 2, figura.Kolor),
                                                            new Klocek(5, 2, figura.Kolor)});
                    figura.obszarOgraniczający["MaxX"] = 5;
                    figura.obszarOgraniczający["MinX"] = 4;
                    figura.obszarOgraniczający["MaxY"] = 2;
                    figura.obszarOgraniczający["MinY"] = 0;
                    break;
                case KszałtFigury.TetriminoJ:
                    figura.Kolor = Brushes.Purple;
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(5, 0, figura.Kolor),
                                                            new Klocek(5, 1, figura.Kolor),
                                                            new Klocek(5, 2, figura.Kolor),
                                                            new Klocek(4, 2, figura.Kolor)});
                    figura.obszarOgraniczający["MaxX"] = 5;
                    figura.obszarOgraniczający["MinX"] = 4;
                    figura.obszarOgraniczający["MaxY"] = 2;
                    figura.obszarOgraniczający["MinY"] = 0;
                    break;
                case KszałtFigury.TetriminoS:
                    figura.Kolor = Brushes.Olive;
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(5, 0, figura.Kolor),
                                                            new Klocek(5, 1, figura.Kolor),
                                                            new Klocek(4, 1, figura.Kolor),
                                                            new Klocek(6, 0, figura.Kolor)});
                    figura.obszarOgraniczający["MaxX"] = 7;
                    figura.obszarOgraniczający["MinX"] = 4;
                    figura.obszarOgraniczający["MaxY"] = 1;
                    figura.obszarOgraniczający["MinY"] = 0;
                    break;
                case KszałtFigury.TetriminoZ:
                    figura.Kolor = Brushes.Magenta;
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(5, 0, figura.Kolor),
                                                            new Klocek(5, 1, figura.Kolor),
                                                            new Klocek(4, 0, figura.Kolor),
                                                            new Klocek(6, 1, figura.Kolor)});
                    figura.obszarOgraniczający["MaxX"] = 7;
                    figura.obszarOgraniczający["MinX"] = 4;
                    figura.obszarOgraniczający["MaxY"] = 1;
                    figura.obszarOgraniczający["MinY"] = 0;
                    break;
            }

            figura.ListaKlocków = kształt;
            return figura;
        }

        public Figura PrzesuńWDół()
        {
            if (this.obszarOgraniczający.ContainsKey("MaxY"))
                this.obszarOgraniczający["MaxY"]++;
            if (this.obszarOgraniczający.ContainsKey("MinY"))
                this.obszarOgraniczający["MinY"]++;
            foreach (Klocek klocek in this.ListaKlocków)
            {
                klocek.Y++;
            }
            return this;
        }

        public Figura PrzesuńWLewo()
        {
            if (this.obszarOgraniczający.ContainsKey("MaxX"))
                this.obszarOgraniczający["MaxX"]--;
            if (this.obszarOgraniczający.ContainsKey("MinX"))
                this.obszarOgraniczający["MinX"]--;
            foreach (Klocek klocek in this.ListaKlocków)
            {
                klocek.X--;
            }
            return this;
        }

        public Figura PrzesuńWPrawo()
        {
            if (this.obszarOgraniczający.ContainsKey("MaxX"))
                this.obszarOgraniczający["MaxX"]++;
            if (this.obszarOgraniczający.ContainsKey("MinX"))
                this.obszarOgraniczający["MinX"]++;
            foreach (Klocek klocek in this.ListaKlocków)
            {
                klocek.X++;
            }
            return this;
        }

        //zmienić algorytm obrotów
        public Figura Obróc()
        {
            if ((this.obszarOgraniczający["MaxX"] - this.obszarOgraniczający["MinX"]) == 2) //pionowo
            {
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MinX"], this.obszarOgraniczający["MaxY"]), new Klocek(this.obszarOgraniczający["MaxX"]+1, this.obszarOgraniczający["MaxY"]-1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MaxX"], this.obszarOgraniczający["MaxY"]), new Klocek(this.obszarOgraniczający["MaxX"]+1, this.obszarOgraniczający["MinY"]+1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MinX"], this.obszarOgraniczający["MaxY"]-1), new Klocek(this.obszarOgraniczający["MaxX"], this.obszarOgraniczający["MaxY"]-1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MaxX"], this.obszarOgraniczający["MaxY"]-1), new Klocek(this.obszarOgraniczający["MaxX"], this.obszarOgraniczający["MinY"]+1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MinX"], this.obszarOgraniczający["MinY"]+1), new Klocek(this.obszarOgraniczający["MinX"], this.obszarOgraniczający["MaxY"]-1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MaxX"], this.obszarOgraniczający["MinY"]+1), new Klocek(this.obszarOgraniczający["MinX"], this.obszarOgraniczający["MinY"]+1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MinX"], this.obszarOgraniczający["MinY"]), new Klocek(this.obszarOgraniczający["MinX"]-1, this.obszarOgraniczający["MaxY"]-1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MaxX"], this.obszarOgraniczający["MinY"]), new Klocek(this.obszarOgraniczający["MinX"]-1, this.obszarOgraniczający["MinY"]+1));

                this.obszarOgraniczający["MaxX"]++;
                this.obszarOgraniczający["MinX"]--;
                this.obszarOgraniczający["MaxY"]--;
                this.obszarOgraniczający["MinY"]++;
            }
            else //poziomo
            {
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MinX"], this.obszarOgraniczający["MinY"]), new Klocek(this.obszarOgraniczający["MinX"]+1, this.obszarOgraniczający["MaxY"]+1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MinX"], this.obszarOgraniczający["MaxY"]), new Klocek(this.obszarOgraniczający["MaxX"]-1, this.obszarOgraniczający["MaxY"]+1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MinX"]+1, this.obszarOgraniczający["MinY"]), new Klocek(this.obszarOgraniczający["MinX"]+1, this.obszarOgraniczający["MaxY"]));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MinX"]+1, this.obszarOgraniczający["MaxY"]), new Klocek(this.obszarOgraniczający["MaxX"]-1, this.obszarOgraniczający["MaxY"]));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MaxX"]-1, this.obszarOgraniczający["MinY"]), new Klocek(this.obszarOgraniczający["MinX"]+1, this.obszarOgraniczający["MinY"]));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MaxX"]-1, this.obszarOgraniczający["MaxY"]), new Klocek(this.obszarOgraniczający["MaxX"]-1, this.obszarOgraniczający["MinY"]));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MaxX"], this.obszarOgraniczający["MinY"]), new Klocek(this.obszarOgraniczający["MinX"]+1, this.obszarOgraniczający["MinY"]-1));
                ZamieńKlocki(new Klocek(this.obszarOgraniczający["MaxX"], this.obszarOgraniczający["MaxY"]), new Klocek(this.obszarOgraniczający["MaxX"]-1, this.obszarOgraniczający["MinY"]-1));

                this.obszarOgraniczający["MaxX"]--;
                this.obszarOgraniczający["MinX"]++;
                this.obszarOgraniczający["MaxY"]++;
                this.obszarOgraniczający["MinY"]--;
            }


            return this;
        }

        public int MinX
        {
            get
            {
                int minX = int.MaxValue;
                foreach (Klocek klocek in this.ListaKlocków)
                {
                    if (klocek.X < minX)
                        minX = klocek.X;
                }
                return minX;
            }
        }

        public int MaxX
        {
            get
            {
                int maxX = int.MinValue;
                foreach (Klocek klocek in this.ListaKlocków)
                {
                    if (klocek.X > maxX)
                        maxX = klocek.X;
                }
                return maxX;
            }
        }


        public int MinY
        {
            get
            {
                int minY = int.MaxValue;
                foreach (Klocek klocek in this.ListaKlocków)
                {
                    if (klocek.Y < minY)
                        minY = klocek.Y;
                }
                return minY;
            }
        }

        public int MaxY
        {
            get
            {
                int maxY = int.MinValue;
                foreach (Klocek klocek in this.ListaKlocków)
                {
                    if (klocek.Y > maxY)
                        maxY = klocek.Y;
                }
                return maxY;
            }
        }


        public Figura RóżnicaPomiędzyFigurami(Figura porównywanaFigura)
        {
            Figura figura = new Figura();
            figura.Kolor = this.Kolor;
            figura.ListaKlocków = new List<Klocek>();
            foreach (Klocek klocek in porównywanaFigura.ListaKlocków)
            {
                if (!this.ListaKlocków.Contains(klocek))
                    figura.ListaKlocków.Add(klocek);
            }
            return figura;
        }

        public object Clone()
        {
            Figura figura = new Figura();
            figura.Kolor = this.Kolor;
            figura.ListaKlocków = new List<Klocek>();
            foreach (Klocek klocek in this.ListaKlocków)
            {
                figura.ListaKlocków.Add((Klocek)klocek.Clone());
            }
            figura.obszarOgraniczający = new Dictionary<string, int>(this.obszarOgraniczający);
            return figura;
        }

        private void ZamieńKlocki(Klocek klocekŹrodłowy, Klocek klocekDocelowy)
        {
            int indexKlockaWLiscie = this.ListaKlocków.IndexOf(klocekŹrodłowy);
            if (indexKlockaWLiscie >= 0)
            {
                this.ListaKlocków[indexKlockaWLiscie].X = klocekDocelowy.X;
                this.ListaKlocków[indexKlockaWLiscie].Y = klocekDocelowy.Y;
            }

        }
    }
}
