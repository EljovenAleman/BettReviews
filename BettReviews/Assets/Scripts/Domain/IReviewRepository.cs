using System.Threading.Tasks;

public interface IReviewRepository
{

    Task SaveReview(Review review);

    Task<Review> GetReview(string movieID, string reviewerEmail);

}
