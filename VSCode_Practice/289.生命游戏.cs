/*
 * @lc app=leetcode.cn id=289 lang=csharp
 *
 * [289] 生命游戏
 */

// @lc code=start
public class Solution289 {
    public void Test()
    {
        var s = "[[0,1,0],[0,0,1],[1,1,1],[0,0,0]]";
        var board = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        GameOfLife(board);
    }

    public void GameOfLife(int[][] board) {
        int n = board.Length;
        int m = board[0].Length;
        int[,] copied = new int[n,m];
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < m; col++) {
                copied[row,col] = board[row][col];
            }
        }

        int[] dx = {-1,-1,0,1,1,1,0,-1};
        int[] dy = {0,1,1,1,0,-1,-1,-1};

        for(int row = 0; row < n; row++)
        {
            for(int col = 0; col < m; col++)
            {
                var cell = copied[row,col];
                var alive = 0;
                for(int i = 0; i < 8; i++)
                {
                    int newX = row + dx[i];
                    int newY = col + dy[i];
                    if(newX < 0 || newY <0 || newX > n - 1 || newY > m - 1)
                    {
                        continue;
                    }

                    if(copied[newX,newY] == 1)
                    {
                        alive++;
                    }
                }

                if(cell == 1 && (alive < 2 || alive > 3))
                {
                    board[row][col] = 0;
                }
                if(cell == 0 && alive == 3)
                {
                    board[row][col] = 1;
                }
            }
        }
    }
}
// @lc code=end

