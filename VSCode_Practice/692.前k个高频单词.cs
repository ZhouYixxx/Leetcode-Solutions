/*
 * @lc app=leetcode.cn id=692 lang=csharp
 *
 * [692] 前K个高频单词
 */

// @lc code=start
using System;
using System.Collections.Generic;


public class Solution692 {
    public void Test()
    {
        var words = new string[]{"love", "i", "leetcode", "i", "love", "coding"};
        //"the","is","sunny","day"
        var k = 4;
        var ans = TopKFrequent(words, k);
    }

    public IList<string> TopKFrequent(string[] words, int k) {
        var dic = new Dictionary<string, int>();
        for (int i = 0; i < words.Length; i++)
        {
            if (!dic.ContainsKey(words[i]))
            {
                dic[words[i]] = 0;
            }
            dic[words[i]] += 1;
        }
        var heap = new Heap<KeyValuePair<string, int>>(true, MyCompare);
        foreach (var pair in dic)
        {
            var freequency = pair.Value;
            if (heap.Count < k)
            {
                heap.Add(pair);
                continue;
            }
            //当前值比堆顶大，需要替换
            if (MyCompare(heap.Top(), pair) < 0)
            {
                heap.RemoveTop();
                heap.Add(pair);   
            }
        }
        var ans = new string[heap.Count];
        //从大到小输出，需要逆序写入
        while (heap.Count > 0)
        {
            var top = heap.Pop();
            ans[heap.Count] = top.Key;
        }
        return ans;
    }

    private int MyCompare(KeyValuePair<string, int> x, KeyValuePair<string, int> y){
        //热度一样，按字典顺序比较。在字典前面的字符较大
        if ( x.Value.CompareTo(y.Value) == 0)
        {
            return DicSort(x.Key,y.Key);
        }
        return x.Value.CompareTo(y.Value);
    }

    private int DicSort(string x, string y)
    {
        int i = 0;
        while (i < x.Length && i < y.Length)
        {
            if (x[i] == y[i])
            {
                i++;
                continue;
            }
            return (int)(x[i] - y[i]) < 0 ? 1 : -1;
        }
        if (i < x.Length)
        {
            return -1;
        }
        return 1;
    }
}

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
    //             while (index > 0 && CompareInternal(array[index], array[(index-1)/2]) < 0)
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
    //             while (index > 0 && CompareInternal(array[index], array[(index-1)/2]) > 0)
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

// @lc code=end

