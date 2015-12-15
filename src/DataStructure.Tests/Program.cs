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

        static void MainTree()
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
    }
}
