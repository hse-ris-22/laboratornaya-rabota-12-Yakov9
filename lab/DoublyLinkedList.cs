using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace lab
{
    public class DoublyLinkedList
    {
        public Point? Beg { get; set; }
        public Point? End { get; set; }
        public int length;

        public int Length
        {
            get => length;
            set
            {
                if (value >= 0)
                    length = value;
                else
                {
                    length = 0;
                }
            }
        }
        public static Point MakePoint()
        {
            Person person = new Person();
            person.RandomInit();
            Point p = new Point(person);
            return p;
        }

        public DoublyLinkedList(int length)
        {
            Length = length;
            if (length == 0)
            {
                Beg = null;
                End = null;
            }
            else
            {
                Point beg = MakePoint();
                //Console.WriteLine($"Добавляем элемент {beg}");
                Point r = beg;
                for (int i = 1; i < length; i++)
                {
                    Point p = MakePoint();
                    //Console.WriteLine($"Добавляем элемент {p}");
                    r.Next = p;
                    p.Prev = r;
                    r = p;
                }
                Beg = beg;
                End = r;
            }
        }

        public void ShowList()
        {
            if (this.length <= 0)
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                Console.WriteLine("Ваш список:");
                Point? p = Beg;
                while (p!=null)
                {
                    Console.WriteLine(p);
                    p = p.Next;
                }
            }
        }
    }
}
