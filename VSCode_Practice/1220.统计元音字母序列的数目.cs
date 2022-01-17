/*
 * @lc app=leetcode.cn id=1220 lang=csharp
 *
 * [1220] 统计元音字母序列的数目
 */

// @lc code=start
using System.Collections.Generic;

public class Solution1220 {
    public void Test()
    {
        var n = 5;
        var ans = CountVowelPermutation(n);
    }

    int mod = 1000000007;
    Dictionary<string, int> memo = new Dictionary<string, int>();
    public int CountVowelPermutation(int n) 
    {
        var c = new char[]{'a','e','i','o','u'};
        if (n == 1) return 5;
        int result = 0;
        for (int i = 0; i < 5; i++) 
        {
            result += dfs(c[i],c, 1,n);
            result = result % mod;
        }
        return result;
    }

    public int dfs(char pre, char[] c, int cur,int n) 
    {
        if (cur == n) 
            return 1;
        if (memo.TryGetValue($"{pre}_{cur}",out var count))
        {
            return count;
        }
        int sum = 0;
        for (int i = 0; i < 5; i++) 
        {
            // 规则1 
            if (pre == 'a' && c[i] == 'e') 
            {
                sum += dfs(c[i],c, cur + 1,n);
            }
            // 规则2
            else if (pre == 'e' && (c[i] == 'a' || c[i] == 'i')) 
            {
                sum += dfs(c[i], c, cur + 1,n);
            } 
            // 规则3
            else if (pre == 'i' && c[i] != 'i') {
                sum += dfs(c[i], c, cur + 1,n);
            } 
            // 规则4
            else if (pre == 'o' && (c[i] == 'i' || c[i] == 'u')) 
            {
                sum += dfs(c[i], c, cur + 1,n);
            } 
            // 规则5
            else if (pre == 'u' && c[i] == 'a') 
            {
                sum += dfs(c[i], c, cur + 1,n);
            }
            sum = sum % mod;
            var key = $"{pre}_{cur}";
            memo[key] = sum;
        }
        return sum;
    }

}
// @lc code=end

