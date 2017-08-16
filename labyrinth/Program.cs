using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labyrinth.Class;

namespace labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            LabyrinthGenerator lb = new LabyrinthGenerator(30,30);
            watch.Stop();

            Console.WriteLine(lb.ToString());
            Console.WriteLine("Elapsed Time: " + watch.ElapsedMilliseconds/1000 + " seconds.") ;
            Console.ReadLine();

        }
    }
}
