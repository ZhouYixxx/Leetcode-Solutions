/*
 * @lc app=leetcode.cn id=37 lang=csharp
 *
 * [37] 解数独
 */

// @lc code=start
using System.Collections.Generic;
public class Solution37 {
    public void Test()
    {
        var board = new char[][]
        {
            new char[]{'5','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'},
        };
        SolveSudoku(board);
    }


    //key:所属九宫格名称，value:九宫格范围（4个角落的坐标）
    Dictionary<string,int[]> gridDic = new Dictionary<string,int[]>()
    {
        ["1_1"] = new int[]{0,2,0,2},
        ["1_2"] = new int[]{0,2,3,5},
        ["1_3"] = new int[]{0,2,6,8},
        ["2_1"] = new int[]{3,5,0,2},
        ["2_2"] = new int[]{3,5,3,5},
        ["2_3"] = new int[]{3,5,6,8},
        ["3_1"] = new int[]{6,8,0,2},
        ["3_2"] = new int[]{6,8,3,5},
        ["3_3"] = new int[]{6,8,6,8},
    };

    public void SolveSudoku(char[][] board) 
    {   
        var res = BackTrack(board);
    }

    private bool BackTrack(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.')
                {
                    continue;
                }
                for (int k = 1; k <= 9; k++)
                {
                    if (IsValid(k, i, j, board))
                    {
                        board[i][j] = (char)(k+48);
                        if (BackTrack(board))
                        {
                            return true;
                        }
                        board[i][j] = '.'; 
                    }   
                }
                return false;
            }
        }
        return true;
    }
    
    private bool IsValid(int num, int row, int col, char[][] board)
    {
        var ch = (char)(num + 48);
        //行
        for (int i = 0; i < 9; i++)
        {
            if (board[row][i] == ch)
            {
                return false;
            }
        }
        //列
        for (int i = 0; i < 9; i++)
        {
            if (board[i][col] == ch)
            {
                return false;
            }
        }
        //九宫格
        var key = $"{row/3+1}_{col/3+1}";
        var range = gridDic[key];
        for (int i = range[0]; i <= range[1]; i++)
        {
            for (int j = range[2]; j <= range[3]; j++)
            {
                if (board[i][j] == ch)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end

