namespace LeetCode
{
    public class HuaweiNo2
    {
        public static int GetCount(string input, char target)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.ToLowerInvariant(input[i]) == char.ToLowerInvariant(target))
                {
                    count++;
                }
            }
            return count;
        }
    }
}