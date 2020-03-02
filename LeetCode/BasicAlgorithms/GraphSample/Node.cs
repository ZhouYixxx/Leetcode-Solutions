using System.Collections;
using System.Collections.Generic;

namespace CodePractice.BasicAlgorithms.GraphSample
{
    /// <summary>
    /// 图的节点/顶点
    /// </summary>
    public class Node
    {
        public Node(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public bool IsVisited { get; set; }

        public IEnumerable<Node> NeighborNodes { get; set; }
    }
}