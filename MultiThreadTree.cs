using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatika
{
    class Program
    {
        public static void Main()
        {
            MultiThreadTree tree = new MultiThreadTree();
            Task[] tasks = new Task[5];
            for (int i = 0; i < tasks.Length; i++)
            {
                int baseValue = i * 10;
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < 5; j++)
                    {
                        tree.Add(j + baseValue);
                    }
                });
            }
            Task.WaitAll(tasks);
        }
    }
    class Node
    {
        public int Value;
        public Node Right;
        public Node Left;
        public readonly object NodeLock = new object();
    }
    class MultiThreadTree
    {
        private object AddLock = new object();
        private Node root;
        public void Add(int value)
        {
            lock(AddLock)
            {
                if (root == null)
                {
                    root = new Node { Value = value };
                    return;
                }
            }
            RekursiveAdd(root, value);
        }
        public void RekursiveAdd(Node current, int value)
        {
            lock(current.NodeLock)
            {
                if (value < current.Value)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node { Value = value };
                    }
                    else
                    {
                        RekursiveAdd(current.Left, value);
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node { Value = value };
                    }
                    else
                    {
                        RekursiveAdd(current.Right, value);
                    }
                }
            }
        }
    }
}
