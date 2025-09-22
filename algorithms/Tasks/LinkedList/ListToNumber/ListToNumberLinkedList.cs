namespace Tasks.LinkedList.ListToNumber;

public class ListNode
{
    public int Value { get; set; }
    public ListNode? Next { get; set; }
}

public class ListToNumberLinkedList
{
    /*
     * Convert a singly linked list,
     * Where each node contains a number in a reverse order, into  the integer value in represents.
     */
    public static int Run( ListNode? head )
    {
        int res = 0;
        int pow = 1;
        ListNode? current = head;
        while ( current != null )
        {
            res += current.Value * pow;
            pow *= 10;
            
            current = current.Next;
        }
        
        return res;
    }
}