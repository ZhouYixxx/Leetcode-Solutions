using System;
using System.Collections.Generic;

public class Solution624
{
    public void Test()
    {
        var arrays = new List<IList<int>>{
            new List<int> { 1,2,8},
            new List<int> { 4, 5, 6},
            new List<int> { 1},
        };
        var ans = MaxDistance1(arrays);
        
    }

    /// <summary>
    /// 两两比较。复杂度O(n²)，
    /// </summary>
    /// <param name="arrays"></param>
    /// <returns></returns>
    public int MaxDistance(IList<IList<int>> arrays) {
        int m = arrays.Count;
        int dis = 0;
        for (int i = 0; i < m; i++)
        {
            int start_i = arrays[i][0];
            int end_i = arrays[i][arrays[i].Count - 1];
            for (int j = 0; j < m; j++)
            {
                if (i == j)
                {
                    continue;
                }
                int start_j = arrays[j][0];
                int end_j = arrays[j][arrays[j].Count - 1];
                var localDis = Math.Max(Math.Abs(start_i - end_j), Math.Abs(start_j - end_i));
                dis = Math.Max(dis, localDis);
            }
        }
        return dis;
    }

    /// <summary>
    /// 一次遍历，实时维护min和max两个值
    /// </summary>
    /// <param name="arrays"></param>
    /// <returns></returns>
    public int MaxDistance1(IList<IList<int>> arrays)
    {
        int dis = 0;
        int min = arrays[0][0];
        int max = arrays[0][arrays[0].Count - 1];
        //dis = max - min;
        for (int i = 1; i < arrays.Count; i++)
        {
            var tempDis = Math.Max(Math.Abs(max - arrays[i][0]), Math.Abs(min - arrays[i][arrays[i].Count-1]));
            dis = Math.Max(dis, tempDis);
            min = Math.Min(min, arrays[i][0]);
            max = Math.Max(max, arrays[i][arrays[i].Count-1]);
        }
        return dis;
    }
}