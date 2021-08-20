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


}
