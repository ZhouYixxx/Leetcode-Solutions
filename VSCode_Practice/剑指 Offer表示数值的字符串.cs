using System.Collections.Generic;
using System;

public class Solution_Offer20 {
    
    public void Test()
    {
        var s = " T3";
        var ans = IsNumberFSM(s);
    }
    public bool IsNumber(string s) 
    {
        s = s.Trim();
        var chArray = new char[s.Length];
        int powIndex = -1;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'e' || s[i] == 'E')
            {
                //之前已经找到过E，说明不可能是数字
                if (powIndex != -1)
                {
                    return false;
                }
                powIndex = i;
            }
            chArray[i] = s[i];
        }
        //无字母E出现
        if (powIndex == -1)
        {
            return IsNumberWithoutPow(s,0, s.Length-1,false);
        }
        //出现字母E，将E前后的指数和底数分别判断
        else
        {
            return IsNumberWithoutPow(s,0, powIndex-1, false) && IsNumberWithoutPow(s,powIndex+1,s.Length-1,true);
        }
    }


    private bool IsNumberWithoutPow(string s, int startIndex, int endIndex, bool isPow)
    {
        if (startIndex > endIndex)
        {
            return false;
        }
        int demicalCount = 0;
        int demicalPointCount = 0;
        for (int i = startIndex; i <= endIndex; i++)
        {
            //正负号只能出现在开头
            if (s[i] == '+' || s[i] == '-')
            {
                if (i != startIndex)
                {
                    return false;
                }
                continue;
            }
            //小数点不能出现在结尾，且只能出现一次
            if (s[i] == '.')
            {
                //指数不允许有小数
                if (isPow)
                {
                    return false;
                }
                demicalPointCount++;
                if (demicalPointCount > 1)
                {
                    return false;
                }
                continue;
            }
            //其他只能是数字
            if ( s[i] < '0' || s[i] > '9')
            {
                return false;
            }
            demicalCount++;
        }
        return demicalCount > 0;
    }

    public bool IsNumberFSM(string s)
    {
        var states = new Dictionary<char,int>[]
        {
            new Dictionary<char,int>(){{' ',0},{'s',1}, {'d',2}, {'.', 4}}, //case 0:空格后可以是空格、数字、±号、小数点
            new Dictionary<char,int>(){{'d',2},{'.',4}}, //case 1
            new Dictionary<char,int>(){{'d',2},{'.',3},{'e',5},{' ',8}}, //case 2
            new Dictionary<char,int>(){{'d',3},{'e',5},{' ',8}}, //case 3
            new Dictionary<char,int>(){{'d',3}}, //case 4
            new Dictionary<char,int>(){{'s',6},{'d',7}}, //case 5
            new Dictionary<char,int>(){{'d',7}}, //case 6
            new Dictionary<char,int>(){{'d',7},{' ',8}}, //case 7
            new Dictionary<char,int>(){{' ',8}}, //case 8
        };
        int p = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char t = 'a';
            var c = s[i];
            if (c >= '0' && c <= '9')
            {
                t = 'd';
            }
            if (c == '+' || c == '-')
            {
                t = 's';
            }
            if (c == 'e' || c == 'E')
            {
                t = 'e';
            }
            if (c == ' ' || c == '.')
            {
                t = c;
            }
            if (!states[p].ContainsKey(t))
            {
                return false;
            }
            p = states[p][t];
        }
        return p == 2 || p == 3 || p == 7 || p == 8;
    }
}