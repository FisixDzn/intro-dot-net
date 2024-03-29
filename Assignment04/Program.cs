using System.IO;
using System.Text.Json;
using Assignment04.Models;
using Assignment04.Services;

string jsonFilePath = "./assignment_04.json";
var json = File.ReadAllText(jsonFilePath);
List<TvShow> tvShowList = JsonSerializer.Deserialize<List<TvShow>>(json);

string baseDirPath = Directory.GetCurrentDirectory();
string writeDirPath = "./Sites";
SiteGenerator site = new SiteGenerator(baseDirPath, writeDirPath, tvShowList);
site.GeneratePages();


