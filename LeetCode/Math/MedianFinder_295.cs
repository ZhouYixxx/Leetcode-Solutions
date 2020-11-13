using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using CodePractice.BasicDataStructure.Heap;

namespace CodePractice.LeetCode.Math
{
    public class MedianFinder_295
    {
    }

    /// <summary>
    /// 自定义的数据结构
    /// </summary>
    public class MedianFinder
    {
        public int Capacity { get; set; }

        public int Count { get; private set; }
        public double MedianNumber { get; private set; }

        private MinHeap<int> minHeap; //小顶堆存储较大的50%
        private MaxHeap<int> maxHeap; //大顶堆存储较小的50%

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
                return;
            }
            if (minHeap.Count == 0)
            {
                minHeap.Insert(num);
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
                min = minHeap.GetMin();
                minHeap.Insert(min);
            }
        }

        public double FindMedian()
        {
            return MedianNumber;
        }
    }
}