/*
 * @lc app=leetcode.cn id=744 lang=csharp
 *
 * [744] 寻找比目标字母大的最小字母
 */

// @lc code=start
using System;

public class Solution744 {
    public void Test()
    {
        var letters = new char[]{'c','f','j'};
        //var letters = new char[]{'e','e','e','n','n'};
        var target = 'e';
        var ans = NextGreatestLetter(letters, target);
    }

    public char NextGreatestLetter(char[] letters, char target)
    {
        int lo = 0, hi = letters.Length;
        while (lo < hi) {
            int mi = lo + (hi - lo) / 2;
            if (letters[mi] <= target) lo = mi + 1;
            else hi = mi;
        }
        return letters[lo % letters.Length];
    }

    public char NextGreatestLetter2(char[] letters, char target) 
    {
        var l = 0;
        var r = letters.Length-1;
        var mid = (l+r)/2;
        while (l <= r)
        {
            mid = (l+r)/2;
            // if (letters[mid] == target)
            // {
            //     // if (mid == letters.Length-1 && letters[mid+1] != letters[mid])
            //     // {
            //     //     return letters[mid+1];
            //     // }
            //     l = mid+1;
            // }
            if (letters[mid] <= target)
            {
                if (mid == letters.Length - 1)
                {
                    return letters[0];
                }
                l = mid+1;
            }
            else
            {
                if (mid == letters.Length-1)
                {
                    return letters[mid];
                }
                r = mid-1;
            }
        }
        return letters[mid];
    }
}
// @lc code=end

