﻿using System;

namespace CodePractice.BasicDataStructure.Heap
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] container; // 存放堆元素的数组,0位置为空

        public int Capacity { get; private set; } // 堆的容量

        public int Count { get; private set; }  // 堆中已经存储的数据个数

        public MinHeap(int _capacity)
        {
            Capacity = _capacity;
            container = new T[Capacity + 1];
            Count = 0;
        }

        public MinHeap(T[] source)
        {
            Count = source.Length;
            Capacity = Count;
            container = new T[Capacity + 1];
            for (int i = 0; i < Capacity; i++)
            {
                container[i + 1] = source[i];
            }
            //建堆
            for (int i = Count / 2; i >= 1; i--)
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
            while (index > 1 && container[index].CompareTo(container[(index >> 1)]) < 0)
            {
                Swap(index, index>>1);
                index = (index >> 1);
            }
        }

        /// <summary>
        /// 移除堆顶元素,不返回堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public void RemoveMin()
        {
            if (Count == 0)
                return;
            container[1] = container[Count];
            Count--;
            int index = 1;
            while (true)
            {
                int maxPos = index;
                //和左节点比
                if ((index << 1) <= Count && container[index].CompareTo(container[(index << 1)]) > 0)
                {
                    maxPos = 2 * index;
                }
                //和右节点比
                if ((index << 1) + 1 <= Count && container[index].CompareTo(container[(index << 1) + 1]) > 0)
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
        /// 移除堆顶元素,并返回堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public T PeekMin()
        {
            if (Count == 0)
                return default(T);
            T result = container[1];
            container[1] = container[Count];
            Count--;
            int index = 1;
            Heapify(index,Count);
            return result;
        }

        /// <summary>
        /// 堆化，自上而下，时间复杂度O(logN)
        /// </summary>
        /// <param name="index"></param>
        public void Heapify(int index, int n)
        {
            while (true)
            {
                int minPos = index;
                //和左节点比
                if ((index << 1) <= n && container[minPos].CompareTo(container[(index << 1)]) > 0)
                {
                    minPos = 2 * index;
                }
                //和右节点比
                if ((index << 1) + 1 <= n && container[minPos].CompareTo(container[(index << 1) + 1]) > 0)
                {
                    minPos = 2 * index + 1;
                }
                //如果比左右节点都大
                if (minPos == index)
                {
                    break;
                }
                Swap(index, minPos);
                index = minPos;
            }
        }

        /// <summary>
        /// 移除堆顶元素,不返回堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public T GetMin()
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
                Console.Write(container[i]+", ");
            }
            Console.WriteLine();
        }

        public void Swap(int a, int b)
        {
            var temp = container[a];
            container[a] = container[b];
            container[b] = temp;
        }

    }
}