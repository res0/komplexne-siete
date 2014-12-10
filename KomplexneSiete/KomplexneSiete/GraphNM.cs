using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class GraphNM : Graph
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);
        public int Nahodne(int i)
        {
            return (int)(random.NextDouble() * i);
        }
        public void Generate(int n , int m)
        {
            if (m > (n * (n - 1)) / 2)
            {
                return; //TODO
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
                }
              
                
            }
            Text();
                base.Generate();
        }
        public override void Draw()

        {

            base.Draw();
        }
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
