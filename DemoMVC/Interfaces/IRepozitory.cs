using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Collections;

namespace DemoMVC.Interfaces
{
    public interface IRepozitory
    {
        IList<Book> findAll();
        Book findBook(int bookId);
        bool save(Book book);
        IList<Book> update(Book book);
        bool delete(int? bookId);
        IList<Book> search(string bookId);

    }
}
