using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class Graph
    {
        public int m { get; set; }

        public List<List<int>> dict = null;

        protected List<Node> nodes;
        public Graph()
        {
            nodes = new List<Node>();
        }
        
        public List<Node> GetNodes()
        {
            return nodes;
        }

        public void AddNode(List<int> edges)
        {
            nodes.Add(new Node(edges));
        }

        public int Count()
        {
            return nodes.Count;
        }
        
        public virtual void Generate()
        {
            
        }
        public virtual void Update()
        {

        }
        public virtual void Draw()
        {

        }
        public void Text()
        {
            int i = 0;

            foreach (Node node in nodes)
            {
                List<int> edg = node.edges;
                string edges = "";
                if (edg != null)
                {
                    foreach (int edge in edg)
                    {
                        edges += edge.ToString() + ", ";
                    }
                }

                Console.WriteLine(i.ToString() + ". deg: " + node.GetDegree().ToString() + ", edge with: " + edges);
                i++;
            }
            Console.WriteLine("Done!");

        }
    }
}
