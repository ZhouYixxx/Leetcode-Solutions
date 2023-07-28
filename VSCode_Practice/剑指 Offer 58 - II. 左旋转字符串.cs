using System.Text;

public class Solution_Offer58_ii {
    public void Test() {
        var s = "abcdefg";
        int k = 2;
        var ans = ReverseLeftWords(s,k);
    }

    public string ReverseLeftWords(string s, int n) {
        var sb = new StringBuilder();
        for (int i = n; i < s.Length; i++)
        {
            sb.Append(s[i]);
        } 
        for (int i = 0; i < n; i++)
        {
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
}