using System;


namespace CodePractice.BasicDataStructure.Heap
{
    public class PrioirtyQuene<T> : IDisposable
    {
        private const int defaultCapacity = 0x10;//默认容量为16

        private MinHeap<T> minHeap;
        private MaxHeap<T> maxHeap;
        private Comparison<T> _comparison;
        private bool ascending;

        private bool _disposed;

        public int Count { get; private set; }
        public long Capacity { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ascending">ascending=true,从小到大排列</param>
        /// <param name="comparer"></param>
        public PrioirtyQuene(T[] source, Comparison<T> comparer,bool ascending = false)
        {
            this._comparison = comparer;
            this.ascending = ascending;
            if (ascending)
            {
                minHeap = new MinHeap<T>(source,_comparison);
                Count = minHeap.Count;
                Capacity = Count <= defaultCapacity ? defaultCapacity : Count *2;
            }
            else
            {
                maxHeap = new MaxHeap<T>(source,_comparison);
                Count = maxHeap.Count;
                Capacity = Count <= defaultCapacity ? defaultCapacity : Count *2;
            }
        }

        public PrioirtyQuene(T[] source, bool ascending = false)
        {
            this.ascending = ascending;
            if (ascending)
            {
                minHeap = new MinHeap<T>(source);
                Count = minHeap.Count;
                Capacity = Count <= defaultCapacity ? defaultCapacity : Count * 2;
            }
            else
            {
                maxHeap = new MaxHeap<T>(source);
                Count = maxHeap.Count;
                Capacity = Count <= defaultCapacity ? defaultCapacity : Count * 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ascending">ascending=true说明从小到大排列，优先队列每次弹出最小值</param>
        public PrioirtyQuene(bool ascending)
        {
            this.ascending = ascending;
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

        /// <summary>
        /// 插入新元素
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            if (ascending)
            {
                minHeap.Insert(value);
                Count++;
                if (Count >= Capacity)
                {
                    Capacity = minHeap.Capacity;
                }
            }
            else
            {
                maxHeap.Insert(value);
                Count++;
                if (Count >= Capacity)
                {
                    Capacity = minHeap.Capacity;
                }
            }
        }

        public void Clear()
        {
            minHeap?.Clear();
            maxHeap?.Clear();
        }

        /// <summary>
        /// 弹出队首元素
        /// </summary>
        /// <param name="value"></param>
        public void Peek(T value)
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("当前队列无数据");
            }
            if (ascending)
            {
                minHeap.RemoveMin();
                Count--;
            }
            else
            {
                maxHeap.RemoveMax();
                Count--;
            }
        }

        /// <summary>
        /// 弹出队首元素并返回该元素
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (Count  == 0)
            {
                throw new IndexOutOfRangeException("当前队列无数据");
            }
            if (ascending)
            {
                Count--;
                return minHeap.Pop();
            }
            else
            {
                Count--;
                return maxHeap.Pop();
            }
        }

        public void Dispose()
        {
            minHeap = null;
            maxHeap = null;
            _disposed = true;
        }
    }
}