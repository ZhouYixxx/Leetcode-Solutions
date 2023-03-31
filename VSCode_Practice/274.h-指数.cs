/*
 * @lc app=leetcode.cn id=274 lang=csharp
 *
 * [274] H 指数
 */

// @lc code=start
public class Solution274 {

    public int HIndex(int[] citations) {
        Array.Sort(citations);
        int h = 0, i = citations.Length - 1; 
        while (i >= 0 && citations[i] > h) {
            h++; 
            i--;
        }
        return h;
    }

    public int HIndex1(int[] citations)
    {
        int l = 0, r = citations.Length;
        while (l < r)
        {
            //猜测：H因子为mid
            var mid = (l+r+1) / 2;
            //count 的含义是：引用次数大于等于 mid 的论文篇数
            int count = 0;
            foreach (var item in citations)
            {
                if (item >= mid)
                {
                    count++;
                }
            }
            if (count >= mid)
            {
                l = mid;
            }
            else
            {
                r = mid-1;
            }
        }
        return l;
    }
} 
// @lc code=end

