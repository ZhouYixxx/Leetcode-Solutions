/*
 * @lc app=leetcode.cn id=9 lang=csharp
 *
 * [9] 回文数
 */

// @lc code=start
public class Solution009 {
    public void Test()
    {
        var x = 300;
        var ans = IsPalindrome(x);
    }

    public bool IsPalindrome(int x) 
    {
        if (x == 0)
            return true;
        if (x < 0 || x % 10 == 0)
            return false;
        
        int num = x;
        int revertedNum = 0;
        while (num > revertedNum)
        {
            var digit = num % 10;
            num = num / 10;
            revertedNum = revertedNum * 10 + digit;
        }
        if (revertedNum ==  num)
        {
            return true;
        }
        else
        {
            revertedNum = revertedNum / 10;
            return num == revertedNum;
        }
    }
}
// @lc code=end

