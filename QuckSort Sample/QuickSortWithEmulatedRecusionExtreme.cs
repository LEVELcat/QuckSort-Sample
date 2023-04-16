using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuckSort_Sample
{
    public static class QuickSortWithEmulatedRecusionExtreme
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

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            RecursiveCell currentCell = new RecursiveCell() { Start = start, End = end, Stage = 2 };
            RecursiveCell newCell;

            while (true)
            {
                if (currentCell == null) break;

                if(currentCell.Stage == 2)
                {
                    currentCell.Stage--;

                    currentCell.Pivot = Partition(array, currentCell.Start, currentCell.End);
                    newCell = new RecursiveCell() { Start = currentCell.Start, End = currentCell.Pivot - 1, Stage = 2 };

                    if(newCell.Start < newCell.End)
                    {
                        newCell.Parent = currentCell;
                        currentCell = newCell;
                        continue;
                    }
                }

                if(currentCell.Stage == 1)
                {
                    currentCell.Stage--;

                    newCell = new RecursiveCell() { Start = currentCell.Pivot + 1, End = currentCell.End, Stage = 2 };
                    if (newCell.Start < newCell.End)
                    {
                        newCell.Parent = currentCell;
                        currentCell = newCell;
                        continue;
                    }
                }

                if(currentCell.Stage == 0)
                    currentCell = currentCell.Parent;
            }
        }

        class RecursiveCell
        {
            public int Start;
            public int End;
            public int Pivot;
            public byte Stage;

            public RecursiveCell Parent;
        }
    }
}
