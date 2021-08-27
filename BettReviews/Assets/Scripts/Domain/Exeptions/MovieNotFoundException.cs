using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieNotFoundException : Exception
{
    public MovieNotFoundException(string movieId) : base("The movie Id " + movieId + " cant be found")
    {

    }
    

}
