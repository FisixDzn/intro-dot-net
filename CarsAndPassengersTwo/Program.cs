Car renegade = new Car(4, 4);
Person nathan = new Person("Nathan", "Jarrett", 21);
Person damian = new Person("Damian", "Welper", 23);
Person tyler = new Person("Tyler", "Smith", 20);
Person jada = new Person("Jada", "Mitchell", 21);
Person jalen = new Person("Jalen", "Smith", 22);
renegade.AssignDriver(nathan);
renegade.AddPassenger(tyler);
renegade.AddPassenger(jada);
renegade.AddPassenger(damian);
renegade.AssignDriver(tyler);
System.Console.WriteLine(renegade.Driver?.FirstName + " " + renegade.Passengers[0]?.FirstName);

