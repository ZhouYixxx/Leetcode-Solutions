/*
 * @lc app=leetcode.cn id=1576 lang=csharp
 *
 * [1576] 替换所有的问号
 */

// @lc code=start

public class Solution250 
{
    public void Test()
    {
        var root1 = DataStructureHelper.GenerateTreeFromArray(new int?[]{5,1,5,5,5,null,5});
        var root2 = DataStructureHelper.GenerateTreeFromArray(new int?[]{5,1,5,5,5,5,5});
        var root3 = DataStructureHelper.GenerateTreeFromArray(new int?[]{5,1,3,1,1,1});
        var ans = CountUnivalSubtrees(root3);
    }
    
    //int ans = 0;

    public int CountUnivalSubtrees(TreeNode root) {
        int ans = 0;
        dfs(root, ref ans);
        return ans;
    }

    private (bool isSame, int value) dfs(TreeNode node, ref int ans)
    {
        if (node == null) return (false, 0);
        if (node.left == null && node.right == null)
        {
            ans++;
            return (true, node.val);
        }
        var leftRes = dfs(node.left, ref ans);
        var rightRes = dfs(node.right, ref ans);
        bool issame = false;
        if (node.left == null)
        {
            issame = rightRes.isSame && rightRes.value == node.val;
            if (issame) ans++;
            return (issame, node.val);
        }
        if (node.right == null)
        {
            issame = leftRes.isSame && leftRes.value == node.val;
            if (issame) ans++;
            return (issame, node.val);
        }
        //left right both not null
        issame = leftRes.isSame && rightRes.isSame && leftRes.value == rightRes.value && leftRes.value == node.val;
        if (issame) ans++;
        return (issame, node.val);
    }
}
// @lc code=end

