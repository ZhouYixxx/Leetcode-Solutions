using System;

public class Solution1230 
{
    public void Test()
    {
        var prob = new double[]{0.4,0.6,0.35,0.757,0.53};
        var target = 1;
        var ans = ProbabilityOfHeads(prob, target);
    }

    public double ProbabilityOfHeads(double[] prob, int target) 
    {
        var n = prob.Length;
        //dp[i,j]=p, 表示扔i个硬币，有j个朝上的概率为p
        var dp = new double[n+1,n+1];
        dp[1,1] = prob[0];
        dp[1,0] = 1-prob[0];
        for (int i = 2; i <= n; i++)
        {
            for (int j = 0; j <= i; j++)     
            {
                if (j == 0)
                {
                    dp[i,j] = dp[i-1,0]*(1-prob[i-1]);
                    continue;
                }
                dp[i,j] = dp[i-1,j-1]*prob[i-1] + dp[i-1,j]*(1-prob[i-1]);
            }
        }
        return dp[n,target];
    }
}