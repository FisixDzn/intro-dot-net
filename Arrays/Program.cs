int sum = 0;
int[] numbers = { 4, 336, 7, 124, 8, 800, 3, 5, 112 };
for(int i = 0; i < numbers.Length; i++)
{
    sum += numbers[i];
}
System.Console.WriteLine(sum);

int[] values = { 15, 22, 2024, 8, 19, 31, -1, 44, -124, 1080 };
int maxValue = values[0];
for(int i = 1; i < values.Length; i++)
{
    if(values[i] > maxValue)
    {
        maxValue = values[i];
    }
}
System.Console.WriteLine(maxValue);

int target = 8;
int[] arr = { 5, 3, 8, 4, 2 };
for(int i = 0; i < arr.Length; i++)
{
    if(arr[i] == target)
    {
        arr[i] = 0;
    }
}

string toRemove = "Cherry";
int foundIndex = -1;
string[] fruits = { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
for(int i = 0; i < fruits.Length; i++)
{
    if(fruits[i] == toRemove)
    {
        fruits[i] = null;
        foundIndex = i;
        break;
    }
}



for(int i = 0; i < fruits.Length; i++)
{
    System.Console.WriteLine(fruits[i]);
}





