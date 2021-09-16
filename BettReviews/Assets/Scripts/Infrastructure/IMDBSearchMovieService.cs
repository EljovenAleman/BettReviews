using System.Threading.Tasks;
using System;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;

public class IMDBSearchMovieService : ISearchMovieService
{
    
    public Task<Movie> SearchMovie(string movieName)
    {
        return Task.FromResult<Movie>(new Movie("name", DateTime.Now, "imageulr", 90, "stringid"));
    }

    private IEnumerator RequestIMBD(string stringToSearch)
    {
        var request = UnityWebRequest.Get("http://www.omdbapi.com/?apikey=6aaadb49&s=" + stringToSearch);

        yield return request.SendWebRequest();

        var responseData = request.downloadHandler.text;
       
        SearchResult result = JsonConvert.DeserializeObject<SearchResult>(responseData);

        yield return null;
    }

    private class SearchResult
    {
        public SearchItem[] Search { get; }
        public string totalResults { get; }
        public string Response { get; }

        public SearchResult(SearchItem[] search, string totalResults, string response)
        {
            Search = search;
            this.totalResults = totalResults;
            Response = response;
        }
    }

    private class SearchItem
    {
        public string Title { get; }
        public string Year { get; }
        public string imdbID { get; }
        public string Type { get; }
        public string Poster { get; }

        public SearchItem(string title, string year, string imdbID, string type, string poster)
        {
            Title = title;
            Year = year;
            this.imdbID = imdbID;
            Type = type;
            Poster = poster;
        }
    }
}




