/*
 * @lc app=leetcode.cn id=1001 lang=csharp
 *
 * [1001] 网格照明
 */

// @lc code=start
using System.Collections.Generic;

public class Solution1001
{
    public void Test()
    {
        var n = 5;
        var lamps = DataStructureHelper.ConvertStringToTwoDimenNumArray("[[0,0],[0,4]]");
        var q = DataStructureHelper.ConvertStringToTwoDimenNumArray("[[0,4],[0,1],[1,4]]");
        var ans = GridIllumination(n, lamps, q);
    }

    public int[] GridIllumination(int n, int[][] lamps, int[][] queries)
    {
        var row = new Dictionary<int, int>();
        var col = new Dictionary<int, int>();
        var left = new Dictionary<int, int>();
        var right = new Dictionary<int, int>();
        var lampPoints = new HashSet<long>();
        //遍历灯，记录四个方向的照亮次数
        foreach (var lamp in lamps)
        {
            int x = lamp[0], y = lamp[1];
            int l = x + y, r = x - y;
            long id = (n + 1) * x + y;
            if (!lampPoints.Add(id))
            {
                continue;
            }
            row[x] = row.ContainsKey(x) ? row[x]+1 : 1;
            col[y] = col.ContainsKey(y) ? col[y]+1 : 1;
            left[l] = left.ContainsKey(l) ? left[l]+1 : 1;
            right[r] = right.ContainsKey(r) ? right[r]+1 : 1;
        }
        var ans = new int[queries.Length];
        var dirs = new int[][] 
        { 
            new int[]{0,0}, new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 }, 
            new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { 1, -1 }, new int[] { 1, 1 } 
        };

        for (int i = 0; i < queries.Length; i++)
        {
            int qx = queries[i][0], qy = queries[i][1];
            int ql = qx + qy, qr = qx - qy;

            //检查是否照亮
            if (row.ContainsKey(qx) && row[qx] > 0)
            {
                ans[i] = 1;
            }
            else if (col.ContainsKey(qy) && col[qy] > 0)
            {
                ans[i] = 1;
            }
            else if (left.ContainsKey(ql) && left[ql] > 0)
            {
                ans[i] = 1;
            }
            else if (right.ContainsKey(qr) && right[qr] > 0)
            {
                ans[i] = 1;
            }
            if (ans[i] == 0)
            {
                continue;
            }
            //检查周围8个方向是否存在灯泡，存在则灭灯
            foreach (var dir in dirs)
            {
                var x = dir[0] + qx;
                var y = dir[1] + qy;
                if (x < 0 || y < 0 || x >= n || y >= n)
                {
                    continue;
                }
                long id = (n+1)*x + y;
                if (lampPoints.Contains(id))
                {
                    lampPoints.Remove(id);
                    row[x]--;
                    col[y]--;
                    left[x+y]--;
                    right[x-y]--;
                }
            }
        }
        return ans;
    }

}
// @lc code=end

