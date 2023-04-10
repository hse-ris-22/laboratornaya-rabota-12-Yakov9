using lab;
namespace lab.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPoint1() //���� ��� ������������ Point ��� ����������
        {
            Point<int> p = new Point<int>();
            Assert.IsTrue(p.Data == 0 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPoint2() //���� ��� ������������ Point c �����������
        {
            Point<int> p = new Point<int>(4);
            Assert.IsTrue(p.Data == 4 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPointToString() //���� ���������� ToString ��� ������ Point<>
        {
            Point<int> p = new Point<int>(4);
            Assert.IsTrue(p.ToString() == "4 ");
        }

        [TestMethod]
        public void TestDoublyLinkedList() //���� ������������ ������� ������
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("��������");
            Assert.IsTrue(list1?.Beg?.Data == "��������");
        }

        [TestMethod]
        public void TestAddingElementList() //���� ���������� ��������� � ������
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("��������");
            list1.AddElement("������");
            Assert.IsTrue(list1.End?.Data == "������");
        }

        [TestMethod]
        public void TestDeleteElementFromBegList() //���� ��� �������� ������� �������� ������
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("��������");
            list1.AddElement("������");
            list1.DeleteElement(list1?.Beg);
            Assert.IsTrue(list1.Length == 1 && list1.Beg.Next == null);
        }

        [TestMethod]
        public void TestDeleteElementFromEndList() //���� ��� �������� ���������� �������� ������
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("��������");
            list1.AddElement("������");
            list1.DeleteElement(list1?.End);
            Assert.IsTrue(list1.Length == 1 && list1?.Beg?.Next == null);
        }

        [TestMethod]
        public void TestDeleteOneElementList() //���� ��� �������� ������������� �������� ������
        {
            DoublyLinkedList<string>? list1 = new DoublyLinkedList<string>("��������");
            list1.DeleteElement(list1?.Beg);
            Assert.IsTrue(list1.Length == 0 && list1.Beg == null);
        }

        [TestMethod]
        public void TestDeleteElementFromMiddleList() //���� ��� �������� �������� ���-�� � �������� ������
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("��������");
            list1.AddElement("������");
            list1.AddElement("������");
            list1.DeleteElement(list1?.Beg?.Next);
            Assert.IsTrue(list1.Length == 2);
        }

        [TestMethod]
        public void TestCloneDoublyLinkedList() //���� ������������ ������
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("��������");
            list1.AddElement("������");
            DoublyLinkedList<string> list2 = (DoublyLinkedList<string>)list1.Clone();
            list2.End.Data = "123";
            Assert.IsTrue(list2.End.Data == "123" && list1.End.Data == "������");
        }

        [TestMethod]
        public void TestRemoveListMemory() //���� �������� ������ �� ������
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("��������");
            list1.AddElement("������");
            list1.RemoveListFromMemory();
            Assert.IsTrue(list1.End.Data == null && list1.Beg.Data == null && list1.Beg.Next == null); ;
        }
    }
}