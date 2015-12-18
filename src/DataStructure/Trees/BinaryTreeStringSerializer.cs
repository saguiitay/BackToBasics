using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DataStructures.Trees
{
    public static class BinaryTreeStringSerializer
    {
        public static string AsString<T>(BinaryTree<T> tree)
        {
            StringBuilder sb = new StringBuilder();
            
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(tree.Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    sb.Append(node.Value + " ");

                    queue.Enqueue(node.Left);
                    queue.Enqueue(node.Right);
                }
                else
                    sb.Append("* ");
            }

            return sb.ToString();
        }

        public static string AsStringCompact<T>(BinaryTree<T> tree) where T : IComparable
        {
            StringBuilder sb = new StringBuilder();

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(tree.Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    sb.Append(node.Value);
                    if (node.Left == null && node.Right == null)
                    {
                        sb.Append("' ");
                    }
                    else
                    {
                        sb.Append(" ");
                        queue.Enqueue(node.Left);
                        queue.Enqueue(node.Right);
                    }
                }
                else
                    sb.Append("* ");
            }

            return sb.ToString().TrimEnd(' ', '*');
        }

        public static BinaryTree<int> FromString(string str)
        {
            var values = str.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            var tree = new BinaryTree<int>();

            if (!values.Any())
                return tree;

            int index = 0;
            var root = tree.Root = new Node<int>(int.Parse(values[index++]));

            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                var left = values[index++];

                if (left != "*")
                {
                    var leftNode = node.Left = new Node<int>(int.Parse(left));
                    queue.Enqueue(leftNode);
                }

                var right = values[index++];
                if (right != "*")
                {
                    var rightNode = node.Right = new Node<int>(int.Parse(right));
                    queue.Enqueue(rightNode);
                }
            }

            return tree;
        }

        public static BinaryTree<int> FromStringCompact(string str)
        {
            var values = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var tree = new BinaryTree<int>();

            if (!values.Any())
                return tree;

            int index = 0;
            var root = tree.Root = new Node<int>(int.Parse(values[index++]));

            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (index < values.Length)
                {
                    var left = values[index++];
                    if (left != "*")
                    {
                        var leftNode = node.Left = new Node<int>(int.Parse(left.TrimEnd('\'')));
                        if (!left.EndsWith("'"))
                            queue.Enqueue(leftNode);
                    }
                }

                if (index < values.Length)
                {
                    var right = values[index++];
                    if (right != "*")
                    {
                        var rightNode = node.Right = new Node<int>(int.Parse(right.TrimEnd('\'')));
                        if (!right.EndsWith("'"))
                            queue.Enqueue(rightNode);
                    }
                }
            }

            return tree;
        }

        public static BinaryTree<T> Reconstruct<T>(T[] preoder, T[] inorder)
        {
            var root = ReconstructNodes(new ArraySegment<T>(preoder), new ArraySegment<T>(inorder));
            return new BinaryTree<T> {Root = root};
        }

        private static Node<T> ReconstructNodes<T>(ArraySegment<T> preoder, ArraySegment<T> inorder)
        {
            if (preoder.Count == 0)
                return null;

            var root = new Node<T>(preoder.First());
            if (preoder.Count == 1)
                return root;

            var indexOfRoot = Array.IndexOf(inorder.Array, preoder.First(), inorder.Offset) - inorder.Offset;


            var leftInorder = new ArraySegment<T>(inorder.Array, inorder.Offset, indexOfRoot);
            var rightInorder = new ArraySegment<T>(inorder.Array, inorder.Offset+indexOfRoot + 1, inorder.Count - indexOfRoot - 1);

            var leftPreorder = new ArraySegment<T>(preoder.Array, preoder.Offset+1, leftInorder.Count);
            var rightPreorder = new ArraySegment<T>(preoder.Array, preoder.Offset + 1 + leftInorder.Count, rightInorder.Count);

            root.Left = ReconstructNodes(leftPreorder, leftInorder);
            root.Right = ReconstructNodes(rightPreorder, rightInorder);

            return root;
        }
    }
}