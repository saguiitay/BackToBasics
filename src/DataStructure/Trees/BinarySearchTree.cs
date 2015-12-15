using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Node<T> _root;

        public virtual void Insert(T value)
        {
            InsertInternal(value, ref _root);
        }

        public bool Contains(T value)
        {
            for (Node<T> node = _root; node != null; node = value.CompareTo(node.Value) >= 0 ? node.Right : node.Left)
            {
                if (node.Value.Equals(value))
                    return true;
            }
            return false;
        }

        private void InsertInternal(T value, ref Node<T> node, Node<T> parent = null)
        {
            if (node == null)
                node = new Node<T>()
                    {
                        Value = value,
                        Parent = parent
                    };
            else if (value.CompareTo(node.Value) < 0)
            {
                Node<T> left = node.Left;
                InsertInternal(value, ref left, node);
                if (node.Left != null)
                    return;
                node.Left = left;
            }
            else
            {
                Node<T> right = node.Right;
                InsertInternal(value, ref right, node);
                if (node.Right != null)
                    return;
                node.Right = right;
            }
        }

        public IEnumerator<Node<T>> GetPreOrderEnumerator()
        {
            return new PreOrderEnumerator(this);
        }

        public class PreOrderEnumerator : IEnumerator<Node<T>>
        {
            private readonly BinarySearchTree<T> _tree;
            private Stack<Node<T>> _queue;

            public Node<T> Current => _queue.Peek();

            object IEnumerator.Current => Current;

            public PreOrderEnumerator(BinarySearchTree<T> tree)
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
                    _queue = new Stack<Node<T>>();
                    if (_tree?._root != null)
                        _queue.Push(_tree._root);
                }
                else
                {
                    Node<T> node = _queue.Pop();
                    if (node.Right != null)
                        _queue.Push(node.Right);
                    if (node.Left != null)
                        _queue.Push(node.Left);
                }
                return _queue.Count > 0;
            }

            public void Reset()
            {
                _queue = null;
            }
        }
    }
}