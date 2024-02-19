public class Car
{
    public int Wheels { get; set; }
    public int Speed { get; set; }
    public Person?[] Passengers { get; set; }
    public int MaxPassengers { get; set; }
    public Person? Driver { get; set; }

    public Car(int wheels)
    {
        this.Wheels = wheels;
        this.MaxPassengers = 4;
        this.Passengers = new Person[4];
    }

    public Car(int wheels, int maxPassengers)
    {
        this.Wheels = wheels;
        this.MaxPassengers = maxPassengers;
        this.Passengers = new Person[maxPassengers];
    }

    public bool AddPassenger(Person person)
    {
        bool addedPassenger = false;
        if(this.CheckPassenger(person.FirstName, person.LastName) == -1 && this.NumAvailableSeats() > 0)
        {
            for(int i = 0; i < this.Passengers.Length; i++)
            {
                if(Passengers[i] == null)
                {
                    this.Passengers[i] = person;
                    addedPassenger = true;
                    System.Console.WriteLine("passenger added to car.");
                    return addedPassenger;
                }
            }
        }
        System.Console.WriteLine(person.FirstName + " " + person.LastName + "is already in this car or there are no available seats.");
        return addedPassenger;
    }

    

    public Person? RemovePassenger(Person person)
    {
        Person? removedPerson = null;
        for(int i = 0; i < Passengers.Length; i++)
        {
            if(this.CheckPassenger(person.FirstName, person.LastName) != -1)
            {
                removedPerson = this.Passengers[i];
                this.Passengers[i] = null;
                System.Console.WriteLine("Passenger successfully removed.");
                return removedPerson;
            }
        }
        System.Console.WriteLine("Cannot remove passenger. this guy doesnt exist");
        return removedPerson;
    }

    public int CheckPassenger(string firstName, string lastName)
    {
        for(int i = 0; i < this.Passengers.Length; i++)
        {
            if(firstName == this.Passengers[i]?.FirstName && lastName == this.Passengers[i]?.LastName)
            {
                return i;
            }
        }
        System.Console.WriteLine("not found");
        return -1;
    }

    public void Drive(int speed)
    {
        if(this.Driver != null)
        {
            this.Speed = speed;
            System.Console.WriteLine("The car is now being driven by " + this.Driver.FirstName + " at " + speed + " mph.");
        }
        else
        {
            System.Console.WriteLine("The car cannot be driven without a driver.");
        }
    }

    public void AssignDriver(Person person)
    {
        if(this.Driver != null)
        {
            Person replacedDriver = this.Driver;
            if(this.CheckPassenger(person.FirstName, person.LastName) == -1)
            {
                this.Driver = null;
                this.AddPassenger(replacedDriver);
            }
            else
            {
                System.Console.WriteLine(person.FirstName + " " + person.LastName + " is in the car. Swapping...");
                int index = this.CheckPassenger(person.FirstName, person.LastName);
                Person? toBeDriver = Passengers[index];
                Passengers[index] = null;
                this.Driver = null;
                this.AddPassenger(replacedDriver);
                System.Console.WriteLine(person.FirstName + " " + person.LastName + " has been assigned to be the driver, swapping out " + replacedDriver?.FirstName + " " + replacedDriver?.LastName);
            }
        }
        this.Driver = person;
        
    }

    public int NumAvailableSeats()
    {
        int numAvailableSeats = 0;
        for(int i = 0; i < Passengers.Length; i++)
        {
            if(Passengers[i] == null)
            {
                numAvailableSeats++;
            }
        } 
        return numAvailableSeats;
    }
}