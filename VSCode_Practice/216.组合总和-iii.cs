/*
 * @lc app=leetcode.cn id=216 lang=csharp
 *
 * [216] 组合总和 III
 */

// @lc code=start
public class Solution216 {

    public void Test()
    {
        var ans = CombinationSum3(9, 45);
    }
    int sum = 0;
    int _n;
    int _k;
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var res = new List<IList<int>>();
        _n = n;
        _k = k;
        if (n > 45)
        {
            return res;
        }
        var min = k*(k+1) / 2;
        var max = k*(19-k) / 2;
        if (n > max || n < min)
        {
            return res;
        }
        var used = new bool[9];
        var path = new List<int>();
        dfs(res, path, used, 1);
        return res;
    }

    private void dfs(IList<IList<int>> res, List<int> temp, bool[] used, int start)
    {
        if (sum > _n || temp.Count > _k)
        {
            return;
        }
        if (sum == _n && temp.Count == _k)
        {
            res.Add(new List<int>(temp));
            return;
        }
        for (int i = start; i <= 9; i++)
        {
            if (used[i-1])
            {
                continue;
            }
            used[i-1] = true;
            temp.Add(i);
            sum += i;
            //为了避免[1,3,4], [1,4,3]这样的重复结果，因此应该设置下一次循环 start = i+1
            dfs(res, temp, used, i+1);
            temp.RemoveAt(temp.Count-1);
            used[i-1] = false;
            sum -= i;
        }
    }
}
// @lc code=end

