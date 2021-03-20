using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.Array
{
    public class MaxiumGap_164 : LeetCodeBase
    {
        public MaxiumGap_164() : base("MaxiumGap_164")
        {
            var nums = new int[] {3, 6, 9, 1, 15};
            Console.WriteLine(MaximumGap(nums));
            Console.ReadKey();
        }

        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2) return 0;
            int len = nums.Length;

            // 找出最大值和最小值 为了方便后面确定桶的数量
            int max = -1, min = Int32.MaxValue;
            for (int i = 0; i < len; i++)
            {
                max = System.Math.Max(nums[i], max);
                min = System.Math.Min(nums[i], min);
            }

            // 排除nums全部为一样的数字，nums = [1,1,1,1,1,1];
            if (max - min == 0) return 0;
            // 用于存放每个桶的最大值
            int[] bucketMin = new int[len - 1];
            // 用于存放每个桶的最小值
            int[] bucketMax = new int[len - 1];
            System.Array.Fill(bucketMax, -1);
            System.Array.Fill(bucketMin, Int32.MaxValue);

            // 确定桶的间距
            int interval = (int)System.Math.Ceiling((double)(max - min) / (len - 1));
            for (int i = 0; i < len; i++)
            {
                // 找到每一个值所对应桶的索引
                int index = (nums[i] - min) / interval;
                if (nums[i] == min || nums[i] == max) continue;
                // 更新每个桶的数据
                bucketMax[index] = System.Math.Max(bucketMax[index], nums[i]);
                bucketMin[index] = System.Math.Min(bucketMin[index], nums[i]);
            }

            // maxGap 表示桶之间最大的差距
            int maxGap = 0;
            // preMax 表示前一个桶的最大值
            int preMax = min;
            for (int i = 0; i < len - 1; i++)
            {
                // 表示某一个桶为空
                // 但凡某一个桶不为空，都会在前面的数据中更新掉bucketMax的值
                if (bucketMax[i] == -1) continue;
                maxGap = System.Math.Max(bucketMin[i] - preMax, maxGap);
                preMax = bucketMax[i];
            }
            // [1,10000000]
            maxGap = System.Math.Max(maxGap, max - preMax);
            return maxGap;
        }
    }
}