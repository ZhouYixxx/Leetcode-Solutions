using System;
using System.Collections;
using CodePractice.BasicDataStructure.Array;
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

            //var str = CompleteExpression.GetCompleteExpression("1+2)*3-4)* 5- 6)) )");
            //Console.WriteLine(str);
            //Console.ReadKey();

            #endregion

            #region 实现一个动态扩容数组

            DynamicArray<int> array = new DynamicArray<int>(4);
            array[0] = 10;
            array[1] = 5;
            array[2] = 4;
            var cap = array.Capacity();
            var count = array.Count;
            array[3] = 6;
            array[4] = 7;
            array[5] = 8;
            array[6] = 9;
            array[7] = 1;
            array[8] = 23;
            array[9] = 44;
            var cap1 = array.Capacity();
            var count1 = array.Count;

            #endregion
        }
    }
}
