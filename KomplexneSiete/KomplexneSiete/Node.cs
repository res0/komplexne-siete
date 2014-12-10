using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class Node
    {
        public List<int> edges;
        public int degree;
        public Node(List<int> edges)
        {
            this.edges = edges;
        }
        public Node()
        {
            edges = new List<int>();
        }
        public Node(int degree)
        {
            this.degree = degree;
        }

        public void AddEdge(int i)
        {
            edges.Add(i);
            degree++;
        }
        public void ChangeDegree(int i)
        {
            degree = i;
        }
        public List<int> GetEdges()
        {
            return edges;
        }
        public int GetDegree()
        {
            return degree;
        }
    }
}
