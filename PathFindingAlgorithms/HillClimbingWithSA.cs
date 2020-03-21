using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingAlgorithms
{
    class HillClimbingWithSA
    {
        public static int RouletteChart(Dictionary<int, int> neighbours, int sumDistances)
        {
            //By subtracting the distances from the total distance, the shortest distance will have the most probability of selection
            Random random = new Random();
            double sum = 0;
            foreach (var item in neighbours)
            {
                sum += sumDistances - item.Value;
            }
            if (neighbours.Count!=0 && sum == 0) return neighbours.Keys.First();//If neighbours list have one element
            double p = random.NextDouble() * sum;//Selects a random number between 0 and total distance
            sum = 0;
            foreach (var item in neighbours)
            {
                sum += sumDistances - item.Value;
                if (p < sum)//It continues to add as long as the total is less than the random number
                {
                    return item.Key;
                }
            }
            return -1;
        }

        public static List<int> GetSolution(int start, int target)
        {
            int[] visited = new int[Program.distances.GetLength(0)];
            int currentNode = start;
            int nextNeighbour = 0;
            List<int> solution = new List<int>();
            while (currentNode != target)
            {
                solution.Add(currentNode);
                visited[currentNode] = 1;
                Dictionary<int, int> neighbours = new Dictionary<int, int>();//List for current node's neighbours
                int sumDistances = 0;
                for (int i = 0; i < Program.distances.GetLength(0); i++)
                {
                    if (Program.distances[currentNode, i] != -1 && visited[i] != 1)//Adjacency and visited check
                    {
                        neighbours.Add(i, Program.heuristics[i]);
                        sumDistances += Program.heuristics[i];//Sums heuristic distances for Roulette Chart
                    }
                }
                nextNeighbour = RouletteChart(neighbours, sumDistances);//Selects nextNeighbour with Roulette Chart
                if (nextNeighbour == -1) break;//if there is no neighbour node then break
                currentNode = nextNeighbour;
            }
            if(nextNeighbour!=-1)solution.Add(currentNode);
            if (currentNode == target) return solution;
            else return null;//If solution's path not valid and returns null
        }

        public static int CalculateFitness(List<int> solution)//Returns total real distance
        {
            if (solution == null) return int.MaxValue;
            int fitness = 0;
            for (int i = 0; i < solution.Count - 1; i++)
            {
                fitness += Program.distances[solution[i], solution[i + 1]];
            }
            return fitness;
        }

        public static List<int> FindPath(int start, int target,bool verbose)
        {
            double T = 100;//Start Temp
            double endTemp = 0.1, coolingRate = 0.988;
            Random random = new Random();
            int delta = 0;
            List<int> current = GreedyHillClimbing.FindPath(start, target,false);//Declare start solution as GreedyHillClimbing's path
            List<int> bestSolution=null;
            while (T > endTemp)
            {
                List<int> temp = null;

                for (int i = 0; i < 100; i++)//Iterate 100 times for each temp
                {
                    List<int> nextElement = GetSolution(start, target);//Get next solution
                    
                    if(nextElement!=null)
                    {
                        delta = CalculateFitness(nextElement) - CalculateFitness(current);// If next solution's distance shorter than current it choose directly
                        if (delta < 0)                                                    // Else it chooses depending on the temperature
                        {
                            current = nextElement;
                        }
                        else
                        {
                            double prob = random.NextDouble();
                            if (prob < Math.Exp(-1 * delta / T))
                            {
                                current = nextElement;
                            }
                        }
                        if (CalculateFitness(current) < CalculateFitness(temp))
                        {
                            temp = current;
                        }
                    }          
                }
                if(temp!=null)
                {
                    current = temp;
                    T *= coolingRate;
                    if (CalculateFitness(current) < CalculateFitness(bestSolution))
                    {
                        bestSolution = current;
                    }
                    /*for (int i = 0; i < current.Count; i++)
                    {
                        Console.Write(current[i] + " ");
                    }
                    Console.WriteLine("\n" + CalculateFitness(current));*/
                }
                
            }
            if (bestSolution==null) Console.WriteLine("There is no path between {0}-{0}", start, target);
            if(verbose)
            {
                Console.Write("Path: ");
                for (int i = 0; i < bestSolution.Count; i++)
                {
                    if(i==bestSolution.Count-1) Console.Write(Program.cityNames[bestSolution[i]]);
                    else Console.Write(Program.cityNames[bestSolution[i]] + "->");

                }
                Console.WriteLine("\nTotal Distance: " + CalculateFitness(bestSolution));
            }        
            return bestSolution;
        }
    }
}
