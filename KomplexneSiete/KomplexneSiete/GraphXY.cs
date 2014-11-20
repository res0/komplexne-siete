using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class GraphXY
    {
        private Graph graf;
        private Dictionary<int, int> count;
        public GraphXY()
        {
            graf = new Graph();
            count = new Dictionary<int, int>();
        }
        public void Set_Graph(Graph grafn)
        {
            graf = grafn;
            count = new Dictionary<int, int>();
        }
        public void Make_Graph()
        {
            List<Node> pom = graf.GetNodes();
            for (int i = 0; i < graf.Count() ; i++)
            {
                if (count.ContainsKey(pom[i].GetDegree()))
                {
                    count[pom[i].GetDegree()]++;
                }
                else
                {
                    count.Add(pom[i].GetDegree(), 1);
                }
            }
        }
        public void Show_graph()
        {
            Make_Graph();
            //TODO
        }

    }
}
