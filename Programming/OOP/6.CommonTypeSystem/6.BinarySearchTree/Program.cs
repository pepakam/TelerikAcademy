using System;

class Program
{
    static void Main()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        for (int i = 1; i < 10; i+=2)
            tree.Add(i);

        Console.WriteLine(tree);
        
        Console.WriteLine((tree.Clone() as BinarySearchTree<int>) == tree);
    }
}