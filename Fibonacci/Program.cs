using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 4;
            int sum = 0;
            Console.Write($"斐波那契数列前{count}项：");
            for (int i = 1; i <= count; i++)
            {
                var a = FibonacciUtil.Fibonacci(i);
                sum += a;
                Console.Write(a+" ");
            }
            Console.WriteLine();
            Console.WriteLine($"前{count}项和：{sum}");
            Console.ReadKey();
        }
    }
}
