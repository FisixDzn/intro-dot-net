using CompanyInfo.Models;

public class EmployeeWriter {
    public string WritePath { get; set; }

    public EmployeeWriter(string writePath) {
        this.WritePath = writePath;
    }

    public void Write(Employee person, EmployeeOptions? options = null) {        
        Directory.CreateDirectory(this.WritePath);
        
        // Move into directory
        Directory.SetCurrentDirectory(this.WritePath);
        string fileName = $"{person.Id}.txt";

        string contents = @$"
        ID: {person.Id}
        Full Name: {person.FullName}
        Annual Salary: {person.AnnualSalary}";

        if(null == options) {
            options = new EmployeeOptions();
        }

        if(options.IncludePosition) {
            contents += @$"
            Position
            ---------
            Position ID: {person.Position.Id}
            Position Description: {person.Position.Description}
            ";
        }

        if(options.IncludeBenefits){
            contents += @"
             Benefits
             ---------
            ";
            foreach(Benefit benefit in person.Benefits) {
                contents += @$"               
                Additional: {benefit.Additional}
                Description: {benefit.Description}
                ";
            }
        }

        File.WriteAllText(fileName, contents);

        Directory.SetCurrentDirectory("..");

    }

    public void WriteAll(List<Employee> employees, EmployeeOptions? options = null) {
        /*
            Writes out all the people passed.
        */
        foreach(Employee emp in employees) {
            this.Write(emp, options);
        }

    }
}