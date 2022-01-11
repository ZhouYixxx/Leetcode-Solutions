/*
 * @lc app=leetcode.cn id=1036 lang=csharp
 *
 * [1036] 逃离大迷宫
 */

// @lc code=start
using System;
using System.Collections.Generic;
public class Solution1036 {
    public void Test()
    {
        
    }

    public bool IsEscapePossible(int[][] blocked, int[] source, int[] target) 
    {
        if (blocked.Length == 0)
        {
            return true;
        }
        var blockList = new HashSet<string>();
        for (int i = 0; i < blocked.Length; i++)
        {
            blockList.Add($"{blocked[i][0]},{blocked[i][1]}");
        }
        return IsConnected(blockList, source, target) && IsConnected(blockList, target, source);
    }

    private bool IsConnected(HashSet<string> blockList, int[] source, int[] target)
    {
        int MAX = (blockList.Count * blockList.Count-1) / 2;
        var queue = new Queue<int[]>();
        var visited = new HashSet<string>();
        queue.Enqueue(source);
        visited.Add($"{source[0]},{source[1]}");
        while (queue.Count > 0)
        {
            if (visited.Count > MAX)
            {
                return true;
            }
            var u = queue.Dequeue();
            if (u[0] == target[0] && u[1] == target[1])
            {
                return true;
            }
            int[] top = u[0] == 0 ? null : new int[2]{u[0]-1, u[1]};
            int[] left = u[1] == 0 ? null : new int[2]{u[0], u[1]-1};
            int[] bot = u[0] == 1E6-1 ? null : new int[2]{u[0]+1, u[1]};
            int[] right = u[1] == 1E6-1 ? null : new int[2]{u[0], u[1]+1};
            if (top != null)
            {
                var index = $"{top[0]},{top[1]}";
                if (!blockList.Contains(index) && !visited.Contains(index))
                {
                    visited.Add(index);
                    queue.Enqueue(top);
                }
            }
            if (left != null)
            {
                var index = $"{left[0]},{left[1]}";
                if (!blockList.Contains(index) &&!visited.Contains(index))
                {
                    visited.Add(index);
                    queue.Enqueue(left);
                }
            }
            if (bot != null)
            {
                var index = $"{bot[0]},{bot[1]}";
                if (!blockList.Contains(index) &&!visited.Contains(index))
                {
                    visited.Add(index);
                    queue.Enqueue(bot);
                }
            }
            if (right != null)
            {
                var index = $"{right[0]},{right[1]}";
                if (!blockList.Contains(index) &&!visited.Contains(index))
                {
                    visited.Add(index);
                    queue.Enqueue(right);
                }
            }
        }
        return false; 
    }
}
// @lc code=end

