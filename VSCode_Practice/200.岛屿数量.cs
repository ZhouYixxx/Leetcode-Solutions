/*
 * @lc app=leetcode.cn id=200 lang=csharp
 *
 * [200] 岛屿数量
 */

// @lc code=start
public class Solution200 {
    public void Test(){
        var s = "['1','1','0','0','0'],['1','1','0','0','0'],['0','0','1','0','0'],['0','0','0','1','1']";
        var grid = DataStructureHelper.ConvertStringToTwoDimenCharArray(s);
        var ans = NumIslands(grid);
    }

    int m = 0;
    int n = 0;
    int[][] directions = new int[][]{
        new int[]{1,0},
        new int[]{0,1},
        new int[]{-1,0},
        new int[]{0,-1},
    };
    public int NumIslands(char[][] grid) {
        return NumIslands_DFS(grid);
    }

    /// <summary>
    /// DFS方法
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int NumIslands_DFS(char[][] grid){
        m = grid.Length;
        n = grid[0].Length;
        var visited = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
        }
        var count = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (visited[i][j] || grid[i][j] == '0')
                {
                    continue;
                }
                dfs(i, j, grid, visited);
                count++;
            }
        }
        return count;
    }

    private void dfs(int i, int j, char[][] grid, bool[][] visited)
    {
        if (i >= m || i < 0 || j >= n || j < 0 || visited[i][j] || grid[i][j] == '0')
        {
            return;
        }
        visited[i][j] = true;
        foreach (var dir in directions)
        {
            var newX = i + dir[0];
            var newY = j + dir[1];
            dfs(newX, newY, grid, visited);
        }
    }

    /// <summary>
    /// BFS方法
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int NumIslands_BFS(char[][] grid){
        m = grid.Length;
        n = grid[0].Length;
        var visited = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
        }
        var count = 0;
        var q = new Queue<int[]>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (visited[i][j] || grid[i][j] == '0')
                {
                    continue;
                }
                bfs(i,j,grid,visited,q);
                count++;
            }
        }
        return count;
    }

    private void bfs(int i, int j, char[][] grid, bool[][] visited, Queue<int[]> q)
    {
        q.Enqueue(new int[]{i,j});
        visited[i][j] = true;
        while (q.Count > 0)
        {
            var pos = q.Dequeue();
            foreach (var direction in directions)
            {
                var newX = pos[0] + direction[0];
                var newY = pos[1] + direction[1];
                if (newX >= m || newX < 0 || newY >= n || newY < 0 || visited[newX][newY] || grid[newX][newY] == '0')
                {
                    continue;
                }
                visited[newX][newY] = true;
                q.Enqueue(new int[]{newX, newY});
            }
        }
    } 
}
// @lc code=end

