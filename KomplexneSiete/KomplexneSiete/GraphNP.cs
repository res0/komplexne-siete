using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    /// <summary>
    /// zabezpečuje generovanie NP modelu
    /// </summary>
    public class GraphNP : Graph
    {
        /// <summary>
        /// vygenreruje graf s n vrcholmi a následne prejde všteky dvojice vrcholv grafu a s pravedpodobnosťou p medzi nimi vytvorí hranu
        /// </summary>
        /// <param name="n"> počet vrcholov grafu</param>
        /// <param name="p"> pradepodobnosť vytvorenia hrany medzi dvoma vrcholmi (0-1)</param>
        public void Generate(int n, double p)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                this.AddNode(new List<int>());
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    double cislo = rnd.NextDouble();
                    if (cislo < p)
                    {
                        //tu sa spravi hrana...
                        nodes[i].AddEdge(j);
                        nodes[j].degree++;
                    }
                }
            }
        }
    }
}
