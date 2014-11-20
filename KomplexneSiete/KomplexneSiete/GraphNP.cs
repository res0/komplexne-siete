using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class GraphNP : Graph
    {
        public void Generate(int n, double p)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                this.AddNode(new List<int>());
            }
            for (int i = 0; i < n; i++)
            {
                double cislo = rnd.NextDouble();
                if (cislo < p)
                { 
                    
                }
            }
        }
    }
}
