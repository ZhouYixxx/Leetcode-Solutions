/*
 * @lc app=leetcode.cn id=28 lang=csharp
 *
 * [28] 实现 strStr()
 */

// @lc code=start
public class Solution28 {
    public void Test(){
        //var s = "(1+(4+5+2)-3)+(6+8)";
        var a = "ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
        var b = "ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
        var ans = StrStr(a,b);
    }

    public int StrStr(string haystack, string needle) {
        if (needle.Length > haystack.Length)
        {
            return -1;
        }
        if (string.IsNullOrEmpty(needle))
        {
            return 0;
        }
        for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            for (int j = 0; j <= needle.Length; j++)
            {
                if (j == needle.Length)
                {
                    return i;
                }
                if (needle[j] != haystack[i+j])
                {
                    break;
                }
            }
        }
        return -1;
    }
}
// @lc code=end

