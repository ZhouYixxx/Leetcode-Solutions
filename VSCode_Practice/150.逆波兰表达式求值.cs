/*
 * @lc app=leetcode.cn id=150 lang=csharp
 *
 * [150] 逆波兰表达式求值
 */

// @lc code=start
public class Solution150 {
    public void Test()
    {
        var tokens = new string[]{"10","6","9","3","+","-11","*","/","*","17","+","5","+"};
        var ans = EvalRPN(tokens);
    }

    public int EvalRPN(string[] tokens) {
        var s = new Stack<int>();
        for (int i = 0; i < tokens.Length; i++)
        {
            var oper = tokens[i];
            if (oper == "+" || oper == "-" || oper == "*" || oper == "/")
            {
                var num1 = s.Pop();
                var num2 = s.Pop();
                switch (oper)
                {
                    case "+":
                        s.Push(num1 + num2);
                        break;
                    case "-":
                        s.Push(num2 - num1);
                        break;
                    case "*":
                        s.Push(num1 * num2);
                        break;
                    case "/":
                        s.Push(num2 / num1);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                s.Push(int.Parse(oper));
            }
        }
        return s.Pop();
    }
}
// @lc code=end

