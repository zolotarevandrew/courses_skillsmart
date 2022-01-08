using AlgorithmsDataStructures;

namespace LinkedList_1
{
    public static class Extensions
    {
        public static LinkedList SumElementsWith(this LinkedList list1, LinkedList list2)
        {
            if (list1.count != list2.count) return null;
            if (list1.count == 0) return list1;

            Node node1 = list1.head;
            Node node2 = list2.head;

            LinkedList res = new LinkedList();
            while (node1 != null)
            {
                res.AddInTail(new Node(node1.value + node2.value));
                node1 = node1.next;
                node2 = node2.next;
            }

            return res;
        }
    }
}