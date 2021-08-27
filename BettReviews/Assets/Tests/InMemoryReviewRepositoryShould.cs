using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMemoryReviewRepositoryShould
{
    [Test]
    public void Save_A_Review()
    {
        //Given
        Review review = new Review("body", 5, "reviewerName", "reviewerEmail", "movieId");
        InMemoryReviewRepository reviewRepository = new InMemoryReviewRepository();



        //When

        reviewRepository.SaveReview(review);


        //Then

        var savedReview = reviewRepository.GetReview(review.MovieId, review.ReviewerEmail).Result;

        Assert.AreEqual(review, savedReview);

    }

    [Test]
    public void Get_A_Review()
    {
        //Given
        Review review = new Review("body", 5, "reviewerName", "reviewerEmail", "movieId");
        InMemoryReviewRepository reviewRepository = new InMemoryReviewRepository();
        reviewRepository.SaveReview(review);


        //When

        var savedReview = reviewRepository.GetReview(review.MovieId, review.ReviewerEmail).Result;


        //Then

        Assert.AreEqual(review, savedReview);
    }

    [Test]
    public void Return_A_Failed_Task_When_The_Movie_Is_Not_Saved()
    {
        //Given
        Review review = new Review("body", 5, "reviewerName", "reviewerEmail", "movieId");
        InMemoryReviewRepository reviewRepository = new InMemoryReviewRepository();


        //When
        var reviewTask = reviewRepository.GetReview(review.MovieId, review.ReviewerEmail);

        //Then

        Assert.IsTrue(reviewTask.IsFaulted);
        Assert.IsInstanceOf<ReviewNotFoundException>(reviewTask.Exception.InnerException);


    }
}
