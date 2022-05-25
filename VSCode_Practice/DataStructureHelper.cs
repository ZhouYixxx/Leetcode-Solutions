using System;
using System.Collections.Generic;

public static class DataStructureHelper
{
    #region 字符串

    /// <summary>
    /// 将形如[[1,2,3],[2,3,4]]的字符串转为int[][]
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int[][] ConvertStringToTwoDimenNumArray(string str)
    {
        var res = new List<int[]>();
        var stack = new Stack<char>();
        int start = 0;
        int end = 0;
        for (int i = 0; i < str.Length; i++)
        {
            var ch = str[i];
            if (ch == '[')
            {
                if (stack.Count == 1)
                {
                    start = i;
                }
                stack.Push(ch);
            }
            else if (ch == ']')
            {
                if (stack.Count == 2)
                {
                    end = i;
                    var tempRes = ConvertStringToNumArrayInternal(str,start, end);
                    res.Add(tempRes);
                    stack.Pop();
                }
            }
        }
        return res.ToArray();
    }

    /// <summary>
    /// 将形如[1,2,3]的字符串转为int[]
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int[] ConvertStringToNumArray(string str)
    {
        return ConvertStringToNumArrayInternal(str, 0, str.Length-1);
    }
    
    private static int[] ConvertStringToNumArrayInternal(string str, int start, int end)
    {
        if (end <= start + 1)
        {
            return new int[0];
        }
        var res = new List<int>();
        int val = 0;
        for (int i = start; i <= end; i++)
        {
            if (str[i] == '[')
            {
                continue;
            }
            if (str[i] <= '9' && str[i] >= '0')
            {
                var digit = (int)str[i] - 48;
                val = val*10 + digit;
            }
            if (str[i] == ',' || (i == end && str[i] == ']'))
            {
                res.Add(val);
                val = 0;
            }
        }
        return res.ToArray();
    }

    #endregion

    #region 链表处理

    /// <summary>
    /// 从数组生成链表
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static ListNode GenerateLinkedListFromArray(int[] nums)
    {
        var dummy = new ListNode();
        var cur = dummy;
        for (int i = 0; i < nums.Length; i++)
        {
            var node = new ListNode(nums[i]);
            cur.next = node;
            cur = cur.next;
        }
        return dummy.next;
    }

    /// <summary>
    /// 从链表生成数组
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static int[] ToArray(this ListNode node)
    {
        var list = new List<int>();
        while (node != null)
        {
            list.Add(node.val);
            node = node.next;
        }
        return list.ToArray();
    }

    #endregion

    #region 二叉树
    /// <summary>
    /// 从数组生成二叉树，数组应该是按二叉树的层依次写入的,允许省略非必要的null值,参考LeetCode题目中的常见写法
    /// </summary>
    /// <param name="nums">包含二叉树每个节点的值，占位的null不能省略</param>
    /// <returns></returns>
    public static TreeNode GenerateTreeFromArray(int?[] nums)
    {
        if (nums.Length == 0 || nums[0] == null)
        {
            return null;
        }
        var dic = new Dictionary<int,TreeNode>();
        for (int i = 0; i < nums.Length; i++)
        {
            var node = nums[i] != null ? new TreeNode(nums[i].Value) : null;
            dic.Add(i,node);
        }
        SearchEachLevel(nums,0,dic,0,0);
        var root = dic[0];
        return root;
    }

    public static TreeNode GetNode(this TreeNode root, int val)
    {
        return DFS(root,val);
    }

    private static TreeNode DFS(TreeNode root, int val)
    {
        if (root == null)
        {
            return null;
        }
        if (root.val == val)
        {
            return root;
        }
        var left = GetNode(root.left, val);
        if (left != null)
        {
            return left;
        }
        var right = GetNode(root.right, val);
        if (right != null)
        {
            return right;
        }
        return null;
    }

    /// <summary>
    /// 二叉树层序生成数组
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns></returns>
    public static int[] ToArray(this TreeNode root)
    {
        var list = new List<int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            list.Add(node.val);
            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }
            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }
        return list.ToArray();
    }

    /// <summary>
    /// 按层解析
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="level"></param>
    /// <param name="dic"></param>
    /// <param name="preLevelStart"></param>
    /// <param name="preLevelEnd"></param>
    private static void SearchEachLevel(int?[] nums, int level, Dictionary<int,TreeNode> dic,int preLevelStart, int preLevelEnd)
    {
        if (preLevelStart > preLevelEnd || preLevelEnd > nums.Length-1)
        {
            return;
        }
        var prevLevelCount = preLevelEnd-preLevelStart+1;
        int nextLevelCount = 2*prevLevelCount;
        var nextStart = preLevelEnd+1;
        var nextEnd = nextStart+nextLevelCount-1;
        nextEnd = nextEnd >= nums.Length ? nums.Length-1 : nextEnd;
        var curIndex = nextStart;

        for (int i = preLevelStart; i <= preLevelEnd && curIndex <= nextEnd; i++)
        {
            if (nums[i] == null)
            {
                nextLevelCount -= 2;
                continue;
            }
            var parent = dic[i];
            if (parent == null)
            {
                continue;
            }
            var left = dic[curIndex];
            var right = curIndex+1 >= nums.Length ? null : dic[curIndex+1];
            parent.left = left;
            parent.right = right;
            curIndex += 2;
        }
        nextEnd = nextStart+nextLevelCount-1;
        nextEnd = nextEnd >= nums.Length ? nums.Length-1 : nextEnd;
        SearchEachLevel(nums,level+1,dic,nextStart,nextEnd);
    }

    #endregion
}