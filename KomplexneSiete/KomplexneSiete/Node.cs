using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class Node
    {
        List<int> edges;
        int degree;
        public Node(List<int> myEdges)
        {
            edges = myEdges;
        }
        public Node()
        {
            edges = new List<int>();
        }
        public Node(int degree)
        {
            this.degree = degree;
        }

        void AddEdge(int i)
        {
            edges.Add(i);
            degree = edges.Count;
        }
        void ChangeDegree(int i)
        {
            degree = i;
        }
        public int GetDegree()
        {
            return degree;
        }
    }
}
