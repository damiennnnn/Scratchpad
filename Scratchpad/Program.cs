// See https://aka.ms/new-console-template for more information

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

var prices = new int[] { 1,2,3,4,5};
var profit = maxProfit(prices);

Console.WriteLine(NthRoot(4,2,7, 20));

int maxProfit(int[] prices)
{
    int profit = 0;
    
    for (int i = 0; i < prices.Length; i++)
    {
        for (int j = i+1; j < prices.Length; j++)
        {
            if (prices[j] > prices[i])
            {
                profit += prices[j] - prices[i];
                i = j+1;
            }
            
        }
    }

    return profit;
}


double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    double result = 0;
    int len = nums1.Length + nums2.Length;
    int[] arr = new int[len];
    int i = 0;
    int j = 0;
    int k = 0;
    
    while (i < nums1.Length && j < nums2.Length)
    {
        if (nums1[i] < nums2[j])
            arr[k++] = nums1[i++];
        else
            arr[k++] = nums2[j++];
    }
    
    while (i < nums1.Length)
        arr[k++] = nums1[i++];

    while (j < nums2.Length)
        arr[k++] = nums2[j++];

    int halfLen = (int)Math.Ceiling(len / 2.0) - 1;
    if (len % 2 == 0)
    {
        result = (arr[halfLen] + arr[halfLen+1])/2.0;
    }
    else
    {
        result = arr[halfLen];
    }
    
    return result;
}

double NthRoot(double num, double n, double initialGuess, double iterations = 5)
{
    if (iterations == 0)
        return initialGuess;
    
    double result = ((n-1)/n * initialGuess) + (num/n)*(1/Math.Pow(initialGuess, n-1));
    Console.WriteLine(result);
    return NthRoot(num, n, result, --iterations);        
}


ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    int val = (l1?.val ?? 0) + (l2?.val ?? 0);
    int carry = val - 10;

    if (carry >= 0)
    {
        var target = l1?.next ?? l2?.next;
    
        if (target is not null)
        {
            target.val++;
        }
        else
        {
            if (l1 is { next : null })
                l1.next = new ListNode(1, null);
            else if (l2 is { next : null })
                l2.next = new ListNode(1, null);
        }
    }
    
    return (l1 is null && l2 is null) ? null :
        new ListNode((carry >= 0) ? carry : val, AddTwoNumbers(l1?.next, l2?.next));
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

