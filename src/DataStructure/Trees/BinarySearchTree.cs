using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Node<T> _root;
        private int _count;

        public int Count => _count;

        public bool Contains(T value)
        {
            for (Node<T> node = _root; node != null; node = value.CompareTo(node.Value) >= 0 ? node.Right : node.Left)
            {
                if (node.Value.Equals(value))
                    return true;
            }
            return false;
        }


        public virtual void InsertRecursive(T value)
        {
            InsertInternal(value, ref _root);
        }

        
        public void Insert(T value)
        {
            Node<T> parentNode = null;
            for (Node<T> node = _root; node != null; parentNode = node, node = value.CompareTo(node.Value) >= 0 ? node.Right : node.Left)
            {
                if (node.Value.Equals(value))
                    return;
            }
            var newNode = new Node<T> {Value = value, Parent = parentNode};
            if (parentNode != null)
            {
                if (value.CompareTo(parentNode.Value) >= 0)
                    parentNode.Right = newNode;
                else
                    parentNode.Left = newNode;
            }
            else
                _root = newNode;
        }

        private void InsertInternal(T value, ref Node<T> node, Node<T> parent = null)
        {
            if (node == null)
            {
                _count++;
                node = new Node<T>
                    {
                        Value = value,
                        Parent = parent
                    };
            }
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

        public IEnumerator<Node<T>> GetInOrderEnumerator()
        {
            return new InOrderEnumerator(this);
        }

        public IEnumerator<Node<T>> GetLevelOrderEnumerator()
        {
            return new LevelOrderEnumerator(this);
        }

        private class PreOrderEnumerator : IEnumerator<Node<T>>
        {
            private readonly BinarySearchTree<T> _tree;
            private Stack<Node<T>> _stack;

            public Node<T> Current => _stack.Peek();

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
                if (_stack == null)
                {
                    _stack = new Stack<Node<T>>();
                    if (_tree?._root != null)
                        _stack.Push(_tree._root);
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


        private class InOrderEnumerator : IEnumerator<Node<T>>
        {
            private readonly BinarySearchTree<T> _tree;
            private Stack<Node<T>> _stack;

            public Node<T> Current => _stack.Peek();

            object IEnumerator.Current => Current;

            public InOrderEnumerator(BinarySearchTree<T> tree)
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
                    if (_tree?._root != null)
                        node = _tree._root;
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

        private class LevelOrderEnumerator : IEnumerator<Node<T>>
        {
            private readonly BinarySearchTree<T> _tree;
            private Queue<Node<T>> _queue;

            public Node<T> Current => _queue.Peek();

            object IEnumerator.Current => Current;

            public LevelOrderEnumerator(BinarySearchTree<T> tree)
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
                    if (_tree?._root != null)
                        _queue.Enqueue(_tree._root);
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

    public static class BinaBinarySearchTreeExtensions
    {
        public static BinarySearchTree<int> FromString(string data)
        {
            var bst = new BinarySearchTree<int>();
            var values = data.Split(' ').Select(x => int.Parse(x));
            foreach (var value in values)
                bst.Insert(value);

            return bst;
        }
    }
}