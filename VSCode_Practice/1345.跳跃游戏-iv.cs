/*
 * @lc app=leetcode.cn id=1345 lang=csharp
 *
 * [1345] 跳跃游戏 IV
 */

// @lc code=start
using System.Collections.Generic;

public class Solution1345 {
    public void Test()
    {
        var list = new List<int>();
        for (int i = 0; i < 50000; i++)
        {
            if (i == 49999)
            {
                list.Add(11);
            }
            else
            {
                list.Add(7);   
            }
        }
        var nums = list.ToArray();
        //var nums = new int[]{7,7,2,1,7,7,7,3,4,1};
        var ans = MinJumps(nums);
    }

    public int MinJumps(int[] arr) 
    {
        Dictionary<int, IList<int>> idxSameValue = new Dictionary<int, IList<int>>();
        for (int i = 0; i < arr.Length; i++) 
        {
            if (!idxSameValue.ContainsKey(arr[i])) 
            {
                idxSameValue.Add(arr[i], new List<int>());
            }
            idxSameValue[arr[i]].Add(i);
        }
        var visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        int step = 0;
        queue.Enqueue(0);
        visited.Add(0);
        while (queue.Count > 0) 
        {
            var levelCount = queue.Count;
            while (levelCount-- > 0)
            {
                var idx = queue.Dequeue();
                if (idx == arr.Length - 1) {
                    return step;
                }
                int v = arr[idx];
                if (idxSameValue.ContainsKey(v)) {
                    foreach (int i in idxSameValue[v]) {
                        if (visited.Add(i)) {
                            queue.Enqueue(i);
                        }
                    }
                    idxSameValue.Remove(v);
                }
                if (idx + 1 < arr.Length && visited.Add(idx + 1)) {
                    queue.Enqueue(idx +1);
                }
                if (idx - 1 >= 0 && visited.Add(idx - 1)) {
                    queue.Enqueue(idx-1);
                }
            }
            step++;
        }
        return 0;
    }
}
// @lc code=end

