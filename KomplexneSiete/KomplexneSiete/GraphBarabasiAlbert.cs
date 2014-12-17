using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    /// <summary>
    /// zabezpečuje generovanie BA modelu
    /// </summary>
    public class GraphBarabasiAlbert : Graph
    {
        /// <summary>
        /// genrátor náhodných čísel
        /// </summary>
        private static Random random = new Random((int)DateTime.Now.Ticks);
        /// <summary>
        /// spočíta súčet stuňov všetkých vrcholov
        /// </summary>
        /// <returns>súčet stuňov všetkých vrcholov</returns>
        public int GetDegreeSum()
        {
            int sum = 0;
            for (int j = 0; j < nodes.Count; j++)
            {
                sum += nodes[j].GetDegree();
            }
            return sum;
        }
        /// <summary>
        /// zvýši stpeň vrchola i o num
        /// </summary>
        /// <param name="i">index vrcholu</param>
        /// <param name="num">príastok , default = 1</param>
        void IncDegree(int i, int num = 1)
        {
            nodes[i].ChangeDegree(nodes[i].GetDegree()+num);
        }
        /// <summary>
        /// zvýši stueň naposledy pridaného vrcholao num
        /// </summary>
        /// <param name="num">príastok</param>
        void IncLastDegree(int num)
        {
            int i = nodes.Count - 1;
            IncDegree(i,num);
        }
        public double GetProbability(int i)
        {
            double d = nodes[i].GetDegree();
            double s = GetDegreeSum();
            return d / s;
        }
        public bool TestProbability(int i)
        {
            double rn = random.NextDouble();
            double prob = GetProbability(i);

            return (rn <= prob);
        }

        /*
         * Postup:
         * - prida 1 vrchol
         * - prida m vrcholov (kazdy ma hranu len s prvym vrcholom)
         * 
         * Cyklus: count - m - 1
         * Algoritmus BA modelu - pridavanie vrcholu
         * - vypocita sa pravdepodobnost pre kazdy existujuci vrchol, otestuje ju, ak splni, prida hranu noveho vrcholu k nemu
         * - opakuje sa
         **/
        /// <summary>
        /// Generates nodes and edges based on Barabasi Albert algorithm.
        /// </summary>
        /// <param name="count">Node count</param>
        /// <param name="m">Number of edges for each node</param>
        public void Generate(int count, int m)
        {
            this.m = m;
            nodes.Clear();

            #region Generate the first m+1 Nodes

            AddNode(null);
            
            List<int> firstEdge = new List<int>();
            firstEdge.Add(0);

            for (int i = 0; i < m; i++)
            {
                AddNode(firstEdge);
                IncLastDegree(1);
                IncDegree(0);
            }

            #endregion

            #region Generate the rest with BA algorithm (hopefully :D)

            while (Count()<count)
            {
                int cn = 0;
                List<int> edge = new List<int>();
                //vo Wikipedii je sice, ze tych hran moze byt mensie alebo rovne m0,
                //ale vo vsetkych obrazkoch co som nasiel sa vzdy pripaja rovnakym poctom hran
                //tak teraz neviem :D ak to tak nie je, tak tento while cyklus vymazem:
                while (edge.Count < m) 
                {
                    for (int j = 0; j < Count(); j++)
                    {
                        if (edge.Contains(j)) continue;
                        int sum = GetDegreeSum();

                        bool testProb = TestProbability(j);

                        if (testProb)
                        {
                            IncDegree(j);
                            edge.Add(j);
                            cn++;
                            if (edge.Count >= m) break;
                        }
                    }
                }
                if (edge.Count > 0)
                {
                    AddNode(edge);
                    IncLastDegree(edge.Count);
                }

            }

            #endregion

        }
        public void Draw()
        {
            if (this.GetNodes() != null) 
            {
                BAform b = new BAform(this.GetNodes(), 20,this.m);
                b.ShowDialog();
            }
        }

       
    }
}
