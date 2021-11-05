using System;
using System.Collections;
using System.Collections.Generic;

namespace CodePractice.BasicDataStructure.Heap
{
    public class MinHeap<T>
    {
        private T[] container; // 存放堆元素的数组,0位置为空

        private readonly static int _defaultCapacity = 16;

        private IComparer<T> _comparer;//默认的比较函数

        private Comparison<T> _comparison = null;//自定义的比较器

        public long Capacity { get; private set; } // 堆的容量

        public int Count { get; private set; }  // 堆中已经存储的数据个数

        public MinHeap(int _capacity)
        {
            Capacity = _capacity;
            container = new T[Capacity + 1];
            _comparer = Comparer<T>.Default;
            Count = 0;
        }

        public MinHeap(T[] source, Comparison<T> comparer)
        {
            Capacity = _defaultCapacity;
            _comparison = comparer;
            ClearAndHeapify(source);
        }

        public MinHeap(T[] source)
        {
            Capacity = _defaultCapacity;
            ClearAndHeapify(source);
        }


        /// <summary>
        /// 插入元素
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value)
        {
            if (Count >= Capacity)
            {
                ExpandSize();
            }
            Count++;
            container[Count] = value;
            int index = Count;
            if (_comparison != null)
            {
                while (index > 1 && _comparison(container[index], container[(index >> 1)]) < 0)
                {
                    Swap(index, index >> 1);
                    index = (index >> 1);
                }
            }
            else
            {
                while (index > 1 && _comparer.Compare(container[index], container[(index >> 1)]) < 0)
                {
                    Swap(index, index >> 1);
                    index >>= 1;
                }
            }
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
                if (_comparison != null)
                {
                    if ((index << 1) <= n && _comparison(container[minPos], container[(index << 1)]) > 0)
                    {
                        minPos = 2 * index;
                    }
                    //和右节点比
                    if ((index << 1) + 1 <= n && _comparison(container[minPos], container[(index << 1) + 1]) > 0)
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
                else
                {
                    if ((index << 1) <= n && _comparer.Compare(container[minPos], container[(index << 1)]) > 0)
                    {
                        minPos = 2 * index;
                    }
                    //和右节点比
                    if ((index << 1) + 1 <= n && _comparer.Compare(container[minPos], container[(index << 1) + 1]) > 0)
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
        }

        /// <summary>
        /// 移除堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public void RemoveMin()
        {
            if (Count == 0)
                return;
            container[1] = container[Count];
            Count--;
            Heapify(1, Count);
        }

        /// <summary>
        /// 获取堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public T Peek()
        {
            if (Count == 0)
                throw new ArgumentOutOfRangeException("当前堆中无数据");
            return container[1];
        }

        /// <summary>
        /// 移除堆顶元素,并返回该堆顶元素
        /// </summary>
        /// <param name="value"></param>
        public T Pop()
        {
            if (Count == 0)
                throw new ArgumentOutOfRangeException("当前堆中无数据");
            T result = container[1];
            container[1] = container[Count];
            Count--;
            int index = 1;
            Heapify(index, Count);
            return result;
        }

        /// <summary>
        /// 清除原有数据后添加新数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        public void ClearAndHeapify(T[] source, IComparer<T> comparer = null)
        {
            Count = source.Length;
            Capacity = Count;
            container = new T[Capacity + 1];
            _comparer = comparer ?? Comparer<T>.Default;
            for (int i = 0; i < Capacity; i++)
            {
                container[i + 1] = source[i];
            }
            //建堆
            for (int i = Count / 2; i >= 1; i--)
            {
                Heapify(i, Count);
            }
        }

        public void Clear()
        {
            System.Array.Clear(container, 0, container.Length);
            Count = 0;
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

        /// <summary>
        /// 扩容
        /// </summary>
        private void ExpandSize()
        {
            Capacity = Count * 2 > int.MaxValue ? int.MaxValue : Count * 2;
            if (Count == int.MaxValue - 1)
            {
                throw new ArgumentOutOfRangeException($"数组容量不能超过{int.MaxValue - 1}");
            }
            var tempArray = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                tempArray[i] = container[i];
            }
            container = new T[Capacity];
            for (int i = 0; i < Count; i++)
            {
                container[i + Count] = tempArray[i];
            }
            tempArray = null;
        }
    }
}