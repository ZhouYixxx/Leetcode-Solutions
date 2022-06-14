/*
 * @lc app=leetcode.cn id=133 lang=csharp
 *
 * [133] 克隆图
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution133 {
    public void Test(){
        var s = "[[2,4],[1,3],[2,4],[1,3]]";
        var adjList = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        var nodeList = DataStructureHelper.GenerateUDGNodesFromArray(adjList);
        var node = nodeList[0];
        var ans = CloneGraph(node);
    }

    public Node CloneGraph(Node node) {
        //key:原节点，value:克隆
        // var dic = new Dictionary<Node,Node>();
        // return dfs(node, dic);
        return bfs(node);
    }

    private Node dfs(Node node, Dictionary<Node, Node> memoDic)
    {
        if (node == null)
        {
            return node;
        }
        if (memoDic.ContainsKey(node))
        {
            return memoDic[node];
        }
        var cloneNode = new Node(node.val, new List<Node>());
        memoDic.Add(node, cloneNode);
        foreach (var neighbor in node.neighbors)
        {
            var cloneNeighbor = dfs(neighbor, memoDic);
            cloneNode.neighbors.Add(cloneNeighbor);
        }
        return cloneNode;
    }

    private Node bfs(Node node)
    {
        if (node == null)
        {
            return node;
        }
        var dic = new Dictionary<Node,Node>();
        var q = new Queue<Node>();
        var cloneNode = new Node(node.val, new List<Node>());
        dic.Add(node, cloneNode);
        q.Enqueue(node);
        while (q.Count > 0)
        {
            var p = q.Dequeue();
            foreach (var neighbor in p.neighbors)
            {
                if (!dic.ContainsKey(neighbor))
                {
                    dic.Add(neighbor, new Node(neighbor.val, new List<Node>()));
                    q.Enqueue(neighbor);
                }
                dic[p].neighbors.Add(dic[neighbor]);
            }
        }
        return cloneNode;
    }
}
// @lc code=end

