namespace Tasks.LinkedList.OddEven;

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

public class OddEvenLinkedList
{
    /*
     * Reorganize a linked list by placing all nodes located at odd indices
     * first, followed, by nodes at even indices, while preserving the relative sequence of both groups
     */
    public static ListNode Run( ListNode head )
    {
        ListNode odd = new ListNode
        {
            Value = 0
        };
        ListNode even = new ListNode
        {
            Value = 0
        };

        ListNode? current = head;
        int idx = 0;
        
        ListNode? oddStart = odd;
        ListNode? evenStart = even;
        while ( current != null )
        {
            ListNode? next = current.Next;
            bool isEven = idx % 2 == 0;
            current.Next = null;
            if ( isEven )
            {
                oddStart.Next = current;
                oddStart = oddStart.Next;
            }
            else
            {
                evenStart.Next = current;
                evenStart = evenStart.Next;
            }
            current = next;
            idx++;
        }

        oddStart.Next = even.Next;
        
        return odd.Next;
    }
    
    public static ListNode? RunV2( ListNode head )
    {
        if ( head?.Next == null ) return head;
        
        ListNode? odd = head;
        ListNode? even = head.Next;
        ListNode? evenStart = even;
        
        while ( even is { Next: not null } )
        {
            odd.Next = even.Next;
            odd = odd.Next;
            
            even.Next = odd.Next;
            even = even.Next;
        }

        odd.Next = evenStart;

        return head;
    }
}