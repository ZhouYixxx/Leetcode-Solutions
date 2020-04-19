/*
189. 旋转数组
给定一个数组，将数组中的元素向右移动 k 个位置，其中 k 是非负数。

示例 1:
输入: [1,2,3,4,5,6,7] 和 k = 3
输出: [5,6,7,1,2,3,4]
解释:
向右旋转 1 步: [7,1,2,3,4,5,6]
向右旋转 2 步: [6,7,1,2,3,4,5]
向右旋转 3 步: [5,6,7,1,2,3,4]

尽可能想出更多的解决方案，至少有三种不同的方法可以解决这个问题。
要求使用空间复杂度为 O(1) 的原地算法。
 */

using System.Collections;

namespace CodePractice.LeetCode.Array
{
    public class RotateArray_189
    {
        /// <summary>
        /// 暴力法，k=1时的情况很容易实现，然后循环k次这种情况即可。时间复杂度O(nk),空间复杂度O(1)
        /// </summary>
        public void Brute(int[] nums, int k)
        {
            int temp, previous;
            for (int i = 1; i <= k; i++)
            {
                previous = nums[nums.Length - 1];
                for (int j = 0; j < nums.Length; j++)
                {
                    temp = nums[j];
                    nums[j] = previous;
                    previous = temp;
                }
            }
        }

        /// <summary>
        /// 使用队列辅助，因此需要额外的空间，时间复杂度O(n),空间复杂度O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void AssistArray(int[] nums, int k)
        {
            k %= nums.Length;
            var queue = new Queue(nums.Length);
            var index = nums.Length - k;
            //从index位置处开始将数组元素压入队列，到最后一个元素后，再从第一个元素开始压入
            for (int i = 0; i < nums.Length; i++)
            {
                if (index < nums.Length)
                {
                    //从第n-k位置处，依次压入队列
                    queue.Enqueue(nums[index]);
                    index++;
                    continue;
                }
                //最后一个元素压入后,从0开始依次压入元素
                queue.Enqueue(nums[i - k]);
            }
            //将队列中的元素依次压出，赋值给数组
            for (int i = 0; i < nums.Length; i++)
            {
                var value = queue.Dequeue();
                nums[i] = (int)value;
            }
        }

        /// <summary>
        /// 采用翻转的方法，先翻转整个数组，再翻转前k个元素，再翻转后n-k个元素。
        /// 需要遍历两次数组因此时间复杂度O(n)，空间复杂度O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void rotate(int[] nums, int k)
        {
            k %= nums.Length;
            reverse(nums, 0, nums.Length - 1);
            reverse(nums, 0, k - 1);
            reverse(nums, k, nums.Length - 1);
        }

        public void reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}
