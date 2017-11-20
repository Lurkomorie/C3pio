using DemoMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoMVC.Models;

namespace DemoMVC.DataAccess
{
    public class BookRepozitory : IRepozitory
    {
         //************
        private static IEnumerable<Book> _books;
        public BookRepozitory()
        {
            if (_books == null)
                _books = init();
        }
             private  IEnumerable<Book> init()
        {

            IList<Book> bookList = new List<Book>();
            for (int i = 0; i < 10; i++)
            {
                bookList.Add(Models.Book.build());
            }
            return bookList;
        }
   
    //************
    public IEnumerable<Book> delete(int bookId)
        {
            return _books = _books.Where(u => u.ID != bookId).ToList();
        }

        public IEnumerable<Book> findAll()
        {
            return _books;
        }

        public Book findBook(int bookId)
        {
            return _books.FirstOrDefault(book=>book.ID==bookId);
        }

        public bool save(Book book)
        {
            throw new NotImplementedException();
        }

        public bool update(Book book)
        {
            
                foreach (Book bookk in _books)
                {
                    if (bookk.ID == book.ID)
                    {
                        book.BookName = bookk.BookName;
                        book.Author = bookk.Author;
                        book.Price = bookk.Price;
                    return true;
                    }
                }
            return false;
            
        }
    }
}