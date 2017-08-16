using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Class
{
    class Point
    {
        public int x { get; }
        public int y { get; }


        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return (obj.GetType() == typeof(Point)) && (((Point) obj).x == this.x && ((Point) obj).y == this.y);
        }


        public override int GetHashCode()
        {
            return 0;
        }
    }

    
}
