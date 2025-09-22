namespace Tasks.LinkedList.Remove;

public class ListNode
{
    public int Value { get; set; }
    public ListNode? Next { get; set; }
}

public class RemoveLinkedList
{
    /*
     * Given a head of a linked list, remove the n-th node from the end of the list and return the modified list
     */
    public static ListNode? Run( ListNode? head, int n )
    {
        if ( head == null ) return null;
        if ( n <= 0 ) throw new ArgumentOutOfRangeException( "n" );
        
        ListNode? current = head;
        int length = 0;
        while ( current != null )
        {
            current = current.Next;
            length++;
        }

        if ( n > length ) throw new ArgumentOutOfRangeException( nameof(n), "n greater than list length." );
        
        current = head;
        int curIndex = 0;
        int neededIndex = length - n;

        ListNode? toDelete = null;
        ListNode? toDeletePrev = null;
        while ( current != null )
        {
            if ( neededIndex == curIndex )
            {
                toDelete = current;
                break;
            }
            
            toDeletePrev = current;
            current = current.Next;
            curIndex++;
        }

        if ( toDelete != null )
        {
            // тогда мы в голове
            if ( toDeletePrev == null )
            {
                return toDelete.Next;
            }
            
            //если мы в середине
            ListNode? toDeleteNext = toDelete.Next;
            toDelete.Next = null;
            toDeletePrev.Next = toDeleteNext;
            return head;
        }
        
        return null;
    }
    
    public static ListNode? RunV2( ListNode? head, int n )
    {
        if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n));
        
        ListNode dummy = new ListNode
        {
            Value = 0,
            Next = head
        };

        ListNode? first = dummy;
        ListNode? second = dummy;

        for ( int i = 0; i < n + 1; i++ )
        {
            first = first?.Next;
        }

        while ( first != null )
        {
            first = first?.Next;
            second = second?.Next;
        }

        second.Next = second.Next?.Next;
        
        return dummy.Next;
    }
}