using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMemoryMovieRepositoryShould
{
    [Test]
    public void Save_A_Movie()
    {
        //Given
        Movie movie = new Movie("nameTest", DateTime.Now, "ImageUrl", 90, "IdTest");
        InMemoryMovieRepository movieRepository = new InMemoryMovieRepository();
        //When

        movieRepository.SaveMovie(movie);

        //Then

        var savedMovie = movieRepository.GetMovie(movie.Id).Result;
        


        Assert.AreEqual(movie, savedMovie);
    }


    [Test]
    public void Get_A_Movie()
    {
        //Given
        Movie movie = new Movie("nameTest", DateTime.Now, "ImageUrl", 90, "IdTest");
        InMemoryMovieRepository movieRepository = new InMemoryMovieRepository();
        movieRepository.SaveMovie(movie);




        //When
        var gottenMovie = movieRepository.GetMovie(movie.Id);


        //Then

        Assert.AreEqual(movie, gottenMovie.Result);

    }


    [Test]
    public void Return_a_failed_task_when_the_movie_is_not_in_the_repository()
    {
        //Given
        Movie movie = new Movie("nameTest", DateTime.Now, "ImageUrl", 90, "IdTest");
        InMemoryMovieRepository movieRepository = new InMemoryMovieRepository();
        




        //When
        var gottenMovie = movieRepository.GetMovie(movie.Id);


        //Then

        

        Assert.IsTrue(gottenMovie.IsFaulted);
        Assert.IsInstanceOf<MovieNotFoundException>(gottenMovie.Exception.InnerException);
        
    }

}
