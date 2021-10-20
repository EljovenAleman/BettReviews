using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSubstitute;
using System.Threading.Tasks;
using System;

public class GetMovieViewPresenterShould : MonoBehaviour
{
    [Test]
    public void Search_For_A_Movie()
    {
        //given
        var threadTaskHandler = Substitute.For<IMainThreadTaskHandler>(); //Mock
        var searchMovieService = Substitute.For<ISearchMovieService>();

        var getMovieViewPresenter = new GetMovieViewPresenter(searchMovieService, threadTaskHandler);

        string movieName = "testMovie";
        //when

        getMovieViewPresenter.OnSubmitMovie(movieName);


        //then

        searchMovieService.Received(1).SearchMovie(movieName);

    }

    [Test]
    public void Handle_Movie_Search_Result_On_Main_Thread()
    {
        //given
        var threadTaskHandler = Substitute.For<IMainThreadTaskHandler>(); //Mock
        var searchMovieService = Substitute.For<ISearchMovieService>();

        var getMovieViewPresenter = new GetMovieViewPresenter(searchMovieService, threadTaskHandler);

        string movieName = "testMovie";

        var movieTask = Task<Movie>.FromResult(new Movie("name", "fecha", "imageURL", "90", "movieID"));

        searchMovieService.SearchMovie(movieName).Returns(movieTask);

        //when

        getMovieViewPresenter.OnSubmitMovie(movieName);

        //then

        threadTaskHandler.Received(1).Handle(movieTask, Arg.Any<Action<Movie>>());
    }


}
