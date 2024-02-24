/*int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
for(int i = 0; i < numbers.Length; i++)
{
    System.Console.WriteLine(numbers[i]);
}*/


/*int[] numbers = new int[1000];
for(int i = 0; i < numbers.Length; i++)
{
    numbers[i] = i;
}
for(int i = 0; i < numbers.Length; i++)
{
    if(numbers[i] % 2 == 0)
    {
        System.Console.WriteLine("Even!");
    }
    else
    {
        System.Console.WriteLine("Odd!");
    }
}*/

/* Excersize 01:
double totalTestScore = 0;
int[] testScores = {90, 80, 95, 85, 65, 70, 80, 100};
for(int i = 0; i < testScores.Length; i++)
{
    totalTestScore += testScores[i];
}
double average = totalTestScore / testScores.Length;
System.Console.WriteLine(average);*/


string[] weekdays = {"monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"};
System.Console.WriteLine("Forwards...");
for(int i = 0; i < weekdays.Length; i++)
{
    System.Console.WriteLine(weekdays[i]);
}
System.Console.WriteLine("Backwards...");
for(int i = weekdays.Length - 1; i > -1; i--)
{
    System.Console.WriteLine(weekdays[i]);
}

int[] highestNumberArray = {5, 12, 9, 34, 16, 7};
int highestNumber = highestNumberArray[0];
for(int i = 1; i < highestNumberArray.Length; i++)
{
    if(highestNumber < highestNumberArray[i])
    {
        highestNumber = highestNumberArray[i];
    }
}
System.Console.WriteLine(highestNumber);