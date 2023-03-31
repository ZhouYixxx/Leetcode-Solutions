/*
 * @lc app=leetcode.cn id=71 lang=csharp
 *
 * [71] 简化路径
 */

// @lc code=start
public class Solution71 {
    public void Test()
    {
        var s = "/a/./b/../../c/";
        var ans = SimplifyPath(s);
    }

    public string SimplifyPath(string path) {
        var names = path.Split('/').ToArray();
        var list = new Stack<string>();
        foreach (var name in names)
        {
            if (name == "" || name == ".")
            {
                continue;
            }
            if (name == "..")
            {
                if (list.Count != 0)
                {
                    list.Pop();
                }
            }
            else
            {
                list.Push(name);
            }
        }
        string res = "";
        while (list.Count > 0)
        {
            res = $"/{list.Pop()}{res}";
        }
        return res == "" ? "/" : res;
    }
}
// @lc code=end

