using ClassLibrary1;
using System.Drawing;

namespace lab
{
    internal class Program
    {
        static void DeleteLastPersonByName(ref DoublyLinkedList? list, string? name)
        {
            Point? p = list.End;
            bool isFound = false;
            if (list.length <= 0)
                Console.WriteLine("Ваш список пуст");
            for (int i = list.length; i > 0; i--, p = p.Prev)
            {
                if (p.Person.Name == name)
                {
                    if (list.length == 1)
                    {
                        list.Beg = null;
                        list.End = null;
                    }
                    else if (p.Prev is null)
                    {
                        list.Beg = list.Beg.Next;
                        list.Beg.Prev = null;
                    }
                    else if (p.Next is null)
                    {
                        list.End = list.End.Prev;
                        list.End.Next = null;
                    }
                    else
                    {
                        p.Next.Prev = p.Prev;
                        p.Prev.Next = p.Next;
                    }
                    isFound = true;
                    list.length--;
                }
            }
            if (!isFound)
                Console.WriteLine($"Элемент c именем {name} не был найден в списке");
            else
            {
                if (list.length == 0)
                    Console.WriteLine($"Элемент c именем {name} был удален. Ваш список теперь пуст.");
                else
                    Console.WriteLine($"Элемент c именем {name} был удален.");
            }
        }

        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList(10);
            list.ShowList();
            Console.WriteLine("Впишите имя человека, которого хотите удалить из списка");
            string? nameToDelete;
            nameToDelete = Console.ReadLine();
            DeleteLastPersonByName(ref list, nameToDelete);
            list.ShowList();
            Console.WriteLine($"\n {list.length} {list.Beg} {list.End}");
        }
    }
}