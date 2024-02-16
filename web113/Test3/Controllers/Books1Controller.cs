using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Test3;

namespace Test3.Controllers
{
    public class Books1Controller : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Books1
        public IQueryable<Book> GetBooks()
        {
            string url = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            var books = db.Books.ToList();
            foreach (var book in books)
            {
                book.image = url + "/Content/images/" + book.image;
            }

            return db.Books;
        }

        // GET: api/Books1/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            string url = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            book.image = url + "/Content/images/" + book.image;

            return Ok(book);
        }

        // PUT: api/Books1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.book_Id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books1
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.book_Id }, book);
        }

        // DELETE: api/Books1/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.book_Id == id) > 0;
        }
    }
}
