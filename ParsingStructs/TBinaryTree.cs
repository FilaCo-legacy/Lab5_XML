using System;
using System.Xml.Serialization;

namespace ParsingStructs
{
    [Serializable]
    [XmlRoot(ElementName = "Дерево_идентификаторов")]
    /// <summary>
    /// Класс, реализующий дерево идентификаторов
    /// </summary>
    public class TBinaryTree
    {        
        [XmlElement(ElementName = "Вершина")]
        /// <summary>
        /// Идентификатор, хранящийся в вершине дерева
        /// </summary>
        public Id Data { get; set; }
        /// <summary>
        /// Указатель на левого потомка
        /// </summary>
        public TBinaryTree Left { get; set; }
        /// <summary>
        /// Указатель на правого потомка
        /// </summary>
        public TBinaryTree Right { get; set; }
        public TBinaryTree()
        {
            Data = null;
            Left = Right = null;
        }
        public TBinaryTree(Id valueData)
        {
            Data = valueData;
            Left = Right = null;
        }
        public void Add(Id elem)
        {
            if (Data is null)
            {
                Data = elem;
                return;
            }
            TBinaryTree cur = this, anc = null;
            while (cur != null)
            {
                anc = cur;
                if (elem < cur.Data)
                    cur = cur.Left;
                else if (elem > cur.Data)
                    cur = cur.Right;
                else
                    return;
            }
            cur = new TBinaryTree(elem);
            if (cur.Data > anc.Data)
                anc.Right = cur;
            else
                anc.Left = cur;
        }
        public void Show(int indent = 0)
        {
            if (Left != null)
                Left.Show(indent + 3);
            Console.WriteLine(new String(' ', indent) + Data);
            if (Right != null)
                Right.Show(indent + 3);
        }
    }
}
