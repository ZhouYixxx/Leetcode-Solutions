/*
 * @lc app=leetcode.cn id=332 lang=csharp
 *
 * [332] 重新安排行程
 */

// @lc code=start

public class Solution332 {
    public void Test()
    {
        var tickets = new List<IList<string>>();
        tickets.Add(new List<string>(){"JFK","MUC"});
        tickets.Add(new List<string>(){"MUC","LHR"});
        tickets.Add(new List<string>(){"SFO","SJC"});
        tickets.Add(new List<string>(){"LHR","SFO"});
        //tickets.Add(new List<string>(){"ATL","SFO"});
        var path = @"C:\Users\CK-BGYF\Desktop\input.txt";
        tickets = readFromFile(path);

        var ans = FindItinerary(tickets);
    }

    private List<IList<string>> readFromFile(string path)
    {
        var tickets = new List<IList<string>>();
        var strs = File.ReadAllText(path).Split('[', ']');
        foreach (var str in strs)
        {
            if (str.Length <= 1)
            {
                continue;
            }
            var inter = str.Replace("\"", string.Empty).Split(',').ToList();
            tickets.Add(inter);
        }
        return tickets;
    }

    Dictionary<string,List<string>> adj; //邻接表: key = from, value = to
    int ticketsCount;

    int level = 0;

    List<string> res;

    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        ticketsCount = tickets.Count;
        res = new List<string>(){"JFK"};
        //建立邻接表
        adj = new Dictionary<string,List<string>>(); //邻接表: key = from, value = to
        foreach (var ticket in tickets)
        {
            var from = ticket[0];
            var to = ticket[1];
            if (adj.TryGetValue(from, out var tList)) tList.Add(to);
            else adj.Add(from, new List<string>(){to});
        }
        foreach (var city in adj.Keys)
        {
            adj[city].Sort((a,b)=>b.CompareTo(a)); //DFS中是按照从后向前进行遍历，因此这里要按照desc顺序排序
        }

        //DFS
        var ans = DFS("JFK", 0);
        return res;
    }

    /// <summary>
    /// 返回true等于可以找到合法路径
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    private bool DFS(string from, int used)
    {
        DataStructureHelper.PrintWithIndent(level++, $"current city={from}, res = {string.Join(',', res)}");
        if (used == ticketsCount)
        {
            DataStructureHelper.PrintWithIndent(--level, $"finish, true! res = {string.Join(',', res)}");
            return true;
        }
        List<string> nextCities;
        adj.TryGetValue(from, out nextCities);
        if (nextCities == null || nextCities.Count == 0)
        {
            DataStructureHelper.PrintWithIndent(--level, $"finish, true! pop up...");
            return false;
        }
        for (int i = nextCities.Count - 1; i >= 0; i--)
        {
            var city = nextCities[i];
            nextCities.RemoveAt(i);
            res.Add(city);
            if (DFS(city, used+1))
            {
                DataStructureHelper.PrintWithIndent(--level, $"finish, true! pop up...");
                return true;
            }
            else
            {
                res.RemoveAt(res.Count-1);
                //nextCities.Add(city);
                nextCities.Insert(i,city);     
            }
        }
        DataStructureHelper.PrintWithIndent(--level, $"finish, false!");
        return false;
    }
}
// @lc code=end

