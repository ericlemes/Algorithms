using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public class UnbalancedBinaryTree<T> where T : IComparable
    {
        private UnbalancedBinaryTreeItem<T> root = null;
        public UnbalancedBinaryTreeItem<T> Root
        {
            get { return root; }
            set { root = value; }
        }

        public void Insert(T item)
        {
            if (root == null)
            {
                root = new UnbalancedBinaryTreeItem<T>();
                root.Item = item;
            }
            else
                Insert(item, root, root);
        }

        /// <summary>
        /// Insert: O(h) - Tree height
        /// </summary>
        /// <param name="item"></param>
        /// <param name="current"></param>
        /// <param name="parent"></param>
        private void Insert(T item, UnbalancedBinaryTreeItem<T> current, UnbalancedBinaryTreeItem<T> parent)
        {
            UnbalancedBinaryTreeItem<T> i = null;
            if (item.CompareTo(current.Item) < 0)
            {
                if (current.Left != null)
                    Insert(item, current.Left, current);
                else
                {
                    i = new UnbalancedBinaryTreeItem<T>();
                    current.Left = i;
                }
            }
            else if (item.CompareTo(current.Item) > 0)
            {
                if (current.Right != null)
                    Insert(item, current.Right, current);
                else
                {
                    i = new UnbalancedBinaryTreeItem<T>();
                    current.Right = i;
                }
            }
            else
                throw new Exception("Duplicated item: " + item.ToString());

            if (i != null)
            {
                i.Item = item;
                i.Parent = current;
            }

        }

        /// <summary>
        /// Search - O(h) 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public UnbalancedBinaryTreeItem<T> Search(T searchValue)
        {
            return Search(root, searchValue);
        }

        public UnbalancedBinaryTreeItem<T> Search(UnbalancedBinaryTreeItem<T> current, T searchValue)
        {
            if (current == null)
                return null;

            int compareResult = searchValue.CompareTo(current.Item);
            if (compareResult == 0)
                return current;
            else if (compareResult < 0)
                return Search(current.Left, searchValue);
            else // > 0
                return Search(current.Right, searchValue);
        }

        /// <summary>
        /// O(h)
        /// </summary>
        /// <returns></returns>
        public UnbalancedBinaryTreeItem<T> GetMinimum()
        {
            return GetMinimum(root);
        }

        public UnbalancedBinaryTreeItem<T> GetMinimum(UnbalancedBinaryTreeItem<T> startItem)
        {
            if (startItem == null)
                return null;

            UnbalancedBinaryTreeItem<T> min = startItem;
            while (min.Left != null)
                min = min.Left;
            return min;

        }

        /// <summary>
        /// O(h)
        /// </summary>
        /// <returns></returns>
        public UnbalancedBinaryTreeItem<T> GetMaximum()
        {
            if (root == null)
                return null;

            UnbalancedBinaryTreeItem<T> max = root;
            while (max.Right != null)
                max = max.Right;
            return max;
        }

        public IList<UnbalancedBinaryTreeItem<T>> TraverseSorted()
        {
            List<UnbalancedBinaryTreeItem<T>> l = new List<UnbalancedBinaryTreeItem<T>>();
            TraverseSorted(root, l);
            return l;
        }

        private void TraverseSorted(UnbalancedBinaryTreeItem<T> current, IList<UnbalancedBinaryTreeItem<T>> result)
        {
            if (current != null)
            {
                TraverseSorted(current.Left, result);
                result.Add(current);
                TraverseSorted(current.Right, result);
            }
        }

        public IList<T> TraverseSortedAsList()
        {
            List<T> l = new List<T>();
            TraverseSorted(root, l);
            return l;
        }

        private void TraverseSorted(UnbalancedBinaryTreeItem<T> current, IList<T> result)
        {
            if (current != null)
            {
                TraverseSorted(current.Left, result);
                result.Add(current.Item);
                TraverseSorted(current.Right, result);
            }
        }

        public void Delete(UnbalancedBinaryTreeItem<T> item)
        {
            if (item.Left == null && item.Right == null)
                SetParentLeftOrRightChildReferenceTo(item, null);
            else if (item.Left != null ^ item.Right != null)
            {
                UnbalancedBinaryTreeItem<T> child = GetValueOfSideWithValue(item);
                SetParentLeftOrRightChildReferenceTo(item, child);
            }
            else //both sides has value.
            {
                var min = GetMinimum(item.Right);
                item.Item = min.Item; //Relabel;
                Delete(min);
            }
        }

        private static UnbalancedBinaryTreeItem<T> GetValueOfSideWithValue(UnbalancedBinaryTreeItem<T> item)
        {
            UnbalancedBinaryTreeItem<T> child = null;
            if (item.Left != null)
                child = item.Left;
            else
                child = item.Right;
            return child;
        }

        /// <summary>
        /// Set which side (left or right) hooks to item to the specified node value
        /// </summary>
        /// <param name="item"></param>
        private static void SetParentLeftOrRightChildReferenceTo(UnbalancedBinaryTreeItem<T> item, UnbalancedBinaryTreeItem<T> value)
        {
            if (item.Parent.Left == item)
                item.Parent.Left = value;
            else
                item.Parent.Right = value;
            item.Parent = null; //let GC work!
        }

        public bool IsMirror()
        {
            if (root.Left == null && root.Right == null)
                return true;

            return IsMirrorItems(root.Left, root.Right);
        }

        private bool IsMirrorItems(UnbalancedBinaryTreeItem<T> left, UnbalancedBinaryTreeItem<T> right)
        {
            if (left == null && right == null)
                return true;
            else if (left == null ^ right == null)
                return false;
            else if (!left.Item.Equals(right.Item))
                return false;
            else
            {
                bool mirror = IsMirrorItems(left.Left, right.Right);
                if (!mirror)
                    return false;
                return IsMirrorItems(left.Right, right.Left);
            }
        }

        public List<UnbalancedBinaryTreeItem<T>> TraverseByLevel()
        {
            if (root == null)
                throw new Exception("Empty tree.");

            List<UnbalancedBinaryTreeItem<T>> l = new List<UnbalancedBinaryTreeItem<T>>();

            Queue<UnbalancedBinaryTreeItem<T>> q = new Queue<UnbalancedBinaryTreeItem<T>>();
            q.Enqueue(root);
            int count = 0;
            int level = 1;
            bool hasNonNullItem = false;
            while (q.Count > 0)
            {
                UnbalancedBinaryTreeItem<T> curr = q.Dequeue();
                if (curr != null)
                {
                    l.Add(curr);
                    hasNonNullItem = true;
                }

                count++;
                if (count >= level)
                {
                    if (!hasNonNullItem)
                        break;
                    else
                        hasNonNullItem = false;
                    l.Add(null); //Indicates level change.
                    level *= 2;
                    count = 0;
                    
                }

                if (curr != null)
                {
                    q.Enqueue(curr.Left);
                    q.Enqueue(curr.Right);
                }
                else
                {
                    q.Enqueue(null);
                    q.Enqueue(null);
                }
            }

            return l;
        }

        private void TraverseItemByLevel(List<UnbalancedBinaryTreeItem<T>> l, UnbalancedBinaryTreeItem<T> left, UnbalancedBinaryTreeItem<T> right)
        {
            l.Add(left);
            l.Add(right);
        }

        public void InsertSortedList(IList<T> merged)
        {
            if (merged.Count > 0) 
                InsertSortedListRecur(merged, 0, merged.Count - 1);
        }

        public void InsertSortedListRecur(IList<T> merged, int low, int high)
        {
            int mid = low + ((high - low) / 2); //avoid overflow;
            Insert(merged[mid]);
            int qtdLeft = (mid - 1) - low;
            if (qtdLeft <= 2){
                for (int i = 0; i <= qtdLeft; i++)
                    Insert(merged[low + i]);
            }
            else
                InsertSortedListRecur(merged, low, mid - 1);
            int qtdRight = high - (mid + 1);
            if (qtdRight <= 2)
            {
                for (int i = 0; i <= qtdRight; i++)
                    Insert(merged[high - i]);
            }
            else
                InsertSortedListRecur(merged, mid + 1, high);
            
        }

        public bool IsValid()
        {
            return IsValidRecur(root);
        }

        private bool IsValidRecur(UnbalancedBinaryTreeItem<T> item) 
        {
             if (item.Left != null && (item.Item.CompareTo(item.Left.Item) < 0))
                  return false;
             else if (item.Right != null && (item.Item.CompareTo(item.Right.Item) > 0))
                  return false;
             if (item.Left != null)
                 if (!IsValidRecur(item.Left))
                     return false;
             if (item.Right != null)
                 if (!IsValidRecur(item.Right))
                     return false;
             return true;
        }

        public bool IsBalanced()
        {
            bool isBalanced = true;
            GetHeight(root, ref isBalanced);
            return isBalanced;
        }

        public int GetHeight()
        {
            bool isBalanced = true;
            return GetHeight(root, ref isBalanced);            
        }

        private int GetHeight(UnbalancedBinaryTreeItem<T> item, ref bool balanced)
        {
            if (item == null)
                return 0;

            int leftHeight = GetHeight(item.Left, ref balanced);
            int rightHeight = GetHeight(item.Right, ref balanced);
            if (Math.Abs(leftHeight - rightHeight) > 1)
                balanced = false;
            if (leftHeight > rightHeight)
                return leftHeight + 1;
            else
                return rightHeight + 1;
        }
    }


    public class UnbalancedBinaryTreeItem<T>
    {
        public T Item
        {
            get;
            set;
        }

        public UnbalancedBinaryTreeItem<T> Left
        {
            get;
            set;
        }

        public UnbalancedBinaryTreeItem<T> Right
        {
            get;
            set;
        }

        public UnbalancedBinaryTreeItem<T> Parent
        {
            get;
            set;
        }

        public UnbalancedBinaryTreeItem()
        {

        }

        public UnbalancedBinaryTreeItem<T> CreateLeft(T item)
        {
            this.Left = new UnbalancedBinaryTreeItem<T>();
            this.Left.Parent = this;
            this.Left.Item = item;
            return this.Left;
        }

        public UnbalancedBinaryTreeItem<T> CreateRight(T item)
        {
            this.Right = new UnbalancedBinaryTreeItem<T>();
            this.Right.Parent = this;
            this.Right.Item = item;
            return this.Right;
        }
        public UnbalancedBinaryTreeItem(T item)
        {
            this.Item = item;
        }

    }
}
