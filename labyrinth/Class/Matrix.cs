using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using labyrinth.Interface;

namespace labyrinth.Class
{
    class Matrix
    {

        public string[,] body;

        public Dictionary<Point, bool> isStepped;
        private int nColumn { get; }
        private int nRow { get; }

        private Random rnd = new Random();

        public Matrix(int row, int column)
        {
            nRow = row;
            nColumn = column;
            body = new string[row, column];
            isStepped = new Dictionary<Point, bool>();
            initializeMatrix();
            emptyInside();

        }

        private void emptyInside()
        {
            for (int i = 1; i < nRow - 1; i++)
            {
                for (int j = 1; j < nColumn -1; j++)
                {
                    body[i, j] = " ";
                }
            }
        }

        private void initializeMatrix()
        {

            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nColumn; j++)
                {
                    body[i, j] = "#";
                    isStepped.Add(new Point(i,j), false);
                }
            }
        }
        public bool isBorder(int row, int column)
        {

            return (row == 0 && column == 0) || (row == nRow - 1 && column == nColumn - 1) ||
                   (row == nRow - 1 && column == 0) || (row == 0 && column == nColumn - 1);

        }

        public string getPos(int row, int column)
        {
            string aux;
            try
            {
                aux = body[row, column];
            }
            catch (IndexOutOfRangeException)
            {
                return "";
            }

            return aux;
        }

        public bool isSteppedOn(Point point)
        {
            bool isStep = false;

            isStepped.TryGetValue(point, out isStep);
            

            return isStep;
        }

        public void setStep(Point point)
        {
            if (isStepped.ContainsKey(point))
            {
                isStepped[point] = true;
                
            }

            
            
        }

        public void setComp(int row, int column, IComponent comp)
        {

            body[row, column] = comp.getComp();
        }

        public void setRandomCompInside(IComponent comp)
        {


            body[rnd.Next(1,nRow -1), rnd.Next(1,nColumn -1)] = comp.getComp();
        }

        public Point setRandomCompInWall(int wall, IComponent comp)
        {
            int rowPos;
            int columnPos;

            //              1
            //      -----------------
            //      -               -
            //      -               -
            //  0   -               -   2
            //      -               -
            //      -               -
            //      -----------------
            //              3


            if (wall == 1)
            {
                do
                {
                    rowPos = 0;
                    columnPos = rnd.Next(0, nColumn);
                } while (isBorder(rowPos, columnPos));


            }
            else if (wall == 2)
            {
                do
                {
                    rowPos = rnd.Next(0,nRow);
                    columnPos = nColumn - 1;
                } while (isBorder(rowPos, columnPos));


            }
            else if (wall == 3)
            {
                do
                {
                    rowPos = nRow -1;
                    columnPos = rnd.Next(0, nColumn);
                } while (isBorder(rowPos, columnPos));
            }
            else
            {
                do
                {
                    rowPos = rnd.Next(0, nRow);
                    columnPos = 0;
                } while (isBorder(rowPos, columnPos));
            }

            Point aux = new Point(rowPos, columnPos);
            body[rowPos, columnPos] = comp.getComp();

            return aux;

        }

        public void emptyDictionary()
        {
            isStepped = new Dictionary<Point, bool>();

            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nColumn; j++)
                {
                    isStepped.Add(new Point(i, j), false);
                }
            }

        }

        public bool isWall(int row, int column)
        {
            return (row == 0 || row == nRow -1 || column == 0 || column == nColumn -1);
        }

        public ArrayList getRow(int row)
        {
            ArrayList aux = new ArrayList();
            for (int i = 0; i < nColumn; i++)
            {
                aux.Add(body[row, i]);
            }

            return aux;
        }

        public ArrayList getColumn(int column)
        {

            ArrayList aux = new ArrayList();
            for (int i = 0; i < nRow; i++)
            {
                aux.Add(body[i, column]);
            }

            return aux;

        }

        public void setRow(int row, ArrayList rowList)
        {


            for (int i = 0; i < nRow; i++)
            {
                body[row, i] = rowList[i].ToString();
            }



        }

        public void setColumn(int column, ArrayList columnList)
        {
            for (int i = 0; i < nRow; i++)
            {
                body[i, column] = columnList[i].ToString();
            }


        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nColumn; j++)
                {
                    sb.Append(body[i, j]);
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
