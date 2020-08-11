namespace Algorithms_and_Data_Structures
{
    public class MySinglyLinkedListNode<T>
    {
        public MySinglyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public MySinglyLinkedListNode<T> Next { get; set; }

        public T Value { get; set; }
    }
}