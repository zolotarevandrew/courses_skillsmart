namespace Tasks.LinkedList.Sort;

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

public class SortLinkedList
{
    /*
     * Arrange the elements of a linked list in ascending order by applying sort such as merge sort
     */
    public static ListNode Run( ListNode? list )
    {
        if ( list?.Next == null ) return list;

        (ListNode beforeMid, ListNode afterMid) = Split( list! );

        ListNode left = Run( beforeMid );
        ListNode right = Run( afterMid );

        return Merge( left, right );
    }
    
    public static (ListNode beforeMid, ListNode AfterMid) Split( ListNode list )
    {
        ListNode slow = list;
        ListNode? fast = list.Next;

        while ( fast is { Next: not null } )
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        ListNode? next = slow.Next;
        slow.Next = null;

        return ( list, next );
    }

    public static ListNode Merge( ListNode left, ListNode right )
    {
        ListNode res = new ListNode
        {
            Value = 0
        };

        ListNode cur = res;
        while ( left != null && right != null )
        {
            if ( left.Value <= right.Value )
            {
                cur.Next = left;
                left = left.Next;
            }
            else
            {
                cur.Next = right;
                right = right.Next;
            }
            cur = cur.Next;
        }

        cur.Next = left ?? right;
        
        return res.Next;
    }
}