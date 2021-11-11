/*
 * @lc app=leetcode.cn id=733 lang=csharp
 *
 * [733] 图像渲染
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class Solution733 {
    public void Test()
    {
        var sr = 0;
        var sc = 0;
        var image = new int[1][]
        {
            new int[1]{2}
        };
        var newColor = 4;
        var ans = FloodFill(image, sr, sc, newColor);
    }

    /// <summary>
    /// bfs
    /// </summary>
    /// <param name="image"></param>
    /// <param name="sr"></param>
    /// <param name="sc"></param>
    /// <param name="newColor"></param>
    /// <returns></returns>
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) 
    {
        var visited = new bool[image.Length][];//记录是否访问过
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = new bool[image[i].Length];
        }
        var oldColor = image[sr][sc];
        var queue = new Queue<Tuple<int,int>>();
        queue.Enqueue(new Tuple<int, int>(sr,sc));
        visited[sr][sc] = true;
        image[sr][sc] = newColor;
        while (queue.Count > 0)
        {
            var head = queue.Dequeue();
            var sr1 = head.Item1;
            var sc1 = head.Item2;
            var topColor = sr1 == 0 ? -1 : image[sr1-1][sc1];
            if (oldColor == topColor && !visited[sr1-1][sc1])
            {
                queue.Enqueue(new Tuple<int, int>(sr1-1,sc1));
                image[sr1-1][sc1] = newColor;
                visited[sr1-1][sc1] = true;
            }

            var leftColor = sc1 == 0 ? -1 : image[sr1][sc1-1];
            if (oldColor == leftColor && !visited[sr1][sc1-1])
            {
                queue.Enqueue(new Tuple<int, int>(sr1,sc1-1));
                image[sr1][sc1-1] = newColor;
                visited[sr1][sc1-1] = true;
            }

            var botColor = sr1 == image.Length-1 ? -1 : image[sr1+1][sc1];
            if (oldColor == botColor && !visited[sr1+1][sc1])
            {
                queue.Enqueue(new Tuple<int, int>(sr1+1,sc1));
                image[sr1+1][sc1] = newColor;
                visited[sr1+1][sc1] = true;
            }

            var rightColor = sc1 == image[0].Length-1 ? -1 : image[sr1][sc1+1];
            if (oldColor == rightColor && !visited[sr1][sc1+1])
            {
                queue.Enqueue(new Tuple<int, int>(sr1,sc1+1));
                image[sr1][sc1+1] = newColor;
                visited[sr1][sc1+1] = true;
            }
        }
        return image;
    }
}
// @lc code=end

