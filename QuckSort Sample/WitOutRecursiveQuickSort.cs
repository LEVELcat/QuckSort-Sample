using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuckSort_Sample
{
    public static class WitOutRecursiveQuickSort
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

            List<int> stack = new List<int>();
            int pointer = 0;
            int bufPointer;

            stack.Insert(pointer, start);
            stack.Insert(pointer + 1, end);
            stack.Insert(pointer + 2, Partition(array, start, end));
            stack.Insert(pointer + 3, 2);

            while (true)
            {
                if(pointer < 0)
                    break;

                if (stack[pointer + 3] == 2)
                {
                    bufPointer = pointer + 4;
                    stack.Insert(bufPointer, stack[pointer]);
                    stack.Insert(bufPointer + 1, stack[pointer + 1]);
                    stack.Insert(bufPointer + 2, Partition(array, stack[pointer], stack[pointer + 1] - 1));
                    stack.Insert(bufPointer + 3, 2);
                    stack[pointer + 3]--;
                    pointer = bufPointer;
                    continue;
                }

                if (stack[pointer + 3] == 1)
                {
                    bufPointer = pointer + 4;
                    stack.Insert(bufPointer, stack[pointer]);
                    stack.Insert(bufPointer + 1, stack[pointer + 1]);
                    stack.Insert(bufPointer + 2, Partition(array, stack[pointer] + 1, stack[pointer + 1]));
                    stack.Insert(bufPointer + 3, 2);
                    stack[pointer + 3]--;
                    pointer = bufPointer;
                    continue;
                }

                if (stack[pointer + 3] == 0)
                {
                    stack.RemoveRange(pointer, 4);
                    pointer -= 4;
                }
            }
        }
    }
}
