using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingAlgorithms
{
    class ReadFile
    {
        public static void Read(string filename)
        {
            /* Input File Structure
             * n -> vertex count
             * n x n distance matrix
             * heuristic infos size of n
             */
            StreamReader sr = new StreamReader(filename);
            int n = Convert.ToInt32(sr.ReadLine());
            Program.distances = new int[n, n];
            Program.heuristics = new int[n];
            string[] line;
            for (int i = 0; i < n; i++)
            {
                line = sr.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    Program.distances[i,j]=Convert.ToInt32(line[j]);
                }
            }

            line = sr.ReadLine().Split(' ');
            for(int i =0;i<n;i++)
            {
                Program.heuristics[i] = Convert.ToInt32(line[i]);
            }
        }
    }
}
