// Создание класса для узла дерева
class Node
{
    public int data;
   
    public Node left, right;
    public int otric { get; set; }
    public Node(int item)
    {
        data = item;
        left = right = null;
       
    }
}
// Создание класса для дерева поиска
class BinarySearchTree
{
    Node root;
    public BinarySearchTree()
    {
        root = null;
    }
    // Метод для добавления узла в дерево
    public void Insert(int data)
    {
        root = InsertRec(root, data);
        
    }
    // Рекурсивный метод для добавления узла в дерево
    private Node InsertRec(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }
        if (data < root.data)
            root.left = InsertRec(root.left, data);
        else if (data > root.data)
            root.right = InsertRec(root.right, data);
        return root;
    }
    // Метод для подсчета суммы значений информационных полей дерева
    public int Sum()
    {
        return SumRec(root);
    }
    // Рекурсивный метод для подсчета суммы значений информационных полей дерева
    private int SumRec(Node root)
    {
        if (root == null)
            return 0;
        return root.data + SumRec(root.left) + SumRec(root.right);
    }
    // Метод для подсчета количества внутренних узлов дерева
    public int CountInternalNodes()
    {
        return CountInternalNodesRec(root);
    }
    // Рекурсивный метод для подсчета количества внутренних узлов дерева
    private int CountInternalNodesRec(Node root)
    {
        if (root == null)
            return 0;
        if (root.left == null && root.right == null)
            return 0;
        return 1 + CountInternalNodesRec(root.left) + CountInternalNodesRec(root.right);
    }
    // Метод для копирования отрицательных значений информационных полей дерева в линейную структуру
    public List<int> CopyNegativeValues()
    {
        List<int> result = new List<int>();
        CopyNegativeValuesRec(root, result);
        return result;
    }
    // Рекурсивный метод для копирования отрицательных значений информационных полей дерева в линейную структуру
    private void CopyNegativeValuesRec(Node root, List<int> result)
    {
        if (root == null)
            return;
        if (root.data < 0)
            result.Add(root.data);
        CopyNegativeValuesRec(root.left, result);
        CopyNegativeValuesRec(root.right, result);
    }
}
// Пример использования класса BinarySearchTree
class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();
        BinarySearchTree bste = new BinarySearchTree();
        // Генерация значений дерева с помощью рандома
        Random random = new Random();
        Console.WriteLine("Первое и второе задание:\n");
        for (int i = 0; i < 10; i++)
        {
            int value = random.Next(10, 1001);
            bst.Insert(value);
            Console.WriteLine("Значение {0} узла дерева = {1}",i,value);
        }
        // Подсчет суммы значений информационных полей дерева
        int sum = bst.Sum();
        Console.WriteLine("Сумма значений информационных полей дерева: " + sum);
        // Подсчет количества внутренних узлов дерева
        int count = bst.CountInternalNodes();
        Console.WriteLine("Количество внутренних узлов дерева: " + count);

        Console.WriteLine("\nТретье задание:\n");
        for (int i = 0; i < 10; i++)
        {
            int value = random.Next(-1000, 1001);
            bste.Insert(value);
            Console.WriteLine("Значение {0} узла дерева = {1}", i, value);
        }
        Console.WriteLine("Отрицательные значения информационных полей дерева:");
        List<int> a = bste.CopyNegativeValues();
        for (int i = 0; i < a.Count; i++)
        {
            Console.WriteLine(a[i]);
        }
    }
}
// Копирование отрицательных значений информационных полей дерева в лин