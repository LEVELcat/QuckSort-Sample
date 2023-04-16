using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuckSort_Sample
{
    public static class QuckSortWithEmulatedRecursion
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

            RecursiveCell[] stack = new RecursiveCell[end];
            int pointer = 0;
            RecursiveCell currentCell = new RecursiveCell() { Start = start, End = end, Stage = 2};
            RecursiveCell newCell;
            
            stack[pointer] = currentCell;

            while (true)
            {
                if (pointer < 0)
                    break;

                currentCell = stack[pointer];

                switch (currentCell.Stage)
                {
                    case 0:
                        pointer--;
                        break;
                    case 2:
                        currentCell.Stage--;

                        currentCell.Pivot = Partition(array, currentCell.Start, currentCell.End);
                        newCell = new RecursiveCell() {
                            Start = currentCell.Start,
                            End = currentCell.Pivot - 1,
                            Stage = 2
                        };

                        if (newCell.Start < newCell.End)
                            stack[++pointer] = newCell;

                        break;
                    case 1:
                        currentCell.Stage--;

                        newCell = new RecursiveCell() {
                            Start = currentCell.Pivot + 1,
                            End = currentCell.End,
                            Stage = 2
                        };

                        if (newCell.Start < newCell.End)
                            stack[++pointer] = newCell;

                        break;
                }
            }
        }

        class RecursiveCell
        {
            public int Start;
            public int End;
            public int Pivot;
            public byte Stage;
        }

    }
}
