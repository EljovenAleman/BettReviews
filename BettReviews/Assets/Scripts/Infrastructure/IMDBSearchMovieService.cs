using System.Threading.Tasks;
using System;

public class IMDBSearchMovieService : ISearchMovieService
{
    public Task<Movie> SearchMovie(string movieName)
    {
        return Task.FromResult<Movie>(new Movie("name", DateTime.Now, "imageulr", 90, "stringid"));
    }
}
