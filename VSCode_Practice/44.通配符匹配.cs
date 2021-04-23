/*
 * @lc app=leetcode.cn id=44 lang=csharp
 *
 * [44] 通配符匹配
 */

// @lc code=start
public class Solution44 {
    public void Test()
    {
        var s = "a";
        var p = "*****";
        var ans = IsMatch(s,p);
    }

    public bool IsMatch(string s, string p) 
    {
        if (s.Length == 0)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] != '*')
                {
                    return false;
                }
            }
            return true;
        }
        var dp = new bool[s.Length+1,p.Length+1];
        dp[0,0] = true;
        for (int j = 1; j <= p.Length; j++)
        {
            for (int i = 1; i <= s.Length; i++)
            {
                if (p[j-1] == '*')
                {
                    if (dp[i-1,j-1])
                    {
                        for (int k = i-1; k <= s.Length; k++)
                        {
                            dp[k,j] = true;
                        }     
                    }
                    if (dp[i,j-1])
                    {
                        for (int k = i; k <= s.Length; k++)
                        {
                            dp[k,j] = true;
                        }     
                    }
                }
                else if (p[j-1] == '?' &&  dp[i-1,j-1])
                {
                    dp[i,j] = true;
                }
                else
                {
                    if (s[i-1] == p[j-1] && dp[i-1,j-1])
                    {
                        dp[i,j] = true;
                    }
                }
            }
        }
        return dp[s.Length,p.Length];
    }

    public bool IsMatch2(string s, string p) 
    {
        int i = 0;//指向字符串s
        int j = 0;//指向字符串p
        int startPos = -1;//记录星号的位置
        int match = -1;//用于匹配星号
        while(i < s.Length){
            //表示相同或者p中为?
            if(j < p.Length && (s[i] == p[j] || p[j] == '?')){
                i++;
                j++;
            }
            //匹配到了星号，记录下的位置
            else if(j < p.Length && p[j] == '*'){
                startPos = j;
                match = i;
                j = startPos + 1;
            }
            //以上都没有匹配到，回到星号所在的位置，往后再次匹配
            else if(startPos != -1){
                match++;
                i = match;
                j = startPos + 1;                
            }
            else{
                return false;
            }
        }
        //去除多余的星号
        while(j < p.Length && p[j] == '*')j++;
        return j==p.Length;
    }
}
// @lc code=end

