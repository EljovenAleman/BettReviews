class GetMovieViewPresenter
{
    private readonly ISearchMovieService searchMovieService;

    public GetMovieViewPresenter(ISearchMovieService searchMovieService)
    {
        this.searchMovieService = searchMovieService;
    }
}
