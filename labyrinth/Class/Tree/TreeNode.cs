using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Class.Tree
{
    class TreeNode
    {

        public Node node { get; }
        public Node parent { get; set; }
        public List<Node> children { get;  }


        public TreeNode(Node node)
        {
            this.node = node;
            this.parent = null;
            this.children = new List<Node>();

        }

        public TreeNode(Node node, Node parent)
        {
            this.node = node;
            this.parent = parent;
            this.children = new List<Node>();
        }

        public void addChildren(Node child)
        {
            children.Add(child);
            
        }

        public bool isPosParent(Node n)
        {
            return n.Equals(node);
        }

    }
}
