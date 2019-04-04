using System;

namespace ParsingStructs
{
    [Serializable]
    /// <summary>
    /// Класс, реализующий дерево идентификаторов
    /// </summary>
    public class TBinaryTree
    {
        private TBinaryTree left, right;
        /// <summary>
        /// Идентификатор, хранящийся в вершине дерева
        /// </summary>
        public Id Data { get; set; }
        public TBinaryTree()
        {
            Data = null;
            left = right = null;
        }
        public TBinaryTree(Id valueData)
        {
            Data = valueData;
            left = right = null;
        }
        public void Add(Id elem)
        {
            if (Data == null)
            {
                Data = elem;
                return;
            }
            TBinaryTree cur = this, anc = null;
            while (cur != null)
            {
                anc = cur;
                if (elem < cur.Data)
                    cur = cur.left;
                else if (elem > cur.Data)
                    cur = cur.right;
                else
                    return;
            }
            cur = new TBinaryTree(elem);
            if (cur.Data > anc.Data)
                anc.right = cur;
            else
                anc.left = cur;
        }
        public void Show(int indent = 0)
        {
            if (left != null)
                left.Show(indent + 3);
            Console.WriteLine(new String(' ', indent) + Data);
            if (right != null)
                right.Show(indent + 3);
        }
    }
}
