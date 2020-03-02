namespace CodePractice.NewCoder.HuaWei
{
    public class No01_GetLastStringLength
    {
        public static int GetLastStringLength(string input)
        {
            int length = 0;
            bool canStart = false;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                var ch = input[i];
                if (ch == ' ' && canStart == false)
                    continue;
                canStart = true;
                if (ch == ' ')
                    break;
                length++;
            }
            return length;
        }
    }
}