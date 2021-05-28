/*
 * @lc app=leetcode.cn id=589 lang=csharp
 *
 * [589] N 叉树的前序遍历
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
using System;
using System.Collections.Generic;

public class Solution589 {
    public IList<int> Preorder(Node root) 
    {
        var ans = new List<int>();
        PreOrder_Recursive(ans, root);
        return ans;
    }

    private void PreOrder_Recursive(IList<int> res, Node node)
    {
        if (node == null)
        {
            return;
        }
        res.Add(node.val);
        for (int i = 0; i < node.children.Count; i++)
        {
            PreOrder_Recursive(res,node.children[i]);
        }
    }
// Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val,IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }

}
// @lc code=end

