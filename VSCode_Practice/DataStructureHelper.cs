using System;
using System.Collections.Generic;

public static class DataStructureHelper
{
    #region 链表处理

    //从数组生成链表
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

    //从链表生成数组
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
    /// <param name="nums"></param>
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
            if (nums[i] != null)
            {
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
        }
        SearchEachLevel(nums,level+1,dic,nextStart,nextEnd);
    }

    #endregion
}