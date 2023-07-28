using System.Collections;

public class MaxQueue {

    private Queue<int> queue;
    private LinkedList<int> maxDeque; //LinkedList可以模拟为双端队列deque, 头部存储最大值

    public int Count => queue.Count;

    public MaxQueue() {
        queue = new Queue<int>();
        maxDeque = new LinkedList<int>();
    }

    public int Max_value() {
        if (maxDeque.Count == 0) 
        {
            return -1;
        }
        return maxDeque.First.Value;
    }
    
    public void Push_back(int value) {
        queue.Enqueue(value);
        if (maxDeque.Count == 0)
        {
            maxDeque.AddFirst(value);
            return;
        }
        //当前值小于最大值队列的队尾，直接尾部入队
        if (value <= maxDeque.Last.Value)
        {
            maxDeque.AddLast(value);
            return;
        }
        //当前值大于最大值队列的队尾，要把队尾元素移除腾出位置
        while (maxDeque.Count > 0 && value > maxDeque.Last.Value) 
        {
            maxDeque.RemoveLast();
        }
        //现在队列中只有比value大的元素，value入队
        if (maxDeque.Count == 0)
        {
            maxDeque.AddFirst(value);
        }
        else
        {
            maxDeque.AddLast(value);
        }
    }
    
    public int Pop_front() {
        if (queue.Count == 0)
        {
            return -1;
        }
        var frontValue = queue.Dequeue();
        if (frontValue == Max_value())
        {
            maxDeque.RemoveFirst();
        }
        return frontValue;
    }
}