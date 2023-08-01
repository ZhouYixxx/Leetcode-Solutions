
public class Solution_Offer67 {
    public void Test() {
        var str = "-+1";
        var ans = StrToInt(str);
    }

    private int max = int.MinValue / 10;

    public int StrToInt(string str) {
        //str = str.Trim();
        int start = 0;
        while (start < str.Length && str[start] == ' ') 
        {
            start++;
        }
        if (start >= str.Length)
        {
            return 0;
        }
        int ans = 0;
        //符号
        bool negative = str[start] == '-';
        start = negative ? start + 1 : start;
        for (int i = start; i < str.Length; i++)
        {
            if (str[i] == '+' && i == start && !negative)
            {
                continue;
            }
            if (!IsNum(str[i]))
            {
                return negative ? ans : -ans;
            }
            //转化为负数，否则-21474836482这样的用例无法通过
            var digit = -(int)(str[i] - '0');
            //如果超限直接返回0
            if (IsOutofRange(ans, negative, digit))
            {
                return negative ? int.MinValue : int.MaxValue;
            }
            ans = ans * 10 + digit;
        }
        return negative ? ans : -ans;
    }

    private bool IsNum(char c)
    {
        return c >= '0' && c <= '9';
    }

    private bool IsOutofRange(int num, bool isNegative, int digit)
    {
        if (num > max)
        {
            return false;
        }
        if (num < max)
        {
            return true;
        }
        //n == max
        var maxDigit = isNegative ? int.MinValue % 10 : -int.MaxValue % 10;
        return digit < maxDigit;
    }
}