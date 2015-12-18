namespace DataStructures.LinkedList
{
    public class DoubleLinkNode<T>
    {

        public DoubleLinkNode()
        { }

        public DoubleLinkNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public SingleLinkNode<T> Next { get; set; }
        public SingleLinkNode<T> Prev { get; set; }
    }
}