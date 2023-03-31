/*
 * @lc app=leetcode.cn id=201 lang=csharp
 *
 * [201] 数字范围按位与
 */

// @lc code=start
public class Solution201 {
    public void Test()
    {
        var left = 1;
        var right = int.MaxValue;
        var ans = RangeBitwiseAnd(left, right);
    }


    public int RangeBitwiseAnd(int left, int right) {
        //求两个数二进制形式的公共前缀
        if (left == 0) return 0;
        int i = 0;
        while (left != right) {
            left >>= 1;
            right >>= 1;
            i++;
        }
        //两个数往右移动了i位，往左移回i位
        return left << i;
    }
}
// @lc code=end

