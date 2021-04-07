using System;
using CodePractice.Core;

namespace CodePractice.LeetCode.DP
{
    public class MaxMeetingValue : LeetCodeBase
    {
        public MaxMeetingValue() : base("MaxMeetingValue")
        {
            var meetings = new Meeting[8];
            meetings[0] = new Meeting(1,4,5);
            meetings[1] = new Meeting(3,5,1);
            meetings[2] = new Meeting(0,6,8);
            meetings[3] = new Meeting(4,7,4);
            meetings[4] = new Meeting(3,8,6);
            meetings[5] = new Meeting(5,9,3);
            meetings[6] = new Meeting(6,10,2);
            meetings[7] = new Meeting(8,11,4);
            Console.WriteLine(MaxValue(meetings));
            Console.ReadKey();
        }

        public int MaxValue(Meeting[] meetings)
        {
            var prev = new int[meetings.Length];
            //prev数组,如果参加第i个会议，prev[i]表示之前能参加的最晚的会议。
            prev[0] = -1;
            for (int i = 1; i < prev.Length; i++)
            {
                prev[i] = -1;
                for (int j = i-1; j >= 0; j--)
                {
                    if (meetings[i].Start >= meetings[j].End)
                    {
                        prev[i] = j;
                        break;
                    }
                }
            }
            //动态规划
            var opt = new int[meetings.Length];
            opt[0] = meetings[0].Value;
            for (int i = 1; i < opt.Length; i++)
            {
                var prevMeetingValue = prev[i] == -1 ? 0 : opt[prev[i]];
                //状态方程, opt[i - 1]表示不参加第i个会议，opt[prev[i]]表示参加第i个会议
                opt[i] = System.Math.Max(opt[i - 1], prevMeetingValue+meetings[i].Value);
            }
            return opt[opt.Length - 1];
        }

        public class Meeting
        {
            public Meeting(int start, int end, int value)
            {
                Start = start;
                End = end;
                Value = value;
            }

            public int Start { get; }
            public int End { get; }
            public int Value { get; }
        }
    }
}