﻿using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using System.Data;

using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class ValuesController : ApiController
    {
        BookContext db = new BookContext();

        public IEnumerable<Book> GetBooks()
        {
            return db.Books;
        }

        public Book GetBook(int id)
        {
            Book book = db.Books.Find(id);
            return book;
        }

        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.Id)
            {
                db.Entry(book).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}