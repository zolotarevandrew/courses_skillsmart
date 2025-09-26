using System.Net.NetworkInformation;

namespace Tasks.LinkedList.Palindrome;

public class ListNode
{
    public int Value { get; set; }
    public ListNode? Next { get; set; }
}

public class PalindromeLinkedList
{
    /*
     * Determine whether a singly linked list is symmetrical, meaning that its elements
     * form the same sequence when read in reverse order as they do from start to finish
     */
    public static bool Run( ListNode? head )
    {
        if ( head?.Next == null ) return false;
        

        ListNode? slow = head;
        ListNode? fast = head;
        while ( fast is { Next: not null } )
        {
            slow = slow?.Next; 
            fast = fast.Next.Next;
        }

        ListNode? current = slow;
        ListNode? prev = null;
        while ( current != null )
        {
            ListNode? next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        ListNode? first_half = head;
        ListNode? second_half = prev;

        while ( second_half != null )
        {
            if ( first_half?.Value != second_half.Value ) return false;
            second_half = second_half.Next;
            first_half = first_half?.Next;
        }
        
        return true;
    }
}