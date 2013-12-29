using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public class LinkedList<T> where T: IComparable
    {
        private LinkedListItem<T> first;
        public LinkedListItem<T> First
        {
            get { return first; }
        }

        private int count;
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Adds items in the beginning of the list. O(1).
        /// </summary>
        /// <param name="item"></param>
        public void AddBegin(T item)
        {
            LinkedListItem<T> i = new LinkedListItem<T>(item, first);            
            first = i;
            count++;            
        }

        /// <summary>
        /// In doubt.  O(n) (because depends on GetLastItem) or O(1), if not depends??
        /// </summary>
        /// <param name="item"></param>
        public void AddEnd(T item)
        {            
            LinkedListItem<T> i = new LinkedListItem<T>(item);
            if (first == null)
                first = i;
            else
            {
                LinkedListItem<T> last = GetLastItem();
                last.SetNext(i);
            }
        }

        /// <summary>
        /// Get last element of the list. O(n).
        /// </summary>
        /// <returns></returns>
        public LinkedListItem<T> GetLastItem()
        {
            if (first == null)
                return null;

            LinkedListItem<T> tmp = first;            
            while (tmp.Next != null)
                tmp = tmp.Next;
            return tmp;
        }

        /// <summary>
        /// Search for an item in the list. O(n)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public LinkedListItem<T> Find(T item)
        {
            if (first == null)
                return null;

            LinkedListItem<T> tmp = first;
            while (tmp != null)
            {
                if (tmp.Item.Equals(item))
                    return tmp;
                tmp = tmp.Next;
            }

            return null;
        }

        /// <summary>
        /// Deletes an elemente from the  list. O(n)
        /// </summary>
        /// <param name="item"></param>
        public void Delete(LinkedListItem<T> item)
        {
            if (item == first)
                first = first.Next;
            else
            {
                LinkedListItem<T> tmp = first;
                LinkedListItem<T> pred  = null;
                while (tmp != null)
                {
                    if (tmp.Next != null && tmp.Next == item)
                    {
                        pred = tmp;
                        break;
                    }
                    tmp = tmp.Next;
                }
                if (pred != null)
                    pred.SetNext(item.Next);
            }
        }

        public bool IsInLoop()
        {
            Dictionary<LinkedListItem<T>, bool> discovered = new Dictionary<LinkedListItem<T>, bool>();

            LinkedListItem<T> tmp = first;
            bool loop = false;
            while (tmp != null)
            {
                if (discovered.ContainsKey(tmp))
                {
                    loop = true;
                    break;
                }

                discovered.Add(tmp, true);
                tmp = tmp.Next;
            }
            return loop;
        }

        /// <summary>
        /// Tortoise and hare algorithm. Use less space than other implementation
        /// </summary>
        /// <returns></returns>
        public bool IsInLoop2()
        {            
            LinkedListItem<T> tortoise = first;
            LinkedListItem<T> hare = first.Next;

            bool loop = false;
            while (tortoise != null)
            {
                if (tortoise == hare)
                {
                    loop = true;
                    break;
                }
                else if (hare.Next == null)
                {
                    loop = false;
                    break;
                }
                
                hare = hare.Next.Next;
                tortoise = tortoise.Next;
            }
            return loop;
        }

        /// <summary>
        /// Without recursion
        /// </summary>
        public void Reverse1()
        {
            LinkedListItem<T> curr = first;
            LinkedListItem<T> prev = null;  
            while (curr != null)
            {
                LinkedListItem<T> tmp = curr;
                curr = curr.Next;
                tmp.SetNext(prev);
                prev = tmp;
            }
            first = prev;
        }

        /// <summary>
        /// With recursion
        /// </summary>
        public void Reverse2()
        {
            if (first.Next != null)
                Reverse2Recur(first.Next, first);
        }

        private void Reverse2Recur(LinkedListItem<T> curr, LinkedListItem<T> prev)
        {
            LinkedListItem<T> next = curr.Next;
            curr.SetNext(prev);
            if (next != null)
                Reverse2Recur(next, curr);
            else
                first = curr;
        }

        public static LinkedListItem<T> MergeTwoSortedLists(LinkedListItem<T> l1, LinkedListItem<T> l2) 
        {
            
            LinkedListItem<T> resultRoot = null, idx1 = l1, idx2 = l2, residx = null;
            while (idx1 != null || idx2 != null)
            {
                if (idx2 == null || (idx1 != null) && (idx1.Item.CompareTo(idx2.Item) < 0))
                {
                    if (resultRoot == null)
                    {
                        resultRoot = idx1;
                        residx = idx1;
                    }
                    else
                    {
                        residx.Next = idx1;
                        residx = residx.Next;
                    }
                    idx1 = idx1.Next;
                }
                else if (idx1 == null || (idx2 != null) && (idx2.Item.CompareTo(idx1.Item) < 0))
                {
                    if (resultRoot == null)
                    {
                        resultRoot = idx2;
                        residx = idx2;
                    }
                    else
                    {
                        residx.Next = idx2;
                        residx = residx.Next;
                    }
                    idx2 = idx2.Next;
                }                
            }
            return resultRoot;
        }
    }

    public class LinkedListItem<T> where T:IComparable
    {
        private T item;
        public T Item
        {
            get { return item; }
        }

        private LinkedListItem<T> next;
        public LinkedListItem<T> Next
        {
            get { return next; }
            set { next = value;}
        }

        public LinkedListItem(T item)
        {
            this.item = item;
        }

        public LinkedListItem(T item, LinkedListItem<T> next)
        {
            this.item = item;
            this.next = next;
        }

        public void SetNext(LinkedListItem<T> next)
        {
            this.next = next;
        }
    }
}
