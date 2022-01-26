/*
 * @lc app=leetcode.cn id=2013 lang=csharp
 *
 * [2013] 检测正方形
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class DetectSquares {
    Dictionary<int, Dictionary<int, int>> mapY;

    public DetectSquares() {
        mapY = new Dictionary<int, Dictionary<int, int>>();
    }

    public void Add(int[] point) {
        int x = point[0], y = point[1];
        if (!mapY.ContainsKey(y)) {
            mapY.Add(y, new Dictionary<int, int>());
        }
        Dictionary<int, int> mapX = mapY[y];
        if (!mapX.ContainsKey(x)) {
            mapX.Add(x, 0);
        }
        mapX[x]++;
    }

    public int Count(int[] point) {
        int res = 0;
        int x = point[0], y = point[1];
        if (!mapY.ContainsKey(y)) {
            return 0;
        }
        Dictionary<int, int> mapX = mapY[y];
        foreach(var pair in mapY) {
            int y_len = pair.Key;
            Dictionary<int, int> colCnt = pair.Value;
            if (y_len != y) {
                // 根据对称性，这里可以不用取绝对值
                int d = y_len - y;
                int cnt1 = colCnt.ContainsKey(x) ? colCnt[x] : 0;
                int cnt2 = colCnt.ContainsKey(x + d) ? colCnt[x + d] : 0;
                int cnt3 = colCnt.ContainsKey(x - d) ? colCnt[x - d] : 0;
                res += (colCnt.ContainsKey(x) ? colCnt[x] : 0) * (mapX.ContainsKey(x + d) ? mapX[x + d] : 0) * (colCnt.ContainsKey(x + d) ? colCnt[x + d] : 0);
                res += (colCnt.ContainsKey(x) ? colCnt[x] : 0) * (mapX.ContainsKey(x - d) ? mapX[x - d] : 0) * (colCnt.ContainsKey(x - d) ? colCnt[x - d] : 0);
            }
        }
        return res;
    }
}

/**
 * Your DetectSquares object will be instantiated and called as such:
 * DetectSquares obj = new DetectSquares();
 * obj.Add(point);
 * int param_2 = obj.Count(point);
 */
// @lc code=end

