public class CQueue {
    private Stack<int> stack1;
    private Stack<int> stack2;

    public CQueue() {
        stack1 = new Stack<int>();
        stack2 = new Stack<int>();
    }
    
    public void AppendTail(int value) {
        stack1.Push(value);
    }
    
    public int DeleteHead() {
        if (stack2.Count > 0)
        {
            return stack2.Pop();
        }
        if (stack1.Count > 0)
        {
            Move();
            return stack2.Pop();
        }
        return -1;
    }

    private void Move()
    {
        while (stack1.Count > 0)
        {
            stack2.Push(stack1.Pop());
        }
    }
}