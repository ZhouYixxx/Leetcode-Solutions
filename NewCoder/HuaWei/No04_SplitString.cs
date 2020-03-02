namespace CodePractice.NewCoder.HuaWei
{
    public class No04_SplitString
    {
        public static string[] SplitString(string input1, string input2)
        {
            var length = 0;
            if (!string.IsNullOrWhiteSpace(input1))
            {
                length += input1.Length / 8 + 1;
            }
            if (!string.IsNullOrWhiteSpace(input2))
            {
                length += input2.Length / 8 + 1;
            }
            var stringArray = new string[length];
            int index = 0;
            var newStr = new char[8] { '0', '0', '0', '0', '0', '0', '0', '0' };
            for (int i = 0; i < input1?.Length; i++)
            {
                newStr[i % 8] = input1[i];
                if ((i + 1) % 8 == 0 || i == input1.Length - 1)
                {
                    stringArray[index] = new string(newStr);
                    index++;
                    newStr = new char[8] { '0', '0', '0', '0', '0', '0', '0', '0' };
                }
                //else
                //{
                //    newStr.Append(input1[i]);
                //}
            }
            for (int i = 0; i < input2?.Length; i++)
            {
                newStr[i % 8] = input2[i];
                if ((i + 1) % 8 == 0 || i == input2.Length - 1)
                {
                    stringArray[index] = new string(newStr);
                    index++;
                    newStr = new char[8] { '0', '0', '0', '0', '0', '0', '0', '0' };
                }
            }
            return stringArray;
        }
    }
}