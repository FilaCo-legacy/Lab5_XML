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
                    Console.ForegroundColor = ConsoleColor.Gray;
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
        static void BinarySerialize(string fileName, TBinaryTree root)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, root);
            }
        }
        static void XmlSerialize(string fileName, TBinaryTree root)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(TBinaryTree));
                xs.Serialize(fs, root);
            }
        }
        static void BinaryDeserialize(string fileName, out TBinaryTree root)
        {
            using(FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                root = (TBinaryTree)bf.Deserialize(fs);
            }
        }
        static void XmlDeserialize(string fileName, out TBinaryTree root)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(TBinaryTree));
                root = (TBinaryTree)xs.Deserialize(fs);
            }
        }
        static void LoadFromFile(string fileName, out TBinaryTree root)
        {
            root = new TBinaryTree();
            using (StreamReader sr = new StreamReader(fileName))
            {
                int iter = 1;
                while (!sr.EndOfStream)
                {
                    string curSource = sr.ReadLine();
                    curSource = regRemoveSpaces.Replace(curSource, " ");
                    curSource = curSource.Trim(' ');
                    try
                    {
                        root.Add(Id.CreateIdFromSource(curSource));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Line {iter} syntax error: {e.Message}");
                    }
                    ++iter;
                }
            }
        }
        static string InputFileName()
        {
            Console.WriteLine("Введите имя файла:");
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            TBinaryTree root = null;
            while (true)
            {
                switch (Menu("Выберите действие", "Загрузить дерево из файла", "Выполнить бинарную сериализацию",
                    "Выполнить XML-сериализацию", "Выполнить бинарную десериализацию", "Выполнить XML-десериализацию", 
                    "Показать дерево", "Выход"))
                {
                    case 0:
                        try
                        {
                            LoadFromFile(InputFileName(), out root);
                            Console.WriteLine("Загрузка дерева из файла прошла успешно.");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine($"Произошла ошибка: {e.Message}\nПопробуйте ещё раз.");
                        }
                        break;
                    case 1:
                        try
                        {
                            BinarySerialize(InputFileName(), root);
                            Console.WriteLine("Бинарная сериализация дерева прошла успешно.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Произошла ошибка: {e.Message}\nПопробуйте ещё раз.");
                        }
                        break;
                    case 2:
                        try
                        {
                            XmlSerialize(InputFileName(), root);
                            Console.WriteLine("XML-сериализация дерева прошла успешно.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Произошла ошибка: {e.Message}\nПопробуйте ещё раз.");
                        }
                        break;
                    case 3:
                        try
                        {
                            BinaryDeserialize(InputFileName(), out root);
                            Console.WriteLine("Бинарная десериализация дерева прошла успешно.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Произошла ошибка: {e.Message}\nПопробуйте ещё раз.");
                        }
                        break;
                    case 4:
                        try
                        {
                            XmlDeserialize(InputFileName(), out root);
                            Console.WriteLine("XML-десериализация дерева прошла успешно.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Произошла ошибка: {e.Message}\nПопробуйте ещё раз.");
                        }
                        break;
                    case 5:
                        if (root != null)
                            root.Show();
                        break;
                    case 6:
                        return;
                }
                Console.WriteLine("Для продолжения нажмите Enter...");
                Console.ReadLine();
            }
        }
    }
}
