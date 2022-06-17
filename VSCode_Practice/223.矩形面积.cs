/*
 * @lc app=leetcode.cn id=223 lang=csharp
 *
 * [223] 矩形面积
 */

// @lc code=start
public class Solution223 {
    public void Test()
    {
        int ax1 = -3, ay1 = 0, ax2 = 3, ay2 = 4, bx1 = 0, by1 = -1, bx2 = 9, by2 = 2;
        var ans = ComputeArea(ax1, ay1, ax2, ay2, bx1, by1, bx2, by2);
    }

    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2) {
        //平行于坐标轴的矩形，将长宽投影到对应的坐标轴上，比较投影线段之间是否存在交集即可判断是否相交
        var intersect_x = Math.Min(ax2, bx2) - Math.Max(ax1, bx1);
        if (intersect_x < 0) intersect_x = 0;
        var intersect_y = Math.Min(ay2, by2) - Math.Max(ay1, by1);
        if (intersect_y < 0) intersect_y = 0;
        
        var square_a = (ax2-ax1)*(ay2-ay1);
        var square_b = (bx2-bx1)*(by2-by1);
        var square_intersect = intersect_x * intersect_y;
        return square_a + square_b - square_intersect;
    }

    
}
// @lc code=end

