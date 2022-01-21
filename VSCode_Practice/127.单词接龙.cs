/*
 * @lc app=leetcode.cn id=127 lang=csharp
 *
 * [127] 单词接龙
 */

// @lc code=start
using System.Collections.Generic;
using System;
public class Solution127 {
    public void Test()
    {
        var wl = new List<string>(){"abo","hco","hbw","ado","abq","hcd","hcj","hww","qbq","qby","qbz","qbx","qbw"};
        var begin = "hbo";
        var end = "qbx";
        var ans = LadderLength(begin, end, wl);
    }
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) 
    {
        return LadderLength_DoubleBFS(beginWord, endWord, wordList);
    }

    /// <summary>
    /// 单向BFS
    /// </summary>
    /// <param name="beginWord"></param>
    /// <param name="endWord"></param>
    /// <param name="wordList"></param>
    /// <returns></returns>
    private int LadderLength_BFS(string beginWord, string endWord, IList<string> wordList) 
    {
        //字典
        var wordSet = new HashSet<string>(wordList.Count);
        //是否访问过
        var visited = new Dictionary<string, bool>();
        for (int i = 0; i < wordList.Count; i++)
        {
            wordSet.Add(wordList[i]);
            visited.Add(wordList[i], false);
        }
        if (!wordSet.Contains(endWord))
        {
            return 0;
        }
        int steps = 1;
        var queue = new Queue<string>();
        queue.Enqueue(beginWord);
        if (visited.ContainsKey(beginWord))
        {
            visited[beginWord] = true;
        }
        while (queue.Count > 0)
        {
            var levelCount = queue.Count;
            while (levelCount-- > 0)
            {
                var word = queue.Dequeue();
                if (word == endWord)
                {
                    return steps;
                }
                var wordChars = word.ToCharArray();
                //用a~z去替换word[i]形成新词，如果包含在字典中且未使用过，就加入队列
                for (int i = 0; i < word.Length; i++)
                {
                    char replace = 'a';
                    while (replace <= 'z')
                    {
                        if (replace == word[i])
                        {
                            replace++;
                            continue;
                        }
                        wordChars[i] = replace;
                        var newWord = new string(wordChars);
                        if (!wordSet.Contains(newWord) || visited[newWord])
                        {
                            wordChars[i] = word[i];//对应字符还原
                            replace++;
                            continue;
                        }
                        visited[newWord] = true;
                        queue.Enqueue(newWord);
                        wordChars[i] = word[i];//对应字符还原
                        replace++;
                    }
                }
            }
            steps++;
        }
        return 0;
    }

    
    bool isOk = false;

    /// <summary>
    /// 双向BFS
    /// </summary>
    /// <param name="beginWord"></param>
    /// <param name="endWord"></param>
    /// <param name="wordList"></param>
    /// <returns></returns>
    private int LadderLength_DoubleBFS(string beginWord, string endWord, IList<string> wordList)
    {
        var wordSet = new HashSet<string>(wordList.Count);
        var beginVisited = new Dictionary<string, bool>();
        var endVisited = new Dictionary<string, bool>();
        for (int i = 0; i < wordList.Count; i++)
        {
            wordSet.Add(wordList[i]);
            beginVisited.Add(wordList[i], false);
            endVisited.Add(wordList[i], false);
        }
        if (!wordSet.Contains(endWord))
        {
            return 0;
        }
        var beginQueue = new Queue<string>();
        beginQueue.Enqueue(beginWord);
        beginVisited[beginWord] = true; 
        var endQueue = new Queue<string>();
        endQueue.Enqueue(endWord);
        endVisited[endWord] = true;
        var beginLevel = new int[1]{1}; 
        var endLevel = new int[1]{1}; 
        while (beginQueue.Count > 0 && endQueue.Count > 0)
        {
            if (beginQueue.Count <= endQueue.Count)
            {
                BFS(beginQueue, beginVisited, endVisited, wordSet, beginLevel);
            }
            else
            {
                BFS(endQueue, endVisited, beginVisited, wordSet, endLevel);
            }
            if (isOk)
            {
                break;
            }
        }
        var res = isOk ? beginLevel[0] + endLevel[0] - 1 : 0;
        return res;
    }

    private void BFS(Queue<string> queue, Dictionary<string,bool> curVisited, Dictionary<string,bool> otherVisited, 
        HashSet<string> wordSet, int[] level)
    {
        var count = queue.Count;
        while (count-- > 0)
        {
            var word = queue.Dequeue();
            var wordChars = word.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                char replace = 'a';
                while (replace <= 'z')
                {
                    if (replace == word[i])
                    {
                        replace++;
                        continue;
                    }
                    wordChars[i] = replace;
                    var newWord = new string(wordChars);
                    //如果newWord不在字典中，或在「当前方向」被记录过，跳过
                    if (!wordSet.Contains(newWord) || curVisited[newWord])
                    {
                        replace++;
                        wordChars[i] = word[i];
                        continue;
                    }
                    //如果newWord在「另一方向」被记录过，说明找到了联通两个方向的最短通路
                    if (otherVisited[newWord])
                    {
                        level[0] += 1;
                        isOk = true;
                        return; 
                    }
                    curVisited[newWord] = true;
                    queue.Enqueue(newWord);
                    wordChars[i] = word[i];//对应字符还原
                    replace++;
                }
            }
        }
        if (queue.Count > 0)
        {
            level[0] += 1;   
        }
    }     
}
// @lc code=end

