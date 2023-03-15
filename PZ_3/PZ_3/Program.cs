using System;
namespace PZ_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int posCount = 0, negCount = 0;
            float sr = 0;
            tree.Insert(-1); // Вставка узлов в дерево
            tree.Insert(2); // Вставка узлов в дерево
            tree.Insert(3); // Вставка узлов в дерево
            tree.Insert(-4); // Вставка узлов в дерево
            tree.Insert(-5); // Вставка узлов в дерево
            tree.Insert(-6); // Вставка узлов в дерево
            tree.Insert(7); // Вставка узлов в дерево
            tree.Insert(8); // Вставка узлов в дерево


            Console.WriteLine("Дерево:");
            tree.PrintTree();
            Console.WriteLine();
            tree.CountPosNegNodes(tree.root, ref posCount, ref negCount, ref sr);
            Console.WriteLine("Среднее арифметическое значений полей узлов дерева: {0} (1 задание)", sr);
            Console.WriteLine("Количество узлов с положительными значениями: {0} (2 задание)", posCount);
            Console.WriteLine("Количество узлов с отрицательными значениями: {0} (2 задание)", negCount);
            Console.WriteLine("Количество узлов со всеми значениями: {0} (3 задание)", posCount+negCount);

            Console.ReadKey();
        }
    }

    public class TreeNode
    {
        public int data; 
        public TreeNode left, right; 

        
        public TreeNode(int item)
        {
            data = item;
            left = right = null;
        }
    }

    
    public class BinaryTree
    {
        public TreeNode root;
     
        public BinaryTree()
        {
            root = null;
        }

       
        public virtual void Insert(int data)
        {
            root = InsertRecursive(root, data);
        }

        
        public TreeNode InsertRecursive(TreeNode current, int data)
        {
           
            if (current == null)
            {
                current = new TreeNode(data);
                return current;
            }
            
            if (data < current.data)
            {
                current.left = InsertRecursive(current.left, data);
            }
           
            else
            {
                current.right = InsertRecursive(current.right, data);
            }
            return current;
        }

        
        public void CountPosNegNodes(TreeNode node, ref int posCount, ref int negCount, ref float sr)
        {
            if (node == null)
                return;

            // Если узел имеет положительное значение, увеличить счетчик положительных узлов
            if (node.data > 0)
                posCount++;

            // Если узел имеет отрицательное значение, увеличить счетчик отрицательных узлов
            else if (node.data < 0)
                negCount++;
            sr = (sr+ node.data)/2;
          
            CountPosNegNodes(node.left, ref posCount, ref negCount, ref sr);
            CountPosNegNodes(node.right, ref posCount, ref negCount, ref sr);
        }

        
        public void PrintTree()
        {
            PrintTreeRecursive(root);
        }

       
        private void PrintTreeRecursive(TreeNode node)
        {
            if (node == null)
                return;

           
            Console.Write(node.data + " ");

            // Рекурсивно вывести левое и правое поддеревья
            PrintTreeRecursive(node.left);
            PrintTreeRecursive(node.right);
        }
    }

   
}