using System.Threading.Tasks;

public interface ISearchMovieService
{
    Task<Movie> SearchMovie(string movieName);


}


