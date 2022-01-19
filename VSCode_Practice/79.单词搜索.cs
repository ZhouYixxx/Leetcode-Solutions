/*
 * @lc app=leetcode.cn id=79 lang=csharp
 *
 * [79] 单词搜索
 */

// @lc code=start
public class Solution79 {
    public void Test()
    {
        var board = new char[][]
        {
            new char[]{'C','A','A','E'},
            new char[]{'A','A','A','S'},
            new char[]{'B','C','D','E'},
        };
        var word = "AAB";
        var ans = Exist(board, word);
    }

    int[][] directions = new int[][]
    {
        new int[2]{-1,0},
        new int[2]{0,-1},
        new int[2]{1,0},
        new int[2]{0,1},
    };
    int m = 0;
    int n = 0;

    public bool Exist(char[][] board, string word) 
    {
        return Exists_DFS(board, word);
    }

    public bool Exists_DFS(char[][] board, string word)
    {
        m = board.Length;
        n = board[0].Length;
        var visited = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] != word[0])
                {
                    continue;
                }
                var ans = dfs(0, i, j, word, board, visited);
                if (ans)
                {
                    return true;
                }
            }
        }
        return false;
    }


    private bool dfs(int index, int row, int col, string word, char[][] board, bool[][] visited)
    {
        if (index >= word.Length)
        {
            return true;
        }
        if (row < 0 || row >= m || col < 0 || col >= n)
        {
            return false;
        }
        if (visited[row][col])
        {
            return false;
        }
        if (word[index] != board[row][col])
        {
            return false;
        }
        visited[row][col] = true;
        for (int i = 0; i < 4; i++)
        {
            var row1 = row + directions[i][0];
            var col1 = col + directions[i][1];
            if (dfs(index + 1, row1, col1, word, board, visited))
            {
                return true;
            }
        }
        visited[row][col] = false;
        return false;
    }
}
// @lc code=end

