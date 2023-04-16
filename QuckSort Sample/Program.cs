namespace QuckSort_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество сортируемых чисел в массиве представленные в худшем варианте");
            int Count = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int[] array = new int[Count];

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length - 1 - i;
            }

            Console.WriteLine("Сортировка через эмуляцию рекурсии");


            QuckSortWithEmulatedRecursion.QuickSort(array, 0, array.Length - 1);

            Console.WriteLine("Завершена успешно" + "\n");

            Console.WriteLine("Сортировка через эмуляцию рекурсии (Односвязный список)");

            QuickSortWithEmulatedRecusionExtreme.QuickSort(array, 0, array.Length - 1);

            Console.WriteLine("Завершена успешно" + "\n");

            Console.WriteLine("Сортировка через рекурсию");

            array = new int[Count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length - 1 - i;
            }

            QuickSortClass.Quicksort(array, 0, array.Length - 1);

            Console.WriteLine("АХАХАХАХ!!!");

            Console.ReadKey();
        }
    }
}