using System;
using CodePractice.BasicDataStructure.Heap;

//问题进阶：如果所有数据都在[0,100]区间？此时不需要维护堆，用一个数组arr[101]去存储每个数字出现的次数，遍历累加一次获得总个数，
//除以二得到要找的数的位置p，再遍历一次找到p，时间复杂度O(1)
namespace CodePractice.LeetCode.Math
{
    public class MedianFinder_295
    {
        public void Test()
        {
            var obj = new MedianFinder();
            obj.AddNum(2);
            obj.AddNum(3);
            obj.AddNum(5);
            obj.AddNum(56);
            obj.AddNum(7);
            var m = obj.FindMedian();
            Console.WriteLine(m);
            Console.ReadKey();
        }
    }
    /// <summary>
    /// 自定义的数据结构
    /// </summary>
    public class MedianFinder
    {
        public int Capacity { get; set; }

        public int Count { get; private set; }

        private MinHeap<int> minHeap; //小顶堆存储较大的50%（n）
        private MaxHeap<int> maxHeap; //大顶堆存储较小的50%（n+1）

        public MedianFinder()
        {
            Capacity = 60000;
            minHeap = new MinHeap<int>(Capacity);
            maxHeap = new MaxHeap<int>(Capacity);
        }



        public void AddNum(int num)
        {
            //前两个数据依次插入大顶堆和小顶堆
            if (maxHeap.Count == 0)
            {
                maxHeap.Insert(num);
                Count++;
                return;
            }
            if (minHeap.Count == 0)
            {
                minHeap.Insert(num);
                Count++;
                var curMax = maxHeap.GetMax();
                if (num < curMax)
                {
                    minHeap.Insert(curMax);
                    maxHeap.RemoveMax();
                    maxHeap.Insert(num);
                }
                return;
            }
            //选择插入大顶端还是小顶堆
            Count++;
            var max = maxHeap.GetMax();
            if (num <= max)
            {
                maxHeap.Insert(num);
            }
            else
            {
                minHeap.Insert(num);
            }
            if (System.Math.Abs(maxHeap.Count - minHeap.Count) > 1)
            {
                ReBalance();
            }
        }

        /// <summary>
        /// 重平衡
        /// </summary>
        private void ReBalance()
        {
            int max = 0;
            int min = 0;
            while (maxHeap.Count - minHeap.Count > 1)
            {
                //大顶堆移除元素，小顶堆加入元素
                max = maxHeap.PeekMax();
                minHeap.Insert(max);
            }
            while (minHeap.Count - maxHeap.Count > 1)
            {
                //小顶堆移除元素，大顶堆加入元素
                min = minHeap.PeekMin();
                maxHeap.Insert(min);
            }
        }

        public double FindMedian()
        {
            if (Count == 0)
            {
                throw new Exception("No data");
            }
            //Count为偶数
            if ((Count & 1) == 0)
            {
                double max = maxHeap.GetMax();
                double min = minHeap.GetMin();
                return min + ((max - min) / 2);
            }
            //Count为奇数
            return maxHeap.Count > minHeap.Count ? (double)maxHeap.GetMax() : (double)minHeap.GetMin();
        }
    }
}