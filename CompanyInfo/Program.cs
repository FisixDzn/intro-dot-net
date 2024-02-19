using System.IO;
using System.Text.Json;

const string jsonFilePath = "./CompanyInfo.json";
string json = File.ReadAllText(jsonFilePath);

var options = new JsonSerializerOptions() {PropertyNameCaseInsensitive = true};

Company? companyA = JsonSerializer.Deserialize<Company>(json, options);

const string writeDir = "employees";
EmployeeWriter writer = new EmployeeWriter(writeDir);

writer.Write(companyA.Employees[0]);
writer.WriteAll(companyA.Employees);
