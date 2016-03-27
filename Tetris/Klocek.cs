using System;
using System.Drawing;

namespace Tetris
{
    public class Klocek : IEquatable<Klocek>, ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Kolor { get; set; }

        public Klocek(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Kolor = Color.Transparent;
        }

        public Klocek(int x, int y, Color kolor)
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
    }
}
