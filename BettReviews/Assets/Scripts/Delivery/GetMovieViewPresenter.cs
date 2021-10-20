using UnityEngine;

public class GetMovieViewPresenter
{
    private readonly ISearchMovieService searchMovieService;
    private readonly IMainThreadTaskHandler threadTaskHandler;

    public GetMovieViewPresenter(ISearchMovieService searchMovieService, IMainThreadTaskHandler threadTaskHandler)
    {
        this.searchMovieService = searchMovieService;
        this.threadTaskHandler = threadTaskHandler;
    }

    public void OnSubmitMovie(string name)
    {
        threadTaskHandler.Handle(searchMovieService.SearchMovie(name), OnMovieFound);
    }

    void OnMovieFound(Movie movie)
    {
        Debug.Log("Encontré la movie y su ID es " + movie.Id);
    }
}
