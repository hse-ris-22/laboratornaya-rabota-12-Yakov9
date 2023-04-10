using ClassLibrary1;
using System.Collections.Generic;
using System.Drawing;

namespace lab
{
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
        static void DeleteLastPersonByName(ref DoublyLinkedList<Person>? list, string? name)
        {
            if (list?.length <= 0) //проверка длины списка
                Console.WriteLine("Ваш список пуст");
            Point<Person>? p = list.End;
            bool isFound = false;
            for (int i = list.length; i > 0; i--, p = p?.Prev)
            {
                if (p?.Data.Name == name)
                {
                    if (list.length == 1) //удаление единственного элемента списка
                    {
                        list.Beg = null;
                        list.End = null;
                    }
                    else if (p?.Prev is null) //удаление первого элемента списка
                    {
                        list.Beg = list.Beg?.Next;
                        list.Beg.Prev = null;
                    }
                    else if (p?.Next is null) //удаление последнего элемента списка
                    {
                        list.End = list.End?.Prev;
                        list.End.Next = null;
                    }
                    else //удаление элемента в середине
                    {
                        p.Next.Prev = p.Prev;
                        p.Prev.Next = p.Next;
                    }
                    isFound = true;
                    list.length--;
                }
            }
            if (!isFound) //если элемент был не найден
                Console.WriteLine($"Элемент c именем {name} не был найден в списке");
            else
            {
                if (list.length == 0) //если единственный элемент был удален
                    Console.WriteLine($"Элемент c именем {name} был удален. Ваш список теперь пуст.");
                else
                    Console.WriteLine($"Элемент c именем {name} был удален.");
            }
        }

        /// <summary>
        /// функция для работы с двунаправленным списком
        /// </summary>
        static void WorkingWithDoublyLinkedList()
        {
            string textMenu = "1 - Cоздать новый двунаправленный список из объектов Person\n2 - Вывести список\n3 - Удалить последний элемент с заданным именем\n4 - Клонирование списка\n5 - \n6 - Завершить работу программы";
            PrintMenu(textMenu);
            DoublyLinkedList<Person>? list = new DoublyLinkedList<Person>(3); //создаем двунаправленный список
            string? operationNumber;
            do
            {
                operationNumber = Console.ReadLine();
                switch (operationNumber)
                {
                    case "1": //создание нового листа
                        Console.WriteLine("Впишите длину нового списка");
                        int len = ReadNumbers.ReadInt(1, 100);
                        list = new DoublyLinkedList<Person>(len);
                        Console.WriteLine("Список был создан");
                        list.ShowList();
                        PrintMenu(textMenu);
                        break;
                    case "2": //вывод списка
                        list?.ShowList();
                        break;
                    case "3": //удаление последнего элемента с заданным именем
                        Console.WriteLine("Впишите имя человека, которого хотите удалить из списка");
                        string? nameToDelete = Console.ReadLine();
                        DeleteLastPersonByName(ref list, nameToDelete);
                        PrintMenu(textMenu);
                        break;
                    case "4": //клонирование списка
                        //list = (DoublyLinkedList<Person>)list.Clone();
                        //list.ShowList();
                        //PrintMenu(textMenu);
                        break;
                    case "5": 
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
            WorkingWithDoublyLinkedList();
        }
    }
}