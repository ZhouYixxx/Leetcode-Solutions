using System.Collections.Generic;

namespace CodePractice.LeetCode.Stack_Quene
{
    /// <summary>
    /// 用队列实现求平均值
    /// </summary>
    public class No346_MovingAverage
    {
        private Queue<int> _queue;
        private double _sum;
        private int index;
        private int size;
        /** Initialize your data structure here. */
        public No346_MovingAverage(int size)
        {
            _queue = new Queue<int>(size);
            this.size = size;
        }

        public double Next(int val)
        {
            if (index < size)
            {
                index++;
            }
            else
            {
                var first = _queue.Peek();
                _queue.Dequeue();
                _sum -= first;
            }
            _queue.Enqueue(val);
            _sum += val;
            return (double)_sum / index;
        }
    }
}