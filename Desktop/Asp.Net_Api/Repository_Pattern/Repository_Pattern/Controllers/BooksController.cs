using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.Core;
using Repository_Pattern.Core.Const;
using Repository_Pattern.Core.Interfaces;
using Repository_Pattern.Core.Models;

namespace Repository_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]

        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(2));
        }
        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.SpecialMethod());    
        }
        [HttpGet("GetByTitle")]

        public IActionResult GetByTitle()
        {
            return Ok(_unitOfWork.Books.Find(x=>x.Title == "OOP"));
        }
        [HttpGet("GetAllWithAuthors")]

        public IActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(x=>x.Title.Contains("OOP"),new [] {nameof(Author) }));
        }
        [HttpGet("GetAllSkipTake")]

        public IActionResult GetAllSkipTake()
        {
            return Ok(_unitOfWork.Books.FindAll(x=>x.Title == "OOP",skip:0,take:1));
        }
        [HttpGet("GetOrder")]

        public IActionResult GetWithOrdering()
        {
            return Ok(_unitOfWork.Books.FindAll(x=>x.Title == "OOP",null,null,x=>x.Id,Order_By.Descending));
        }
        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = new Book { Title = "OOD Unit Of Work ", AuthorId = 1 };

            _unitOfWork.Books.Add(book);

            _unitOfWork.Complete();

            return Ok(book);
        }
        [HttpPost("AddRange")]
        public IActionResult AddRange()
        {
            return Ok(_unitOfWork.Books.AddRange([new Book {Title ="C#",AuthorId =1 }, new Book { Title = "Linq", AuthorId = 1 }]));

        }
    }
}
