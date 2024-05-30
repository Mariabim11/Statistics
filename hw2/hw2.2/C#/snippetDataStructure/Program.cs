// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;

//Array

Console.WriteLine("How to loop in an array");
int[] a = {1, 2, 3, 4, 5, 6};
foreach (int i in a)
{
    Console.WriteLine(i);
}

Console.WriteLine("How to add element in an array/list");
List<int> b = new List<int> { 1, 2, 3, 4, 5 };
b.Add(6);
for (int i = 0; i < b.Count; i++) //loop for a list
{
    Console.WriteLine(b[i]);
}

b.Remove(4);
for (int i = 0; i < b.Count; i++)
{
    Console.WriteLine(b[i]);
}

Console.WriteLine("How to get an element in an array/list");
Console.WriteLine(b[3]);

Console.WriteLine("How to set an element in an array/list");
b[3] = 71;
Console.WriteLine(b[3]);

Console.WriteLine("How to check the existence of a value in an array/list");
int value = 8;
if (b.Contains(value))
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}

//Dictionary

Console.WriteLine("Dictionary");
Dictionary<string, string> mydict = new Dictionary<string, string>();
//add in a dictionary
KeyValuePair<string, string> kvp = new KeyValuePair<string, string>("Zio", "Paperino");

mydict.Add("Zio", "Paperino"); 
mydict.Add("Jerry", "Scotti");
mydict.Add("tonio", "cartonio");
//How to loop in a dictionary
for (int x = 0; x < mydict.Count; x++) 
{
    Console.WriteLine("{0} {1}", mydict.Keys.ElementAt(x),mydict[mydict.Keys.ElementAt(x)]);

}
//get in a dictionary
string chiaveDaCercare = "Zio";
if (mydict.ContainsKey(chiaveDaCercare))
{
    string valore = mydict[chiaveDaCercare];
    Console.WriteLine($"Key found! The corresponding value is: {valore}");
}

else
{
    Console.WriteLine("Key not found!");
}
    //set in a dictionary
Console.WriteLine("I want to change a value");
if (mydict.ContainsKey(chiaveDaCercare)) //can be also used to chack the existence of a value
{
    string new_valore = "Paperone";
    string valore = mydict[chiaveDaCercare];
    mydict[chiaveDaCercare] = new_valore;
    Console.WriteLine($"Key found! The new corresponding value is: {new_valore}");
    for (int x = 0; x < mydict.Count; x++)
    {
        Console.WriteLine("{0} {1}", mydict.Keys.ElementAt(x), mydict[mydict.Keys.ElementAt(x)]);
    }
}

//rimuovere zio paperone
mydict.Remove(chiaveDaCercare);
for (int x = 0; x < mydict.Count; x++)
{
    Console.WriteLine("{0} {1}", mydict.Keys.ElementAt(x), mydict[mydict.Keys.ElementAt(x)]);
}

//sortedList
SortedList<int, string> sortedList = new SortedList<int, string>();

// Adding elements to the sorted list
sortedList.Add(3, "Three");
sortedList.Add(1, "One");
sortedList.Add(2, "Two");

// Loop through the sorted list
Console.WriteLine("Loop through the sorted list:");
foreach (var item in sortedList)
{
    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
}

// Add new elements
sortedList.Add(4, "Four");

// Remove an element by key
sortedList.Remove(2);

// Get the value by key
int keyToGet = 3;
if (sortedList.ContainsKey(keyToGet))
{
    string val = sortedList[keyToGet];
    Console.WriteLine($"Value for key {keyToGet}: {val}");
}
else
{
    Console.WriteLine($"Key {keyToGet} not found in the sorted list.");
}

// Set the value by key
int keyToSet = 1;
if (sortedList.ContainsKey(keyToSet))
{
    sortedList[keyToSet] = "Updated One";
    Console.WriteLine($"Updated value for key {keyToSet}: {sortedList[keyToSet]}");
}
else
{
    Console.WriteLine($"Key {keyToSet} not found in the sorted list.");
}

// Check the existence of a key
int keyToCheck = 2;
bool keyExists = sortedList.ContainsKey(keyToCheck);
Console.WriteLine($"Key {keyToCheck} exists in the sorted list: {keyExists}");
        

//Hashset
HashSet<int> hashSet = new HashSet<int>();

// Adding
hashSet.Add(3);
hashSet.Add(1);
hashSet.Add(2);

// Loop 
Console.WriteLine("Loop through the HashSet:");
foreach (var item in hashSet)
{
    Console.WriteLine($"Value: {item}");
}

// Add
hashSet.Add(4);

// Remove
int elementToRemove = 2;
bool removed = hashSet.Remove(elementToRemove);
if (removed)
{
    Console.WriteLine($"Removed element: {elementToRemove}");
}
else
{
    Console.WriteLine($"Element {elementToRemove} not found in the HashSet.");
}

// Check if an element exists
int elementToCheck = 3;
bool contains = hashSet.Contains(elementToCheck);
Console.WriteLine($"HashSet contains {elementToCheck}: {contains}");

//Set an element, firs you have to delete it and then recreate ir
if (hashSet.Contains(elementToCheck))
{
    hashSet.Remove(elementToCheck);
    hashSet.Add(30); // Adding the updated value
    Console.WriteLine($"Updated element {elementToCheck} to 30");
}
else
{
    Console.WriteLine($"Element {elementToCheck} not found in the HashSet.");
}

Console.WriteLine("Loop through the modified HashSet:");
foreach (var item in hashSet)
{
    Console.WriteLine($"Value: {item}");
}


// SortedSet
SortedSet<int> sortedSet = new SortedSet<int>();
sortedSet.Add(3);
sortedSet.Add(1);
sortedSet.Add(2);

// Loop
Console.WriteLine("Loop through the SortedSet:");
foreach (var item in sortedSet)
{
    Console.WriteLine($"Value: {item}");
}

// Add 
sortedSet.Add(4);

// Remove
int elementToRemoveS = 2;
bool removedS = sortedSet.Remove(elementToRemoveS);
if (removedS)
{
    Console.WriteLine($"Removed element: {elementToRemove}");
}
else
{
    Console.WriteLine($"Element {elementToRemove} not found in the SortedSet.");
}

// Check if an element exists
int elementToCheckS = 3;
bool containsS = sortedSet.Contains(elementToCheckS);
Console.WriteLine($"SortedSet contains {elementToCheckS}: {contains}");

// Set
if (sortedSet.Contains(elementToCheckS))
{
    sortedSet.Remove(elementToCheckS);
    sortedSet.Add(30); // Adding the updated value
    Console.WriteLine($"Updated element {elementToCheckS} to 30");
}
else
{
    Console.WriteLine($"Element {elementToCheckS} not found in the SortedSet.");
}

Console.WriteLine("Modificato:");
foreach (var item in sortedSet)
{
    Console.WriteLine($"{item}");
}


//queue

Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

// Loop
Console.WriteLine("Loop through the Queue:");
foreach (var item in queue)
{
    Console.WriteLine($"{item}");
}

// Add
queue.Enqueue(4);

// Remove an element
int removeQueue = queue.Dequeue();
Console.WriteLine($"Removed element: {removeQueue}");

// Peek at the front element without removing it
int frontElement = queue.Peek();
Console.WriteLine($"Front element: {frontElement}");

// Check if an element exists
int echeckQueue = 3;
bool containsQ = queue.Contains(echeckQueue);
Console.WriteLine($"Queue contains {echeckQueue}: {containsQ}");

// Loop through the modified Queue
Console.WriteLine("Loop through the modified Queue:");
foreach (var item in queue)
{
    Console.WriteLine($"{item}");
}


// Stack
Stack<int> stack = new Stack<int>();

// Adding elements to the Stack
stack.Push(1);
stack.Push(2);
stack.Push(3);

// Loop 
Console.WriteLine("Loop through the Stack:");
foreach (var item in stack)
{
    Console.WriteLine($"{item}");
}

// Add 
stack.Push(4);

// Remove
int remStack = stack.Pop();
Console.WriteLine($"Removed element: {remStack}");

// get
int topElement = stack.Peek();
Console.WriteLine($"Top element: {topElement}");

// Check if an element exists
int checkStack = 3;
bool containsStack = stack.Contains(checkStack);
Console.WriteLine($"Stack contains {checkStack}: {containsStack}");

// Loop through the modified Stack
Console.WriteLine("Loop through the modified Stack:");
foreach (var item in stack)
{
    Console.WriteLine($"{item}");
}

// LinkedList 
LinkedList<int> linkedList = new LinkedList<int>();
linkedList.AddLast(1);
linkedList.AddLast(2);
linkedList.AddLast(3);

// Loop
Console.WriteLine("Loop through the LinkedList:");
foreach (var item in linkedList)
{
    Console.WriteLine($"{item}");
}

// Add
linkedList.AddLast(4);

// Remove 
int listToremove = 2;
LinkedListNode<int> nodeToRemove = linkedList.Find(listToremove);
if (nodeToRemove != null)
{
    linkedList.Remove(nodeToRemove);
    Console.WriteLine($"Removed element: {listToremove}");
}
else
{
    Console.WriteLine($"Element {elementToRemove} not found in the LinkedList.");
}

// Check if an element exists
int listToCheck = 3;
bool containsList = linkedList.Contains(listToCheck);
Console.WriteLine($"LinkedList contains {listToCheck}: {containsList}");

Console.WriteLine("Modified LinkedList:");
foreach (var item in linkedList)
{
    Console.WriteLine($"{item}");
}

