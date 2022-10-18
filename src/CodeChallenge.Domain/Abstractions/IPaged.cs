namespace CodeChallenge.Domain.Abstractions
{
    public interface IPaged
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        void Normalize();
    }
}
