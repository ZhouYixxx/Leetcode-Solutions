/*
 * @lc app=leetcode.cn id=155 lang=csharp
 *
 * [155] 最小栈
 */

// @lc code=start
using System.Collections.Generic;
using System;

public class MinStack {

    private Stack<int> _stack;//存所有数据
    private Stack<int> _minStack;//存最小值
    public MinStack() 
    {
        _stack = new Stack<int>();
        _minStack = new Stack<int>();
    }
    
    public void Push(int val) {
        _stack.Push(val);
        if (_minStack.Count == 0 || _minStack.Peek() >= val)
        {
            _minStack.Push(val);
        }
    }
    
    public void Pop() {
        var top = _stack.Pop();
        if (top <= _minStack.Peek())
        {
            _minStack.Pop();
        }
    }
    
    public int Top() {
        return _stack.Peek();
    }
    
    public int GetMin() {
        return _minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
// @lc code=end

