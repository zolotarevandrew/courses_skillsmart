namespace Tasks.LinkedList.Reorder;

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

public class ReorderLinkedList
{
    /*
     * Given the head of singly linked list, reorder the nodes to alternate
     * between the start and end of the list, forming the following sequence
     * L0 -> LN -> L1 -> LN-1 -> L2 -> LN-2
     * You must only rearrange nodes 
     */
    public static ListNode Run( ListNode head )
    {
        if ( head?.Next?.Next == null ) return head;

        ListNode slowPrev = new ListNode
        {
            Value = 0
        };
        ListNode? slow = head;
        ListNode? fast = head;
        while ( fast is { Next: not null } )
        {
            slowPrev.Next = slow;
            slowPrev = slowPrev.Next;
            slow = slow?.Next;
            fast = fast.Next.Next;
        }

        slowPrev.Next = null;

        ListNode? reversed = null;
        ListNode? current = slow;
        while ( current != null )
        {
            ListNode? next = current.Next;
            current.Next = reversed;
            reversed = current;
            current = next;
        }

        ListNode? left = head;
        ListNode? right = reversed;
        ListNode? last = null;

        while ( left != null && right != null )
        {
            last = right;
            ListNode? leftNext = left.Next;
            ListNode? rightNext = right.Next;

            left.Next = right;
            right.Next = leftNext;
            
            left = leftNext;
            right = rightNext;
        }

        if ( right != null )
        {
            last.Next = right;
        }
        
        return head;
    }
}