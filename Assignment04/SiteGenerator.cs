using System.IO;
using Assignment04.Components;
using Assignment04.Models;
namespace Assignment04.Services;

public class SiteGenerator 
{
    private List<TvShow> Shows { get; }
    public string BaseDirPath { get; set; }
    public string WriteDirPath { get; set; }    

    public SiteGenerator(string basePath, string writePath, List<TvShow> shows) 
    {
        this.BaseDirPath = basePath;
        this.WriteDirPath = writePath;
        this.Shows = shows;
    }

    public void GeneratePages() 
    {
        if(!Directory.Exists(WriteDirPath))
        {
            Directory.CreateDirectory(WriteDirPath);
            Directory.SetCurrentDirectory(WriteDirPath);
        }
        foreach(TvShow show in Shows)
        {
            string page = "";
            page += @"
            <!DOCTYPE html>
            <html>";
            page += GenerateHeader(show.Name);
            page += GenerateNav();
            page += GenerateBody(show);
            page += @"</html>";
            string fileName = $"./{show.Id}.html";
            File.WriteAllText(fileName, page);
        }
        Directory.SetCurrentDirectory("..");
    }

    private string GenerateHeader(string? title)
    {
        return @$"
        <head>
            <meta charset=""utf-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
            <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.css"" integrity=""sha512-1cK78a1o+ht2JcaW6g8OXYwqpev9+6GqOkz9xmBN9iUUhIndKtxwILGWYOSibOKjLsEdjyjZvYDq/cZwNeak0w=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""/>
            <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD"" crossorigin=""anonymous"">
            <title>{title}</title>
        </head>";
    }

    private string GenerateNav()
    {
        NavComponent navBar = new NavComponent();
        return navBar.GenerateHtml();
    }

    private string GenerateBody(TvShow show) 
    {
        string body = "\n\t<body>";
        body += new SelectComponent(Shows, show).GenerateHtml();
        body += new TvShowComponent(show).GenerateHtml();
        body += GenerateBottomScriptIncludes();
        body += "</body>\n";
        return body;
    }
    private string GenerateBottomScriptIncludes(){
        return @"
            <script src=""https://cdnjs.cloudflare.com/ajax/libs/aos/2.3.4/aos.js"" integrity=""sha512-A7AYk1fGKX6S2SsHywmPkrnzTZHrgiVT7GcQkLGDe2ev0aWb8zejytzS8wjo7PGEXKqJOrjQ4oORtnimIRZBtw=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
            <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN"" crossorigin=""anonymous""></script>
            <script src=""https://cdn.tailwindcss.com""></script>
            <script type=""text/javascript"">
                AOS.init({
                    duration: 1200,
                });
                
                function getValue() {
                    let dropdown = document.getElementById(""tv-show-select"");
                    let selectedValue = dropdown.value;
                    let url = document.URL;
                    let newUrl = url.split('/').slice(0,-1).join('/') + '/' + selectedValue + '.html';
                    window.location = newUrl;
                }
      
            </script>
        ";
    }

}
