namespace CodePractice.NewCoder.HuaWei
{
    public class No06_PrimeFactorization
    {
        /// <summary>
        /// 质因数分解
        /// </summary>
        public static string PrimeFactorization(long ulDataInput)
        {
            var str = string.Empty;
            var max = ulDataInput / 2;
            for (int i = 2; i <= max; i++)
            {
                if (ulDataInput % i == 0)
                {
                    ulDataInput = ulDataInput / i;
                    str += $"{i} ";
                    i--;
                }
            }
            if (string.IsNullOrEmpty(str))
            {
                str = $"{ulDataInput} ";
            }
            return str;
        }
    }
}