using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DailyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var cellName = ColumnIndexToColumnLetter(703);

            #region 字典中value是否随着
            var s = "pwwkew";
            var length = LengthOfLongestSubstring(s);
            Console.WriteLine(length);
            var array1 = new int[] { 1, 6, 0, 3, 3, 6, 7, 2, 0, 1 };
            var array2 = new int[] { 6, 3, 0, 8, 9, 6, 6, 9, 6, 1 };
            var node1 = new ListNode(array1[0]);
            var tempNode = node1;
            for (int i = 0; i < array1.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                tempNode.next = new ListNode(array1[i]);
                tempNode = tempNode.next;
            }
            var node2 = new ListNode(array2[0]);
            tempNode = node2;
            for (int i = 0; i < array2.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                tempNode.next = new ListNode(array2[i]);
                tempNode = tempNode.next;
            }
            var r = AddTwoNumbersFast(node1, node2);
            while (r != null)
            {
                Console.Write($"{r.val} ;");
                r = r.next;
            }
            Console.ReadKey();
            //var dic = new Dictionary<string, List<string>>();
            //var records = new List<string>();
            //dic.Add("1", records);
            //records.Add("record1");
            //records.Add("record2");
            //records.Add("record3");
            //records.Add("record4");
            //var value = dic["1"];
            //foreach (var item in value)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            #endregion

            #region List中更新

            //var list = new List<string>(){"a","b","c","d"};
            //var value = list.FirstOrDefault(t => t == "a");
            //value = "aa";
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();
            #endregion

        }
        private static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;
            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0 || s.Length == 1)
            {
                return s.Length;
            }
            int startIndex = 0;
            var endIndex = 0;
            var maxLength = 0;
            var strSet = new HashSet<string>();
            for (int i = startIndex; i < s.Length; i++)
            {
                for (int j = endIndex; j < s.Length; j++)
                {
                    var innerChar = s[j];
                    if (strSet.Contains($"{s[j]}"))
                    {
                    }
                }
            }
            return -1;
        }

        public static ListNode AddTwoNumbersFast(ListNode l1, ListNode l2)
        {
            ListNode pre = new ListNode(0);
            ListNode cur = pre;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int x = l1 == null ? 0 : l1.val;
                int y = l2 == null ? 0 : l2.val;
                int sum = x + y + carry;

                carry = sum / 10;
                sum = sum % 10;
                cur.next = new ListNode(sum);

                cur = cur.next;
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            if (carry == 1)
            {
                cur.next = new ListNode(carry);
            }
            return pre.next;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode(0);
            if (l1 == null && l2 == null)
            {
                return new ListNode(0);
            }
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            var p1 = l1;
            var p2 = l2;
            var carry = 0;
            var haed = new ListNode(0);
            haed.next = result;
            while (p1 != null || p2 != null)
            {
                result.val = carry;
                if (p1 == null)
                {
                    p1 = new ListNode(0);
                }
                if (p2 == null)
                {
                    p2 = new ListNode(0);
                }
                var sum = p1.val + p2.val + carry;
                if (sum >= 10)
                {
                    sum = sum - 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
                result.val = sum;
                if (p1.next == null && p2.next == null && carry == 0)
                {
                    break;
                }
                p1 = p1.next;
                p2 = p2.next;
                result.next = new ListNode(carry);
                result = result.next;

            }
            return haed.next;
        }
    }
    
    //Definition for singly-linked list.
      public class ListNode
      {
          public int val;
          public ListNode next;
          public ListNode(int x) { val = x; }
      }

}
