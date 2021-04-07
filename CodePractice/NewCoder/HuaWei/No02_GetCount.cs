namespace CodePractice.NewCoder.HuaWei
{
    public class No02_GetCount
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