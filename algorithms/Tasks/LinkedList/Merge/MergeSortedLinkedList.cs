namespace Tasks.LinkedList.Merge;

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

public class MergeSortedLinkedList
{
    /*
     * Given the heads of two sorted linked lists
     * Merge two lists into one sorted linked list.
     * Return the head of the merged list
     */
    public static ListNode Run( ListNode head1, ListNode head2 )
    {
        ListNode? left = head1;
        ListNode? right = head2;

        ListNode res = new ListNode
        {
            Value = 0
        };

        ListNode? cur = res;
        while ( left != null && right != null )
        {
            int leftValue = left.Value;
            int rightValue = right.Value;
            if ( leftValue <= rightValue )
            {
                cur.Next = new ListNode
                {
                    Value = leftValue
                };
                cur = cur.Next;
                left = left.Next;
            }
            else
            {
                cur.Next = new ListNode
                {
                    Value = rightValue
                };
                cur = cur.Next;
                right = right.Next;
            }
        }

        while ( left != null )
        {
            cur.Next = new ListNode
            {
                Value = left.Value
            };
            cur = cur.Next;
            left = left.Next;
        }

        while ( right != null )
        {
            cur.Next = new ListNode
            {
                Value = right.Value
            };
            cur = cur.Next;
            right = right.Next;
        }
        return res.Next;
    }
}