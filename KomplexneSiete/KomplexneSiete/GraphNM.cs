using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    /// <summary>
    /// zabezpečuje generovanie NM modelu
    /// </summary>
    public class GraphNM : Graph
    {
        /// <summary>
        /// generátor náhodných čísel
        /// </summary>
        private static Random random = new Random((int)DateTime.Now.Ticks);
        /// <summary>
        /// na základe i vráti náhodné čislo
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Nahodne(int i)
        {
            return (int)(random.NextDouble() * i);
        }
        /// <summary>
        /// vygeneruje graf s n vrcholmi a následne vytvorí m hrán v grafe medzi náhodnými vrcholmi (nevytvára násobné hrani ani slučky)
        /// </summary>
        /// <param name="n">počet vrcholov grafu</param>
        /// <param name="m">počet hrán grafu</param>
        public void Generate(int n , int m)
        {
            if (m > (n * (n - 1)) / 2)
            {
                return;
            }
            dict = new List<List<int>>();
            for(int i=0; i < n; i++)
            {
                this.AddNode(new List<int>());
            }
            for (int j = 0; j < m; j++ )
            {
                int cislo1 = Nahodne(n);
                int cislo2 = Nahodne(n);
                if (cislo1 == cislo2||!kontrola(cislo1 , cislo2))
                {
                    j--;
                }
                else
                {
                    if (cislo1 > cislo2)
                    {
                        int c = cislo1;
                        cislo1 = cislo2;
                        cislo2 = c;
                    }
                    dict.Add(new List<int>());
                    dict[dict.Count - 1].Add(cislo1);
                    dict[dict.Count - 1].Add(cislo2);
                    nodes[cislo1].AddEdge(cislo2);
                    nodes[cislo2].degree++;
                }
              
                
            }
            //Text();
                base.Generate();
        }
        /// <summary>
        /// skontroluje ci existuje hrana mezdi vrcholmi c1 ac2
        /// </summary>
        /// <param name="c1">prvy vrchol</param>
        /// <param name="c2">druhy vrchol</param>
        /// <returns>ak hrana existuje false inak true</returns>
        public bool kontrola(int c1 ,int c2){
            for (int i = 0; i < nodes[c1].GetEdges().Count; i++)
            {
                if (nodes[c1].GetEdges()[i] == c2)
                {
                    return false;
                }

            }
            for (int i = 0; i < nodes[c2].GetEdges().Count; i++)
            {
                if (nodes[c2].GetEdges()[i] == c1)
                {
                    return false;
                }

            }

                return true;
    }
    }
}
