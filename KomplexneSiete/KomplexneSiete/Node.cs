using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomplexneSiete
{
    /// <summary>
    /// predsatavuje vrchol grafu
    /// </summary>
    public class Node
    {
        /// <summary>
        /// zoznam vrcholov do ktorých bola z tohto vrcholu vytvorená hrana 
        /// </summary>
        public List<int> edges;
        /// <summary>
        /// stupeň vrcholu
        /// </summary>
        public int degree;
        /// <summary>
        /// konštruktor ,vyrvorý vrchol s hranamy
        /// </summary>
        /// <param name="edges">zoznam vrcholov do ktorých bola z tohto vrcholu vytvorená hrana</param>
        public Node(List<int> edges)
        {
            this.edges = edges;
        }
        /// <summary>
        /// konštruktor, vytvorý vrchol bez hrán
        /// </summary>
        public Node()
        {
            edges = new List<int>();
        }
        /// <summary>
        /// konštruktor , vytrvorý vrchol zo zadaným stupňom
        /// </summary>
        /// <param name="degree">spueň vrchola</param>
        public Node(int degree)
        {
            this.degree = degree;
        }
        /// <summary>
        /// do edges pridá i, teda pridá tomuto vrcholu hranu a zvýši jeho stueň
        /// </summary>
        /// <param name="i"></param>
        public void AddEdge(int i)
        {
            edges.Add(i);
            degree++;
        }
        /// <summary>
        /// zmení stueň vrchola na i
        /// </summary>
        /// <param name="i">nový stupeň vrchola</param>
        public void ChangeDegree(int i)
        {
            degree = i;
        }
        /// <summary>
        /// vracia zoznam hrán
        /// </summary>
        /// <returns>zoznam hrán</returns>
        public List<int> GetEdges()
        {
            return edges;
        }
        /// <summary>
        /// vracia stupeň vrchola
        /// </summary>
        /// <returns>stuepň vrchola</returns>
        public int GetDegree()
        {
            return degree;
        }
    }
}
