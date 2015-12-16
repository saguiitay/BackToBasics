using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees.Enumerators
{
    class PreOrderEnumerator<T> : IEnumerator<Node<T>>
    {
        private readonly ITree<T> _tree;
        private Stack<Node<T>> _stack;

        public Node<T> Current => _stack.Peek();

        object IEnumerator.Current => Current;

        public PreOrderEnumerator(ITree<T> tree)
        {
            _tree = tree;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_stack == null)
            {
                _stack = new Stack<Node<T>>();
                if (_tree?.Root != null)
                    _stack.Push(_tree.Root);
            }
            else
            {
                Node<T> node = _stack.Pop();
                if (node.Right != null)
                    _stack.Push(node.Right);
                if (node.Left != null)
                    _stack.Push(node.Left);
            }
            return _stack.Count > 0;
        }

        public void Reset()
        {
            _stack = null;
        }
    }
}