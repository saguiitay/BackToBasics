using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees.Enumerators
{
    class InOrderEnumerator<T> : IEnumerator<Node<T>>
    {
        private readonly ITree<T> _tree;
        private Stack<Node<T>> _stack;

        public Node<T> Current => _stack.Peek();

        object IEnumerator.Current => Current;

        public InOrderEnumerator(ITree<T> tree)
        {
            _tree = tree;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            Node<T> node = null;
            if (_stack == null)
            {
                _stack = new Stack<Node<T>>();
                if (_tree?.Root != null)
                    node = _tree.Root;
            }
            else
            {
                node = _stack.Pop();
                node = node.Right;
            }
            if (node != null)
                PushLeft(node);
            return _stack.Count > 0;
        }

        private void PushLeft(Node<T> node)
        {
            do
            {
                _stack.Push(node);
                node = node.Left;
            } while (node != null);
        }

        public void Reset()
        {
            _stack = null;
        }
    }
}