/*
 * @lc app=leetcode.cn id=241 lang=csharp
 *
 * [241] 为运算表达式设计优先级
 */

// @lc code=start
public class Solution241 {
    public void Test()
    {
        var exp = "2+3-4*5";
        var ans = DiffWaysToCompute(exp);
    }

    public IList<int> DiffWaysToCompute(string expression) {
        var res = dfs(expression, 0, expression.Length-1);
        return res;
    }

    private List<int> dfs(string exp, int start, int end)
    {
        if (start > end)
        {
            return new List<int>();
        }
        if (start == end || start + 1 == end)
        {
            var num = int.Parse(exp.Substring(start, end-start+1));
            return new List<int>(){num};
        }
        var res = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (exp[i] >= '0' && exp[i] <= '9') continue;
            var left = dfs(exp,start, i-1);
            var right = dfs(exp, i+1, end);
            foreach (var a in left)
            {
                foreach (var b in right)
                {
                    if (exp[i] == '+')
                    {
                        res.Add(a+b);
                    }
                    else if (exp[i] == '-')
                    {
                        res.Add(a-b);
                    }
                    else if (exp[i] == '*')
                    {
                        res.Add(a*b);
                    }
                }
            }
        }
        return res;   
    }
}
// @lc code=end

