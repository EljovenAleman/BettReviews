using System.Threading.Tasks;

public interface IMovieRepository
{

    Task SaveMovie(Movie movie);

    Task<Movie> GetMovie(string movieID);

}
