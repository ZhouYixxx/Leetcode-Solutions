/*
 * @lc app=leetcode.cn id=514 lang=csharp
 *
 * [514] 自由之路
 */

// @lc code=start

public class Solution514 {
    public void Test()
    {
        var ring = "acooooooobcoo";
        var key = "acb";
        var ans = FindRotateSteps(ring, key);
    }


    string _ring;
    string _key;

    Dictionary<string, int> memo = new Dictionary<string, int>();

    public int FindRotateSteps(string ring, string key) {
        _ring = ring;
        _key = key;
        var steps = key.Length + dfs(0, 0);
        return steps;
    }

/**

func dfs(int ringI,int keyI) {
	递归结束 return 0
	定义 res 变量，当前子问题的解

	for 枚举出 keyI[keyI] 在 ring 中的字符索引：targetI { // 枚举出所有选项
		算出 ringI 和 targetI 的距离，有顺时针逆时针两种，选出其中较小者
		该较小者 + 剩余key字符的递归结果 = 属于当前targetI的解 // 属于当前选项的解
		属于当前targetI的解，试图更新当前子问题的解 res // 在多个选项的解中，取优
	}

	return 当前子问题的解 res
}

**/    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rIndex">当前指向12点位置的index</param>
    /// <param name="kIndex">需要旋转的位置</param>
    /// <returns></returns>
    private int dfs(int rIndex, int kIndex)
    {
        //memorization
        var key = $"{rIndex}-{kIndex}";
        if (memo.TryGetValue(key, out var res))
        {
            //Console.WriteLine($"pruning by memorization: rIndex = {rIndex}('{_ring[rIndex]}'), kIndex={kIndex}('{_key[kIndex]}'), steps={res}");
            return res;
        }
        //base case
        if (kIndex == _key.Length)
        {
            return 0;
        }
        var target = _key[kIndex];
        int steps = int.MaxValue;
        for (int i = 0; i < _ring.Length; i++)
        {
            if (_ring[i] != target) continue;
            var step_clock = Math.Abs(i - rIndex);
            var step_anticlock =  _ring.Length - step_clock;
            var curSteps = Math.Min(step_clock, step_anticlock);
            var subSteps = dfs(i, kIndex+1);
            steps = Math.Min(steps, curSteps + subSteps);
        }
        //Console.WriteLine($"rIndex = {rIndex}('{_ring[rIndex]}'), kIndex={kIndex}('{target}'), steps={steps}");
        memo.Add(key, steps);
        return steps;
    }
}
// @lc code=end

