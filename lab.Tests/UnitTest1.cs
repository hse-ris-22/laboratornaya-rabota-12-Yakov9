using lab;
namespace lab.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPoint1() //тест дл€ конструктора Point без параметров
        {
            Point<int> p = new Point<int>();
            Assert.IsTrue(p.Data == 0 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPoint2() //тест дл€ конструктора Point c параметрами
        {
            Point<int> p = new Point<int>(4);
            Assert.IsTrue(p.Data == 4 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPointToString() //тест перегрузки ToString дл€ класса Point<>
        {
            Point<int> p = new Point<int>(4);
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
            Assert.IsTrue(list2.End.Data == "123" && list1.End.Data == "второй");
        }

        [TestMethod]
        public void TestRemoveListMemory() //тест удалени€ списка из пам€ти
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("ѕроверка");
            list1.AddElement("второй");
            list1.RemoveListFromMemory();
            Assert.IsTrue(list1.End.Data == null && list1.Beg.Data == null && list1.Beg.Next == null); ;
        }
    }
}