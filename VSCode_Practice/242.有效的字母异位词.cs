/*
 * @lc app=leetcode.cn id=242 lang=csharp
 *
 * [242] 有效的字母异位词
 */

// @lc code=start
public class Solution242 {
    public void Test()
    {
        var s = "anagram";
        var t = "nagaram";
        var ans = IsAnagram(s,t);
    }
    
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
        {
            return false;
        }
        var countMap = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            var index = s[i] - 'a';
            countMap[index]++;
            var intdex2 = t[i]-'a';
            countMap[intdex2]--;
        }
        for (int i = 0; i < countMap.Length; i++)
        {
            if (countMap[i] != 0)
            {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

