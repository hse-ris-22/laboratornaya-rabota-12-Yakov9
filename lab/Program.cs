using ClassLibrary1;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

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
            } while (operationNumber != "6"); //программа действует пока пользователь не введет 6
        }

        /// <summary>
        /// функция для работы с деревьями
        /// </summary>
        static void WorkingWithTrees()
        {
            string textMenu = "1 - Cоздать новое идеально сбалансированное дерево\n2 - Вывести дерево\n3 - \n4 - \n5 - \n6 - Назад в меню";
            PrintMenu(textMenu);
             //создаем идеально сбалансированное список дерево объектов Person
            string? operationNumber;
            do
            {
                operationNumber = Console.ReadLine();
                switch (operationNumber)
                {
                    case "1": //создание нового идеально сбалансированного дерева
                        PrintMenu(textMenu);
                        break;
                    case "2": //вывод списка
                        break;
                    case "3": //удаление последнего элемента с заданным именем
                        PrintMenu(textMenu);
                        break;
                    case "4": //клонирование списка
                        PrintMenu(textMenu);
                        break;
                    case "5": //удалить список из памяти
                        PrintMenu(textMenu);
                        break;
                    default: //вывод ошибки при некорректном вводе
                        if (operationNumber != "6")
                            Console.WriteLine("\aВпишите номер операции (целое число от 1 до 6)!");
                        break;
                }
            } while (operationNumber != "6"); //программа действует пока пользователь не введет 6
        }
        static void Main(string[] args)
        {
            string textMenu = "1 - Работа с двунаправленными списками\n2 - Работа с деревьями\n3-Завершить работу программы";
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
                        PrintMenu(textMenu);
                        break;
                    default: //вывод ошибки при некорректном вводе
                        if (operationNumber != "3")
                            Console.WriteLine("\aВпишите номер операции (целое число от 1 до 3)!");
                        break;
                }
            } while (operationNumber != "3"); //программа действует пока пользователь не введет 3
        }
    }
}