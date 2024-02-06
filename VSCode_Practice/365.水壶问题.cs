/*
 * @lc app=leetcode.cn id=365 lang=csharp
 *
 * [365] 水壶问题
 */

// @lc code=start
public class Solution365 {
    public void Test()
    {
        int jug1Capacity = 104579, jug2Capacity = 104593, targetCapacity = 12444;
        var ans = CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
    }
    
    private HashSet<long> vis = new HashSet<long>();
    private int x, y, z;

    public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity) {
        x = jug1Capacity;
        y = jug2Capacity;
        z = targetCapacity;
        return dfs(0, 0);
    }

    private bool dfs(int i, int j) {
        long st = f(i, j);
        if (!vis.Add(st)) {
            return false;
        }
        if (i == z || j == z || i + j == z) {
            return true;
        }
        if (dfs(x, j) || dfs(i, y) || dfs(0, j) || dfs(i, 0)) {
            return true;
        }
        int a = Math.Min(i, y - j);
        int b = Math.Min(j, x - i);
        return dfs(i - a, j + a) || dfs(i + b, j - b);
    }

    private long f(int i, int j) {
        return i * 1000000L + j;
    }
}
// @lc code=end

