namespace Week12Assignment12._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1");
            LinkedList list = new LinkedList();

            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(6);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);

            Console.WriteLine("Current List:");
            list.Display();

            Console.WriteLine("\nRemoving 6:");
            list.RemoveValue(6);
            list.Display();
        }
    }
}
