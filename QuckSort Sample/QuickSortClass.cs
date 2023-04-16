namespace QuckSort_Sample
{
    static class QuickSortClass
    {
        static int Partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker++;
                }
            }

            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        public static void Quicksort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }
    }
}