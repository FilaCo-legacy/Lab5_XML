using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ParsingStructs;

namespace Id_tree_Serializing
{
    class Program
    {
        static Regex regRemoveSpaces = new Regex(@"\s+");
        static int Menu(string title, params string[] items)
        {
            Console.Clear();
            Console.WriteLine(title);
            int curItem = 0, x = 2, y = 2, oldItem = 0;
            Console.CursorVisible = false;
            for (int i = 0; i < items.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y + i);
                Console.Write(items[i]);
            }
            bool choice = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + oldItem);
                Console.Write(items[oldItem] + " ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y + curItem);
                Console.Write(items[curItem]);

                oldItem = curItem;

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        curItem++;
                        break;
                    case ConsoleKey.UpArrow:
                        curItem--;
                        break;
                    case ConsoleKey.Enter:
                        choice = true;
                        break;
                }
                if (curItem >= items.Length)
                    curItem = 0;
                else if (curItem < 0)
                    curItem = items.Length - 1;
                if (choice)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorVisible = true;
                    Console.Clear();
                    break;
                }
            }
            Console.Clear();
            Console.CursorVisible = true;
            return curItem;
        }
        static void BinarySerialize(TBinaryTree root, string fileName)
        {

        }
        static void XmlSerialize(TBinaryTree root, string fileName)
        {

        }
        static void BinaryDeserialize(string fileName, out TBinaryTree root)
        {

        }
        static void XmlDeserialize(string fileName, out TBinaryTree root)
        {

        }
        static void LoadFromFile(string fileName, out TBinaryTree root)
        {
            root = new TBinaryTree();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string curSource = sr.ReadLine();
                    curSource = regRemoveSpaces.Replace(curSource, " ");
                    curSource = curSource.Trim(' ');
                    root.Add(Id.CreateIdFromSource(curSource));
                }
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
