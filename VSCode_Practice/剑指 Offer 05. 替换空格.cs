using System.Text;

public class Solution_Offer05 {
    public void Test(){
        string s = "We are happy.";
        var ans = ReplaceSpace(s);
    }

    public string ReplaceSpace(string s) {
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                sb.Append("%20");
            }
            else{
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }
}