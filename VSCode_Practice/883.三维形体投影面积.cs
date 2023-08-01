/*
 * @lc app=leetcode.cn id=883 lang=csharp
 *
 * [883] 三维形体投影面积
 */

// @lc code=start
public class Solution883 {
    public void Test() {
        var grid1 = DataStructureHelper.ConvertStringToTwoDimenNumArray("[[2,3],[2,4]]");
        var grid2 = DataStructureHelper.ConvertStringToTwoDimenNumArray("[[1,2],[3,4]]");
        var ans = ProjectionArea(grid1);
    }

    public int ProjectionArea(int[][] grid) {
        int areaXY = 0;
        int areaXZ = 0;
        int areaYZ = 0;
        for (int x = 0; x < grid.Length; x++)
        {
            int yHeight = 0;
            int xHeight = 0;
            for (int y = 0; y < grid[x].Length; y++)
            {
                yHeight = Math.Max(yHeight, grid[x][y]);
                xHeight = Math.Max(xHeight, grid[y][x]);
                var z = grid[x][y];
                if (z > 0)
                {
                    areaXY++;
                }
            }
            areaXZ += yHeight;
            areaYZ += xHeight;
        }
        return areaXY + areaXZ + areaYZ;
    }
}
// @lc code=end

