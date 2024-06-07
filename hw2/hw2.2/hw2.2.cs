```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ARRAY ---------------------------------------------------------------------------------------------------
            */
            int[] array = { 1, 2, 3, 4, 5 };

            // Loop
            foreach (int element in array)
            {
                Console.WriteLine(element);
            }

            int val3 = array[3]; // Get

            array[1] = 7; // Set

            // Add value
            int[] originalArray = { 1, 2, 3, 4, 5 };
            int newElement = 6;
            int[] updatedArray = AddElement(originalArray, newElement);

            // Remove element
            int[] originalArray2 = { 1, 2, 3, 4, 5 };
            int elementToRemove = 3;
            int[] updatedArray2 = RemoveElement(originalArray2, elementToRemove);

            /*
            LIST ---------------------------------------------------------------------------------------------------
            */
            List<int> myList = new List<int>();

            // Loop
            for (int i = 0; i < myList.Count; i++)
            {
                int item = myList[i];
            }

            // Foreach loop
            foreach (int item in myList)
            {
            }

            myList.Add(10); // Add

            int item = myList[0]; // Get

            myList.Remove(10); // Remove

            myList.RemoveAt(0); // Remove at index

            myList.RemoveAll(item => item == 5); // Remove if matches condition

            bool exists = myList.Contains(10); // Check existence

            int index = myList.IndexOf(10); // Find index

            myList[index] = 20; // Set

            myList.Sort(); // Sort

            /*
            DICTIONARY ---------------------------------------------------------------------------------------------------
            */
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            // Loop
            foreach (var kvp in dictionary)
            {
                string key = kvp.Key;
                string value = kvp.Value;
            }

            dictionary.Add("Monkey", "value"); // Add.

            dictionary["Monkey"] = "updated value"; // Overwrites value if key exists, otherwise adds a new key-value pair.

            dictionary.Remove("Monkey"); // Removes key:value.

            string valueFromDictionary = dictionary["Monkey"]; // Get

            bool keyExists = dictionary.ContainsKey("Monkey"); // Check key existence.

            int count = dictionary.Count; // Returns the number of key-value pairs in the dictionary.

            /*
            SORTED LIST ---------------------------------------------------------------------------------------------------
            */
            SortedList<int, string> sortedList = new SortedList<int, string>();

            // Loop 
            foreach (var key in sortedList.Keys)
            {
                string valueFromSortedList = sortedList[key];
            }

            sortedList.Add(1, "value"); // Add

            sortedList.Remove(1); // Remove

            string valueFromSortedList2 = sortedList[1]; // Get

            bool containsKey = sortedList.ContainsKey(1); // Check key existence

            bool containsValue = sortedList.ContainsValue("value"); // Check value existence

            int countFromSortedList = sortedList.Count; // Number of key-value pairs

            /*
            HASHSET ---------------------------------------------------------------------------------------------------
            */
            HashSet<int> myHashSet = new HashSet<int>();

            // Loop 
            foreach (var item in myHashSet)
            {
            }

            myHashSet.Add(1); // Add 

            myHashSet.Remove(1); // Remove 

            bool existsInHashSet = myHashSet.Contains(1); // Check existence

            int countFromHashSet = myHashSet.Count; // Number of elements

            /*
            SORTEDSET ---------------------------------------------------------------------------------------------------
            */
            SortedSet<int> sortedSet = new SortedSet<int>();

            // Loop
            foreach (int element in sortedSet)
            {
            }

            sortedSet.Add(1); // Add

            sortedSet.Remove(1); // Remove 

            sortedSet.Clear(); // Remove all

            bool containsInSortedSet = sortedSet.Contains(1); // Check existence

            int minFromSortedSet = sortedSet.Min; // Get Min.

            int maxFromSortedSet = sortedSet.Max; // Get Max.

            int countFromSortedSet = sortedSet.Count; // Number of elements


            /*
            QUEUE ---------------------------------------------------------------------------------------------------
            */
            Queue<int> queue = new Queue<int>();

            // Loop
            foreach (int itemInQueue in queue)
            {
            }

            queue.Enqueue(1); // Add

            int dequeuedItem = queue.Dequeue(); // Remove (front of queue)

            int peekedItem = queue.Peek(); // Get front element

            bool isEmptyQueue = queue.Count == 0; // Check if empty

            bool existsInQueue = queue.Contains(1); // Check existence

            int countInQueue = queue.Count; // Number of elements


            /*
            STACK ---------------------------------------------------------------------------------------------------
            */
            Stack<int> stack = new Stack<int>();

            // Loop
            foreach (int itemInStack in stack)
            {
            }

            stack.Push(1); // Add

            int poppedItem = stack.Pop(); // Remove

            int topItem = stack.Peek(); // Get

            bool isEmptyStack = stack.Count == 0; // Check if empty

            bool existsInStack = stack.Contains(1); // Check existence

            int countInStack = stack.Count; // Number of elements


            /*
            LINKED LIST ---------------------------------------------------------------------------------------------------
            */
            LinkedList<string> linkedList = new LinkedList<string>();

            // Add elements to the LinkedList
            linkedList.AddLast("Tiger");
            linkedList.AddLast("Elephant");
            linkedList.AddLast("Zebra");

            // Iterating through a LinkedList
            foreach (string item in linkedList)
            {
                Console.WriteLine(item);
            }

            // Remove elements:
            linkedList.Remove("Elephant"); // Remove a specific element
            linkedList.RemoveFirst(); // Remove the first element
            linkedList.RemoveLast(); // Remove the last element

            // Check if an element exists:
            bool containsInLinkedList = linkedList.Contains("Zebra");

            // Set (modify) an element by finding its node:
            LinkedListNode<string> nodeToModify = linkedList.Find("Tiger");
            if (nodeToModify != null)
            {
                nodeToModify.Value = "Giraffe";
            }

            // Use LinkedListNode<T> for more control:
            LinkedListNode<string> newNode = linkedList.AddAfter(nodeToModify, "Rhino"); // Add "Rhino" after "Giraffe"
            linkedList.AddBefore(newNode, "Panda"); // Add "Panda" before "Rhino"
