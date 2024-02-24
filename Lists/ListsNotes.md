# **Lists - C#**
Lists in C# are part of the System.Collections.Generic namespace and provide a way to work with  
collections of objects. Unlike arrays, lists are dynamic, meaning they can grow and shrink in size  
dyunamically at runtime.

## Lists vs Arrays
### Similarities to Arrays
- *Type-Specific:* Like arrays, lists are stringly typed. You define the type of elements they can  
contain.
- *Index-Based Access:* Elements in a list can be accessed via an index, much like arrays.
### Differences from Arrays
- *Size Flexibility:* Arrays have a fixed size. Once an array's size is set, it cannot be changed.  
Lists, however, can grow and shrink dynamically.
- *Rich Set of Methods:* Lists provide a richer set of methods for manipulation (e.g. adding +  
removing elements) compared to arrays.

## Syntax and Usage
~~~ cs
//creates a new empty list of integers
List<int> numbers = new List<int>();
~~~
This declares a list of integers and initializes an empty List. The type of elements the list can  
hold is specified within the angle brackets `<>` (this is the "generic" part).

## Common Methods and Examples
### **Adding Elements: Use the `Add` method to add elements to the end of the list.**
~~~ cs
numbers.Add(1); //adds 1 to the list
numbers.Add(2); //adds 2 to the list
~~~
---
### **Adding Range of Elements: `AddRange` method adds collection of elements to the end of the list.**
~~~ cs
List<int> numbers = new List<int> {1, 2, 3};
int[] moreNumbers = {4, 5, 6};

numbers.AddRange(moreNumbers);

//numbers now contains: 1, 2, 3, 4, 5, 6
foreach (var number in numbers)
{
    System.Console.WriteLine(number);
}
~~~
---
### **Remove Element by Value: `Remove` method removes an element by value.**
~~~ cs
numbers.Remove(1); //removes the first occurrence of 1 from the list
~~~
---
### **Remove Element at Index: `RemoveAt` method removes an element at a certain index**
~~~ cs
numbers.RemoveAt(0); //removes the element at index 0
~~~
---
### **Remove All Elements Satisfying Predicate: `RemoveAll`**
~~~ cs
List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

numbers.RemoveAll(n => n < 5);

//remaining numbers: 5, 6, 7, 8, 9, 10
foreach(var number in numbers)
{
    System.Console.WriteLine(number);
}
~~~
**Removes numbers less than a threshold.**
~~~ cs
List<string> fruits = new List<string> {"Apple", "Banana", "Cherry", "Avocado", "Blueberry"};
fruits.RemoveAll(fruit => fruit.StartsWith("A"));

//remaining fruits: banana, cherry, blueberry
foreach(var fruit in fruits)
{
    System.Console.WriteLine(fruit);
}
~~~
**Removes strings that start with a specific character.**
~~~ cs
List<string?> names = new List<string> {"Alice", null, "Bob", null, "Charlie"};
names.RemoveAll(name => name == null);

//remaining names: alice, bob, charlie
foreach(var name in names)
{
    System.Console.WriteLine(name);
}
~~~
**Removes all the `null` values in the list.**

---
### **Clearing the List: The `Clear` method removes all elements from the list.**
~~~ cs
numbers.Clear(); //clears the list
~~~
---
### **Find First Element Satisfying Predicate: `Find`**
~~~ cs
List<int> numbers = new List<int> {1, 3, 5, 6, 7, 8};
int firstEven = numbers.Find(n => n % 2 == 0);

System.Console.WriteLine(firstEven); //output: 6
~~~
**Finds the first even number.**
~~~ cs
List<Person> people = new List<Person>
{
    new Person("Bob"),
    new Person("Charlie"),
    new Person("Alice"),
    new Person("David")
};
Person alice = people.Find(person => person.Name == "Alice");

System.Console.WriteLine(alice?.Name ?? "Not Found"); //output: alice
~~~
**Finds Person by name.**
~~~ cs
List<Product> products = new List<Product>
{
    new Product("Bread", 2.99m),
    new Product("TV", 299.99m),
    new Product("Apple", 0.99m)
};
Product affordableProduct = products.Find(product => product.Price < 10m)

System.Console.WriteLine(affordableProduct?.Name ?? "No affordable product found"); //output: bread
~~~
**Finds Product below a certain price.**

---
### **Find All Elements Satisfying Predicate: `FindAll`**
~~~ cs
List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
List<int> evenNumbers = numbers.FindAll(n => n % 2 == 0);

//output: 2, 4, 6, 8, 10
foreach(var number in evenNumbers)
{
    System.Console.WriteLine(number);
}
~~~
**Finds all even numbers.**
~~~ cs
List<string> names = new List<string> {"Alice", "Bob", "Charlie", "David", "Eve"};
List<string> namesStartingWithC = names.FindAll(name => name.StartsWith("C"));

//output: charlie
foreach(var name in namesStartingWithC)
{
    System.Console.WriteLine(name);
}
~~~
**Finds all names starting with a specific letter.**
~~~ cs
List<Product> products = new List<Product>
{
    new Product("Bread", 2.99m),
    new Product("TV", 299.99m),
    new Product("Apple", 0.99m)
};
List<Product> affordableProducts = products.FindAll(product => product.Price < 10m);

//output: apple, bread
foreach(var product in affordableProducts)
{
    System.Console.WriteLine(product.Name);
}
~~~
**Finds all Products below a certain price.**

---
### **Get Elements in Range: `GetRange`**
~~~ cs
List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

//extracts a range starting at index 4 with a count of 3
List<int> subrange = numbers.GetRange(4, 3);

//subrange countains: 5, 6, 7
foreach(var number in subrange)
{
    System.Console.WriteLine(number);
}
~~~
~~~ cs
List<string> fruits = new List<string> {"Apple", "Banana", "Cherry", "Date", "Elderberry"};

// extracts strings from index 1 to 3
List<string> selectedFruits = fruits.GetRange(1, 3)

foreach(var fruit in selectedFruits)
{
System.Console.WriteLine(fruit.Name);
}
~~~
---
### **Count: The `Count` property gets the number of elements contained in the list.**
~~~ cs
int count = numbers.Count; 
~~~
---
### **Accessing Elements: Access elements by index, similar to arrays.**
~~~ cs
int firstNumber = numbers[0]; //accesses the first element
~~~
---
### **Inserting Elements: The `Insert` method inserts an element at a specified index.**
~~~ cs
numbers.Insert(1, 3); //inserts a 3 at index 1
~~~
---
### **Finding Elements: The `Contains` method checks if a list contains a specific element.**
~~~ cs
bool hasThree = numbers.Contains(3);
~~~
---
### **Iteration: Use a `foreach` loop to iterate over each element in the list.**
~~~ cs
foreach(int number in numbers)
{
    System.Console.WriteLine(number);
}
~~~
---
## Shallow vs Deep Copies
### Shallow Copy
A shallow copy of an object copies all of the member field values. This means that any reference  
types among the fields are copied as a reference, not the underlying object itself. Therefore, both  
the original and the copy reference the same object. For value types (like `int`, `double`, etc), a  
shallow copy duplicates the values.
### Deep Copy
A deep copy copies all fields, and for reference types, it creates copies of the objects it refers to.  
Deep copying an object involves creating a new object and then recursively copying all objects  
referenced by the fields, achieving complete independence from the original object. 