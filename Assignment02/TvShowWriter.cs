public class TvShowWriter
{
    public string BaseDirPath {get; set;}
    public string WriteDirPath {get; set;}
    public TvShowWriter(string baseDirectory, string writeDirectoryPath)
    {
        this.BaseDirPath = baseDirectory;
        this.WriteDirPath = writeDirectoryPath;
    }
    public void MoveToBaseDir()
    {
        Directory.SetCurrentDirectory(BaseDirPath);
    }
    public void Write(TvShow tvShow)
    {
        Directory.CreateDirectory(WriteDirPath);
        Directory.SetCurrentDirectory(WriteDirPath);
        string fileName = $"{tvShow.Id}.txt";
        string contents = @$"
        ID: {tvShow.Id}
        Backdrop Path: {tvShow.BackDropPath}
        Name: {tvShow.Name}
        Origin Country: {tvShow.OriginCountry}
        Original Language: {tvShow.OriginalLanguage}
        Original Name: {tvShow.OriginalName}
        Overview: {tvShow.Overview}
        Popularity: {tvShow.Popularity}
        Poster Path: {tvShow.PosterPath}
        Vote Average: {tvShow.VoteAverage}
        Vote Count: {tvShow.VoteCount}";
        fileName.WriteAllText(fileName, contents);
        Directory.SetCurrentDirectory("../");
    }
    public int CreateCountryDirectories(List<TvShow> tvShows, string countryDirName, bool returnToBasePath = true)
    {
        int count = 0;
        Directory.SetCurrentDirectory(WriteDirPath);
        if(!Directory.Exists(countryDirName))
        {
            string countryDirPath = "./Countries";
            string fullPath = Path.Combine(WriteDirPath, countryDirPath, countryDirName);
            Directory.SetCurrentDirectory(countryDirPath);
        }
        foreach(var show in tvShows)
        {
            string originPropertyPath = $"./{show.OriginCountry}";
            Directory.CreateDirectory(originPropertyPath);
        }
        return count;
    }
    public void WriteShowsByCountry(List<TvShow> tvShows, string countryDirName, bool returnToBasePath = true)
    {

    }
}