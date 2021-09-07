using System.Threading.Tasks;

public class IMDBSearchMovieService : ISearchMovieService
{
    public Task<Movie> SearchMovie(string movieName)
    {
        return Task.FromResult<Movie>(default);
    }
}
