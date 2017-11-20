using DemoMVC.Models;
using System;
using System.Collections.Generic;

namespace DemoMVC.Interfaces
{
    public interface IRepozitory
    {
        IEnumerable<Book> findAll();
        Book findBook(int bookId);
        bool save(Book book);
        bool update(Book book);
        IRepozitory delete(int bookId);
    }
}
