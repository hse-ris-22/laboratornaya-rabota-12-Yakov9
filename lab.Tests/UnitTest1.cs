using lab;
using ClassLibrary1;
namespace lab.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPointList1() //тест для конструктора PointList без параметров
        {
            PointList<int> p = new PointList<int>();
            Assert.IsTrue(p.Data == 0 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPointList2() //тест для конструктора PointList c параметрами
        {
            PointList<int> p = new PointList<int>(4);
            Assert.IsTrue(p.Data == 4 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPointListToString() //тест перегрузки ToString для класса PointList<>
        {
            PointList<int> p = new PointList<int>(4);
            Assert.IsTrue(p.ToString() == "4 ");
        }

        [TestMethod]
        public void TestDoublyLinkedList() //тест конструктора двунапр списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("Проверка");
            Assert.IsTrue(list1?.Beg?.Data == "Проверка");
        }

        [TestMethod]
        public void TestAddingElementList() //тест добавления элементов в список
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("Проверка");
            list1.AddElement("второй");
            Assert.IsTrue(list1.End?.Data == "второй");
        }

        [TestMethod]
        public void TestDeleteElementFromBegList() //тест для удаления первого элемента списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("Проверка");
            list1.AddElement("второй");
            list1.DeleteElement(list1?.Beg);
            Assert.IsTrue(list1.Length == 1 && list1.Beg.Next == null);
        }

        [TestMethod]
        public void TestDeleteElementFromEndList() //тест для удаления последнего элемента списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("Проверка");
            list1.AddElement("второй");
            list1.DeleteElement(list1?.End);
            Assert.IsTrue(list1.Length == 1 && list1?.Beg?.Next == null);
        }

        [TestMethod]
        public void TestDeleteOneElementList() //тест для удаления единственного элемента списка
        {
            DoublyLinkedList<string>? list1 = new DoublyLinkedList<string>("Проверка");
            list1.DeleteElement(list1?.Beg);
            Assert.IsTrue(list1.Length == 0 && list1.Beg == null);
        }

        [TestMethod]
        public void TestDeleteElementFromMiddleList() //тест для удаления элемента где-то в середине списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("Проверка");
            list1.AddElement("второй");
            list1.AddElement("третий");
            list1.DeleteElement(list1?.Beg?.Next);
            Assert.IsTrue(list1.Length == 2);
        }

        [TestMethod]
        public void TestCloneDoublyLinkedList() //тест клонирования списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("Проверка");
            list1.AddElement("второй");
            DoublyLinkedList<string> list2 = (DoublyLinkedList<string>)list1.Clone();
            list2.End.Data = "123";
            Assert.IsTrue(list2.End.Data == "123" && list1?.End?.Data == "второй");
        }

        [TestMethod]
        public void TestRemoveListMemory() //тест удаления списка из памяти
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("Проверка");
            list1.AddElement("второй");
            list1.RemoveListFromMemory();
            Assert.IsTrue(list1?.End?.Data == null && list1?.Beg?.Data == null && list1?.Beg?.Next == null); ;
        }

        [TestMethod]
        public void TestPointTree1() //тест для конструктора PointTree без параметров
        {
            PointTree<int> p = new PointTree<int>();
            Assert.IsTrue(p.Data == 0 && p.Right == null && p.Left == null);
        }

        [TestMethod]
        public void TestPointTree2() //тест для конструктора PointTree c параметрами
        {
            PointTree<int> p = new PointTree<int>(4);
            Assert.IsTrue(p.Data == 4 && p.Right == null && p.Left == null);
        }

        [TestMethod]
        public void TestPointTreeToString() //тест перегрузки ToString для класса PointTree<>
        {
            PointTree<int> p = new PointTree<int>(4);
            Assert.IsTrue(p.ToString() == "4 ");
        }

        [TestMethod]
        public void TestTree1() //тест конструктора дерева с 1 параметром - size
        {
            Tree<Person> tree = new Tree<Person>(2);
            Assert.IsTrue(tree?.size == 2);
        }

        [TestMethod]
        public void TestTree2() //тест конструктора дерева с 2 параметрами 
        {
            Person per = new Person("Вася", "Мужской", 26);
            PointTree<Person> p = new PointTree<Person>(per);
            Tree<Person> tree = new Tree<Person>(p, 2);
            Assert.IsTrue(tree?.size == 2);
        }

        [TestMethod]
        public void TestSearchTree() //тест преобразования идеально сбалансированного дерева в дерево поиска
        {
            Person per1 = new Person("Ян", "Мужской", 30);
            PointTree<Person> p = new PointTree<Person>(per1);
            Tree<Person> tree = new Tree<Person>(p, 10);
            tree = Tree<Person>.CreateSearchTree(tree);
            Assert.IsTrue(tree?.R?.Left != null);
        }

        [TestMethod]
        public void TestRemoveTreeFromMemory() //тест удаление дерева
        {
            Tree<Person> tree = new Tree<Person>(3);
            tree.RemoveTreeFromMemory();
            Assert.IsTrue(tree?.R == null && tree?.size == 0);
        }

        [TestMethod]
        public void TestCreateSearchTreeEmpty() // тест создания дерева поиска при пустом дереве
        {
            Tree<Person> tree = new Tree<Person>(3);
            tree.RemoveTreeFromMemory();
            tree = Tree<Person>.CreateSearchTree(tree);
            Assert.IsTrue(tree?.R == null && tree?.size == 0);
        }

        [TestMethod]
        public void TestHTable() //тест для конструктора HTable
        {
            HTable<Person> table = new HTable<Person>();
            Assert.AreEqual(table.Size, 30);
        }

        [TestMethod]
        public void TestPointHTable() //тест для конструктора PointHTable
        {
            Person person = new Person();
            person.Age = 30;
            PointHTable<Person> point = new PointHTable<Person>(person);
            Assert.AreEqual(point.value.Age, 30);
        }


        [TestMethod]
        public void TestPointHTableToString() //тест преобразования PointHTable в string
        {
            Person person = new Person();
            person.Age = 30;
            PointHTable<Person> point = new PointHTable<Person>(person);
            Assert.AreEqual(point.ToString(), "30:Имя NoName, пол Мужской, возраст 30");
        }

        [TestMethod]
        public void AddElementTestHTable1() //тест добавления элементов в таблицу 1
        {
            HTable<Person> table = new HTable<Person>();
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            table.Add(person1);
            Assert.IsTrue(table.table[20] != null);
        }

        [TestMethod]
        public void AddElementTestHTable2() //тест добавления элементов в таблицу 2 (добавление элемента с уже существующим хэш кодом - возникновение коллизии)
        {
            HTable<Person> table = new HTable<Person>();
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            Person person2 = new Person();
            person2.Name = "Вова";
            person2.Age = 20;
            table.Add(person1);
            table.Add(person2);
            Assert.IsTrue(table.table[20] != null && table.table[25] != null && table.table[20].value.Name == "Имя" && table.table[25].value.Name == "Вова");
        }

        [TestMethod]
        public void AddElementTestHTable3() //тест добавления элементов в таблицу 3 (добавление элемента при заполненной хэш таблице)
        {
            HTable<Person> table = new HTable<Person>(10);
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            Person person2 = new Person();
            person2.Name = "Вова";
            person2.Age = 20;
            Person person3 = new Person();
            person3.Name = "Катя";
            person3.Age = 20;
            table.Add(person1);
            table.Add(person2);
            Assert.IsFalse(table.Add(person3));
        }

        [TestMethod]
        public void FindElementHTable1() //тест поиска элемента в хэш тейбл (нашел с 1 раза)
        {
            HTable<Person> table = new HTable<Person>(10);
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            table.Add(person1);
            Assert.IsFalse(table.FindElement(person1) == -1);
        }

        [TestMethod]
        public void FindElementHTable2() //тест поиска элемента в хэш тейбл (нашел не с первого раза из-за коллизий)
        {
            HTable<Person> table = new HTable<Person>(10);
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            Person person2 = new Person();
            person2.Name = "Вова";
            person2.Age = 20;
            table.Add(person1);
            table.Add(person2);
            Assert.IsFalse(table.FindElement(person2) == -1);
        }

        [TestMethod]
        public void FindElementHTable3() //тест поиска элемента в хэш тейбл (не нашел)
        {
            HTable<Person> table = new HTable<Person>(10);
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            table.Add(person1);
            Person person2 = new Person();
            person2.Name = "Вова";
            person2.Age = 20;
            Assert.IsTrue(table.FindElement(person2) == -1);
        }

        [TestMethod]
        public void DelElementHTable1() //тест удаления элемента из хэш тейбл (нашел с 1 раза и удалил)
        {
            HTable<Person> table = new HTable<Person>(10);
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            table.Add(person1);
            Assert.IsTrue(table.DelElement(person1));
        }

        [TestMethod]
        public void DelElementHTable2() //тест удаления элемента из хэш тейбл (не удалил (цикл поиска сработал 1 раз))
        {
            HTable<Person> table = new HTable<Person>(10);
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            Assert.IsFalse(table.DelElement(person1));
        }

        [TestMethod]
        public void DelElementHTable3() //тест удаления элемента из хэш тейбл (не удалил (цикл поиска сработал более одного раза - коллизия))
        {
            HTable<Person> table = new HTable<Person>(10);
            Person person1 = new Person();
            person1.Name = "Имя";
            person1.Age = 20;
            table.Add(person1);
            Person person2 = new Person();
            person2.Name = "Вова";
            person2.Age = 20;
            Assert.IsFalse(table.DelElement(person2));
        }
    }
}