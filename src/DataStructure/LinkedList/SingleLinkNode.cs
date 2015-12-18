namespace DataStructures.LinkedList
{
    public class SingleLinkNode<T>
    {

        public SingleLinkNode()
        { }

        public SingleLinkNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public SingleLinkNode<T> Next { get; set; }
    }
}
