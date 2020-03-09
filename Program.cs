using System;
using CodePractice.BasicDataStructure.Stack_Queue;
using CodePractice.LeetCode.Stack_Quene;
using CodePractice.NewCoder.HuaWei;

namespace CodePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //No08_MergeDic.MergeDic();

            #region No346_MovingAverage
            //No346_MovingAverage movingAverage = new No346_MovingAverage(3);
            //Console.WriteLine(movingAverage.Next(1));
            //Console.WriteLine(movingAverage.Next(10));
            //Console.WriteLine(movingAverage.Next(3));
            //Console.WriteLine(movingAverage.Next(5));
            //Console.ReadKey();
            #endregion

            #region GetCompleteExpression

            var str = CompleteExpression.GetCompleteExpression("1+2)*3-4)* 5- 6)) )");
            Console.WriteLine(str);
            Console.ReadKey();
            #endregion
        }
    }
}
