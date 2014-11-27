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
            for(int i=0; i < n; i++)
            {
                this.AddNode(new List<int>());
            }
            for (int j = 0; j < m; j++ )
            {
                int cislo1 = Nahodne(n);
                int cislo2 = Nahodne(n);
                /*if (cislo1 == cislo2)
                {
                    Testovanie ci hrana nebude slucka
                    + max 1 hrana medzi 2 vrcholmi
                }*/
                if(cislo1>cislo2){
                    int c = cislo1;
                    cislo1 = cislo2;
                    cislo2 = c;
                }
                nodes[cislo1].AddEdge(cislo2);
            }
            Text();
                base.Generate();
        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}
