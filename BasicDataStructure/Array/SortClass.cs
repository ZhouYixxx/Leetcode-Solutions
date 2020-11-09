using System;

namespace CodePractice.BasicDataStructure.Array
{
    public class SortClass
    {
        public static void Test()
        {
            var array = new int[] {6, 11, 3, 9, 8, 2, 16, 33, 150, 27,72};
            QuickSort(array);
            foreach (var value in array)
            {
                Console.Write(value+", ");
            }
            Console.ReadKey();
        }

        #region QucikSort

        public static void QuickSort(int[] arrInts)
        {
            QuickSort(arrInts, 0, arrInts.Length - 1);
        }

        public static void QuickSort(int[] arrInts, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            //获取pivot的下标
            var p = Partition(arrInts, start, end);
            QuickSort(arrInts, start, p - 1);
            QuickSort(arrInts, p + 1, end);
        }

        /// <summary>
        /// 返回pivot所处的下标
        /// </summary>
        /// <param name="arrInts"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static int Partition(int[] arrInts, int start, int end)
        {
            int pivot = arrInts[end];
            //假设从小到大排列
            //[start,i-1]该区间所有数字均比pivot小,i是要求的pivot的下标
            int i = start;
            int j = i;
            while (j<=end)
            {
                if (arrInts[j] >= pivot)
                {
                    j++;
                    continue;
                }
                //如果arrInts[j] < pivot,则需要把i位置处更新为arrInts[i]，然后i，j加一。采用原色交换的方法实现
                if (i != j)
                {
                    var temp = arrInts[i];
                    arrInts[i] = arrInts[j];
                    arrInts[j] = temp;
                }
                i++;
                j++;
            }
            arrInts[end] = arrInts[i];
            arrInts[i] = pivot;
            return i;
        }

        #endregion
    }
}