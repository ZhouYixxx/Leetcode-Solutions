using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodePractice.BasicDataStructure.Array;
using CodePractice.BasicDataStructure.LinkedList;
using CodePractice.BasicDataStructure.Stack_Queue;
using CodePractice.LeetCode.Array;
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

            #region LinkedList

            #region 实现一个动态扩容数组

            //DynamicArray<int>.Test();

            #endregion

            #region 反转链表

            //ReverseLinkedList.Test();

            #endregion

            #region 链表中环的检测

            //CheckCircle.Test();

            #endregion

            #region 合并两个有序链表

            //MergeTwoLists.Test();

            #endregion

            #region 删除链表倒数第N个元素

            //DeleteNode.Test();


            #endregion

            #endregion



            #region String

            #region 917.仅仅反转字母

            //ReverseOnlyLetters_917.Test();

            #endregion

            #region 50面试.第一个只出现一次的字符

            //FirstUniqChar_50Interview.Test();

            #endregion

            #endregion



            #region Array

            #region 26.去除有序数组重复元素

            //RemoveDuplicates_26.Test();

            #endregion

            #region 977.有序数组的平方

            //SquaresSortedArray_977.Test();

            #endregion

            #region 88. 合并两个有序数组

            //_MergeSortedArray_88.Test();

            #endregion

            #region 1. 两数之和

            //TwoSum_001.Test();

            #endregion

            #region 283. 移动零

            //MoveZeroes_283.Test();

            #endregion

            #region 66. 加一

            //PlusOne_66.Test();

            #endregion

            #endregion



            #region Tree

            #region 94. 二叉树中序遍历

            //new InorderTraversal_94().Test();

            #endregion

            #region 144. 二叉树前序遍历

            //new PreorderTraversal_144().Test();

            #endregion

            #region 145. 二叉树后序遍历

            new PostorderTraversal_145().Test();

            #endregion

            #endregion

        }
    }
}
