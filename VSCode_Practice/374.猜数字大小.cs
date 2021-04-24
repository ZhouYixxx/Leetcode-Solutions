/*
 * @lc app=leetcode.cn id=374 lang=csharp
 *
 * [374] 猜数字大小
 */

// @lc code=start
/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */
 
// using System;

// public class Solution : GuessGame {
//     public int GuessNumber(int n) 
//     {
//         var l = 1;
//         var r = n;
//         while (l <= r)
//         {
//             var mid = l+(r-l)/2;
//             var res = guess(mid);
//             if (res == 0)
//             {
//                 return mid;
//             }
//             //pick > mid
//             if (res == 1)
//             {
//                 l = mid+1;
//             }
//             //pick < mid
//             if (res == -1)
//             {
//                 r = mid-1;
//             }
//         }
//         return -1;
//     }
// }
// @lc code=end

