using Assignment04.Models;
namespace Assignment04.Components;
public abstract class BaseWebComponent : IWebComponent
{
    protected string Id {get; set;}
    public BaseWebComponent(string id)
    {
        this.Id = id;
    }
    public abstract string GenerateHtml();
}
public class NavComponent : IWebComponent
{
    public string GenerateHtml()
    {
        return @"
        <nav class=""fixed top-0 left-0 right-0 z-10 bg-gray-900 text-white p-4"">
            <div class=""max-w-7xl mx-auto"">
                <div class=""flex justify-between items-center"">
                <a href=""#"" class=""text-2xl font-bold"">My Website</a>
                    <div class=""hidden md:flex items-center"">
                    <a href=""#"" class=""px-3 py-2 hover:bg-gray-800"">Home</a>
                    <a href=""#"" class=""px-3 py-2 hover:bg-gray-800"">About</a>
                    <a href=""#"" class=""px-3 py-2 hover:bg-gray-800"">Contact</a>
                    </div>
                </div>
            </div>
        </nav>";
    }
}
public class SelectComponent : BaseWebComponent
{
    private static readonly string SelectId = "tv-show-select";
    public List<TvShow> TvShows {get; set;}
    public TvShow SelectedShow {get; set;}
    public SelectComponent(List<TvShow> tvShowList, TvShow selectedShow) : base(SelectId)
    {
        TvShows = tvShowList;
        SelectedShow = selectedShow;
    }
    public override string GenerateHtml()
    {
        string tvShowOptions = "";
        foreach(TvShow show in TvShows)
        {
            if(show.Id == SelectedShow.Id)
            {
                tvShowOptions += $"<option value=\"{show.Id}\" selected=\"selected\">{show.Name}</option>\n\t\t\t\t";
            }
            else
            {
                tvShowOptions += $"<option value=\"{show.Id}\">{show.Name}</option>\n\t\t\t\t";
            }
        }
        return @$"
        <div class=""flex justify-center bg-white mt-24"">
            <select id=""tv-show-select"" class=""bg-gray-50 w-1/4 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"">
                {tvShowOptions}
            </select>
            <span class=""ml-4"">
            <button type=""button"" class=""btn btn-primary"" style=""background-color: #007bff !important;"" onclick=""getValue()"">Select</button>
            </span>
        </div>";
    }
}
public class TvShowComponent : BaseWebComponent
{
    private TvShow Show {get;}
    public TvShowComponent(TvShow show) : base(show.Id.ToString())
    {
        Show = show;
    }
    public override string GenerateHtml()
    {
        return @$"
        <div class=""container mx-auto px-4 py-12"">
            <div class=""bg-white rounded-lg shadow-lg w-full md:w-1/2 mx-auto"" data-aos=""fade-up"">
                <div class=""flex justify-center"">
                    <img class=""object-cover object-center rounded-t-lg"" 
                    src=""{Show.PosterPath}""
                    alt=""{Show.Name}"">
                </div>
                <div class=""p-6"">
                    <h2 class=""text-xl font-semibold mb-2"">{Show.Name}</h2>
                    <p class=""text-gray-700 text-sm mb-4"">{Show.Overview}
                    </p>
                    <div class=""grid grid-cols-2 gap-4"">
                        <div>
                            <p class=""text-gray-600 text-xs"">Popularity:</p>
                            <p class=""text-sm"">{Show.Popularity}</p>
                        </div>
                        <div>
                            <p class=""text-gray-600 text-xs"">Vote Average:</p>
                            <p class=""text-sm"">{Show.VoteAverage}</p>
                        </div>
                        <div>
                            <p class=""text-gray-600 text-xs"">Vote Count:</p>
                            <p class=""text-sm"">{Show.VoteCount}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>";
    }
}