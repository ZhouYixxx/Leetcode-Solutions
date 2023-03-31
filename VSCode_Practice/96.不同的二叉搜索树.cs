/*
 * @lc app=leetcode.cn id=96 lang=csharp
 *
 * [96] 不同的二叉搜索树
 */

// @lc code=start
public class Solution96{
    public void Test()
    {
        int n = 5;
        var ans = NumTrees(n);
    }

    public int NumTrees(int n) {
        if (n == 1 || n == 2)
        {
            return n;
        }
        var ans = new int[n+1];
        ans[0] = 1;
        ans[1] = 1;
        ans[2] = 2;
        for (int i = 3; i <= n; i++)
        {
            int l = 0, r = i - l - 1;
            while (r >= 0)
            {
                ans[i] += ans[l++]*ans[r--];
            }
        }
        return ans[n];
    }

}
// @lc code=end

