using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InMemoryMovieRepository : IMovieRepository
{
    private List<Movie> moviesList = new List<Movie>();

    public Task<Movie> GetMovie(string movieID)
    {
        foreach(Movie movie in moviesList)
        {
            if(movie.Id == movieID)
            {
                return Task.FromResult(movie);
            }
        }



        return Task.FromException<Movie>(new MovieNotFoundException(movieID));


    }

    public Task SaveMovie(Movie movie)
    {
        moviesList.Add(movie);

        return Task.CompletedTask;
    }


}
