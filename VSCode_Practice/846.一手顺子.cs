/*
 * @lc app=leetcode.cn id=846 lang=csharp
 *
 * [846] 一手顺子
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution846 {
    public void Test()
    {
        var s = "[1,2,3,6,2,3,4,7,8]";
        var hand = DataStructureHelper.ConvertStringToArray(s);
        int groupSize = 3;
        var ans = IsNStraightHand(hand, groupSize);
    }

    /// <summary>
    /// 贪心
    /// </summary>
    /// <param name="hand"></param>
    /// <param name="groupSize"></param>
    /// <returns></returns>
    public bool IsNStraightHand(int[] hand, int groupSize) 
    {
        if (hand.Length % groupSize != 0)
        {
            return false;
        }
        if (groupSize == 1)
        {
            return true;
        }
        Array.Sort(hand);
        var countDic = new Dictionary<int, int>();
        for (int i = 0; i < hand.Length; i++)
        {
            countDic[hand[i]] = countDic.ContainsKey(hand[i]) ? countDic[hand[i]] + 1 : 1;
        }
        for (int i = 0; i < hand.Length; i++)
        {
            var x = hand[i];
            if (!countDic.ContainsKey(x) || countDic[x] == 0)
            {
                continue;
            }
            //检查从x+1到x+groupSize-1;
            int next = x;
            while (next < (x + groupSize))
            {
                if (!countDic.ContainsKey(next) || countDic[next] == 0)
                {
                    return false;
                }
                countDic[next] -= 1;
                next++;
            }
        }
        return true;
    }
}
// @lc code=end

