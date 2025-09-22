namespace Tasks.LinkedList.Reverse;

public class ListNode
{
    public int Value { get; set; }
    public ListNode? Next { get; set; }
}

public class ReverseLinkedList
{
    
    /*
     * Given a singly linked list reverse it in place and return the new head of a list
     */
    public static ListNode? Run( ListNode? head )
    {
        ListNode? prev = null;

        ListNode? current = head;
        while ( current != null )
        {
            ListNode? nextNode = current.Next;
            current.Next = prev;
            prev = current;
            current = nextNode;
        }
        
        return prev;
    }
}