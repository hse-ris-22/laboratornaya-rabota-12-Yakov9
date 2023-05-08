using lab;
using ClassLibrary1;
namespace lab.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPointList1() //тест дл€ конструктора PointList без параметров
        {
            PointList<int> p = new PointList<int>();
            Assert.IsTrue(p.Data == 0 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPointList2() //тест дл€ конструктора PointList c параметрами
        {
            PointList<int> p = new PointList<int>(4);
            Assert.IsTrue(p.Data == 4 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPointListToString() //тест перегрузки ToString дл€ класса PointList<>
        {
            PointList<int> p = new PointList<int>(4);
            Assert.IsTrue(p.ToString() == "4 ");
        }

        [TestMethod]
        public void TestDoublyLinkedList() //тест конструктора двунапр списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("ѕроверка");
            Assert.IsTrue(list1?.Beg?.Data == "ѕроверка");
        }

        [TestMethod]
        public void TestAddingElementList() //тест добавлени€ элементов в список
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("ѕроверка");
            list1.AddElement("второй");
            Assert.IsTrue(list1.End?.Data == "второй");
        }

        [TestMethod]
        public void TestDeleteElementFromBegList() //тест дл€ удалени€ первого элемента списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("ѕроверка");
            list1.AddElement("второй");
            list1.DeleteElement(list1?.Beg);
            Assert.IsTrue(list1.Length == 1 && list1.Beg.Next == null);
        }

        [TestMethod]
        public void TestDeleteElementFromEndList() //тест дл€ удалени€ последнего элемента списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("ѕроверка");
            list1.AddElement("второй");
            list1.DeleteElement(list1?.End);
            Assert.IsTrue(list1.Length == 1 && list1?.Beg?.Next == null);
        }

        [TestMethod]
        public void TestDeleteOneElementList() //тест дл€ удалени€ единственного элемента списка
        {
            DoublyLinkedList<string>? list1 = new DoublyLinkedList<string>("ѕроверка");
            list1.DeleteElement(list1?.Beg);
            Assert.IsTrue(list1.Length == 0 && list1.Beg == null);
        }

        [TestMethod]
        public void TestDeleteElementFromMiddleList() //тест дл€ удалени€ элемента где-то в середине списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("ѕроверка");
            list1.AddElement("второй");
            list1.AddElement("третий");
            list1.DeleteElement(list1?.Beg?.Next);
            Assert.IsTrue(list1.Length == 2);
        }

        [TestMethod]
        public void TestCloneDoublyLinkedList() //тест клонировани€ списка
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("ѕроверка");
            list1.AddElement("второй");
            DoublyLinkedList<string> list2 = (DoublyLinkedList<string>)list1.Clone();
            list2.End.Data = "123";
            Assert.IsTrue(list2.End.Data == "123" && list1?.End?.Data == "второй");
        }

        [TestMethod]
        public void TestRemoveListMemory() //тест удалени€ списка из пам€ти
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("ѕроверка");
            list1.AddElement("второй");
            list1.RemoveListFromMemory();
            Assert.IsTrue(list1?.End?.Data == null && list1?.Beg?.Data == null && list1?.Beg?.Next == null); ;
        }

        [TestMethod]
        public void TestPointTree1() //тест дл€ конструктора PointTree без параметров
        {
            PointTree<int> p = new PointTree<int>();
            Assert.IsTrue(p.Data == 0 && p.Right == null && p.Left == null);
        }

        [TestMethod]
        public void TestPointTree2() //тест дл€ конструктора PointTree c параметрами
        {
            PointTree<int> p = new PointTree<int>(4);
            Assert.IsTrue(p.Data == 4 && p.Right == null && p.Left == null);
        }

        [TestMethod]
        public void TestPointTreeToString() //тест перегрузки ToString дл€ класса PointTree<>
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
            Person per = new Person("¬ас€", "ћужской", 26);
            PointTree<Person> p = new PointTree<Person>(per);
            Tree<Person> tree = new Tree<Person>(p, 2);
            Assert.IsTrue(tree?.size == 2);
        }

        [TestMethod]
        public void TestSearchTree() //тест преобразовани€ идеально сбалансированного дерева в дерево поиска
        {
            Person per1 = new Person("ян", "ћужской", 30);
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
        public void TestCreateSearchTreeEmpty() // тест создани€ дерева поиска при пустом дереве
        {
            Tree<Person> tree = new Tree<Person>(3);
            tree.RemoveTreeFromMemory();
            tree = Tree<Person>.CreateSearchTree(tree);
            Assert.IsTrue(tree?.R == null && tree?.size == 0);
        }
    }
}