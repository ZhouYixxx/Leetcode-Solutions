using System;
using System.Collections.Generic;

/// <summary>
/// 并查集😇
/// </summary>
public class UnionFindSet
{
    private readonly int[] root;//存储所有顶点的根节点
    private readonly int[] rank;//存储所有顶点的秩
    public UnionFindSet(int size)
    {
        root = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++)
        {
            root[i] = i;
            rank[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (root[x] == x)
        {
            return x;
        }
        root[x] = Find(root[x]);//路径压缩
        return root[x];
    }

    public void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);
        if (rootX == rootY)
            return;
        //按秩合并
        if (rank[rootX] > rank[rootY])
        {
            //取rootX作为根节点
            root[rootY] = rootX;
        }
        else if (rank[rootX] < rank[rootY])
        {
            //取rootY作为根节点
            root[rootX] = rootY;
        }
        else
        {
            //两个秩相同，随便取一个为新根节点，且新根节点秩+1
            root[rootY] = rootX;
            rank[rootX] += 1;
        }
    }

    public bool IsConnected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}
