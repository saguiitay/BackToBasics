using System;
using DataStructures;
using DataStructures.Trees;

namespace DataStructure.Tests
{
    class Program
    {
        static void Main()
        {
            MainTree();

            //MainBinaryTree();

            //MainSetAll();
        }


        static void MainSetAll()
        {
            var setAll = new DataStructures.SetAll.SetAll<int>(10);
            setAll[2] = 200;
            setAll[4] = 400;

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}: {1}", i, setAll[i]);

            setAll.SetAllValues(5);

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}: {1}", i, setAll[i]);

            setAll[6] = 600;
            setAll[8] = 800;

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}: {1}", i, setAll[i]);

            setAll.SetAllValues(-5);

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}: {1}", i, setAll[i]);

        }

        static void MainBinaryTree()
        {
            //var bst = new BinarySearchTree<int>();
            //bst.Insert(5);
            //bst.Insert(1);
            //bst.Insert(8);
            //bst.Insert(2);
            //bst.Insert(7);
            //bst.Insert(9);
            //bst.Insert(13);
            //bst.Insert(11);
            //bst.Insert(6);
            //bst.Insert(14);

            var bst = BinaBinarySearchTreeExtensions.FromString("5 1 2 8 6 7 9 13 11 14");

            //        5
            //      /  \
            //     1     8
            //    / \   / \
            //      2  6   9
            //          \   \
            //           7  13
            //             /  \
            //            11   14



            for (int i = 0; i < 15; i++)
                Console.WriteLine("Contains {0}: {1}", i, bst.Contains(i));

            Console.WriteLine();

            // Depth PreOrder: 5 1 2 8 6 7 9 13 11 14
            Console.WriteLine("PreOrder: ");
            var preOrder = bst.GetPreOrderEnumerator();
            while (preOrder.MoveNext())
                Console.Write(" {0} ", preOrder.Current.Value);

            Console.WriteLine();
            Console.WriteLine();

            // Depth InOrder: 1 2 5 6 7 8 9 11 13 14
            Console.WriteLine("InOrder: ");
            var inOrder = bst.GetInOrderEnumerator();
            while (inOrder.MoveNext())
                Console.Write(" {0} ", inOrder.Current.Value);

            Console.WriteLine();
            Console.WriteLine();

            // Depth LevelOrder: 5 1 8 2 6 9 7 13 11 14
            Console.WriteLine("LevelOrder: ");
            var levelOrder = bst.GetLevelOrderEnumerator();
            while (levelOrder.MoveNext())
                Console.Write(" {0} ", levelOrder.Current.Value);

        }

        static void MainTree()
        {
            var tree = new BinaryTree<int>();
            tree.Root = new Node<int> { Value = 1};

            var node2 = tree.Root.Left = new Node<int>(2);
            var node3 = tree.Root.Right = new Node<int>(3);

            var node4 = node2.Left = new Node<int>(4);
            var node5 = node2.Right = new Node<int>(5);

            var node6 = node4.Right = new Node<int>(6);
            var node7 = node4.Left = new Node<int>(7);

            var node0 = node3.Right = new Node<int>(0);
            var node8 = node0.Left = new Node<int>(8);

            //        1
            //      /  \
            //     2     3
            //    / \     \
            //   4   5     0
            //  / \       /
            // 7   6     8


            for (int i = 0; i < 12; i++)
                Console.WriteLine("Contains {0}: {1}", i, tree.FindNode(i) != null);

            Console.WriteLine();

            // Depth PreOrder: 1 2 4 7 6 5 3 0 8
            Console.WriteLine("PreOrder: ");
            var preOrder = tree.GetPreOrderEnumerator();
            while (preOrder.MoveNext())
                Console.Write(" {0} ", preOrder.Current.Value);

            Console.WriteLine();
            Console.WriteLine();

            // Depth InOrder: 7 4 6 2 5 1 3 8 0
            Console.WriteLine("InOrder: ");
            var inOrder = tree.GetInOrderEnumerator();
            while (inOrder.MoveNext())
                Console.Write(" {0} ", inOrder.Current.Value);

            Console.WriteLine();
            Console.WriteLine();

            // Depth LevelOrder: 1 2 3 4 5 0 7 6 8
            Console.WriteLine("LevelOrder: ");
            var levelOrder = tree.GetLevelOrderEnumerator();
            while (levelOrder.MoveNext())
                Console.Write(" {0} ", levelOrder.Current.Value);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("String representation: ");
            var str = BinaryTreeStringSerializer.AsString(tree);
            Console.WriteLine(str);

            var loadedTree = BinaryTreeStringSerializer.FromString(str);
            Console.WriteLine(BinaryTreeStringSerializer.AsString(loadedTree));

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("String representation Compact: ");
            var strCompact = BinaryTreeStringSerializer.AsStringCompact(tree);
            Console.WriteLine(strCompact);

            var loadedTreeCompact = BinaryTreeStringSerializer.FromStringCompact(strCompact);
            Console.WriteLine(BinaryTreeStringSerializer.AsStringCompact(loadedTreeCompact));
            Console.WriteLine(BinaryTreeStringSerializer.AsString(loadedTreeCompact));

            Console.ReadLine();
        }
    }
}
