using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    /// <summary>
    /// trieda tvoriaca graf ako zoznam nodov
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// ak je graf BA tak určuje źačiatočný počet vrcolov
        /// </summary>
        public int m { get; set; }
        /// <summary>
        /// ak je graf NM tak si pamatá ktoré dvjice vrchlov boli náhodne vyberané
        /// </summary>
        public List<List<int>> dict = null;
        /// <summary>
        /// zoznam vrchlov grafu
        /// </summary>
        protected List<Node> nodes;
        /// <summary>
        /// konštruktor , vytvorý prázdny graf
        /// </summary>
        public Graph()
        {
            nodes = new List<Node>();
        }
        /// <summary>
        /// vracia zoznam vrchlov grafu
        /// </summary>
        /// <returns>zoznam vrchlov grafu</returns>
        public List<Node> GetNodes()
        {
            return nodes;
        }
        /// <summary>
        /// pridá vrchlo do grafu
        /// </summary>
        /// <param name="edges">zoznam hrán nového vrcholu</param>
        public void AddNode(List<int> edges)
        {
            nodes.Add(new Node(edges));
        }
        /// <summary>
        /// vráti počet vrcholv grafu
        /// </summary>
        /// <returns>počet vrcholv grafu</returns>
        public int Count()
        {
            return nodes.Count;
        }
        /// <summary>
        /// virtuálna metóda pregenerovanie
        /// </summary>
        public virtual void Generate()
        {
            
        }
        /// <summary>
        /// virtuálna metída pre vizualizáciu
        /// </summary>
        public virtual void Draw()
        {

        }
        /// <summary>
        /// debugovacia funkcia , do konzoli vypíše zoznam vrchlov a hrán grafu
        /// </summary>
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
