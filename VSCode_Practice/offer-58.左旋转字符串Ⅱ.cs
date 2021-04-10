using System;

public class Solution58_offer {
    public void Test()
    {
        var s = "lrloseumgh";
        int k = 6;
        var ans = ReverseLeftWords(s,k);
    }

    public string ReverseLeftWords(string s, int n) {
        var k = n % s.Length;
        if (k == 0)
        {
            return s;
        }
        var charArray = new char[s.Length];
        int index = k;//s中从k开始
        var newIndex = 0;//新字符串从0开始
        while (newIndex < s.Length)
        {
            charArray[newIndex] = s[index];
            index++;
            if (index >= s.Length)
            {
                index = 0;
            }
            newIndex++;
        }
        var ans = new string(charArray);
        return ans;
    }
}