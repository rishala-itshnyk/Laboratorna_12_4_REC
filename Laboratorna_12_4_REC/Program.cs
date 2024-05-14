 using System;

public class Node {
    public int data;
    public Node next;
    
    public Node(int data) {
        this.data = data;
        this.next = null;
    }
}

public class CircularLinkedList {
    public Node head;
    public Node tail;
    
    public CircularLinkedList() {
        this.head = null;
        this.tail = null;
    }

    public void CreateCircularList(int[] values, int index = 0) {
        if (index >= values.Length) {
            if (head != null) {
                tail.next = head;
            }
            return;
        }

        Node newNode = new Node(values[index]);

        if (head == null) {
            head = newNode;
            tail = newNode;
        }
        else {
            tail.next = newNode;
            tail = newNode;
        }

        CreateCircularList(values, index + 1);
    }



    private void SwapPairsRecursive(Node current) {
        if (current == null || current == tail) // Перевірка на останній елемент
            return;

        int temp = current.data;
        current.data = current.next.data;
        current.next.data = temp;

        SwapPairsRecursive(current.next.next);
    }

    public void SwapPairs() {
        if (head == null || head == tail) // Перевірка на порожній список або список з одним елементом
            return;

        SwapPairsRecursive(head);
    }


    private void DisplayCircularListRecursive(Node current) {
        Console.Write(current.data + " ");
        if (current.next != head) // Перевірка, чи ми досягли початку
            DisplayCircularListRecursive(current.next);
    }

    public void DisplayCircularList() {
        if (head == null) // Перевірка на пустий список
            return;

        DisplayCircularListRecursive(head);
        Console.WriteLine();
    }

}

class Program {
    static void Main(string[] args) {
        CircularLinkedList circularList = new CircularLinkedList();
        int[] values = { 1, 2, 3, 4, 5 };
        
        circularList.CreateCircularList(values);
        
        Console.Write("Original List: ");
        circularList.DisplayCircularList();
        
        circularList.SwapPairs();
        
        Console.Write("List after swapping pairs: ");
        circularList.DisplayCircularList();
    }
}