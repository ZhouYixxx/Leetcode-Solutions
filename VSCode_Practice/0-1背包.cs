using System;
using System.Collections.Generic;

public class SolutionPackage 
{
    public void Test()
    {
        var gold = new int[]{2,3,1,5,4};
        var w = 7;
        var ans = MaxWeight(gold, w);
    }

    public int MaxWeight(int[] gold, int w)
    {
        var res = new List<List<int>>();
        BackTrack(res, new List<int>(), gold, 0, 0, w);
        var max = int.MinValue;
        for (int i = 0; i < res.Count; i++)
        {
            var sum = 0;
            for (int j = 0; j < res[i].Count; j++)
            {
                sum += gold[res[i][j]];
            }
            max = Math.Max(sum, max);
        }
        return max;
    }

    private void BackTrack(List<List<int>> res, List<int> path, int[] gold, int index, int sum, int w)
    {
        if (sum > w || index >= gold.Length)
        {
            var temp = new List<int>(path);
            if (path.Count == 0)
            {
                return;
            }
            temp.RemoveAt(temp.Count-1);
            res.Add(temp);
            return;
        }
        path.Add(index);
        sum += gold[index];
        BackTrack(res, path, gold, index+1, sum, w);
        path.RemoveAt(path.Count-1);
        sum -= gold[index];
        BackTrack(res, path, gold, index+1, sum, w);
    }
}