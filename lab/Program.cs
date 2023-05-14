using ClassLibrary1;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;

namespace lab
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        /// <summary>
        /// функция для вывода меню
        /// </summary>
        /// <param name="text">само меню</param>
        static void PrintMenu(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan; //смена цвета текста консоли
            Console.WriteLine(message);
            Console.WriteLine("Введите соответствующий номер операции");
            Console.ResetColor();
        }

        /// <summary>
        /// функция для удаления последнего элемента с заданным именем
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        static void DeleteLastPersonByName(ref DoublyLinkedList<Person>? list)
        {
            if (list?.Length <= 0) //проверка длины списка
                Console.WriteLine("Ваш список пуст");
            Console.WriteLine("Впишите имя человека, которого хотите удалить из списка");
            string? name = Console.ReadLine(); //ввод имени человека для удаления
            PointList<Person>? p = list?.End;
            bool isFound = false;
            for (int i = list.Length; i > 0; i--, p = p?.Prev)
            {
                if (p?.Data?.Name == name)
                {
                    list?.DeleteElement(p); //удаление элементов
                    isFound = true;
                }
            }
            if (!isFound) //если элемент был не найден
                Console.WriteLine($"Элемент c именем {name} не был найден в списке");
            else
            {
                if (list?.Length == 0) //если единственный элемент был удален
                    Console.WriteLine($"Элемент c именем {name} был удален. Ваш список теперь пуст.");
                else
                    Console.WriteLine($"Элемент c именем {name} был удален.");
            }
        }

        /// <summary>
        /// создание двумерного списка из элементов Person
        /// </summary>
        /// <returns></returns>
        public static DoublyLinkedList<Person>? CreateDoublyLinkedList()
        {
            Person p1 = new Person();
            p1.RandomInit();
            DoublyLinkedList<Person>? newList = new DoublyLinkedList<Person>(p1);
            Console.WriteLine("Впишите длину нового списка");
            int len = ReadNumbers.ReadInt(1, 100); //ввод длины списка
            for (int i = 0; i < len-1; i++) //заполнение списка элементами Person
            {
                Person p = new Person();
                p.RandomInit();
                newList.AddElement(p);
            }
            Console.WriteLine("Список был создан");
            return newList;
        }

        /// <summary>
        /// функция для клонирования и проверки клона
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DoublyLinkedList<Person>? CreateCheckClone(DoublyLinkedList<Person> list)
        {
            if (list.Length <= 0)
            {
                Console.WriteLine("Ваш список пуст, нажмите 1");
                return list;
            }
                DoublyLinkedList<Person> newList = (DoublyLinkedList<Person>)list.Clone();
                Console.WriteLine("Изменим 1 элемент на Сергея в клонированном списке");
                Person p1 = new Person("Сергей", "Мужской", 23);
                newList.Beg.Data = p1;
                list.ShowList();
                Console.Write("Его клон, ");
                return newList; 
        }


        /// <summary>
        /// функция для работы с двунаправленным списком
        /// </summary>
        static void WorkingWithDoublyLinkedList()
        {
            string textMenu = "1 - Cоздать новый двунаправленный список из объектов Person\n2 - Вывести список\n3 - Удалить последний элемент с заданным именем\n4 - Клонирование списка\n5 - Удалить список из памяти\n6 - Назад в меню";
            PrintMenu(textMenu);
            DoublyLinkedList<Person>? list = new DoublyLinkedList<Person>(new Person()); //создаем двунаправленный список объектов Person
            string? operationNumber;
            do
            {
                operationNumber = Console.ReadLine();
                switch (operationNumber)
                {
                    case "1": //создание нового листа
                        list = CreateDoublyLinkedList();
                        list?.ShowList();
                        PrintMenu(textMenu);
                        break;
                    case "2": //вывод списка
                        list?.ShowList();
                        PrintMenu(textMenu);
                        break;
                    case "3": //удаление последнего элемента с заданным именем
                        DeleteLastPersonByName(ref list);
                        PrintMenu(textMenu);
                        list?.ShowList();
                        break;
                    case "4": //клонирование списка
                        list = CreateCheckClone(list);
                        list?.ShowList();
                        PrintMenu(textMenu);
                        break;
                    case "5": //удалить список из памяти
                        list?.RemoveListFromMemory();
                        Console.WriteLine("Список был удален из памяти");
                        PrintMenu(textMenu);
                        break;
                    default: //вывод ошибки при некорректном вводе
                        if (operationNumber != "6")
                            Console.WriteLine("\aВпишите номер операции (целое число от 1 до 6)!");
                        break;
                }
            } while (operationNumber != "6"); //цикл действует пока пользователь не введет 6
        }

        /// <summary>
        /// функция для создания идеально сбалансированного дерева из элементов типа Person
        /// </summary>
        /// <returns></returns>
        public static Tree<Person> CreateIdealTreeOfPeople()
        {
            Console.WriteLine("Создание нового идеально сбалансированного дерева.\nВпишите длину вашего дерева");
            int l = ReadNumbers.ReadInt(1, 100);
            Tree<Person> newTree = new Tree<Person>(l);
            return newTree;
        }

        /// <summary>
        /// функция для нахождения человека с минимальным возрастом из дерева
        /// </summary>
        /// <param name="root"></param>
        public static void FindPersonSmallestAge(PointTree<Person>? root)
        {
            Person? youngestPerson = root?.Data;
            Stack<PointTree<Person>> inS = new Stack<PointTree<Person>>();
            Stack<PointTree<Person>> outS = new Stack<PointTree<Person>>();
            PointTree<Person> temp = new PointTree<Person>();
            PointTree<Person> item = new PointTree<Person>();
            if (root!=null)
            {
                inS.Push(root);
                while (inS.Count>0)
                {
                    temp=inS.Pop();
                    outS.Push(temp);
                    if (temp.Left!=null) inS.Push(temp.Left);
                    if (temp.Right!=null) inS.Push(temp.Right);
                }
                while (outS.Count>0)
                {
                    item=outS.Pop();
                    if (item.Data?.Age < youngestPerson?.Age) //проверка возраста
                        youngestPerson = item.Data;
                }
                Console.WriteLine($"Человек с минимальным возрастом - {youngestPerson}");
            }
            else
                Console.WriteLine("Дерево пустое, создайте новое, нажав единицу");
        }

        /// <summary>
        /// функция для работы с деревьями
        /// </summary>
        static void WorkingWithTrees()
        {
            string textMenu = "1 - Cоздать новое идеально сбалансированное дерево\n2 - Вывести дерево\n3 - Найти человека с минимальным возрастом\n4 - Преобразовать идеально сбалансированное дерево в дерево поиска\n5 - Удалить дерево из памяти\n6 - Назад в меню";
            //создаем идеально сбалансированное дерево объектов Person
            Tree<Person> tree = CreateIdealTreeOfPeople();
            Console.WriteLine("Ваше дерево:");
            Tree<Person>.ShowTree(tree.R, 3);
            PrintMenu(textMenu);
            string? operationNumber;
            do
            {
                operationNumber = Console.ReadLine();
                switch (operationNumber)
                {
                    case "1": //создание нового идеально сбалансированного дерева
                        tree = CreateIdealTreeOfPeople();
                        Console.WriteLine("Ваше дерево:");
                        Tree<Person>.ShowTree(tree.R, 3);
                        PrintMenu(textMenu);
                        break;
                    case "2": //вывод дерева
                        Console.WriteLine("Ваше дерево:");
                        if (tree.R == null)
                            Console.WriteLine("Ваша дерево пустое, создайте новое, нажав единицу");
                        Tree<Person>.ShowTree(tree.R, 3);
                        PrintMenu(textMenu);
                        break;
                    case "3": //Найти минимальный элемент в дереве (например элемент с минимальным возрастом).
                        FindPersonSmallestAge(tree.R);
                        break;
                    case "4": //преобразовать идеально сбалансированное дерево в дерево поиска
                        tree = Tree<Person>.CreateSearchTree(tree);
                        Tree<Person>.ShowTree(tree.R, 3);
                        PrintMenu(textMenu);
                        break;
                    case "5": //удалить дерево из памяти
                        tree.RemoveTreeFromMemory();
                        PrintMenu(textMenu);
                        break;
                    default: //вывод ошибки при некорректном вводе
                        if (operationNumber != "6")
                            Console.WriteLine("\aВпишите номер операции (целое число от 1 до 6)!");
                        break;
                }
            } while (operationNumber != "6"); //цикл действует пока пользователь не введет 6
        }

        /// <summary>
        /// создание новой хэш таблицы объектов Person
        /// </summary>
        /// <returns></returns>
        public static HTable<Person> CreateHTable()
        {
            int size = ReadNumbers.ReadInt(1, 100000, "Впишите размер новой хэш таблицы");
            Console.WriteLine("Хэш таблица создана");
            return new HTable<Person>(size);
        }

        /// <summary>
        /// добавление случайного человека (Person) в таблицу
        /// </summary>
        /// <param name="hTable"></param>
        public static void AddRandomPeople(ref HTable<Person> hTable)
        {
            int numberOfElementsAdd = ReadNumbers.ReadInt(1, hTable.Size, "Впишите кол-во элементов, которые вы хотите добавить");
            for (int i = 0; i < numberOfElementsAdd; i++)
            {
                Person p = new Person();
                p.RandomInit();
                if (hTable.Add(p))
                Console.WriteLine("Элемент был добавлен.");
            }
        }

        /// <summary>
        /// функция для работы с хэш таблицами
        /// </summary>
        static void WorkingWithHashTables()
        {
            string textMenu = "1 - Cоздать новую хэш таблицу\n2 - Вывод хэш таблицы\n3 - Добавить элементы\n4 - Поиск элемента по ключу\n5 - Удаление элемента\n6 - Назад в меню";
            PrintMenu(textMenu);
            HTable<Person> hTable = new HTable<Person>();
            string? operationNumber;
            do
            {
                operationNumber = Console.ReadLine();
                switch (operationNumber)
                {
                    case "1": //создать новую хэш таблицу
                        hTable = CreateHTable();
                        hTable.PrintHTable();
                        PrintMenu(textMenu);
                        break;
                    case "2": //вывод хэш таблицы
                        hTable.PrintHTable();
                        PrintMenu(textMenu);
                        break;
                    case "3": //добавить элемент/ы
                        AddRandomPeople(ref hTable);
                        hTable.PrintHTable();
                        PrintMenu(textMenu);
                        break;
                    case "4": //поиск элемента по ключу
                        Person per1 = new Person();
                        per1.Init();
                        int indexIsFound = hTable.FindElement(per1);
                        if (indexIsFound == -1) //проверка найден ли
                            Console.WriteLine("Человек не был найден");
                        else
                            Console.WriteLine($"Человек был найден на {indexIsFound} месте");
                        break;
                    case "5": //удаление элемента
                        Person per2 = new Person();
                        per2.Init();
                        if (hTable.DelElement(per2)) //был ли удален элемент
                            Console.WriteLine("Элемент был удален");
                        else
                            Console.WriteLine("Элемент не был найден в хэш таблице");
                        hTable.PrintHTable();
                        break;
                    default: //вывод ошибки при некорректном вводе
                        if (operationNumber != "6")
                            Console.WriteLine("\aВпишите номер операции (целое число от 1 до 6!)");
                        break;
                }
            } while (operationNumber != "6"); //цикл действует пока пользователь не введет 6
        }

        static void Main(string[] args)
        {
            string textMenu = "1 - Работа с двунаправленными списками\n2 - Работа с деревьями\n3 - Работа с хэш таблицами\n4 - Завершить работу программы";
            PrintMenu(textMenu);
            string? operationNumber;
            do
            {
                operationNumber = Console.ReadLine();
                switch(operationNumber)
                {
                    case "1": //работа с двунаправленными списками
                        WorkingWithDoublyLinkedList();
                        PrintMenu(textMenu);
                        break;
                    case "2": //работа с деревьями
                        WorkingWithTrees();
                        PrintMenu(textMenu);
                        break;
                    case "3": //работа с хэш таблицами
                        WorkingWithHashTables();
                        PrintMenu(textMenu);
                        break;
                    default: //вывод ошибки при некорректном вводе
                        if (operationNumber != "4")
                            Console.WriteLine("\aВпишите номер операции (целое число от 1 до 4)!");
                        break;
                }
            } while (operationNumber != "4"); //программа действует пока пользователь не введет 4
        }
    }
}