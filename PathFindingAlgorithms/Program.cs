using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingAlgorithms
{
    class Program
    {
        public static int [,] distances;
        public static int [] heuristics;
        /*public static char[] cityNames = { 'A', 'X', 'Y', 'Z', 'K', 'L', 'M', 'N', 'T', 'B' };*/
        public static String[] cityNames = {"ORADEA", "ZERIND", "ARAD", "TIMISOARA", "LUGOJ", "MEHADIA",
        "DROBETA", "CRAIOVA","SIBIU", "FAGARAS", "RIMNICU VILCEA", "PITESTI",
        "BUCHAREST", "GIURGIU", "URZICENI", "HIRSOVA", "EFORIE", "VASLUI", "IASI", "NEAMT"};
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            //ReadFile.Read("distances.txt");
            ReadFile.Read("romania.txt");
            Console.WriteLine("Enter a start and target node:");
            string[] input = Console.ReadLine().Split(' ');
            int start = Convert.ToInt32(input[0]);
            int target = Convert.ToInt32(input[1]);
            //All algorithms take start,target and verbose parameters
            //GreedyHillClimbing
            Console.WriteLine("--------------------\nGreedy Hill Climbing\n--------------------");
            stopWatch.Start();
            //GreedyHillClimbing.FindPath(start, target, true);
            GreedyHillClimbing.FindPath(start, target, true);
            stopWatch.Stop();
            Console.WriteLine("Elapsed Time: " + stopWatch.Elapsed);
            //HillClimbingWithSimulatedAnnealing
            Console.WriteLine("--------------------------------------\nHill Climbing With Simulated Annealing\n--------------------------------------");
            stopWatch.Start();
            //HillClimbingWithSA.FindPath(start, target, true);
            HillClimbingWithSA.FindPath(start, target, true);
            stopWatch.Stop();
            Console.WriteLine("Elapsed Time: " + stopWatch.Elapsed);
            //A*
            Console.WriteLine("---------\nA* Search\n---------");
            stopWatch.Start();
            //AStar.FindPath(start, target, true);
            AStar.FindPath(start, target, true);
            stopWatch.Stop();
            Console.WriteLine("Elapsed Time: "+stopWatch.Elapsed);
            Console.Read();
        }
    }
}
