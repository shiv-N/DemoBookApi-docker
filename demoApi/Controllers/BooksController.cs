using System;
using System.Linq;
using demoApi.Data;
using demoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public BooksController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpPost("{BookName}")]
        public IActionResult RegisterBook(string BookName)
        {
            try{
                Book newBook = new Book();
                newBook.Name = BookName;
                this._context.Books.Add(newBook);
                int result = this._context.SaveChanges();

                if(result > 0){
                    return this.Ok(new {success = true, Message = "Book is added."});
                }
                else{
                    return this.BadRequest(new {success = false, Message = "Book is not added."});
                }
            }
            catch(Exception ex){
                return this.BadRequest(new {success = false,Message = ex.Message, InnerException = ex.InnerException});
            }
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            try{
                    var Books = this._context.Books.ToList();
                    if(Books != null){
                        return this.Ok(new {success = true, data = Books});
                    }
                    else{
                        return this.NotFound(new {Message = "Books not found"});
                    }
                }
            catch(Exception ex){
                return this.BadRequest(new {success = false,Message = ex.Message, InnerException = ex.InnerException});
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetBookById(int Id)
        {
            try{
                    var Books = this._context.Books.FirstOrDefault(x => x.Id==Id);
                    if(Books != null){
                        return this.Ok(new {success = true, data = Books});
                    }
                    else{
                        return this.NotFound(new {Message = "Book not found"});
                    }
                }
            catch(Exception ex){
                return this.BadRequest(new {success = false,Message = ex.Message, InnerException = ex.InnerException});
            }
        }
    }
}