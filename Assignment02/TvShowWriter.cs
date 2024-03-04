using System.IO;
using System.Text.Json;
using Assignment02.Models;

public class TvShowWriter
{
    public string BaseDirPath {get; set;}
    public string WriteDirPath {get; set;}
    public TvShowWriter(string baseDirectory, string writeDirectoryPath)
    {
        this.BaseDirPath = baseDirectory;
        this.WriteDirPath = writeDirectoryPath;
        if(!Directory.Exists(WriteDirPath))
        {
            Directory.CreateDirectory(WriteDirPath);
        }
    }
    public void MoveToBaseDir()
    {
        Directory.SetCurrentDirectory(BaseDirPath);
    }
    public void Write(TvShow tvShow)
    {
        string fileName = $"./{tvShow.Id}.txt";
        //string filePath = Path.Combine(WriteDirPath, fileName);
        string contents = @$"
        ID: {tvShow.Id}
        Backdrop Path: {tvShow.BackdropPath}
        Name: {tvShow.Name}
        Origin Country: {tvShow.OriginCountry}
        Original Language: {tvShow.OriginalLanguage}
        Original Name: {tvShow.OriginalName}
        Overview: {tvShow.Overview}
        Popularity: {tvShow.Popularity}
        Poster Path: {tvShow.PosterPath}
        Vote Average: {tvShow.VoteAverage}
        Vote Count: {tvShow.VoteCount}";
        File.WriteAllText(fileName, contents);
    }
    public int CreateCountryDirectories(List<TvShow> tvShows, string countryDirName, bool returnToBasePath = true)
    {
        int count = 0;
        string countryDirPath = Path.Combine(WriteDirPath, countryDirName);
        if(!Directory.Exists(countryDirPath))
        {
            Directory.CreateDirectory(countryDirPath);
            count++;
        }
        Directory.SetCurrentDirectory(countryDirPath);
        foreach(var show in tvShows)
        {
            string originPropertyPath = Path.Combine(countryDirPath, $"./{show.OriginCountry}");
            if(!Directory.Exists(originPropertyPath))
            {
                Directory.CreateDirectory(originPropertyPath);
                count++;
            }
        }
        if(returnToBasePath)
        {
            MoveToBaseDir();
        }
        return count;
    }
    /*public void WriteShowsByCountry(List<TvShow> tvShows, string countryDirName, bool returnToBasePath = true)
    {
        string countryDirPath = Path.Combine(WriteDirPath, countryDirName);
        if(!Directory.Exists(countryDirPath))
        {
            Directory.CreateDirectory(countryDirPath);
        }
        Directory.SetCurrentDirectory(countryDirPath);
        string[] subdirectories = Directory.GetDirectories(countryDirPath);
        foreach(TvShow show in tvShows.Where(show => show.OriginCountry == countryDirName))
        {
            Write(show);
        }
        if(returnToBasePath)
        {
            MoveToBaseDir();
        }
    }*/

    public void WriteShowsByCountry(List<TvShow> tvShows, string countryDirName, bool returnToBasePath = true)
    {
        CreateCountryDirectories(tvShows, countryDirName, returnToBasePath);
        string pathToCountry = $"./{WriteDirPath}/{countryDirName}";
        Directory.SetCurrentDirectory(pathToCountry);
        string[] subdirectories = Directory.GetDirectories(pathToCountry);
        Directory.SetCurrentDirectory(subdirectories[0]);
        foreach(var s in subdirectories)
        {
            foreach(var show in tvShows)
            {
                Write(show);
            }
        }
    }
}