using System;
using System.Collections;
using System.Collections.Generic;

namespace CodePractice.BasicDataStructure.Heap
{
    public class PrioirtyQuene<T> where T:IComparable<T>
    {
        private const int defaultCapacity = 0x10;//默认容量为16

        private MinHeap<T> minHeap;
        private MaxHeap<T> maxHeap;
        private IComparer<T> comparer;
        private bool ascending;

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ascending">ascending=true,则为小顶堆</param>
        /// <param name="comparer"></param>
        public PrioirtyQuene(T[] source,bool ascending = false, Comparer<T> comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            this.ascending = ascending;
            if (ascending)
            {
                minHeap = new MinHeap<T>(source);
                Count = minHeap.Count;
                Capacity = Count <= defaultCapacity ? defaultCapacity : Count << 1;
            }
            else
            {
                maxHeap = new MaxHeap<T>(source);
                Count = maxHeap.Count;
                Capacity = Count <= defaultCapacity ? defaultCapacity : Count << 1;
            }
        }

        public PrioirtyQuene(bool ascending)
        {
            this.ascending = ascending;
            this.comparer = Comparer<T>.Default;
            if (ascending)
            {
                minHeap = new MinHeap<T>(defaultCapacity);
                Count = minHeap.Count;
                Capacity = defaultCapacity;
            }
            else
            {
                maxHeap = new MaxHeap<T>(defaultCapacity);
                Count = maxHeap.Count;
                Capacity = defaultCapacity;
            }
        }

        public void Push(T value)
        {
            if (ascending)
            {
                minHeap.Insert(value);
            }
            else
            {
                maxHeap.Insert(value);
            }
        }

        public void Pop(T value)
        {
            if (Count >= Capacity)
            {
                return;
            }
            if (ascending)
            {
                minHeap.RemoveMin();
            }
            else
            {
                maxHeap.RemoveMax();
            }
        }

        public T Peek(T value)
        {
            if (Count >= Capacity)
            {
                throw new IndexOutOfRangeException("已经超出了容量值");
            }
            if (ascending)
            {
               return minHeap.PeekMin();
            }
            else
            {
                return maxHeap.PeekMax();
            }
        }
    }
}