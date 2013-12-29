using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public class Heap<T> where T : IComparable
    {
        private int size;
        public int Size
        {
            get { return size; }
        }

        private T[] buffer;

        public Heap()
            : this(50)
        {

        }

        public Heap(int initialCapacity)
        {
            buffer = new T[initialCapacity];
            size = 0;
        }

        public Heap(T[] array)
        {
            buffer = array;
            size = array.Length;

            for (int i = size / 2; i >= 1; i--)
                BubbleDown(i - 1);
        }

        /// <summary>
        /// O(log n)
        /// </summary>
        /// <param name="item"></param>
        public void Insert(T item)
        {
            if (size >= buffer.Length)
                Grow();
            else
            {                
                buffer[size] = item;                
                BubbleUp(size);
                size++;
            }
        }

        private void BubbleUp(int position)
        {
            if (GetParentPosition(position) < 0)
                return;
            else
            {
                int equalityResult = buffer[GetParentPosition(position)].CompareTo(buffer[position]);
                if (equalityResult > 0)
                {
                    Swap(position, GetParentPosition(position));
                    BubbleUp(GetParentPosition(position));
                }

            }

        }

        private void Swap(int p1, int p2)
        {
            T tmp = buffer[p2];
            buffer[p2] = buffer[p1];
            buffer[p1] = tmp;
        }

        private int GetParentPosition(int position)
        {
            return position = position / 2;
        }



        public T PeekMinimum()
        {
            if (size <= 0)
                throw new Exception("No items in the heap.");
            return buffer[0];
        }

        private void Grow()
        {
            Array.Resize(ref buffer, buffer.Length * 2);
        }


        /// <summary>
        /// O(log n)
        /// </summary>
        /// <returns></returns>
        public T ExtractMinimum()
        {
            if (size <= 0)
                throw new Exception("Empty heap");

            T min = buffer[0];
            buffer[0] = buffer[size - 1];
            size--;
            BubbleDown(0);
            return min;
        }

        private void BubbleDown(int p)
        {
            int mininum = p;
            int left = GetLeftChild(p);            

            for (int i = 0; i <= 1; i++)
            {
                if ((left + i) <= (this.size - 1)) //If element to be tested is in the queue.
                {
                    int compareResult = buffer[mininum].CompareTo(buffer[left + i]);
                    if (compareResult > 0)
                        mininum = left + i;
                }
            }
            if (mininum != p)
            {
                Swap(mininum, p);
                BubbleDown(mininum);
            }
        }

        public static int GetLeftChild(int p)
        {
            return (2 * p) + 1; //Because I've used 0-indexed arrays.. :-(
        }

        /// <summary>
        /// Side effect: will clear the heap
        /// O(n log n)
        /// </summary>
        /// <returns></returns>
        public T[] HeapSort()
        {
            if (this.size <= 0)
                throw new Exception("Empty heap");

            T[] result = new T[this.size];
            int currIndex = 0;
            while (this.size > 0)
            {
                result[currIndex] = this.ExtractMinimum();
                currIndex++;
            }
            return result;
        }
    }
}
