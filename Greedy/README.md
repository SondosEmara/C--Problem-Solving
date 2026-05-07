# 📈 Best Time to Buy and Sell Stock II
> **LeetCode #122** · Greedy · C#

---

## 🧩 Problem Statement

You are given an integer array `prices` where `prices[i]` is the price of a given stock on day `i`.

On each day, you may decide to **buy and/or sell** the stock. You can only hold **at most one share** at a time, but you may buy and sell on the **same day**.

Return the **maximum profit** you can achieve.

**Example:**
```
Input:  prices = [7, 1, 5, 3, 6, 4]
Output: 7
Explanation: Buy on day 2 (price=1), sell on day 3 (price=5) → profit = 4
             Buy on day 4 (price=3), sell on day 5 (price=6) → profit = 3
             Total profit = 7
```

---

## 💡 The Greedy Idea

> **"Capture every upward slope."**

Instead of trying to find the perfect buy/sell windows, the greedy insight is simple:

> If tomorrow's price is **higher than today's**, buy today and sell tomorrow — collect that profit.

This works because:
- Every peak can be decomposed into a sum of consecutive daily gains.
- `Peak − Valley = (Day2−Day1) + (Day3−Day2) + ... + (DayN−Day(N-1))`
- We just grab every positive difference.

```
prices = [1, 5, 3, 6]

          5           6
         /           /
        /     3     /
       /     /     /
      1     /     /

  +4 ✅  -2 ❌  +3 ✅  → Total profit = 7
```

---

## 💻 C# Solution

```csharp
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int totalProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            // Greedy: grab every positive daily gain
            if (prices[i] > prices[i - 1])
            {
                totalProfit += prices[i] - prices[i - 1];
            }
        }

        return totalProfit;
    }
}
```

### Complexity

| | |
|---|---|
| ⏱ **Time** | O(n) — single pass through the array |
| 🧠 **Space** | O(1) — no extra data structures |

---

## 🏢 Business Case: Stock Trading & Profit Maximization

This algorithm mirrors a real-world **active trading strategy** used in financial systems.

### Scenario: Algorithmic Day Trading Engine

Imagine you are a **quantitative analyst** building an automated trading bot for a brokerage firm.

| Real-World Concept | Algorithm Equivalent |
|---|---|
| Daily stock price feed | `prices[]` array |
| Deciding when to buy | `prices[i-1]` (yesterday's price) |
| Deciding when to sell | `prices[i]` (today's price) |
| Locking in a gain | `totalProfit += prices[i] - prices[i-1]` |
| Ignoring losing days | `if (prices[i] > prices[i-1])` guard |

### Why Greedy Works in Business

In an **ideal frictionless market** (no transaction fees, no slippage), the greedy strategy is **mathematically optimal** because:

1. **Every profitable micro-movement is captured** — no gains are left on the table.
2. **No prediction is needed** — you only look at the next day, not the entire future.
3. **Risk is minimized** — you never hold a position through a down day.

```
Real profit decomposition:

Buy at 1 → Sell at 5  =  +4   ✅ greedy captures this
Buy at 3 → Sell at 6  =  +3   ✅ greedy captures this
─────────────────────────────
Total                 =   7   🎯 Maximum possible
```

---

## 🔗 Greedy Pattern Connection

This problem is a classic example of the **"Local Optimum → Global Optimum"** greedy property:

```
Greedy Property Check ✅
─────────────────────────────────────────────────────
Local decision:   "Take profit if tomorrow > today"
Global result:    Maximum total profit over all days
Proof:            Any skipped positive gain reduces total
                  Any captured negative gain reduces total
                  → Only capturing positives is optimal
```

