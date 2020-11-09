using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodePractice.BasicDataStructure.Array;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.BasicDataStructure.Stack_Queue;
using CodePractice.BasicDataStructure.Tree;
using CodePractice.LeetCode.Array;
using CodePractice.LeetCode.Bit;
using CodePractice.LeetCode.Stack_Quene;
using CodePractice.LeetCode.String;
using CodePractice.LeetCode.Tree;
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

            //new SortByBits_1356().Test();

            #region LinkedList

            LeetCode.LinkedList.ExcuteProgram.Excute();

            #endregion

            #region String

            LeetCode.String.ExcuteProgram.Excute();

            #endregion

            #region Array

            LeetCode.Array.ExcuteProgram.Excute();

            #endregion

            #region Tree

            LeetCode.Tree.ExcuteProgram.Excute();

            #endregion

            #region Math

            LeetCode.Math.ExcuteProgram.Excute();

            #endregion
        }
    }
}
