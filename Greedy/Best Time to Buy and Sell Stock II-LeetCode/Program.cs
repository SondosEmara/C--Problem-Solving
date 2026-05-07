class Program
{
    public static int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length == 1)
        {
            return 0;
        }
        

        int sellValue = -1;
        int buyValue = prices[0];

        for (int i = 1; i < prices.Length - 1; i++)
        {
            buyValue = Math.Min(buyValue, prices[i]);
            if (prices[i + 1] >= buyValue && prices[i + 1] >= sellValue)
            {
                sellValue = prices[i + 1];
            }
        }
        var profit = sellValue - buyValue;
        return (profit <= 0) ? 0 : profit;
    }


    static async Task Main()
    {

        var x = MaxProfit([7, 1, 5, 3, 6, 4]);
        Console.WriteLine(x);
    }

    static async Task MethodA()
    {
        Console.WriteLine($"MethodA START - Thread: {Thread.CurrentThread.ManagedThreadId}");

        await MethodB();

        Console.WriteLine($"MethodA AFTER await - Thread: {Thread.CurrentThread.ManagedThreadId}");
    }

    static async Task MethodB()
    {
        Console.WriteLine($"MethodB START - Thread: {Thread.CurrentThread.ManagedThreadId}");

        await SimulateIO();

        Console.WriteLine($"MethodB AFTER await - Thread: {Thread.CurrentThread.ManagedThreadId}");
    }

    static async Task SimulateIO()
    {
        Console.WriteLine($"SimulateIO START (before await) - Thread: {Thread.CurrentThread.ManagedThreadId}");

        await Task.Delay(2000); // 🔥 REAL async I/O simulation point

        Console.WriteLine($"SimulateIO AFTER await - Thread: {Thread.CurrentThread.ManagedThreadId}");
    }
}