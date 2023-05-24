using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class HTable<T> where T : ICloneable
    {
        public PointHTable<T>[] table;
        public int Size { get; set; }

        /// <summary>
        /// конструктор с параметром длины
        /// </summary>
        /// <param name="size"></param>
        public HTable(int size = 30)
        {
            Size = size;
            table = new PointHTable<T>[Size];
        }

        /// <summary>
        /// добавление элементов в хэш таблицу
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(T item)
        {
            PointHTable<T> point = new PointHTable<T>(item);
            int index = Math.Abs(point.GetHashCode()) % Size;
            int initialIndex = index;
            if (table[index] == null)
            {
                table[index] = point;
                return true;
            }
            else //в случае возникновения коллизии
            {
                index = (index + 1) % Size;
                while (index != (initialIndex - 1))
                {
                    if (table[index] == null)
                    {
                        table[index] = point;
                        return true;
                    }
                    if (string.Compare(table[index].ToString(), point.ToString()) == 0) return false;
                    index = (index + 1) % Size;
                }
                table = Rewrite().table;
                Add(item);
                Console.WriteLine("В хэш таблице недостаточно мест, она увеличена");
                return false;
            }
        }

        public HTable<T> Rewrite()
        {
            HTable<T> table2 = new HTable<T>(Size*2);
            for (int i = 0; i < this.Size; i++)
            {
                if (table[i] == null) Console.WriteLine(i + " : ");
                else
                {
                    table2.Add(table[i].value);
                }
            }
            Size = Size*2;
            return table2;
        }


        [ExcludeFromCodeCoverage]
        /// <summary>
        /// печать хэш таблицы
        /// </summary>
        public void PrintHTable()
        {
            if (table == null) //если пустая
            { 
                Console.WriteLine("Таблица пустая!"); 
                return; 
            }
            for (int i = 0; i < Size; i++)
            {
                if (table[i] == null) Console.WriteLine(i + " : ");
                else
                {
                    Console.Write(i + " : ");
                    Console.Write(table[i].ToString());
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// поиск элемента в хэш таблице
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int FindElement(T data)
        {
            PointHTable<T> point1 = new PointHTable<T>(data);
            int code = Math.Abs(point1.GetHashCode()) % Size;
            int initialCode = code;
            while (code != (initialCode - 1))
            {
                if (table[code] != null && String.Compare(table[code].value.ToString(), data.ToString()) == 0)
                    return code;
                code = (code + 1) % Size;
            }
            return -1;
        }

        /// <summary>
        /// удаление элемента из хэш таблицы
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool DelElement(T data)
        {
            PointHTable<T> point1 = new PointHTable<T>(data);
            int code = Math.Abs(point1.GetHashCode()) % Size;
            int initialCode = code;
            if (table[code] == null) return false;
            while (code != (initialCode-1))
            {
                if (table[code] != null && String.Compare(table[code].value.ToString(), data.ToString()) == 0)
                {
                    table[code] = null;
                    return true;
                }
                code = (code + 1) % Size;
            }
            return false;
        }

    }
}
