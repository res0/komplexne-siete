using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class GraphNP : Graph
    {
        public override void Generate(int n, double p)
        {
            for (int i = 0; i < n; i++)
            {
                this.AddNode(new List<int>());
            }
        }
    }
}
