/*
 * @lc app=leetcode.cn id=36 lang=csharp
 *
 * [36] 有效的数独
 */

// @lc code=start
public class Solution36 {
    public void Test(){
        var board = new char[][]{
            new char[]{'5','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'}
        };
        var isvalid = IsValidSudoku(board);
    }

    public bool IsValidSudoku(char[][] board) {
        var set = new HashSet<int>();
        //判断行
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.' && !set.Add(board[i][j]-'0'))
                {
                    return false;
                }
            }
            set.Clear();
        }
        //判断列
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[j][i] != '.' && !set.Add(board[j][i]-'0'))
                {
                    return false;
                }
            }
            set.Clear();
        }
        //判断九宫格
        var startPos = new int[][]{
            new int[]{0,0},new int[]{3,0},new int[]{6,0},
            new int[]{0,3},new int[]{3,3},new int[]{6,3},
            new int[]{0,6},new int[]{3,6},new int[]{6,6},
        };
        for (int i = 0; i < 9; i++)
        {
            var startX = startPos[i][0];
            var startY = startPos[i][1];
            for (int m = startX; m < startX+3; m++)
            {
                for (int n = startY; n < startY+3; n++)
                {
                    if (board[m][n] != '.' && !set.Add(board[m][n]-'0'))
                    {
                        return false;
                    }
                }
            }
            set.Clear();
        }
        return true;
    }
}
// @lc code=end

