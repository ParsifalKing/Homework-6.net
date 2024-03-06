using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class BookService
{
    private readonly DapperContext _context;

    public BookService()
    {
        _context = new DapperContext();
    }

    public string AddBook(Book book)
    {
        var sql = @"insert into Books(Title,Author,Category,Access) values(@Title,@Author,@Category,@Access)";
        _context.Connection().Execute(sql, book);
        return $"Book created succesfully!";
    }
    public List<Book> GetBooks()
    {
        var sql = @"select * from Books";
        return _context.Connection().Query<Book>(sql).ToList();
    }

    public string UpdateBook(Book book)
    {
        var sql = @"update Books set Title=@Title,Author=@Author,Category=@Category,Access=@Access where id=@Id";
        _context.Connection().Execute(sql, book);
        return $"Book update succesfully!";
    }

    public string DeleteBook(int id)
    {
        var sql = @"delete from Books where id=@id";
        _context.Connection().Execute(sql, new { Id = id });
        return $"Book deleted succesfully!";
    }

    public Book GetBookByTitle(string title)
    {
        var sql = @"select * from Books  where title=@title";
        return _context.Connection().QueryFirstOrDefault<Book>(sql, new { Title = title });
    }

    public List<Book> GetBooksByAuthor(string auhtor)
    {
        var sql = @"select * from Books where author=@auhtor";
        return _context.Connection().Query<Book>(sql, new { Auhtor = auhtor }).ToList();
    }

    public List<Book> GetBooksByCategory(string category)
    {
        var sql = @"select * from Books where category=@category";
        return _context.Connection().Query<Book>(sql, new { Category = category }).ToList();
    }

    public string ChangeAccessOfBook(int id, bool access)
    {
        var sql = @"update Books set Access=@Access where id=@id";
        _context.Connection().Execute(sql, new { Id = id, Access = access });
        return $"changing access finished succesfully!";
    }



}
