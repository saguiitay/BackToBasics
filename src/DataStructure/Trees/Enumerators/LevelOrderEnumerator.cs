using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees.Enumerators
{
    class LevelOrderEnumerator<T> : IEnumerator<Node<T>>
    {
        private readonly ITree<T> _tree;
        private Queue<Node<T>> _queue;

        public Node<T> Current => _queue.Peek();

        object IEnumerator.Current => Current;

        public LevelOrderEnumerator(ITree<T> tree)
        {
            _tree = tree;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_queue == null)
            {
                _queue = new Queue<Node<T>>();
                if (_tree?.Root != null)
                    _queue.Enqueue(_tree.Root);
            }
            else
            {
                Node<T> node = _queue.Dequeue();
                if (node.Left != null)
                    _queue.Enqueue(node.Left);
                if (node.Right != null)
                    _queue.Enqueue(node.Right);
            }
            return _queue.Count > 0;
        }

        public void Reset()
        {
            _queue = null;
        }
    }
}