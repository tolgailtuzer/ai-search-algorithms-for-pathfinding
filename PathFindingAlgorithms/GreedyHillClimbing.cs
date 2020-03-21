using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingAlgorithms
{
    class GreedyHillClimbing
    {
        public static int GetBestNeighbour(int [] visited, int currentNode)
        {
            int bestNode = 0, bestValue = int.MaxValue;
            for(int i=0;i<Program.distances.GetLength(0); i++)
            {
                if(Program.distances[currentNode,i]!=-1 && visited[i]!=1)//Adjacency and visited check
                {
                    if(Program.heuristics[i]<bestValue)//Select nearest neighbour with heuristic info
                    {
                        bestValue = Program.heuristics[i];
                        bestNode = i;
                    }
                }
            }
            if (bestNode != 0) return bestNode;
            else return -1;//If bestNode never assign it means there is no next neighbour
        }

        public static List<int> FindPath(int start, int target, bool verbose)
        {
            int[] visited = new int[Program.distances.GetLength(0)];//Declare visited array for checking visited nodes
            string path = "";
            int currentNode = start;
            int realDistance = 0;
            int neighbour=0;
            List<int> solution = new List<int>();
            while(currentNode != target)
            {
                path += Program.cityNames[currentNode]+"->";
                solution.Add(currentNode);
                visited[currentNode] = 1;
                neighbour = GetBestNeighbour(visited, currentNode);
                if (neighbour == -1) break;//if there is no neighbour node then break
                realDistance += Program.distances[currentNode, neighbour];
                currentNode = neighbour;
            }
            path += Program.cityNames[currentNode];
            if (neighbour != -1) solution.Add(currentNode);
            if(verbose)Console.WriteLine("Path: "+path + "\nTotal Distance: " + realDistance);
            return solution;
        }
    }
}
