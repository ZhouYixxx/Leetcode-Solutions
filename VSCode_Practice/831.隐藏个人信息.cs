/*
 * @lc app=leetcode.cn id=831 lang=csharp
 *
 * [831] 隐藏个人信息
 */

// @lc code=start
using System;
using System.Text;

public class Solution831 {
    public void Test()
    {
        var s = "+86(234)567-890";
        var bs = MaskPII(s);
    }

    public string MaskPII(string S) 
    {
        if(IsMail(S))
        {
            return BlockedMailInfo(S);
        }
        return BlockedPhonelInfo(S);
    }

    private bool IsMail(string s)
    {
        return s[0] >= 'A';
    }

    private string BlockedMailInfo(string s)
    {
        var separators = new char[]{'@','.'};
        var splitsArray = s.Split(separators);
        var sb = new StringBuilder();
        int name1LastIndex = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            if (ch == '@')
            {
                name1LastIndex = i-1;
                //添加屏蔽符号
                var start = s[0] < 'a' ? (char)(s[0]+32) : s[0];
                var last = s[name1LastIndex] < 'a' ? (char)(s[name1LastIndex]+32) : s[name1LastIndex];
                sb.Append(start);
                sb.Append("*****");
                sb.Append(last);
                sb.Append('@');
                continue;
            }
            if (ch == '.')
            {
                sb.Append('.');
                continue;
            }
            //name1LastIndex = 0说明还没有遇到@号，此时先不急于做大写转小写操作
            if (name1LastIndex > 0)
            {
                sb.Append(ch < 'a' ? (char)(ch+32) : ch);
            }
        }

        return sb.ToString();
    }

    private string BlockedPhonelInfo(string s)
    {
        var postfix = new char[4];
        int index = 3;
        int num = 0;
        for (int i = s.Length-1; i >= 0; i--)
        {
            if (s[i] <= '9' && s[i] >= '0')
            {
                if (index >= 0)
                {
                    postfix[index] = s[i];
                    index--; 
                }
                num++;
            }
        }
        var res = string.Empty;
        var str = new string(postfix);
        if (num == 10)
            res = "***-***-"+str;
        if (num == 11)
            res = "+*-***-***-"+str;
        if (num == 12)
            res = "+**-***-***-"+str;
        if (num >= 13)
            res = "+***-***-***-"+str;
        return res;
    }
}
// @lc code=end

