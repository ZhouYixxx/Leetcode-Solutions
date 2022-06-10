/*
 * @lc app=leetcode.cn id=89 lang=csharp
 *
 * [89] 格雷编码
 */

// @lc code=start
public class Solution89 {
    public void Test(){
        var res = GrayCode(4);
    }


    public IList<int> GrayCode(int n) {
        if (n == 1)
        {
            return new List<int>(){0,1};
        }
        int added = 1;
        for (int i = 1; i < n; i++)
        {
            added = added << 1;
        }
        var sub = GrayCode(n-1);
        var ans = new List<int>();
        for (int i = 0; i < sub.Count; i++)
        {
            ans.Add(sub[i]);
        }
        for (int i = sub.Count-1; i >= 0; i--)
        {
            ans.Add(sub[i] + added);
        }
        return ans;
    }
}
// @lc code=end

