/*
 * @lc app=leetcode.cn id=187 lang=csharp
 *
 * [187] 重复的DNA序列
 */

// @lc code=start
public class Solution187 {
    public void Test(){
        var s = "AAAAAAAAAAAAA";
        var ans = FindRepeatedDnaSequences(s);
    }

    public IList<string> FindRepeatedDnaSequences(string s) {
        var res = new List<string>();
        var set = new Dictionary<string, int>();
        for (int i = 0; i+9 < s.Length; i++)
        {
            var subStr = s.Substring(i,10);
            if (!set.ContainsKey(subStr))
            {
                set.Add(subStr,1);
                continue;
            }
            if (set[subStr] == 1)
            {
                set[subStr] = 2;
                res.Add(subStr);
            }

        }
        return res;
    }
}
// @lc code=end

