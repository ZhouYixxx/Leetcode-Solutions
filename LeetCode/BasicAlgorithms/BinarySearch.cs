using System.CodeDom.Compiler;
using System.Linq;

namespace LeetCode.BasicAlgorithms
{
    //二分查找
    public class BinarySearch
    {
        public static int Search(int[] array, int target)
        {
            var low = 0;
            var high = array.Length - 1;
            while (low < high)
            {
                var mid = (low + high) / 2;
                var guess = array[mid];
                if (guess > target)
                {
                    high = mid;
                    continue;
                }
                else if (guess < target)
                {
                    low = mid + 1;
                    continue;
                }
                return mid;
            }
            if (low == high)
            {
                var guess = array[low];
                if (guess != target)
                {
                    return -1;
                }
            }
            return -1;
        }

    }
}