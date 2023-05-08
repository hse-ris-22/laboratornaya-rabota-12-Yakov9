using lab;
using ClassLibrary1;
namespace lab.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPointList1() //���� ��� ������������ PointList ��� ����������
        {
            PointList<int> p = new PointList<int>();
            Assert.IsTrue(p.Data == 0 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPointList2() //���� ��� ������������ PointList c �����������
        {
            PointList<int> p = new PointList<int>(4);
            Assert.IsTrue(p.Data == 4 && p.Next == null && p.Prev == null);
        }

        [TestMethod]
        public void TestPointListToString() //���� ���������� ToString ��� ������ PointList<>
        {
            PointList<int> p = new PointList<int>(4);
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
            Assert.IsTrue(list2.End.Data == "123" && list1?.End?.Data == "������");
        }

        [TestMethod]
        public void TestRemoveListMemory() //���� �������� ������ �� ������
        {
            DoublyLinkedList<string> list1 = new DoublyLinkedList<string>("��������");
            list1.AddElement("������");
            list1.RemoveListFromMemory();
            Assert.IsTrue(list1?.End?.Data == null && list1?.Beg?.Data == null && list1?.Beg?.Next == null); ;
        }

        [TestMethod]
        public void TestPointTree1() //���� ��� ������������ PointTree ��� ����������
        {
            PointTree<int> p = new PointTree<int>();
            Assert.IsTrue(p.Data == 0 && p.Right == null && p.Left == null);
        }

        [TestMethod]
        public void TestPointTree2() //���� ��� ������������ PointTree c �����������
        {
            PointTree<int> p = new PointTree<int>(4);
            Assert.IsTrue(p.Data == 4 && p.Right == null && p.Left == null);
        }

        [TestMethod]
        public void TestPointTreeToString() //���� ���������� ToString ��� ������ PointTree<>
        {
            PointTree<int> p = new PointTree<int>(4);
            Assert.IsTrue(p.ToString() == "4 ");
        }

        [TestMethod]
        public void TestTree1() //���� ������������ ������ � 1 ���������� - size
        {
            Tree<Person> tree = new Tree<Person>(2);
            Assert.IsTrue(tree?.size == 2);
        }

        [TestMethod]
        public void TestTree2() //���� ������������ ������ � 2 ����������� 
        {
            Person per = new Person("����", "�������", 26);
            PointTree<Person> p = new PointTree<Person>(per);
            Tree<Person> tree = new Tree<Person>(p, 2);
            Assert.IsTrue(tree?.size == 2);
        }

        [TestMethod]
        public void TestSearchTree() //���� �������������� �������� ����������������� ������ � ������ ������
        {
            Person per1 = new Person("��", "�������", 30);
            PointTree<Person> p = new PointTree<Person>(per1);
            Tree<Person> tree = new Tree<Person>(p, 10);
            tree = Tree<Person>.CreateSearchTree(tree);
            Assert.IsTrue(tree?.R?.Left != null);
        }

        [TestMethod]
        public void TestRemoveTreeFromMemory() //���� �������� ������
        {
            Tree<Person> tree = new Tree<Person>(3);
            tree.RemoveTreeFromMemory();
            Assert.IsTrue(tree?.R == null && tree?.size == 0);
        }

        [TestMethod]
        public void TestCreateSearchTreeEmpty() // ���� �������� ������ ������ ��� ������ ������
        {
            Tree<Person> tree = new Tree<Person>(3);
            tree.RemoveTreeFromMemory();
            tree = Tree<Person>.CreateSearchTree(tree);
            Assert.IsTrue(tree?.R == null && tree?.size == 0);
        }
    }
}