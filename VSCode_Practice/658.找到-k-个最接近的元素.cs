/*
 * @lc app=leetcode.cn id=658 lang=csharp
 *
 * [658] 找到 K 个最接近的元素
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution658 {

    public void Test()
    {
        var arr = new int[]{0,2,3,4,5,6,8,9,11,16};
        //var arr = new int[]{1,2,3,3,6,6,7,7,9,9};
        //var arr = new int[]{-2,-1,1,2,3,4,5};
        var k = 4;
        var x = 0;
        var ans = FindClosestElements(arr,k,x);
    }
    
    public IList<int> FindClosestElements(int[] arr, int k, int x) 
    {
        var closestIndex = FindClosestElementIndex(arr,x);
        var left = closestIndex-1;
        var right = closestIndex+1;
        var start = closestIndex;
        var count = k;
        k--;
        var list = new List<int>(k);
        while (k > 0 && left >=0 && right < arr.Length)
        {
            if (Math.Abs(arr[left]-x) <= Math.Abs(arr[right]-x))
            {
                start = left;
                left--;
            }
            else
            {
                right++;
            }
            k--;
        }
        while (k > 0 && right == arr.Length && start > 0)
        {
            start--;
            k--;
        }
        for (int i = start; i < start+count; i++)
        {
            list.Add(arr[i]);
        }
        return list;
    }

    //二分寻找与x最接近的元素的下标
    public int FindClosestElementIndex(int[] arr, int x) 
    {
        var l = 0;
        var r = arr.Length-1;
        while (l < r)
        {
            var mid = l+(r-l)/2;
            if (arr[mid] == x)
            {
                return mid;
            }
            if (arr[mid] > x)
            {
                r = mid;
            }
            if (arr[mid] < x)
            {
                l = mid+1;
            }
        }
        if (l == 0)
        {
            return 0;
        }
        return Math.Abs(arr[l]-x) < Math.Abs(arr[l-1]-x) ? l : l-1;
    }
}
// @lc code=end

