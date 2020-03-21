using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingAlgorithms
{
    class AStar
    {
        public struct Vertex
        {
            public int id;
            public int total_distance;
            public int fitness;
            public int ancestor;

            public Vertex(int id, int total_distance, int fitness, int ancestor)
            {
                this.id = id;
                this.total_distance = total_distance;
                this.fitness = fitness;
                this.ancestor = ancestor;
            }
            public void Setter(Vertex A)
            {
                this.id = A.id;
                this.total_distance = A.total_distance;
                this.fitness = A.fitness;
                this.ancestor = A.ancestor;
            }
        }
        public static void GetPath(Vertex vertex, Dictionary<int, Vertex> allVertices, int start)//Backtracks with using Vertex->ancestor and finds path.
        {
            int current = vertex.id;
            string path = "";
            int realDistance = 0;
            while (current != start)
            {
                path += Program.cityNames[current] + ">";
                realDistance += Program.distances[allVertices[current].ancestor, current];
                current = allVertices[current].ancestor;
            }
            path += Program.cityNames[current];
            string[] array = path.Split('>');
            Array.Reverse(array);
            Console.Write("Path: ");
            for(int i =0;i<array.Length;i++)
            {
                if (i == array.Length - 1) Console.Write(array[i]);
                else Console.Write(array[i] + "->");
            }
            Console.WriteLine("\nTotal Distance: " + realDistance);
        }

        public static List<int> FindPath(int start, int target, bool verbose)
        {
            int[] visited = new int[Program.distances.GetLength(0)];
            List<int> open = new List<int>();
            List<int> closed = new List<int>();
            Dictionary<int, Vertex> all_vertices = new Dictionary<int, Vertex>();
            List<int> solution = new List<int>();
            Vertex current = new Vertex(start, 0, 0, 0);
            all_vertices.Add(start, current);
            double heuristicWeight = 1; //If problem heuristic info is over-estimated(heuristic distance greater than real distance). Because of that A* algorithm not finding optimal path. 
            while (current.id != target)//If we decrease the heuristicWeight, algorithm find the optimal path.
            {
                for (int i = 0; i < Program.distances.GetLength(0); i++)
                {
                    if (Program.distances[current.id, i] != -1 && !closed.Contains(i))//Adjacency and visited check
                    {
                        Vertex temp = new Vertex();
                        if (!open.Contains(i) && !closed.Contains(i))//If vertex never explored
                        {
                            open.Add(i);
                            all_vertices.Add(i, temp);
                            temp.ancestor = current.id;
                            temp.fitness = 0;
                        }
                        //Applies f(fitness)=g(total_distance)+h(heuristic_info)
                        int total_distance = all_vertices[current.id].total_distance + Program.distances[current.id, i];//total distance = currentvertex_total_distance + distance[current->neighbour]
                        int fitness = total_distance + Convert.ToInt32(Program.heuristics[i] * heuristicWeight);//We can change heuristicWeight if heuristic info not admissible
                        if (fitness < all_vertices[i].fitness || all_vertices[i].fitness == 0)//If vertex fitness never assigned or current fitness lower than vertex fitness. New values are assign.
                        {
                            temp.id = i;
                            temp.fitness = fitness;
                            temp.total_distance = total_distance;
                            temp.ancestor = current.id;
                            all_vertices[i] = temp;
                        }

                    }
                }
                closed.Add(current.id);
                int minFitness = int.MaxValue;
                Vertex minElement = new Vertex();
                foreach (int element in open)//Choose minimum fitness element as current from openList
                {
                    if (all_vertices[element].fitness < minFitness)
                    {
                        minFitness = all_vertices[element].fitness;
                        minElement.Setter(all_vertices[element]);
                    }
                }
                open.Remove(minElement.id);
                current.Setter(minElement);
            }
            GetPath(current, all_vertices, start);
            return solution;
        }
    }
}
