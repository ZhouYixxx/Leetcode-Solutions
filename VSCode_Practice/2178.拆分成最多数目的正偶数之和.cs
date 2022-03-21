using System.Collections.Generic;
using System;


public class Solution2178 {
    public void Test()
    {
        var sum = 6914017674;
        var ans = MaximumEvenSplit(sum);
    }

    public IList<long> MaximumEvenSplit(long finalSum) {
        var ans = new List<long>();
        if((finalSum & 1) == 1)
            return ans;
        long cur = 2;
        long sum = 0;
        while(sum + cur <= finalSum)
        {
            sum += cur;
            ans.Add(cur);
            cur += 2;
        }
        if(sum == finalSum)
            return ans;
        cur -= 2;
        sum -= cur;
        var last = finalSum - sum;
        ans[ans.Count-1] = last;
        return ans;
    }
}