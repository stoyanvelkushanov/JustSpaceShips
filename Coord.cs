using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustSpaceShips
{
    public class Coord
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Coord(int x, int y) 
        {
            this.Row = x;
            this.Col = y;
        }

        public static Coord operator +(Coord a, Coord b)
        {
            return new Coord((a.Row + b.Row), (a.Col + b.Col));
        }

        public static Coord operator -(Coord a, Coord b)
        {
            return new Coord((a.Row - b.Row), (a.Col - b.Col));
        }

        public static bool operator ==(Coord a, Coord b)
        {
            return ((a.Row == b.Row) && (a.Col == b.Col));
        }

        public static bool operator !=(Coord a, Coord b)
        {
            return (a == b);
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() & this.Col;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.Row, this.Col);
        }
    }
}
