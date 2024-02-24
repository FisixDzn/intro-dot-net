//prompt 1
using System.Globalization;

List<int> integers = new List<int>();
for(int i = 0; i < 10; i++)
{
    integers.Add(i + 1);
}
foreach(int i in integers)
{
    System.Console.WriteLine(i);
}

//prompt 2
List<string?> names = new List<string?>();
for(int i = 0; i < 5; i ++)
{
    System.Console.WriteLine("Please enter name " + (i + 1) + " out of 5:");
    string? input = Console.ReadLine();
    names.Add(input);
}
foreach(string? n in names)
{
    System.Console.WriteLine(n);
}

//prompt 3
List<string> names2 = new List<string>{"Andrew", "Marcus", "Janelle", "Nathan", "Lauren", "Matthew", "Mitchell"};
names2.RemoveAll(n => n.StartsWith("A"));

foreach(var n in names2)
{
    System.Console.WriteLine(n);
}

//prompt 4 (im using the list from prompt 1)
int max = integers[0];
foreach(int i in integers)
{
    if(i > max)
    {
        max = i;
    }
}
System.Console.WriteLine(max);

//prompt 5
List<int> nums = new List<int>{11, 12, 13, 14, 15};
List<int> nums2 = new List<int>{16, 17, 18, 19, 20};
nums.AddRange(nums2);
foreach(int n in nums)
{
    System.Console.WriteLine(n);
}

//prompt 6
List<int> nums3 = new List<int>{21, 22, 23, 24, 25, 26, 27, 28, 29, 30};
List<int> sublist = nums3.GetRange(2, 4);
foreach(int n in sublist)
{
    System.Console.WriteLine(n);
}

//prompt 7
List<int> nums4 = new List<int>{31, 31, 32, 33, 34, 35, 35, 35, 35};
List<int> nums5 = nums4.FindAll(n => n == 35);
System.Console.WriteLine("number of 35s: " + nums5.Count);

//prompt 8
List<int> nums6 = new List<int>{45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55};
for(int i = 0; i < nums6.Count; i++)
{
    if(nums6[i] < 50)
    {
        nums6[i] += 10;
    }
}
foreach(int n in nums6)
{
    System.Console.WriteLine(n);
}