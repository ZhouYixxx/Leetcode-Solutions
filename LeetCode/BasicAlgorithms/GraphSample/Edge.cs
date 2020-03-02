using System.Collections.Generic;

namespace CodePractice.BasicAlgorithms.GraphSample
{
    /// <summary>
    /// 图的边
    /// </summary>
    public class Edge<T>
    {
        public Edge()
        {

        }

        public Edge(Node startNode, Node endNode, T value)
        {
            StartNode = startNode;
            EndNode = endNode;
            Weight = value;
        }

        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        public T Weight { get; set; }
    }
}