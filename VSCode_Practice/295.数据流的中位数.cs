/*
 * @lc app=leetcode.cn id=295 lang=csharp
 *
 * [295] 数据流的中位数
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class MedianFinder {

    private Heap<int> maxHeap;
    private Heap<int> minHeap;
    private int count;
    public MedianFinder() {
        maxHeap = new Heap<int>(false);
        minHeap = new Heap<int>(true);
    }
    
    public void AddNum(int num) {
        count++;
        //num比小顶堆堆顶更大，那么应该将num放入小顶堆
        if (minHeap.Count != 0 && num > minHeap.Top())
        {
            minHeap.Add(num);
        }
        else
        {
            maxHeap.Add(num);
        }
        //保证：大顶堆数量 = 小顶堆数量 || 小顶堆数量 + 1
        if (maxHeap.Count - minHeap.Count == 2)
        {
            var top = maxHeap.Pop();
            minHeap.Add(top);
        }
        else if (minHeap.Count - maxHeap.Count == 1)
        {
            var top = minHeap.Pop();
            maxHeap.Add(top);
        }
    }
    
    public double FindMedian() {
        //总数为奇数
        if ((count & 1) == 1)
        {
            return maxHeap.Top();
        }
        //总数为偶数
        return (minHeap.Top() + maxHeap.Top())/2d;
    }
}

/// <summary>
/// 大顶堆/小顶堆实现
/// </summary>
// public class Heap<T>
// {
//     private T[] array;//用数组存储数据
//     public int Capacity { get; private set; } = 16;
//     public int Count { get; private set; }
//     private IComparer<T> _comparer = Comparer<T>.Default;

//     private Comparison<T> _comparison = null;//自定义的比较器

//     private bool isMinHeap = false;

//     /// <summary>
//     /// 
//     /// </summary>
//     /// <param name="isDesc">为false时，生成大顶堆，否则为小顶堆</param>
//     public Heap(bool isMainHeap = false, Comparison<T> comparer = null)
//     {
//         isMinHeap = isMainHeap;
//         array = new T[Capacity];
//         Count = 0;
//         _comparison = comparer;
//     }

//     public Heap(T[] source, bool isMainHeap = false, Comparison<T> comparer = null)
//     {
//         isMinHeap = isMainHeap;
//         _comparison = comparer;
//         var n = source.Length;
//         Capacity = 2*n;
//         array = new T[Capacity];
//         Array.Copy(source, array, n);
//         for (int i = n/2; i >= 0; i--)
//         {
//             Heapify(array, i, array.Length-1);
//         }
//         Count = n;
//     }

//     /// <summary>
//     /// 添加数据，复杂度O(logN)
//     /// </summary>
//     /// <param name="value"></param>
//     public void Add(T value)
//     {
//         if (Count >= Capacity)
//         {
//             ExpandSize();
//         }
//         array[Count] = value;
//         int index = Count;
//         Count++;
//         //heapify from bottom to top
//         //小顶堆
//         if (isMinHeap)
//         {
//             while (index >= 0 && CompareInternal(array[index], array[(index-1)/2]) < 0)
//             {
//                 var parentIndex = (index-1) / 2;
//                 //swap
//                 SWAP(index, parentIndex, array);
//                 index = parentIndex;
//             }
//         }
//         //大顶堆
//         else
//         {
//             while (index >= 0 && CompareInternal(array[index], array[(index-1)/2]) > 0)
//             {
//                 var parentIndex = (index-1) / 2;
//                 //swap
//                 SWAP(index, parentIndex, array);
//                 index = parentIndex;
//             }
//         }
//     }

//     public void RemoveTop()
//     {
//         if (Count == 0)
//         {
//             throw new IndexOutOfRangeException("Heap is Empty!");
//         }
//         //swap first element and the last element
//         array[0] = array[--Count];
//         array[Count] = default(T);
//         //heapify from top to bottom
//         Heapify(array, 0, Count-1);
//     }

//     private static void SWAP(int index1, int index2, T[] array)
//     {
//         var temp = array[index1];
//         array[index1] = array[index2];
//         array[index2] = temp;
//     }

//     public T Pop()
//     {
//         if (Count == 0)
//         {
//             throw new IndexOutOfRangeException("Heap is Empty!");
//         }
//         var top = array[0];
//         RemoveTop();
//         return top;
//     }

//     public T Top()
//     {
//         if (Count == 0)
//         {
//             throw new IndexOutOfRangeException("Heap is Empty!");
//         }
//         return array[0];
//     }

//     /// <summary>
//     /// 堆排序，大顶堆返回升序排列数组,小顶堆将返回降序排列数组
//     /// </summary>
//     /// <param name="source"></param>
//     public void HeapSort(T[] source, bool desc = false)
//     {
//         //建堆
//         isMinHeap = desc;
//         for (int i = source.Length/2; i >= 0; i--)
//         {
//             Heapify(source, i, source.Length-1);
//         }
//         //排序
//         int idx = source.Length-1;
//         while (idx >= 0)
//         {
//             var top = source[0];
//             SWAP(idx,0,source);
//             Heapify(source, 0,--idx);
//         }
//     }

//     /// <summary>
//     /// 扩容
//     /// </summary>
//     private void ExpandSize()
//     {
//         Capacity = (long)Count * 2 > int.MaxValue ? int.MaxValue : Count * 2;
//         if (Count == int.MaxValue)
//         {
//             throw new ArgumentOutOfRangeException($"数组容量不能超过{int.MaxValue}");
//         }
//         var tempArray = new T[Count];  
//         for (int i = 0; i < Count; i++)
//         {
//             tempArray[i] = array[i];
//         }
//         array = new T[Capacity];
//         for (int i = 0; i < Count; i++)
//         {
//             array[i] = tempArray[i];
//         }
//         tempArray = null;
//     }

//     /// <summary>
//     /// 自顶向下的堆化
//     /// </summary>
//     /// <param name="a"></param>
//     /// <param name="index"></param>
//     private void Heapify(T[] a, int index, int maxPos)
//     {
//         while (index*2+1 <= maxPos || index*2+2 <= maxPos)
//         {
//             var childIndex1 = index * 2 + 1;
//             var childIndex2 = index * 2 + 2;
//             if (childIndex2 > maxPos)
//             {
//                 //大顶堆
//                 if (!isMinHeap && CompareInternal(a[index], a[childIndex1]) >= 0)
//                     break;
//                 //小顶堆
//                 if (isMinHeap && CompareInternal(a[index], a[childIndex1]) <= 0)
//                     break;
//                 SWAP(index, childIndex1, a);
//                 index = childIndex1;
//             }
//             else
//             {
//                 //大顶堆处理
//                 if (!isMinHeap)
//                 {
//                     if (CompareInternal(a[index], a[childIndex1]) >= 0 && CompareInternal(a[index], a[childIndex2]) >= 0)
//                         break;
//                     if (CompareInternal(a[childIndex1], a[childIndex2]) >= 0)
//                     {
//                         SWAP(index, childIndex1, a);
//                         index = childIndex1;
//                     }
//                     else
//                     {
//                         SWAP(index, childIndex2, a);
//                         index = childIndex2;
//                     }
//                 }
//                 //小顶堆处理
//                 else
//                 {
//                     if (CompareInternal(a[index], a[childIndex1]) <= 0 && CompareInternal(a[index], a[childIndex2]) <= 0)
//                         break;
//                     if (CompareInternal(a[childIndex1], a[childIndex2]) <= 0)
//                     {
//                         SWAP(index, childIndex1, a);
//                         index = childIndex1;
//                     }
//                     else
//                     {
//                         SWAP(index, childIndex2, a);
//                         index = childIndex2;
//                     }
//                 }
//             }
//         }
//     }

//     private int CompareInternal(T x, T y)
//     {
//         return _comparison == null ? _comparer.Compare(x,y) : _comparison(x, y);
//     }
// }


/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// @lc code=end

