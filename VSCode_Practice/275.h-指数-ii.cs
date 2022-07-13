/*
 * @lc app=leetcode.cn id=275 lang=csharp
 *
 * [275] H 指数 II
 */

// @lc code=start
public class Solution275 {
    public void Test()
    {
        var c = new int[]{0,1,3,5,6};
        var ans = HIndex(c);
    }

    public int HIndex2(int[] citations) {
        int count = 0;
        for (int i = citations.Length-1; i >= 0; i--)
        {
            if (citations[i] > count)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }

    public int HIndex(int[] citations)
    {
        int l = 0, r = citations.Length;
        while (l < r)
        {
            var mid = (l+r)/2;
            if (citations.Length - mid > citations[mid])
            {
                l = mid+1;
            }
            else
            {
                r = mid;
            }
        }
        return citations.Length - l;
    }
}
// @lc code=end

