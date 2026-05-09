public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int startIndex = 0;
        int totalGas = gas[0];
        int i = 0;
        int countTwiceCicruit = 1;

        while (startIndex < gas.Length)
        {

            if (i == startIndex && countTwiceCicruit > 1 && totalGas > 0)
            {
                return startIndex;
            }
            else if (totalGas < cost[i] || (startIndex + 1 < gas.Length && cost[startIndex] == gas[startIndex]))
            {
                startIndex++;
                if (startIndex < gas.Length) totalGas = gas[startIndex];
                i = startIndex; countTwiceCicruit = 1;
            }
            else
            {
                totalGas = totalGas - cost[i];
                i = (i + 1) % gas.Length;
                totalGas = totalGas + gas[i];
                countTwiceCicruit++;


            }
        }
        return -1;

    }
}