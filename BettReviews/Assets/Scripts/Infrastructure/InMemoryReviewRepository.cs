using System.Collections.Generic;
using System.Threading.Tasks;

public class InMemoryReviewRepository : IReviewRepository
{
    List<Review> reviewsList = new List<Review>();

    public Task<Review> GetReview(string movieID, string reviewerEmail)
    {
        foreach(Review review in reviewsList)
        {
            if(review.MovieId == movieID && review.ReviewerEmail == reviewerEmail)
            {
                return Task.FromResult(review);
            }
        }

        return Task.FromException<Review>(new ReviewNotFoundException(movieID, reviewerEmail));
        
    }

    public Task SaveReview(Review review)
    {
        reviewsList.Add(review);

        return Task.CompletedTask;

    }
}
