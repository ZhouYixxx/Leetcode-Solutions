namespace Recursive
{
    public class FibonacciUtil
    {
        /// <summary>
        /// 获取第n项的值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        internal static int Fibonacci(int n)
        {
            if (n ==1 || n ==2  )
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}