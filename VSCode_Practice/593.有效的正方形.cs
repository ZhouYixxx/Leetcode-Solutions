/*
 * @lc app=leetcode.cn id=593 lang=csharp
 *
 * [593] 有效的正方形
 */

// @lc code=start
using System;

public class Solution593 {
    public void Test()
    {
        var p1 = new []{1,0};
        var p2 = new []{0,1};
        var p3 = new []{-1,0};
        var p4 = new []{0,-1};
        var ans = ValidSquare(p1,p2,p3,p4);
    }
    
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        double[] edges = new double[6];

        var sqrLen_12 = GetSquareLength(p1,p2);
        edges[0] = sqrLen_12;
        var sqrLen_13 = GetSquareLength(p1,p3);
        edges[1] = sqrLen_13;

        var sqrLen_14 = GetSquareLength(p1,p4);
        edges[2] = sqrLen_14;

        var sqrLen_23 = GetSquareLength(p2,p3);
        edges[3] = sqrLen_23;

        var sqrLen_24 = GetSquareLength(p2,p4);
        edges[4] = sqrLen_24;

        var sqrLen_34 = GetSquareLength(p3,p4);
        edges[5] = sqrLen_34;

        Array.Sort(edges);
        return edges[0] != 0 && edges[0] == edges[1] && edges[1] == edges[2] 
                && edges[2] == edges[3] && edges[4] == edges[5];
    }

    private double GetSquareLength(int[] p1, int[] p2)
    {
        return (p1[0]-p2[0])*(p1[0]-p2[0])+(p1[1]-p2[1])*(p1[1]-p2[1]);
    }

    private bool IsRightAngle(int[] p1, int[] p2, int[] origin)
    {
        var vec1 = new int[2]{p1[0]-origin[0],p1[1]-origin[1]}; 
        var vec2 = new int[2]{p2[0]-origin[0],p2[1]-origin[1]};
        return vec1[0]*vec2[0]+vec1[1]*vec2[1] == 0; 
    }
}
// @lc code=end

