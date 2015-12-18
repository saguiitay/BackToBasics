namespace DataStructures.Trees
{
    public class Node<T>
    {
        private Node<T> _left;
        private Node<T> _right;

        public Node()
        { }

        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public Node<T> Left
        {
            get { return _left; }
            set
            {
                _left = value;
                if (_left != null)
                    _left.Parent = this;
            }
        }

        public Node<T> Right
        {
            get { return _right; }
            set
            {
                _right = value;
                if (_right != null)
                    _right.Parent = this;
            }
        }
    }
}
