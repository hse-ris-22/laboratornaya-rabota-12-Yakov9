using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace lab
{
    public class DoublyLinkedList<T>
    {
        //первый элемент списка
        public Point<Person>? Beg { get; set; }
        //последний элемент списка
        public Point<Person>? End { get; set; }
        public int length;

        /// <summary>
        /// правила для длины списка
        /// </summary>
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

        /// <summary>
        /// создание элемента списка рандомом
        /// </summary>
        /// <returns></returns>
        public static Point<Person> MakePointPerson()
        {
            Person person = new Person();
            person.RandomInit(); //инициализируем человека
            Point<Person> p = new Point<Person>(person);
            return p;
        }


        /// <summary>
        /// конструктор с параметром длины
        /// </summary>
        /// <param name="length"></param>
        public DoublyLinkedList(int length)
        {
            Length = length;
            if (length == 0) //проверка длины
            {
                Beg = null;
                End = null;
            }
            else
            {
                Point<Person> beg = MakePointPerson(); //создаем первый элемент
                Point<Person> r = beg;
                for (int i = 1; i < length; i++) //добавляем(присоединяем) остальные элементы
                {
                    Point<Person> p = MakePointPerson();
                    r.Next = p;
                    p.Prev = r;
                    r = p;
                }
                Beg = beg;
                End = r;
            }
        }


        /// <summary>
        /// вывод списка
        /// </summary>
        public void ShowList()
        {
            if (this.length <= 0) //проверка длины
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                Console.WriteLine("Ваш список:");
                Point<Person>? p = Beg;
                while (p!=null)
                {
                    Console.WriteLine(p);
                    p = p.Next;
                }
            }
        }

        //public static object Clone<Person>(DoublyLinkedList<Person> list)
        //{
        //    DoublyLinkedList<Person> newList = new DoublyLinkedList<Person>(Length);
        //    Point<Person>? pOld = Beg; 
        //    Point<Person>? pNew = newList.Beg;
        //    while (pNew is not null)
        //    {
        //        pNew.Data = (T)pOld.Data.Clone();
        //        pNew = pNew?.Next;
        //        pOld = pOld?.Next;
        //    }
        //    newList.Beg.Person.Age = 50;
        //    ShowList();
        //    return newList;
        //}
    }
}
