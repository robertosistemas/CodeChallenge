namespace CodeChallenge.Domain.Abstractions
{
    public interface IPaged
    {
        int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
