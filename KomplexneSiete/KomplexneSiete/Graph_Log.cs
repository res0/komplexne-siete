using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    public class Graph_Log
    {
        private List<List<int>> changes;
        public Graph_Log()
        {
            changes = new List<List<int>>();
        }
        public void Add_Step(List<int> edgesn)
        {
            changes.Add(edgesn);
        }
        public List<int> Get_Step(int i)
        { 
            if ((i < 0) || (i >= changes.Count))
            {
                return null;
            }
            return changes[i];
        }
    }
}
