using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class BarabasiAlbertGraph : Graph
    {
        int m;
        
        public void Generate(int count, int m)
        {
            this.m = m;
            this.nodeCount = count;

            nodes.Clear();
            nodes.Add(new Node(m));

            for (int i = 0; i < nodeCount; i++)
            {
                int sum = GetDegreeSum();
                
            }


        }

        int GetDegreeSum()
        {
            int sum = 0;
            for (int j = 0; j < nodes.Count; j++)
            {
                sum += nodes[j].GetDegree();
            }
            return sum;
        }
    }
}
