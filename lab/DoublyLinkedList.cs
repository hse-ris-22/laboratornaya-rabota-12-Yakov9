using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace lab
{
    public class DoublyLinkedList<T> where T : ICloneable
    {
        //первый элемент списка
        public Point<T>? Beg { get; set; }
        //последний элемент списка
        public Point<T>? End { get; set; }
        //длина списка
        public int Length { get; set; }


        /// <summary>
        /// конструктор с параметром длины
        /// </summary>
        /// <param name="length"></param>
        public DoublyLinkedList(T data)
        {
            Length = 1;
            Point<T> beg = new Point<T>(data); //создаем первый элемент
            //for (int i = 1; i < length; i++) //добавляем(присоединяем) остальные элементы
            //{
            //    Point<Person> p = MakePointPerson();
            //    r.Next = p;
            //    p.Prev = r;
            //    r = p;
            //}
            Beg = beg;
            End = beg;
        }

        /// <summary>
        /// добавление элемента в список
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(T element)
        {
            Point<T>? p = new Point<T>(element);
            Point<T>? t = this.End;
            this.End.Next = p;
            this.End = p;
            this.End.Prev = t;
            Length++;
        }

        /// <summary>
        /// удаление элемента из списка
        /// </summary>
        /// <param name="p"></param>
        public void DeleteElement(Point<T> p)
        {
            if (this.Length == 1) //удаление единственного элемента списка
            {
                this.Beg = null;
                this.End = null;
            }
            else if (p?.Prev is null) //удаление первого элемента списка
            {
                this.Beg = this.Beg?.Next;
                this.Beg.Prev = null;
            }
            else if (p?.Next is null) //удаление последнего элемента списка
            {
                this.End = this.End?.Prev;
                this.End.Next = null;
            }
            else //удаление элемента в середине
            {
                p.Next.Prev = p?.Prev;
                p.Prev.Next = p?.Next;
            }
            Length--;
        }

        /// <summary>
        /// удаление списка из памяти
        /// </summary>
        /// <param name="list"></param>
        public void RemoveListFromMemory()
        {
            this.Beg.Data = default(T);
            this.Beg.Next = null;
            this.Beg.Prev = null;
            this.End.Data = default(T);
            this.End.Next = null;
            this.End.Prev = null;
            this.Length = 0;
        }


        [ExcludeFromCodeCoverage]
        /// <summary>
        /// вывод списка
        /// </summary>
        public void ShowList()
        {
            if (this.Length <= 0) //проверка длины
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                Console.WriteLine("Ваш список:");
                Point<T>? p = Beg;
                while (p!=null)
                {
                    Console.WriteLine(p);
                    p = p?.Next;
                }
            }
        }

        /// <summary>
        /// клонирование списка
        /// </summary>
        /// <returns></returns>
        public DoublyLinkedList<T> Clone()
        {
            DoublyLinkedList<T> newList = new DoublyLinkedList<T>((T)this.Beg.Data.Clone());
            Point<T>? pOld = Beg.Next;
            for (int i = 0; i < Length -1; i++, pOld = pOld.Next)
            {
                newList.AddElement((T)pOld.Data.Clone());
            }
            return newList;
        }
    }
}
