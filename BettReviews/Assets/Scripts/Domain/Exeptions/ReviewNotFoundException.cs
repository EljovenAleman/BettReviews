using System;

public class ReviewNotFoundException : Exception
{
    public ReviewNotFoundException(string movieId, string reviewerEmail) : base("The review with the Id " + movieId + " and the reviewer Email " + reviewerEmail + " cant be found")
    {

    }


}
