using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingStructs
{
    /// <summary>
    /// Класс, реализующий дерево идентификаторов
    /// </summary>
    class BinaryTree
    {
        private BinaryTree left, right;
        public Id Data { get; set; }
        public BinaryTree()
        {
            Data = null;
            left = right = null;
        }
        public BinaryTree(Id valueData)
        {
            Data = valueData;
            left = right = null;
        }
        public void Add(Id elem)
        {
            if (elem > Data)
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
