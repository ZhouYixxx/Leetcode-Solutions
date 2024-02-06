/*
 * @lc app=leetcode.cn id=21 lang=csharp
 *
 * LCP 30. 魔塔游戏
 */

 using System;
public class SolutionLCP30 {
    public void Test()
    {
        var nums = new int[]{100,100,100,-250,-60,-140,-50,-50,100,150};
    }
    public int MagicTower(int[] nums) {
        var minHp = new PriorityQueue<int, int>();
        long curHp = 1;
        int count = 0;
        long delay = 0; //从堆中取出的所有值的和
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 0) minHp.Enqueue(nums[i], nums[i]);
            curHp += nums[i];
            if (curHp > 0)
            {
                //hp > 0, 继续
                continue;
            }
            //此时hp <= 0, 从前面的扣血中，拿出一个扣血量最大的数（最小的负数），把这次扣掉的血重新加回来。这次扣血则放到最后再扣
            var maxDeductHp = minHp.Dequeue(); 
            curHp -= maxDeductHp; 
            delay += maxDeductHp; //记录要扣除的血量，最后统一扣除
            count++;
        }
        curHp = curHp + delay; //待扣的血量要扣掉
        return curHp <= 0 ? -1 : count;
    }
}
// @lc code=end

