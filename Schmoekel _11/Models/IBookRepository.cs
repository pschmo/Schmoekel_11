namespace Schmoekel__11.Models
{
    public interface IBookRepository
    {
           public IQueryable<Book> Books { get; }
    }
}
