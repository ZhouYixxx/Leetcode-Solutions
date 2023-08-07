using System;
using System.Collections.Generic;
using System.Linq;

public class Solution_contenst357 {
    public void Test(){
        var nums = new int[]{8, 11, 7, 1, 3, 10, 1, 14, 3, 11, 9, 10, 10, 10, 5, 13, 5, 13, 1, 18, 1, 15, 2, 18};
        int m = 21;
        var ans = CanSplitArray(nums, m);
    }


    public bool CanSplitArray(IList<int> nums, int m) {
        if (nums.Count <= 2)
        {
            return true;
        }
        for(int i = 0; i < nums.Count - 1; i++){
            if(nums[i] + nums[i+1] >= m)return true;
        }
        return false;
    }

    private bool DFS(IList<int> nums, int m, int start, int end, List<int> prefixSum)
    {
        if (end == start)
        {
            return true;
        }
        var sum = Sum(start,end, prefixSum);
        if (sum < m)
        {
            return false;
        }
        for (int i = start; i < end; i++)
        {
            var leftRes = DFS(nums, m, start, i, prefixSum);
            if (leftRes != true)
            {
                continue;
            }
            var rightRes = DFS(nums, m, i+1, end, prefixSum);
            if (leftRes && rightRes)
            {
                return true;
            }
        }
        return false;
    }

    private int Sum(int start, int end, List<int> prefixSum)
    {
        var sum = prefixSum[end+1] - prefixSum[start];
        return sum;
    }
}