using System;
using System.Globalization;
using System.Xml.Xsl;
using CodePractice.BasicDataStructure.Heap;
using CodePractice.Core;

namespace CodePractice.BasicDataStructure.Array
{
    public class SortClass : LeetCodeBase
    {
        public SortClass() : base("SortClass")
        {
            Test();
        }

        public void Test()
        {
            var array = new int[] { 6, 11, 3, 9, 8, 2, 16, 33, 150, 27, 72 };
            InsertSort(array);
            foreach (var value in array)
            {
                Console.Write(value + ", ");
            }
            Console.ReadKey();
        }

        #region InsertSort

        public static void InsertSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int index = 0;
                var temp = nums[i];
                for (int j = i-1; j >= 0 ; j--)
                {
                    //后移一位
                    if (nums[j] > temp)
                    {
                        nums[j + 1] = nums[j];
                        continue;
                    }
                    //找到要插入的位置，不要再往下遍历
                    index = j + 1;
                    break;
                }
                nums[index] = temp;
            }
        }

        #endregion

        #region QucikSort

        /// <summary>
        /// 时间复杂度O(NlgN)，不稳定，原地
        /// </summary>
        /// <param name="arrInts"></param>
        public static void QuickSort(int[] arrInts)
        {
            QuickSortFunc(arrInts, 0, arrInts.Length - 1);
        }

        private static void QuickSortFunc(int[] arrInts, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            var q = Partition(arrInts, start, end);
            QuickSortFunc(arrInts,start,q-1);
            QuickSortFunc(arrInts, q+1, end);
        }

        /// <summary>
        /// 时间复杂度O(N)
        /// </summary>
        /// <param name="arrInts"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static int Partition(int[] arrInts, int start, int end)
        {
            var pivot = arrInts[end];
            int i = start;
            int j = start;
            //j遍历一遍数组
            while (j <= end)
            {
                if (arrInts[j] >= pivot)
                {
                    j++;
                    continue;
                }
                //if arrInts[j]<pivot, swap i,j
                var temp = arrInts[i];
                arrInts[i] = arrInts[j];
                arrInts[j] = temp;
                j++;
                i++;
            }
            arrInts[end] = arrInts[i];
            arrInts[i] = pivot;
            return i;
        }

        #endregion

        #region MergeSort

        /// <summary>
        /// 时间复杂度O(NlgN)，稳定算法，非原地
        /// </summary>
        /// <param name="arrInts"></param>
        public static void MergeSort(int[] arrInts)
        {
            MergeSortFunc(arrInts, 0, arrInts.Length - 1);
        }

        private static void MergeSortFunc(int[] arrInts, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            //加法要避免越限
            var mid = start + ((end - start) >> 1);
            MergeSortFunc(arrInts, start, mid);
            MergeSortFunc(arrInts, mid+1, end);
            Merge(arrInts, start, mid, end);
        }

        private static void Merge(int[] arrInts,int start,int mid, int end)
        {
            if (start > end)
            {
                return;
            }
            var left = start;
            var right = mid + 1;
            var index = 0;
            var temp = new int[end - start + 1];
            //左右双指针移动并比较
            while (left <= mid && right <= end)
            {
                if (arrInts[left] <= arrInts[right])
                {
                    temp[index] = arrInts[left];
                    left++;
                    index++;
                }
                else
                {
                    temp[index] = arrInts[right];
                    right++;
                    index++;
                }
            }
            //右指针先走到底，直接将左指针之后的数据加入temp
            while (left <= mid)
            {
                temp[index] = arrInts[left];
                left++;
                index++;
            }
            //左指针先走到底，直接将右指针之后的数据加入temp
            while (right <= end)
            {
                temp[index] = arrInts[right];
                right++;
                index++;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                arrInts[i+start] = temp[i];
            }
        }

        #endregion

        #region HeapSort

        /// <summary>
        /// 时间复杂度O(N),空间复杂度O(N)
        /// </summary>
        /// <param name="arrInts"></param>
        public static void HeapSort(int[] arrInts)
        {
            //var minHeap = new MinHeap<int>(arrInts);
            int index = arrInts.Length;
            //int i = 0;
            //while (index >= 1)
            //{
            //    //移除堆顶元素，然后堆化
            //    arrInts[i] = minHeap.PeekMin();
            //    i++;
            //    index--;
            //}
            var maxHeap = new MaxHeap<int>(arrInts);
            while (index >= 1)
            {
                index--;
                arrInts[index] = maxHeap.Pop();
            }
            //minHeap.ShowHeap();
        }

        #endregion
    }
}