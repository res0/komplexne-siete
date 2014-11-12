using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class Graph
    {
        protected List<Node> nodes;
        protected int nodeCount;
        public Graph()
        {
            nodes = new List<Node>();
        }
        public void AddNode()
        {
            Node nod = new Node();
            nodes.Add(nod);
        }
        Node Get(int i)
        {
            return nodes[i];
        }

        List<Node> GetNodes()
        {
            return nodes;
        }

        int Count()
        {
            return nodes.Count;
        }

        public virtual void Generate() {
            
        }
    }
}
