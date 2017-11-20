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
        public static IList<Book> _books;
        public BookRepozitory()
        {
            if (_books == null)
                _books = init();
        }
       private  IList<Book> init()
        {

            IList<Book> bookList = new List<Book>();
            for (int i = 0; i < 10; i++)
            {
                bookList.Add(Models.Book.build());
            }
            return bookList;
        }
   
    //************
        public bool delete(int? bookId)
        {

            foreach (Book bookk in _books)
            {
                if (bookk.ID == bookId)
                {
                   _books.Remove(bookk);
                    return true;
                }
            }
            return false;
        }

        public IList<Book> findAll()
        {
            return _books;
        }

        public Book findBook(int bookId)
        {
            return _books.FirstOrDefault(book=>book.ID==bookId);
        }

        public bool save(Book book)
        {
             _books.Add(book);
            return true;
        }

        public IList<Book> search(string name) {
            IList<Book> books = new List<Book>();
            foreach (Book book in _books) {
                if(name == book.BookName) {
                    books.Add(book);
                }
            }
            return books;
        }

        public IList<Book> update(Book book)
        {
            
                foreach (Book bookk in _books)
                {
                    if (bookk.ID == book.ID)
                    {
                        bookk.BookName = book.BookName;
                        bookk.Author = book.Author;
                        bookk.Price = book.Price;
                        bookk.IsPresent = book.IsPresent;
                        return _books;
                    }
                }
            return _books;
            
        }
    }
}