using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class GraphBarabasiAlbert : Graph
    {
        int m;

        public int GetDegreeSum()
        {
            int sum = 0;
            for (int j = 0; j < nodes.Count; j++)
            {
                sum += nodes[j].GetDegree();
            }
            return sum;
        }

        public void Generate(int count, int m)
        {
            this.m = m;
            

            nodes.Clear();
            nodes.Add(new Node(m));

            for (int i = 0; i < Count(); i++)
            {
                int sum = GetDegreeSum();
                
            }


        }


        
    }
}
