namespace Tasks.LinkedList.AddTwoNumbers;

public class ListNode
{
    public int Value { get; set; }
    public ListNode? Next { get; set; }

    public List<int> AsArray()
    {
        var res = new List<int>();
        var curr = this;
        while (curr != null)
        {
            res.Add(curr.Value);
            curr = curr.Next;
        }
        return res;
    }
}

public class AddTwoNumbersLinkedList
{
    /*
     * Given two not empty linked lists, where each represents non negative integer.
     * The digits of the numbers stored in reverse order, with each node containing a single digit.
     * Add the two numbers and return result as a linked list
     */
    public static ListNode Run( ListNode first, ListNode second )
    {
        ListNode result = new ListNode
        {
            Value = 0
        };
        
        ListNode? curFirst = first;
        ListNode? curSecond = second;
        ListNode curResult = result;
        int carry = 0;
        while ( curFirst != null || curSecond != null || carry != 0 )
        {
            int val1 = curFirst?.Value ?? 0;
            int val2 = curSecond?.Value ?? 0;
            int total = val1 + val2 + carry;
            
            curResult.Next = new ListNode
            {
                Value = total % 10
            };
            carry = total / 10;
            curResult = curResult.Next;
            curFirst = curFirst?.Next;
            curSecond = curSecond?.Next;
        }

        return result.Next;
    }
}