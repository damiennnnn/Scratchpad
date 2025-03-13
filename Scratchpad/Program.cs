// See https://aka.ms/new-console-template for more information

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

using Scratchpad.Maths;

var prices = new int[] { 1,2,3,4,5};
var profit = maxProfit(prices);

Console.WriteLine(Root.NthRoot(50000, 2));

var list4 = FourSum([2,2,2,2,2], 8);
Console.WriteLine();

IList<IList<int>> FourSum(int[] nums, int target)
{
    var result = new List<IList<int>>();
    Array.Sort(nums);
    
    // Avoid edge cases where calculation of sum results in int overflow 
    var longs = nums.Select(i => (long)i).ToArray();
    
    for (int h = 0; h < longs.Length - 3; h++)
    {
        if (h > 0 && longs[h] == longs[h - 1]) continue;

        // Early termination; if the first 4 sorted nums are already bigger than target, end now.
        if (longs[h] + longs[h + 1] + longs[h + 2] + longs[h + 3] > target) break;
        
        // Early termination; if the largest possible sum is below target, continue.
        if (longs[h] + longs[^3] + longs[^2] + longs[^1] < target) continue;

        for (int i = h + 1; i < longs.Length - 2; i++)
        {
            if (i > h + 1 && longs[i] == longs[i - 1]) continue;

            // Early termination; if the first 4 sorted nums are already bigger than target, end now.
            if (longs[h] + longs[i] + longs[i + 1] + longs[i + 2] > target) break;
            
            // Early termination; if the largest possible sum is below target, continue.
            if (longs[h] + longs[i] + longs[^2] + longs[^1] < target) continue;

            int l = i + 1;
            int r = longs.Length - 1;

            while (l < r)
            {
                long sum = longs[h] + longs[i] + longs[l] + longs[r];

                if (sum == target)
                {
                    result.Add(new List<int> { (int)longs[h], (int)longs[i], (int)longs[l], (int)longs[r] });

                    while (l < r && longs[l] == longs[l + 1]) l++;
                    while (l < r && longs[r] == longs[r - 1]) r--;

                    l++;
                    r--;
                }
                else if (sum < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
        }
    }

    return result;
}

List<List<int>> ThreeSum(int[] nums, int target)
{
    var result = new List<List<int>>();
    Array.Sort(nums);

    for (int i = 0; i < nums.Length - 2; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1]) continue;

        int l = i + 1;
        int r = nums.Length - 1;

        while (l < r)
        {
            long sum = (long)nums[i] + (long)nums[l] + (long)nums[r];

            if (sum == target)
            {
                result.Add(new List<int> { nums[i], nums[l], nums[r] });
                
                while (l < r && nums[l] == nums[l + 1]) l++;
                while (l < r && nums[r] == nums[r - 1]) r--;
                
                l++;
                r--;
            }
            else if (sum < target)
            {
                l++;
            }
            else
            {
                r--;
            }
        }
    }

    return result;
}
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

