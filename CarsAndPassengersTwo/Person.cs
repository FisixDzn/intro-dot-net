public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public void DriveCar(Car car, int speed)
    {
        if(car.Driver == this)
        {
            car.Drive(speed);
        }
        System.Console.WriteLine(this.FirstName + " is not the driver of this car.");
    }

    public void GetInCar(Car car)
    {
        car.AddPassenger(this);
    }

    public void GetOutOfCar(Car car)
    {
        car.RemovePassenger(this);
    }
}