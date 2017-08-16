using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using labyrinth.Class.Tree;
using labyrinth.Interface;

namespace labyrinth.Class
{
    class LabyrinthGenerator
    {
        private Matrix matrix;
        private Point whereIsEntry;
        private Point whereIsExit;
        private int N;
        private int M;
        private Random rnd = new Random();
        private TreeNode tree;

        public LabyrinthGenerator(int N, int M)
        {
            this.N = N;
            this.M = M;
            matrix = new Matrix(N,M);
            EntryExit();
            do
            {
                CreateRandomLabyrinth();
                
            } while (!existPath());


        }

        private bool existPath()
        {
            tree = new TreeNode(new Node(0,whereIsEntry));
            Node rNode = null;
            ContinueToExit(tree, ref rNode);

            return rNode != null;
        }

        private void ContinueToExit(TreeNode tree, ref Node rNode)
        {
            List<Point> possiblePath = new List<Point>();
            

            possiblePath.Add(new Point(tree.node.pos.x + 1, tree.node.pos.y));
            possiblePath.Add(new Point(tree.node.pos.x - 1, tree.node.pos.y));
            possiblePath.Add(new Point(tree.node.pos.x, tree.node.pos.y + 1));
            possiblePath.Add(new Point(tree.node.pos.x, tree.node.pos.y - 1));

            for (int i = 0; i < 4; i++)
            {
                Node aux = new Node(possiblePath[i].x, possiblePath[i].y, tree.node.distance + 1, matrix.getPos(possiblePath[i].x, possiblePath[i].y));
                if (rNode != null)
                {
                    break;
                }else if (aux.component == " " && !tree.isPosParent(aux) && !matrix.isSteppedOn(aux.pos))
                {
                    tree.addChildren(aux);
                    matrix.setStep(aux.pos);
                    ContinueToExit(new TreeNode(aux, tree.node),ref rNode);
                    
                }else if (aux.component == "S")
                {
                    rNode = aux;
                }
                
                
            }

           






        }

       
        private void CreateRandomLabyrinth()
        {
            int insideWalls = (N * M - (N * 2 + (M - 2) * 2));


            IComponent aux;

            for (int i = 0; i < insideWalls; i++)
            {
                if (rnd.Next(0, 2) == 0)
                {
                    aux = new EmptyPath();
                }
                else
                {
                    aux = new Wall();
                }

                matrix.setRandomCompInside(aux);
            }

            matrix.emptyDictionary();


        }

        private void EntryExit()
        {
            
            int entryWall, exitWall;

            do
            {
                entryWall = rnd.Next(0, 4);
                exitWall = rnd.Next(0, 4);
            } while (entryWall == exitWall);

            whereIsEntry = matrix.setRandomCompInWall(entryWall, new Entry());
            whereIsExit = matrix.setRandomCompInWall(exitWall, new Exit());

        }


        public override string ToString()
        {
            return matrix.ToString();
        }
    }
}
