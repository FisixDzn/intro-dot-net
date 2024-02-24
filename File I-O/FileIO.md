# **File I/O - C#**
The following are essential methods for working with files and directories in C#, using the  
`System.IO` namespace for file operations and `System.Text.Json` for JSON  
serialization/deserialization.

## Read Input From User
The `Console.ReadLine()` method is a fundamental part of C#'s `System` namespace, providing  
an easy way to read input from the console as a string. This method waits for the user to input  
text followed by the Enter key before proceeding with the execution of the subsequent code.
### Basic Usage
~~~ cs
Console.WriteLine("Please enter your name:");
string name = Console.ReadLine();
Console.WriteLine($"Hello, {name}!");
~~~
In this example, the program prompts the user to enter their name. The `Console.ReadLine()`  
method captures the user's input as a string, which is then stored in the variable `name`. Finally,  
the program greets the user with the entered name.
### Handling Empty or Null Input
`Console.ReadLine()` returns `null` if the input stream is redirected and no more input is  
available. However, in normal console applications, it will wait for user input indefiitely  
until the Enter key is pressed. If the user simply presses Enter without typing anything,  
`Console.ReadLine()` returns an empty string (`""`).  
To handle empty or null input, you can use conditional statements:
~~~ cs
Console.WriteLine("Enter your favorite color:");
string color = Console.ReadLine();

if(string.IsNullOrEmpty(color))
{
    Console.WriteLine("No color entered.");
}
else
{
    Console.WriteLine($"Youfavorite color is {color}.");
}
~~~
### Parsing Numeric Input
Often, you'll want the user to input numeric values. Since `Console.ReadLine()` returns a  
string, you'll need to parse this string to the desired numeric type:
~~~ cs
Console.WriteLine("Enter your age:");
string input = Console.ReadLine();
int age;

if(int.TryParse(input, out age))
{
    Console.WriteLine("$You are {age} years old.");
}
else
{
    Console.WriteLine("Invalid input. Please enter a number.");
}
~~~
In this example, `int.TryParse` attempts to parse the user's input into an integer. It's a safe  
parsing method that returns `true` if the parsing succeeds and `false` if it fails, which helps  
prevent exceptions from invalid input.
### Reading Multiple Values
You can use `Console.ReadLine()` in a loop or multiple times consecutively to read multiple  
values from the console:
~~~ cs
Console.WriteLine("Enter three fruits, pressing Enter after each one:");
string fruit1 = Console.ReadLine();
string fruit2 = Console.ReadLine();
string fruit3 = Console.ReadLine();

Console.WriteLine($"You entered: {fruit1}, {fruit2}, and {fruit3}.");
~~~
This exmaple reads three lines of input from the user, each expected to be a fruit name.
### Loop Until Valid Input
Sometimes, you may want to keep asking the user for input until they provide a valid  
response. This can be achieved with a loop:
~~~ cs
int number;
do
{
    Console.WriteLine("Enter a positive number:");
}
while(!int.TryParse(Console.ReadLine(), out number) || number <= 0);

Console.WriteLine($"Valid number entered: {number}");
~~~
This loop continues to prompt the user until they enter a positive number.

## Basic File Operations
### Reading from a File
~~~ cs
string jsonFilePath = "./data.json";
string jsonFileContents = File.ReadAllText(jsonFilePath);

string textFilePath = "./book.txt";
string textContents = File.ReadAllText(textFilePath);
~~~
---
### Writing to a File
~~~ cs
string pathToFile = "./hello.txt";
string content = "Hello, world!";
File.WriteAllText(pathToFile, content);
~~~
---
### Appending to a File
~~~ cs
string moreContent = "The sun is out!";
File.AppendAllText("./hello.txt", moreContent);
~~~
---
### Copying a File
~~~ cs
string sourcePath = "./source_file.txt";
string destinationPath = "./destination_folder/destination_file.txt";

File.Copy(sourcePath, destinationPath);
~~~
---
### Moving a File
~~~ cs
string sourceFilePath = "./source_file.txt";
string destinationFilePath = "./destination_folder/destination_file.txt";

File.Move(sourceFilePath, destinationFilePath);
~~~
- `sourceFilePath` is the path to the file you want to move. This can either be a relative  
path (as shown) or as an absolute path.
- `destinationFilePath` is the path where you want to move the file to, including the new  
name of the file if you wish to rename it during the move. This can also be either a  
relative or an absolute path.
- `File.Move` is the method used to move the file from `sourceFilePath` to  
`destinationFilePath`.
### **Additional Note:**
**Overwriting an Existing File:** By default, if a file already exists at the  
`destinationFilePath`, `File.Move` will throw an `IOException` to prevent accidental data  
loss. To overwrite the destination file if it exists, you can use the `File.Move` method  
with an additional boolean parameter in .NET 5.0 and later:
~~~ cs
//the "true" parameter allows overwriting the destination file
File.Move(sourceFilePath, destinationFilePath, true);
~~~
---
### Serialization to JSON
~~~ cs
string jsonFilePath = "./data.json";

//assuming there is a Car class created
Car alfredo = new Car();

var options = new JsonSerializerOptions {WriteIndented = true};
string jsonString = JsonSerializer.Serialize(alfredo, options);

File.WriteAllText(jsonFilePath, jsonString);
~~~
### Deserialization from JSON
~~~ cs
string jsonFilePath = "./data.json";
var json = File.ReadAllText(jsonFilePath);

var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
var myObject = JsonSerializer.Deserialize<MyClass>(json, options);
~~~

## Basic Directory Operations
### Checking if a Directory Exists
~~~ cs
string dirPath = "./myDirectory";
bool exists = Directory.Exists(dirPath);
~~~
### Creating a Directory
~~~ cs
string dirPath = "./myDirectory";

Directory.CreateDirectory(dirPath);
~~~
Create a directory.
~~~ cs
string dirPath = "./myDirectory";
bool exists = Directory.Exists(dirPath);

if(!exists)
{
    Directory.CreateDirectory(dirPath);
}
~~~
Only create the directory if it does not already exist.
### Deleting a Directory
~~~ cs
string directoryPath = "./myDirectory";

Directory.Delete(directoryPath, true);
~~~
- `directoryPath` is the path to the directory you wish to delete. It can be either a relative  
path, as shown, or an absolute path.
- The first parameter is the path to the directory to delete.
- The second parameter, `true`, specifies that if you want to delete the directory and all its  
contents. If set to `false`, the method will only delete the directory if it is empty;  
otherwise, it will throw and `IOException`.
### Setting the Current Directory
~~~ cs
string path = "/path/to/go";
Directory.SetCurrentDirectory(path);
~~~
### Getting the Current Directory
~~~ cs
string currentDir = Directory.GetCurrentDirectory();
~~~
### Listing Directories
~~~ cs
string currentDir = Directory.GetCurrentDirectory();

string[] subdirectories = Directory.GetDirectories(currentDir);

foreach(stringt dir in subdirectories)
{
    Console.WriteLine(dir);
}
~~~
### Path Combine
The `Path.Combine()` method in C# is used to concatenate two or more strings into a path.  
It takes care of inserting or omitting the directory separator characters (such as `\` on  
Windows or `/` on UNIX-based systems) between the parts, ensuring that the resulting path  
is correctly formatted for the operating system. This method is part of the `System.IO`  
namespace, which provides support for reading and writing files, data streams, and file  
system operations.
### **How `Path.Combine()` Works**
- **Directory Separators:** It automatically inserts the correct directory separator between  
parts of the path, depending on the operating system.
- **Cross-platform:** It ensures that your paths are correctly formed on any platform,  
making your code more portable.
- **Safety:** It prevents common errors in path concatenation, such as double directory  
separators or missing separators.
### Example
~~~ cs
string dirName = "data";
string fileName = "example.txt";
string fullPath = Path.Combine(currentDir, dirName, fileName);
Console.WriteLine(fullPath);
