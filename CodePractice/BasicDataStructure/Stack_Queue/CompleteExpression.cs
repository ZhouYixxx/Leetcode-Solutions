/*
* 示例：1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )
* 补全括号后输出：( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )
* 思路：运算符问题一般采用栈来解决。一个运算符需要两个数字匹配；这里用两个栈分别存储数字和运算符
*/

using System.Collections.Generic;

namespace CodePractice.BasicDataStructure.Stack_Queue
{
    /// <summary>
    /// 使用栈补全左边括号
    /// </summary>
    public class CompleteExpression
    {
        public static string GetCompleteExpression(string expression)
        {
            expression = expression.Replace(" ", "");
            var array = expression.ToCharArray();
            var oprStack = new Stack<string>();
            var dataStack = new Stack<string>();
            for (int i = 0; i < array.Length; i++)
            {
                //遇到右括号，分别从栈取出两个数和一个运算符，用于合成一个带括号的新的表达式
                if (array[i] == ')')
                {
                    var data1 = dataStack.Pop();
                    var data2 = dataStack.Pop();
                    var opr = oprStack.Pop();
                    //形成一个新的表达式
                    var newStr = $"({data2}{opr}{data1})";
                    //新的表达式压入数据栈中
                    dataStack.Push(newStr);
                }
                //遇到运算符
                else if (array[i] == '+' || array[i] == '-' || array[i] == '*' || array[i] == '/')
                {
                    oprStack.Push(array[i].ToString());
                }
                //遇到数字
                else
                {
                    dataStack.Push(array[i].ToString());
                }
            }
            return dataStack.Pop();
        }
    }
}