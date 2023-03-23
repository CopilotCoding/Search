using System.Diagnostics;
using System.Web;

class 
{
    public static void Run()
    {
        Console.Write("Enter your search query: ");

        var query = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Invalid search query.");
        }

        try
        {
            SearchEngine.Search(query);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

class SearchEngine
{
    public static void Search(string query)
    {
        // Encode the search query
        string encodedQuery = HttpUtility.UrlEncode(query);

        // Construct URLs for all search engines using the encoded query
        List<string> urls = new List<string>();
        urls.Add("https://www.google.com/search?q=" + encodedQuery);
        urls.Add("https://www.bing.com/search?q=" + encodedQuery);
        urls.Add("https://search.yahoo.com/search?p=" + encodedQuery);
        urls.Add("https://duckduckgo.com/?q=" + encodedQuery);

        // Open each URL in a separate tab/window of the default browser
        foreach (string url in urls)
        {
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }
    }
}