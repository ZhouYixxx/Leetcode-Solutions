/*
 * @lc app=leetcode.cn id=350 lang=csharp
 *
 * [350] 两个数组的交集 II
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution350 {
    public void Test(){
        var nums1 = new int[]{4,4,9,5,1};
        var nums2 = new int[]{9,4,9,8,4,5};
        var ans = Intersect1(nums1, nums2);
    }

    /// <summary>
    /// BF方法：用两个字典记录数组中每个数出现的次数，时间复杂度O(N)
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public int[] Intersect(int[] nums1, int[] nums2) {
        var cntDic1 = new Dictionary<int, int>();
        var cntDic2 = new Dictionary<int, int>();
        var res = new List<int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            if (!cntDic1.ContainsKey(nums1[i]))
            {
                cntDic1[nums1[i]] = 0;
            }
            cntDic1[nums1[i]] += 1;
        }
        for (int i = 0; i < nums2.Length; i++)
        {
            if (!cntDic2.ContainsKey(nums2[i]))
            {
                cntDic2[nums2[i]] = 0;
            }
            cntDic2[nums2[i]] += 1;
        }
        foreach (var key in cntDic1.Keys)
        {
            if (cntDic2.ContainsKey(key))
            {
                var min_count = Math.Min(cntDic1[key], cntDic2[key]);
                for (int j = 0; j < min_count; j++)
                {
                    res.Add(key);
                }
            }
        }
        return res.ToArray();
    }

    /// <summary>
    /// 如果数组已经排好序，采用双指针法O(N)
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public int[] Intersect1(int[] nums1, int[] nums2) {
        Array.Sort(nums1);
        Array.Sort(nums2);
        int i = 0, j = 0;
        var ans = new List<int>();
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j])
            {
                ans.Add(nums1[i]);
                i++;
                j++;
            }
            else if (nums1[i] > nums2[j])
            {
                j++;
            }
            else
            {
                i++;
            }
        }
        return ans.ToArray();
    }

}
// @lc code=end

