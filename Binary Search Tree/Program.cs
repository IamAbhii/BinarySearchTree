using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            root.right.left.right = new Node(8);

            int sum = BinaryTreeSum(root);
            Console.WriteLine("Sum of all the elements is: " + sum);

            calculationTree tree = new calculationTree();
            tree.root = new Node(26);
            tree.root.left = new Node(10);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(6);
            tree.root.right.right = new Node(3);

            if (tree.isSumTree(tree.root) != 0)
                Console.WriteLine("The given tree is a calculation tree");
            else
                Console.WriteLine("The given tree is not a calculation tree");

            Queue(root);
            Console.ReadLine();
        }
        public class Node
        {
            public int data { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int item)
            {
                data = item;
                left = null;
                right = null;
            }
        }


        public static int BinaryTreeSum(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            return (root.data + BinaryTreeSum(root.left) + BinaryTreeSum(root.right));
        }

        class calculationTree
        {
            public Node root;
            public int isSumTree(Node node)
            {
                int leftSide, rightSide;

                if ((node == null) || (node.left == null && node.right == null))
                    return 1;

                leftSide = BinaryTreeSum(node.left);
                rightSide = BinaryTreeSum(node.right);
                //checking the tree node with sum of leaf elements
                if ((node.data == leftSide + rightSide) && (isSumTree(node.left) != 0)
                        && (isSumTree(node.right)) != 0)
                    return 1;

                return 0;
            }

        }

        public static void Queue(Node node)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                Node CusrrentNode = queue.Dequeue();
                Console.WriteLine("Current Node:{0}",CusrrentNode.data);
                if (CusrrentNode.left != null)
                {
                    queue.Enqueue(CusrrentNode.left);
                }
                if (CusrrentNode.left != null)
                {
                    queue.Enqueue(CusrrentNode.right);
                }
            }
        }
    }
    
}
