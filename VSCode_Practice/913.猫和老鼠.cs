/*
 * @lc app=leetcode.cn id=913 lang=csharp
 *
 * [913] 猫和老鼠
 */

// @lc code=start
public class Solution913 {
    public void Test()
    {
        var s = "[[2,5],[3],[0,4,5],[1,4,5],[2,3],[0,2,3]]";
        var g = DataStructureHelper.ConvertStringToTwoDimenNumArray(s);
        var ans = CatMouseGame(g);
    }

    int MOUSE_WIN = 1;
    int CAT_WIN = 2;
    int DRAW = 0;

    public int CatMouseGame(int[][] graph) 
    {
        var n = graph.Length;
        //f[turns][mouse][cat]=ans, turns：当前步数，偶数时老鼠行动，mouse：老鼠当前位置，cat：猫当前位置
        var memo = new int[2*n][][];
        for (int k = 0; k < 2*n; k++)
        {
            memo[k] = new int[n][];
            for (int i = 0; i < n; i++)
            {
                memo[k][i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    memo[k][i][j] = -1;
                }
            }
        }
        return dfs(0,1,2, memo, graph);
    }

    private int dfs(int turns, int mousePos, int catPos, int[][][] memo, int[][] graph)
    {
        var n = graph.Length;
        //轮次超过节点数量的2倍为平局
        if (turns == 2*n)
        {
            return DRAW;
        }
        //老鼠赢了
        if (mousePos == 0)
        {
            return MOUSE_WIN;
        }
        //猫赢了
        if (mousePos == catPos)
        {
            return CAT_WIN;
        }
        // 缓存中有，直接返回
        if (memo[turns][mousePos][catPos] != -1)
        {
            return memo[turns][mousePos][catPos];
        }
        //老鼠走
        if (turns % 2 == 0)
        {
            var ans = CAT_WIN;
            var nextSteps = graph[mousePos];
            for (int p = 0; p < nextSteps.Length; p++)
            {
                var new_mousePos = nextSteps[p];
                int next = dfs(turns+1, new_mousePos, catPos, memo, graph);
                //老鼠可以赢，直接返回
                if (next == MOUSE_WIN)
                {
                    memo[turns][mousePos][catPos] = MOUSE_WIN;
                    return MOUSE_WIN;
                }
                //老鼠可以保平，先记录在ans中
                if (next == DRAW)
                {
                    ans = DRAW;
                }
            }
            memo[turns][mousePos][catPos] = ans;
            return ans;
        }
        //猫的回合
        else
        {
            var ans = MOUSE_WIN;
            var nextSteps = graph[catPos];
            for (int p = 0; p < nextSteps.Length; p++)
            {
                var new_catPos = nextSteps[p];
                //下一位置为0，猫不能到达
                if (new_catPos == 0)
                {
                    continue;
                }
                int next = dfs(turns+1, mousePos, new_catPos, memo, graph);
                //猫可以赢，直接返回
                if (next == CAT_WIN)
                {
                    memo[turns][mousePos][catPos] = CAT_WIN;
                    return CAT_WIN;
                }
                //猫可以保平，先记录在ans中
                if (next == DRAW)
                {
                    ans = DRAW;
                }
            }
            memo[turns][mousePos][catPos] = ans;
            return ans;
        }
    }
}
// @lc code=end

