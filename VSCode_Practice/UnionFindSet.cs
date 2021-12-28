using System;
using System.Collections.Generic;

public class UnionFindSet
{
    private readonly int[] root;
    public UnionFindSet(int size)
    {
        root = new int[size];
        for (int i = 0; i < size; i++)
        {
            root[i] = i;
        }
    }

    public int Find(int x)
    {
        while (x != root[x])
        {
            x = root[x];
        }
        return x;
    }

    public void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);
        if (rootX != rootY)
        {
            root[rootY] = rootX;
        }
    }

    public bool IsConnected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}
