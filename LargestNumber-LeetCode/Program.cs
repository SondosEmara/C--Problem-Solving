using System.Collections;

public class Solution
{
    public string LargestNumber(int[] nums)
    {
        //Bubble Sort Idea
        var list = new List<string>();
        foreach (var item in nums)
        {
            list.Add(item.ToString());
        }
        list.Sort((a, b) => (b + a).CompareTo(a + b));
        if (list[0] == "0") return "0";

        var result = string.Empty;
        foreach (var item in list)
        {
            result += item;
        }
        return result;

    }


}


class program
{
    static async Task Main()
    {

        var objec = new Solution();
    }
}