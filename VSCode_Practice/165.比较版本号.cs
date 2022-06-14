/*
 * @lc app=leetcode.cn id=165 lang=csharp
 *
 * [165] 比较版本号
 */

// @lc code=start
public class Solution165 {
    public void Test(){
        var version1 = "1.01.0.1";
        var version2 = "1.001";
        var ans = CompareVersion(version1, version2);
    }

    public int CompareVersion(string version1, string version2) {
        var revisionNumbers1 = version1.Split('.').ToArray(); 
        var revisionNumbers2 = version2.Split('.').ToArray();
        int idx1 = 0, idx2 = 0;
        while (idx1 < revisionNumbers1.Length || idx2 < revisionNumbers2.Length)
        {
            var num1 = idx1 >= revisionNumbers1.Length ? 0 : StringToInt(revisionNumbers1[idx1++]);
            var num2 = idx2 >= revisionNumbers2.Length ? 0 : StringToInt(revisionNumbers2[idx2++]);
            if (num1 < num2)
            {
                return -1;
            }
            if (num1 > num2)
            {
                return 1;
            }
        }
        return 0;
    }

    private int StringToInt(string str){
        int num = 0;
        for (int i = 0; i < str.Length; i++)
        {
            num = num * 10 + str[i] - '0';
        }
        return num;
    }
}
// @lc code=end

