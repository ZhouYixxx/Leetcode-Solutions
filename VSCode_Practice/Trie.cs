using System;
using System.Collections.Generic;

public class Trie
{
    private TrieNode root = null;

    public Trie() {
        root = new TrieNode();
    }

    public Trie(IEnumerable<string> words)
    {
        root = new TrieNode();
        foreach (var word in words)
        {
            Insert(word);
        }
    }

    public TrieNode GetRoot()
    {
        return root;
    }

    /// <summary>
    /// Trie插入一个字符串
    /// </summary>
    /// <param name="word"></param>
    public void Insert(string word)
    {
        var node = root;
        for (int i = 0; i < word.Length; i++)
        {
            var u = word[i]-'a';
            if (node.children[u] == null)
            {
                node.children[u] = new TrieNode();
            }
            node = node.children[u];   
        }
        node.isEnd = true;
    }
    
    /// <summary>
    /// 如果字符串 word 在前缀树中，返回 true；否则，返回 false
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public bool Search(string word) {
        var node = root;
        for (int i = 0; i < word.Length; i++)
        {
            var index = word[i] - 'a';
            if (node.children[index] == null)
            {
                return false;
            }
            node = node.children[index];
        }
        return node.isEnd;
    }
    
    /// <summary>
    /// 是否存在前缀prefix
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public bool StartsWith(string prefix) {
        var node = root;
        for (int i = 0; i < prefix.Length; i++)
        {
            var index = prefix[i] - 'a';
            if (node.children[index] == null)
            {
                return false;
            }
            node = node.children[index];
        }
        return true;
    }
}

public class TrieNode
{
    public bool isEnd = false; //是否存在以当前节点结尾的字符串
    public TrieNode[] children = new TrieNode[26];
}