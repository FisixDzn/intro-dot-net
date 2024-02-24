# **2D Arrays - C#**
A 2-Dimensional array in C# is a matrix - akin to a table structure with rows and columns.  
This structure is useful for representing martices, grids, or any data that naturally forms  
a tabular format. You can think of a 2D array a lot like the *grid system* of Battleship.

## C# Handles 2D Arrays *Differently* from Languages like Java
When you declare a multi-dimensional array in C# using syntax like:
~~~ cs
int[,] matrix = new int[3, 3];
~~~
The above line is creating a *single, contiguous* **block of memory** thats **logically** divided into rows and colums.  
***Unlike*** jagged arrays (`int[][]`), where *each row* is an *independent array* (and therefore a *separate* block of memory), a  
regular **multi-dimensional array** (like in the code block above) is stored as a *single, linear* sequence of **elements** in memory. 

## Syntax for Declaring and Initializing 2D Arrays
### Declaration
~~~ cs
int[,] matrix;
~~~
**Declares a 2D array.**
### Initializing
~~~ cs
int[,] matrix = new int[3, 2];
~~~
**Creates a 2D array with 3 rows and 2 colums.**

## Populating 2D Arrays
### Manually
~~~ cs
int[,] matrix = 
{
    {1, 2}, //row 0
    {3, 4}, //row 1
    {5, 6}  //row 2
};
~~~
**Each inner curly brace {} represents a row.**
### For-Loop
~~~ cs
// creates a 2D array with 3 rows and 2 colums
int[,] matrix = new int[3, 2];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        //assigning a value based on row and column
        matrix[row, col] = row + col;
    }
}
~~~
**You can populate a 2D array using nested loops. The outer loop iterates over rows, amd the inner loop iterates over colums.**
- `GetLength(0)` returns the numbers of rows (the length of the first dimension).
- `GetLength(1)` returns the number of columns (the length of the second dimension).
- `Length` returns the total elements in the 2D array. 

## Accessing and Modifying Elements
### Access
~~~ cs
int value = matrix[1, 2];
~~~
**Access element at second row, third colums. (Remember count starts at 0).**
### Modify
~~~ cs
matrix [1, 2] = 10;
~~~
**Modify element at second row, third column. (Again, count starts at 0).**

## Traversing 2D Arrays with Nested Loops
**Traversing a 2D array typically requires nested loops - one loop to go through the rows and another to go through the columns.**
### Classic For-Loop
~~~ cs
int[,] matrix = new matrix[3, 3];

//populating array
for(int i = 0; i < matrix.GetLength(0); i++)
{
    for(int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = (i * j) + 8;
    }
}
//accessing array elements
for(int i = 0; i < matrix.GetLength(0); i++)
{
    for(int j = 0; j < matrix.GetLength(1); j++)
    {
        System.Console.WriteLine(matrix[i, j] + " ");
    }
    System.Console.WriteLine(); //moves onto the next line after each row
}
~~~
### Foreach loop *(Probably Different Than You Expect)*
~~~ cs
int[,] matrix = new int[3, 3];
foreach(int element in matrix)
{
    System.Console.WriteLine(element);
}
~~~
**This loop will go through each element in the order that they are stored in memory, which for a 2D array is typically row by row.**
**You don't have access to the row and column indices in a `foreach` loop. It simply goes through every element, one after the other.**

## Multi-Dimensional vs Jagged Arrays
In C#, you have a clear distinction between a multi-dimensional array and a jagged array.  
C# handles arrays differently than in other languages, like Java. In Java, a 2D array is an  
array of arrays. However, in C#, a square 2D array is a ***single array.***
### Multi-Dimensional Array
~~~ cs
int[,] matrix = new int[3, 3];
~~~
This is more like a matrix. All rows and colums are of *fixed size.*
### Jagged Array
~~~ cs
int[][] jaggedArray = new int[3][];

jaggedArray[0] = new int[3]; //first row
jaggedArray[1] = new int[3]; //second row
jaggedArray[2] = new int[3]; //third row
~~~
This is an *array or arrays* where *each inner array* can have a *different length.*
### Key Differences
#### Initialization
In Java, `new int[3][3]` creates a 3x3 array. In C#, `new int[3, 3]` creates a 3x3 multi-dimensional  
array, whereas `new int[3][]` creates a jagged array with 3 rows (each of which must be initialized seperately).
#### Flexibility
C# explicitly differentiates between fixed-size multi-dimensional arrays and more flexible jagged arrays.  
In Java, a 2D array is generally more like C#'s jagged array.
