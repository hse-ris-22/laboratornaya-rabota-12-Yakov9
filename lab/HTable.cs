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
    public class HTable<T>
    {
        public PointHTable<T>[] table;
        public int Size { get; }

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
            if (item == null) return false;
            int index = Math.Abs(point.GetHashCode()) % Size;
            if (table[index] == null)
            {
                table[index] = point;
                return true;
            }
            else //в случае возникновения коллизии
            {
                index += 5;
                while (index < Size)
                {
                    if (table[index] == null)
                    {
                        table[index] = point;
                        return true;
                    }
                    if (string.Compare(table[index].ToString(), point.ToString()) == 0) return false;
                    index += 5;
                }
                Console.WriteLine("В хэш таблице недостаточно мест");
                return false;
            }
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
            while (code < Size)
            {
                if (table[code] != null && String.Compare(table[code].value.ToString(), data.ToString()) == 0)
                    return code;
                code += 5;
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
            if (table[code] == null) return false;
            while (code < Size)
            {
                if (table[code] != null && String.Compare(table[code].value.ToString(), data.ToString()) == 0)
                {
                    table[code] = null;
                    return true;
                }
                code += 5;
            }
            return false;
        }

    }
}
