using System;
using System.Diagnostics;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class SuperEggDrop_887 : LeetCodeBase
    {
        public SuperEggDrop_887() : base("SuperEggDrop_887")
        {
            var sw = new Stopwatch();
            sw.Start();
            //for (int k = 1; k < 100; k++)
            //{
            //    for (int n = 1; n <= 10000; n = n * 10)
            //    {
            //        Console.WriteLine(SuperEggDrop(6, 10000));
            //    }
            //}
            Console.WriteLine(SuperEggDrop2(6, 10000));
            Console.ReadKey();
        }

        /// <summary>
        /// N：楼层数，K：鸡蛋数,时间复杂度O（KN²）
        /// </summary>
        /// <param name="K"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public int SuperEggDrop(int K, int N)
        {
            int[][] func = new int[N+1][];
            for (int i = 0; i <= N; i++)
            {
                func[i] = new int[K+1];
                for (int j = 0; j <= K; j++)
                {
                    if (j == 0)
                    {
                        func[i][0] = 0;
                        continue;
                    }
                    if (i == 0)
                    {
                        func[0][j] = 0;
                        continue;
                    }
                    if (i == 1)
                    {
                        func[1][j] = 1;
                        continue;
                    }
                    func[i][j] = Int32.MaxValue;
                }
                func[i][1] = i;
            }
            //从第t层开始扔
            for (int i = 2; i <= N; i++)
            {
                for (int j = 2; j <= K; j++)
                {
                    for (int t = 1; t <= i; t++)
                    {
                        func[i][j] = System.Math.Min(func[i][j], System.Math.Max(func[t-1][j - 1], func[i - t][j]) + 1);
                    }
                }
            }
            return func[N][K];
        }

        /// <summary>
        /// N：楼层数，K：鸡蛋数,时间复杂度O（KN*logN）
        /// </summary>
        /// <param name="K"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public int SuperEggDrop1(int K, int N)
        {
            int[][] func = new int[N + 1][];
            for (int i = 0; i <= N; i++)
            {
                func[i] = new int[K + 1];
                for (int j = 0; j <= K; j++)
                {
                    if (j == 0)
                    {
                        func[i][0] = 0;
                        continue;
                    }
                    if (i == 0)
                    {
                        func[0][j] = 0;
                        continue;
                    }
                    if (i == 1)
                    {
                        func[1][j] = 1;
                        continue;
                    }
                    func[i][j] = Int32.MaxValue;
                }
                func[i][1] = i;
            }
            //从第t层开始扔
            for (int i = 2; i <= N; i++)
            {
                for (int j = 2; j <= K; j++)
                {
                    //用二分法查找，原理：func[t - 1][j - 1]是关于t的增函数，func[i - t][j]是关于t的减函数，
                    //找到func[t - 1][j - 1] <= func[i - t][j]的t就是关键
                    var left = 1;
                    var right = i;
                    int mid = left;
                    while (left < right)
                    {
                        //mid = left + (right - left) / 2;
                        //if (func[mid - 1][j - 1] < func[i - mid][j])
                        //{
                        //    left = mid + 1;
                        //}
                        //else if (func[mid - 1][j - 1] > func[i - mid][j])
                        //{
                        //    right = mid;
                        //}
                        //else break;
                        mid = left + (right - left + 1) / 2;
                        if (func[mid - 1][j - 1] > func[i - mid][j])
                        {
                            right = mid - 1;
                        }
                        else if(func[mid - 1][j - 1] < func[i - mid][j])
                        {
                            left = mid;
                        }
                        else break;
                    }
                    func[i][j] = System.Math.Min(func[i][j], System.Math.Max(func[mid - 1][j - 1], func[i - mid][j]) + 1);
                    //for (int t = 1; t <= i; t++)
                    //{
                    //    func[i][j] = System.Math.Min(func[i][j], System.Math.Max(func[t - 1][j - 1], func[i - t][j]) + 1);
                    //}
                }
            }
            return func[N][K];
        }

        /// <summary>
        /// N：楼层数，K：鸡蛋数,时间复杂度O（KN*logN）
        /// </summary>
        /// <param name="K"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public int SuperEggDrop2(int K, int N)
        {
            // dp[i][j] i 个鸡蛋扔 j 次能确定的最大区间的层数
            int[,] dp = new int[K + 1, N + 1];

            for (int j = 1; j <= N; j++)
            {
                for (int i = 1; i <= K; i++)
                {
                    dp[i, j] = dp[i - 1, j - 1] + dp[i, j - 1] + 1;
                    if (dp[i, j] >= N)
                        return j;
                }
            }
            return N;
        }
    }
}