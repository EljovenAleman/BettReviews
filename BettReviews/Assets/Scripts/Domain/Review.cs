public struct Review
{

    public string Body { get; }
    public int Score { get; }
    public string ReviewerName { get; }
    public string ReviewerEmail { get; }

    public string MovieId { get; }

    public Review(string body, int score, string reviewerName, string reviewerEmail, string movieId)
    {
        Body = body;
        Score = score;
        ReviewerName = reviewerName;
        ReviewerEmail = reviewerEmail;
        MovieId = movieId;
    }
}
