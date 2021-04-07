using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class ShortestWay_1055 : LeetCodeBase
    {
        public ShortestWay_1055() : base("ShortestWay_1055")
        {

        }

        public int ShortestWay(string source, string target)
        {
            int len = 0, i = 0;
            while (i < target.Length)
            {
                int temp = i, j = 0;
                //寻找target中以target.charAt(i)开头的连续子字符串所能匹配的source最长子序列
                while (j < source.Length)
                {
                    if (source[j++] == target[i])
                    {
                        if (++i == target.Length) break;
                    }
                }
                //若source中的子序列与target的子字符串不能匹配
                if (temp == i) return -1;
                len++;
            }
            return len;
        }
    }
}