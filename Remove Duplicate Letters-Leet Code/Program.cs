using System.Collections;

public class Solution
{

    public bool isDuplicated(string s ,char target, int startindex , int endIndex)
    {
        var isDuplicated = false;
        for (int i = startindex; i < endIndex; i++)
        {
            if (s[i] == target) return true;
        }
        return isDuplicated;
    }
    public string RemoveDuplicateLetters(string s)
    {
        var stackValues= new Stack<char>() { };
        stackValues.Push(s[0]);

        for (int i = 1; i < s.Length; i++) 
        {
          
            if (stackValues.Contains(s[i])) continue;
            var current = s[i];
            while (stackValues.Count > 0 &&
                   current < stackValues.Peek() &&
                   isDuplicated(s, stackValues.Peek(), i + 1, s.Length))
            {
                stackValues.Pop();
            }

            stackValues.Push(current);
        }
        return new string(stackValues.Reverse().ToArray());
    }
}


class program
{
    static async Task Main()
    {

        var objec = new Solution();
        Console.WriteLine(objec.RemoveDuplicateLetters("bcabc"));
    }
}