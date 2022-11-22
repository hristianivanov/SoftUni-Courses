namespace CollectionHierarchy
{
    using System;

    using CollectionHierarchy.Models;

    public class Program
    {
        static void Main(string[] args)
        {
            AddCollection add = new AddCollection();
            AddRemoveCollection addRemove = new AddRemoveCollection();
            MyList list = new MyList();

            string[] items = Console.ReadLine().Split();
            int removeCount = int.Parse(Console.ReadLine());

            foreach (string item in items)
                Console.Write(add.Add(item) + " ");
            Console.WriteLine();

            foreach (string item in items)
                Console.Write(addRemove.Add(item) + " ");
            Console.WriteLine();

            foreach (string item in items)
                Console.Write(list.Add(item) + " ");
            Console.WriteLine();

            for (int i = 0; i < removeCount; i++)
                Console.Write(addRemove.Remove() + " ");
            Console.WriteLine();

            for (int i = 0; i < removeCount; i++)
                Console.Write(list.Remove() + " ");
        }
    }
}
