/*
 * @lc app=leetcode.cn id=1185 lang=csharp
 *
 * [1185] 一周中的第几天
 */

// @lc code=start
public class Solution1185 {
    public void Test()
    {
        var d = 5;
        var m = 1;
        var y = 2022;
        var ans = DayOfTheWeek(d,m,y);
    }
    
    public string DayOfTheWeek(int day, int month, int year) 
    {
        string[] weekDays = new string[]{"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"};
        int[] monthDays = new int[12]{31,28,31,30,31,30,31,31,30,31,30,31};
        int days = 4;
        bool isLeapYear = year % 400 == 0 || (year % 100 != 0 && year % 4 == 0);
        for (int i = 1971; i < year; i++)
        {
            var isLeap = i % 400 == 0 || (i % 100 != 0 && i % 4 == 0);
            days = isLeap ? days + 366 : days + 365;
        }
        for (int i = 1; i < month; i++)
        {
            days += monthDays[i-1];
            if (isLeapYear && i == 2)
            {
                days++;
            }
        }
        days += day;
        return weekDays[days%7];

    }
}
// @lc code=end

