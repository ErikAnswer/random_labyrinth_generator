using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Class.Tree
{
    class Node
    {
        public int distance { get; set; }
        public Point pos { get; set; }

        public string component { get; set; }

        public bool isPath { get; set; }
        
        public Node()
        {
            distance = 0;
            pos = new Point(0,0);
            isPath = false;
        }

        public Node(int posx, int posy)
        {
            distance = 0;
            pos = new Point(posx, posy);
            isPath = false;
        }

        public Node(int posx, int posy, int distance)
        {
            this.distance = distance;
            this.pos = new Point(posx, posy);
            isPath = false;
        }

        public Node(int posx, int posy, int distance, string path)
        {
            this.distance = distance;
            this.pos = new Point(posx, posy);
            this.component = path;
            isPath = false;
        }

        public Node(int distance, Point pos)
        {
            this.distance = distance;
            this.pos = pos;
            isPath = false;
        }

        public override bool Equals(object obj)
        {
            return (obj != null) && (obj.GetType() == (typeof(Node))) && ((Node)obj).pos.Equals(this.pos);
        }
    }
}
