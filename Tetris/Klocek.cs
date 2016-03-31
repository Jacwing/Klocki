using System;
using System.ComponentModel;
using System.Windows.Media;

namespace Tetris
{
    public class Klocek : IEquatable<Klocek>, ICloneable, INotifyPropertyChanged
    {
        private Brush kolor;
        public int X { get; set; }
        public int Y { get; set; }
        public Brush Kolor
        {
            get { return kolor; }
            set
            {
                if (kolor != value)
                {
                    kolor = value;
                    OnPropertyChanged("Kolor");
                }
            }
        }

        public Klocek(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Kolor = Brushes.Transparent;
        }

        public Klocek(int x, int y, Brush kolor)
        {
            this.X = x;
            this.Y = y;
            this.Kolor = kolor;
        }

        public bool Equals(Klocek klocek)
        {
            if ((this.X == klocek.X) && (this.Y == klocek.Y))
                return true;
            else
                return false;
        }

        public object Clone()
        {
            Klocek klocek = new Klocek(this.X, this.Y, this.Kolor);
            return klocek;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
