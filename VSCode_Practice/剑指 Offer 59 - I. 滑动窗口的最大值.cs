using System.Text;

public class Solution_Offer59_i {
    public void Test() {
        var nums = new int[]{4};
        int k = 1;
        var ans = MaxSlidingWindow(nums, k);
    }

    /// <summary>
    /// 优先队列方法
    /// </summary>
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var queue = new PriorityQueue<int[], int>(Comparer<int>.Create((x,y)=> y - x));
        var ans = new int[nums.Length - k + 1];
        for (int i = 0; i < k; i++)
        {
            //同时记录索引和数值
            queue.Enqueue(new int[2]{nums[i], i}, nums[i]);
        }
        ans[0] = queue.Peek()[0];
        for (int i = k; i < nums.Length; i++)
        {
            queue.Enqueue(new int[2]{nums[i], i}, nums[i]);
            //队列顶端最大值的索引应该处于区间 (i-k, i]之间
            while (queue.Peek()[1] <= (i-k))
            {
                queue.Dequeue();
            }
            ans[i - k + 1] = queue.Peek()[0];;
        }
        return ans;
    }
}