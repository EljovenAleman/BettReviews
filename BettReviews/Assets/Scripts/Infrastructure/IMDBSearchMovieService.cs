using System.Threading.Tasks;
using System;
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;
using System.Net.Http;

public class IMDBSearchMovieService : ISearchMovieService
{
    HttpClient httpClient = new HttpClient();


    public async Task<Movie> SearchMovie(string movieName)
    {
        //return Task.FromResult<Movie>(new Movie("name", DateTime.Now, "imageulr", 90, "stringid"));
        var itemsBody = await httpClient.GetStringAsync("http://www.omdbapi.com/?apikey=6aaadb49&s=" + movieName);
        var item = ToSearchItem(itemsBody);

        var movieBody = await httpClient.GetStringAsync("http://www.omdbapi.com/?apikey=6aaadb49&i=" + item.imdbID);

        return ToMovie(movieBody);

    }    

    private Movie ToMovie(string movieBody)
    {
        var deserializedMovie = JsonConvert.DeserializeObject<DeserializedMovie>(movieBody);

        return new Movie(deserializedMovie.Title, deserializedMovie.Year, deserializedMovie.Poster, deserializedMovie.Runtime, deserializedMovie.imdbID);
    }

    
    private SearchItem ToSearchItem(string responseBody)
    {        
        SearchResult result = JsonConvert.DeserializeObject<SearchResult>(responseBody);

        return result.Search[0];


    }

    private class DeserializedMovie
    {

        public string Title { get; }
        public string Year { get; }
        public string Poster { get; }
        public string Runtime { get; }
        public string imdbID { get; }


        public DeserializedMovie(string title, string year, string poster, string runtime, string imdbID)
        {
            Title = title;
            Year = year;
            Poster = poster;
            Runtime = runtime;
            this.imdbID = imdbID;
        }
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




