using CompanyInfo.Models;

public class EmployeeWriter
{
    public string WritePath {get; set;}
    public EmployeeWriter(string writePath)
    {
        this.WritePath = writePath;
    }
    public void Write(Employee person, EmployeeOptions? options = null)
    {
        //check if WritePath exists. If it does not we create it and move into WritePath. 
        //once inside, write out all the info about the employee except the position and benefits.
        Directory.CreateDirectory(this.WritePath);
        Directory.SetCurrentDirectory(this.WritePath);
        string fileName = $"{person.Id}.txt";
        string contents = @$"
        ID: {person.Id}
        Full Name: {person.FullName}
        Annual Salary: {person.AnnualSalary}";
        if(null == options)
        {
            options = new EmployeeOptions();
        }
        
        if(options.includePosition)
        {
            contents += @$"
            Position Description: {person.Position.Description}";
        }
        File.WriteAllText(fileName, contents);
        Directory.SetCurrentDirectory("..");
    }

    public void WriteAll(List<Employee> employees, bool writePosition = false, HttpVersionPolicy writeBenefits = false)
    {
        foreach(Employee emp in employees)
        {
            this.Write(emp);
        }
        if(writeBenefits)
        {
            foreach(Benefit benefit in employees.Benefits)
            {

            }
        }
    }
}