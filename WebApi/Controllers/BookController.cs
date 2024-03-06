using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController
{
    private readonly BookService _bookService;

    public BookController()
    {
        _bookService = new BookService();
    }

    [HttpPost("add-book")]
    public string AddBook(Book book)
    {
        return _bookService.AddBook(book);
    }

    [HttpGet("get-books")]
    public List<Book> GetBooks()
    {
        return _bookService.GetBooks();
    }

    [HttpPut("update-book")]
    public string UpdateBook(Book book)
    {
        return _bookService.UpdateBook(book);
    }

    [HttpDelete("delete-book")]
    public string DeleteBook(int id)
    {
        return _bookService.DeleteBook(id);
    }

    [HttpGet("get-book-by-title")]
    public Book GetBookByTitle(string title)
    {
        return _bookService.GetBookByTitle(title);
    }

    [HttpGet("get-books-by-author")]
    public List<Book> GetBooksByAuthor(string auhtor)
    {
        return _bookService.GetBooksByAuthor(auhtor);
    }

    [HttpGet("get-books-by-category")]
    public List<Book> GetBooksByCategory(string category)
    {
        return _bookService.GetBooksByCategory(category);
    }

    [HttpPut("change-access-of-book")]
    public string ChangeAccessOfBook(int id, bool access)
    {
        return _bookService.ChangeAccessOfBook(id, access);
    }


}
