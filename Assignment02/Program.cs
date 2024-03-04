using System.IO;
using System.Text.Json;
using Assignment02.Models;

//prompt 1: create an instance of TvShowWriter with a specific write directory path. Verify that the directory exists after initialization.
string baseDirPath = @"C:/Users/natha/Desktop/intro-dot-net/Assignment02";
string writeDirPath = "./tvshow_directory";
TvShowWriter tvShowWriterA = new TvShowWriter(baseDirPath, writeDirPath);

/* prompt 2: extract a single TvShow object from the data and use the Write method to save its details to a text file 
in a location of your choosing. Verify that the file exists and contains the correct content. */
string jsonFilePath = "./assignment_02.json";
var json = File.ReadAllText(jsonFilePath);
List<TvShow> tvShowList = JsonSerializer.Deserialize<List<TvShow>>(json);
tvShowWriterA.Write(tvShowList[0]);

/* prompt 3: after using the Write method, call MoveToBaseDir and verify that the current directory 
has been correctly changed back to the base directory. */
tvShowWriterA.MoveToBaseDir();
System.Console.WriteLine(Directory.GetCurrentDirectory());

/* prompt 4: given a list of TvShow objects with varying OriginCountry values, use CreateCountryDirectories to create directories 
for each unique country. Verify that no duplicate directories are created. */
//tvShowWriterA.CreateCountryDirectories(tvShowList, "countries", true);

// prompt 5: after calling CreateCountryDirectories, verify that when returnToBasePath is true, the current working directory is set back to the base directory.
System.Console.WriteLine(Directory.GetCurrentDirectory());

/* prompt 6: utilize WriteShowsByCountry with a list of TvShow objects to create directories for each country and write files for shows 
corresponding to their origin country. Verify the correct organization of directories and files. */
tvShowWriterA.WriteShowsByCountry(tvShowList, "countries", true);