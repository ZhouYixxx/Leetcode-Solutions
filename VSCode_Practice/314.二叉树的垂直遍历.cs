/*
 * @lc app=leetcode.cn id=1576 lang=csharp
 *
 * [1576] 替换所有的问号
 */

// @lc code=start
public class Solution314 
{
    public void Test()
    {
        var root1 = DataStructureHelper.GenerateTreeFromArray(new int?[]{3,9,20,null,null,15,7});
        var root2 = DataStructureHelper.GenerateTreeFromArray(new int?[]{3,9,8,4,0,1,7});
        var root3 = DataStructureHelper.GenerateTreeFromArray(new int?[]{3,9,8,4,0,1,7,null,null,null,2,5});
        var ans = VerticalOrder(root3);
    }
    
    private SortedDictionary<int, List<int[]>> dic; //key = column idx, value = [node_value, row_index]

    public IList<IList<int>> VerticalOrder(TreeNode root) {
        dic = new SortedDictionary<int, List<int[]>>();
        dfs(root, 0, 0);

        var res = new List<IList<int>>();
        foreach (var col in dic.Keys)
        {
            var lst = dic[col].OrderBy(t=>t[1]).Select(t=>t[0]).ToList();
            res.Add(lst);
        }

        return res;
    }

    private void dfs(TreeNode node, int row, int col)
    {
        if (node == null) return;
        if (dic.TryGetValue(col, out var nodeList))
        {
            nodeList.Add(new int[]{node.val, row});
        }
        else
        {
            dic.Add(col, new List<int[]>(){new int[]{node.val, row}});
        }
        dfs(node.left, row+1, col-1);
        dfs(node.right, row+1, col+1);

    }
}
// @lc code=end

