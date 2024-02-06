using System;
using System.Collections.Generic;
using System.Globalization;

/*
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;

	public TreeNode (int x)
	{
		val = x;
	}
}
*/

public class Solution_interview {

    public void Test()
    {
        var rand = new Random();
        int n = 8;
        var nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = rand.Next(0,2*n);
        }
        var ans = NextGreaterNumber(nums);
    }

    public TreeNode reConstructBinaryTree (List<int> preOrder, List<int> vinOrder) {
        // write code here
        var root = BuildTree(preOrder, 0, preOrder.Count - 1, vinOrder, 0, vinOrder.Count-1);
        return root;
    }

    private TreeNode BuildTree(List<int> preOrder, int pre_start, int pre_end, List<int> vinOrder,
        int in_start, int in_end)
    {
        if(pre_start == pre_end || in_start == in_end)
            return new TreeNode(preOrder[pre_start]);
        if(pre_start > pre_end || in_start > in_end)
            return null;
        var root = new TreeNode(preOrder[pre_start]);
        var root_index = vinOrder.IndexOf(root.val);
        var leftCount = root_index - in_start; //node count in left tree
        var rightCount = in_end - root_index; //node count in right tree
        var leftNode = BuildTree(preOrder, pre_start+1 , pre_start+leftCount, vinOrder, in_start, root_index-1);
        var rightNode = BuildTree(preOrder, pre_start + leftCount + 1, pre_end, vinOrder, root_index+1, in_end);
        root.left = leftNode;
        root.right = rightNode;
        return root;
    }

    public int findKth(List<int> a, int n, int K) {
        // write code here
        int k = K;
        QuickSort(a, 0, a.Count-1);
        for (int i = a.Count-1; i >= 0; i--)
        {
            k--;
            if (k == 0)
            {
                return a[i];
            }
        }
        return -1;
    }

    private void QuickSort(List<int> nums, int start, int end)
    {
        if (start >= end) return;
        var pivotIndex = Partition(nums, start, end);
        QuickSort(nums, start, pivotIndex-1);
        QuickSort(nums, pivotIndex+1, end);
    }

    private int Partition(List<int> nums, int start, int end)
    {
        var pivot = nums[start]; //将首元素作为基准
        int low = start, high = end;
        while (low < high)
        {
            //先考察high，从右到左，寻找第一个小于pivot的元素
            while (low < high && nums[high] >= pivot) high--;
            //到这里，nums[high] < pivot,应该放到左边，即low的位置
            if (low < high)
            {
                nums[low] = nums[high];
                //low++; 该步骤可以省略 
            }
            //再考察low，从左到右，寻找首个大于pivot的元素
            while (low < high && nums[low] <= pivot) low++;
            //到这里，nums[low] > pivot, 放到右边，即high的位置
            if (low < high) 
            {
                nums[high] = nums[low];
                //high--; 该步骤可以省略  
            }
        }
        //low = high
        nums[low] = pivot;
        return low;
    }

    private void Swap(List<int> nums, int a, int b)
    {
        var temp = nums[a];
        nums[a] = nums[b];
        nums[b] = temp;
    }


    public List<int> maxInWindows (List<int> num, int size) {
        // write code here
        var priorityQueue = new PriorityQueue<(int idx, int val),int>();
        var count = num.Count - size + 1;
        
        for (int i = 0; i < size; i++)
        {
            priorityQueue.Enqueue((i, num[i]), -num[i]);
        }
        var ans = new List<int>(count);
        ans[0] = priorityQueue.Peek().val;
        for (int i = size; i <= num.Count - size; i++)
        {
            priorityQueue.Enqueue((i, num[i]), -num[i]);
            
            while (priorityQueue.TryPeek(out var element, out var priority) && element.idx <= i-size)
            {
                priorityQueue.Dequeue();
            }
            ans[i-size+1] = priorityQueue.Peek().val;
        }
        return ans;
    }



    public int solve (List<List<int>> matrix) {
        // write code here
        n = matrix.Count;
        m = matrix[0].Count;
        memo = new Dictionary<int,int>();
        var visited = new bool[n][];
        int ans = 0;
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                 
                //recursion
                var key = i * 10000 + j;
                if(memo.TryGetValue(key, out int value))
                {
                    ans = Math.Max(ans, value);
                    continue;
                }
                var temp = DFS(i, j, matrix, 0);
                ans = Math.Max(ans, temp);
            }
        }
        return ans;
    }

    private int m;
    private int n;

    private Dictionary<int, int> memo;


    /// <summary>
    /// 以(i,j)为起点的路径长度
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="visited"></param>
    /// <param name="matrix"></param>
    /// <returns></returns>
    private int DFS(int i, int j, List<List<int>> matrix, int level)
    {
        DataStructureHelper.PrintWithIndent(level,$"i = {i}, j = {j}, level = {level}");
        if(i >= n || j >= m || i < 0 || j < 0)
            return 0;
        var key = i * 10000 + j;
        if(memo.TryGetValue(key, out int value))
        {
            DataStructureHelper.PrintWithIndent(level,$"i = {i}, j = {j}, level={level}, return..");
            return value;
        }
        int max = 0;
        //top
        if(i-1 >= 0 && matrix[i][j] < matrix[i-1][j])
        {
            var len = DFS(i-1, j, matrix, level+1);
            max = Math.Max(max, len);
        }
        //bottom
        if(i+1 < n && matrix[i][j] < matrix[i+1][j])
        {
            var len = DFS(i+1, j, matrix,  level+1);
            max = Math.Max(max, len);
        }
        //left
        if(j-1 >= 0 && matrix[i][j] < matrix[i][j-1])
        {
            var len = DFS(i, j-1, matrix,  level+1);
            max = Math.Max(max, len);
        }
        //right
        if(j+1 < m && matrix[i][j] < matrix[i][j+1])
        {
            var len = DFS(i, j+1, matrix,  level+1);
            max = Math.Max(max, len);
        }
        memo.Add(key, max+1);
        DataStructureHelper.PrintWithIndent(level,$"i = {i}, j = {j}, level={level}, return..");
        return max+1;
    }

    public int[] NextGreaterNumber(int[] nums)
    {
        var s = new Stack<int>();
        var ans = new int[nums.Length];
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            //每次循环，保证stack中只保存num[i]及比num[i]更大的值（升序）

            //比nums[i]小或相等的要依次出栈
            while (s.Count != 0 && s.Peek() <= nums[i])
            {
                s.Pop();
            }
            ans[i] = s.Count == 0 ? -1 : s.Peek();
            s.Push(nums[i]);
        }
        return ans;
    }
}