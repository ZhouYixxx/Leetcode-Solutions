using System;
using System.Collections.Generic;

namespace CodePractice.BasicDataStructure.Heap
{
    public class MaxHeap<T>
    {
        private T[] container; // 存放堆元素的数组,0位置为空

        private IComparer<T> _comparison;

        public int Capacity { get; private set; } // 堆的容量

        public int Count { get; private set; }  // 堆中已经存储的数据个数

        public MaxHeap(int _capacity, IComparer<T> comparer = null)
        {
            Capacity = _capacity;
            container = new T[Capacity + 1];
            Count = 0;
            _comparison = comparer ?? Comparer<T>.Default;
        }

        public MaxHeap(T[] source, IComparer<T> comparer = null)
        {
            Count = source.Length;
            Capacity = Count;
            container = new T[Capacity + 1];
            _comparison = comparer ?? Comparer<T>.Default;
            for (int i = 0; i < Capacity; i++)
            {
                container[i + 1] = source[i];
            }
            for (int i = Capacity/2; i >= 1; i--)
            {
                Heapify(i,Count);
            }
        }


        /// <summary>
        /// 插入元素
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value)
        {
            if (Count >= Capacity)
                return;
            Count++;
            container[Count] = value;
            int index = Count;
            while (index > 1 && _comparison.Compare(container[index], container[(index>>1)]) > 0)
            {
                Swap(index, index >> 1);
                index = (index >> 1);
            }
        }

        /// <summary>
        /// 移除堆顶元素,不返回堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public void RemoveMax()
        {
            if (Count == 0)
                return;
            container[1] = container[Count];
            Count--;
            Heapify(1, Count);
        }

        /// <summary>
        /// 移除堆顶元素,并返回堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public T PeekMax()
        {
            if (Count == 0)
                return default(T);
            T result = container[1];
            container[1] = container[Count];
            Count--;
            Heapify(1, Count);
            return result;
        }

        /// <summary>
        /// 堆化，时间复杂度O(logN)
        /// </summary>
        /// <param name="index"></param>
        public void Heapify(int index,int n)
        {
            while (true)
            {
                int maxPos = index;
                //和左节点比
                if ((index << 1) <= n && _comparison.Compare(container[maxPos], container[(index << 1)]) < 0)
                {
                    maxPos = 2 * index;
                }
                //和右节点比
                if ((index << 1) + 1 <= n && _comparison.Compare(container[maxPos], container[(index << 1)+1]) < 0)
                {
                    maxPos = 2 * index + 1;
                }
                //如果比左右节点都大
                if (maxPos == index)
                {
                    break;
                }
                Swap(index,maxPos);
                index = maxPos;
            }
        }

        /// <summary>
        /// 移除堆顶元素,不返回堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public T GetMax()
        {
            if (Count == 0)
                return default(T);
            return container[1];
        }

        /// <summary>
        /// 输出堆中元素
        /// </summary>
        public void ShowHeap()
        {
            if (Count < 1)
                return;
            for (int i = 1; i <= Count; i++)
            {
                Console.WriteLine(container[i]);
            }
        }

        public void Swap(int a, int b)
        {
            var temp = container[a];
            container[a] = container[b];
            container[b] = temp;
        }

    }
}