/*
 * @lc app=leetcode.cn id=212 lang=csharp
 *
 * [212] 单词搜索 II
 */

// @lc code=start
using System.Collections.Generic;
using System.Text;

public class Solution212 {
    public void Test()
    {
        var board = new char[][]
        {
            new char[]{'o','a','b','n'},
            new char[]{'o','t','a','e'},
            new char[]{'a','h','k','r'},
            new char[]{'a','f','l','v'},
        };
        var words = new string[]{"oa","oaa"};
        var ans = FindWords_Trie(board, words);
    }

    int m;
    int n;
    int[][] directions = new int[][]
    {
        new int[2]{-1,0},
        new int[2]{0,-1},
        new int[2]{1,0},
        new int[2]{0,1},
    };

    #region 粗糙DFS, 遍历words, 对每个单词检查是否存在

    public IList<string> FindWords(char[][] board, string[] words) {
        m = board.Length;
        n = board[0].Length;
        var visited = new bool[m][];
        var wordSet = new HashSet<string>(words);
        var ans = new List<string>();
        foreach (var word in wordSet)
        {
            if (Exists_DFS(board, word, visited))
            {
                ans.Add(word);
            }
        }
        return ans;
    }

    private bool Exists_DFS(char[][] board, string word, bool[][] visited)
    {
        for (int j = 0; j < m; j++)
        {
            visited[j] = new bool[n];
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var exists = dfs(0,i,j,board, word, visited);
                if (exists)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool dfs( int index, int row, int col , char[][] board, string word, bool[][] visited)
    {
        if (index >= word.Length)
        {
            return true;
        }
        if (row < 0 || row >= m || col < 0 || col >= n)
        {
            return false;
        }
        if (visited[row][col] || board[row][col] != word[index])
        {
            return false;
        }
        visited[row][col] = true;
        for (int i = 0; i < directions.Length; i++)
        {
            var new_row = row + directions[i][0];
            var new_col = col + directions[i][1];
            if (dfs(index+1, new_row, new_col,board, word, visited))
            {
                return true;
            }
        }
        visited[row][col] = false;
        return false;
    }

    #endregion

    #region 前缀树

    public IList<string> FindWords_Trie(char[][] board, string[] words) {
        m = board.Length;
        n = board[0].Length;
        var visited = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
        }
        var wordSet = new HashSet<string>(words);
        var ans = new HashSet<string>();
        var trie = new Trie(wordSet);
        var root = trie.GetRoot();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var sb = new StringBuilder();
                dfs_trie(i,j,root,board,visited, sb, ans);
            }
        }
        return new List<string>(ans);
    }

    private void dfs_trie(int row, int col, TrieNode trieNode, char[][] board, bool[][] visited, StringBuilder sb, 
        HashSet<string> res)
    {
        if (row < 0 || row >= m || col < 0 || col >= n || visited[row][col])
        {
            return;
        }
        var nextNode = trieNode.children[board[row][col] - 'a'];
        if (nextNode == null)
        {
            return;
        }
        sb.Append(board[row][col]);
        if (nextNode.isEnd)
        {
            res.Add(sb.ToString());
        }
        visited[row][col] = true;
        for (int i = 0; i < directions.Length; i++)
        {
            var new_row = row + directions[i][0];
            var new_col = col + directions[i][1];
            dfs_trie(new_row, new_col, nextNode, board, visited, sb, res);
        }
        visited[row][col] = false;
        sb.Remove(sb.Length-1,1);
    }

    #endregion
}
// @lc code=end

