/*
实现一个支持动态扩容的数组。 
1.实现数组基本的功能
2.实现数组的扩容
 */

using System;
using System.Collections;

namespace CodePractice.BasicDataStructure.Array
{
    public class DynamicArray<T> 
    {
        private T[] _data;
        //数组中的元素个数（非容量）
        private int _size;

        public DynamicArray(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("Array size cannot be >= 0");
            _data = new T[count];
        }

        public DynamicArray() : this(10)
        {
        }

        //数组下标索引
        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= _data.Length)
                    throw new ArgumentOutOfRangeException();
                return _data[index];
            }
            set
            {
                if (index < 0 )
                    throw new ArgumentOutOfRangeException();
                //检查是否越界，越界则需要扩容
                if (index >= _data.Length)
                {
                    Resize(_data.Length * 2);
                }
                _data[index] = value;
                _size++;
            }
        }

        // 获取数组容量
        public int Capacity()
        {
            return _data.Length;
        }

        // 获取当前元素个数
        public int Count
        {
            get { return _size; }
        }

        // 判断数组是否为空
        public bool IsEmpty
        {
            get { return _size == 0; }
        }

        //数组是否已满
        private bool IsFull()
        {
            return _size == _data.Length;
        }

        //数组扩容（实际应该在下标越界时候做这个操作）
        public void Resize(int count)
        {
            if (count < 0)
            {
                throw new Exception("动态数组的容量不得小于0");
            }

            if (count <= _data.Length)
            {
                var newArray = new T[count];
                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] = _data[i];
                }
                _data = newArray;
            }
            else
            {
                var newArray = new T[count];
                for (int i = 0; i < _data.Length; i++)
                {
                    newArray[i] = _data[i];
                }
                _data = newArray;
            }
        }
    }
}