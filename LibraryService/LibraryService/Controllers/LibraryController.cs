using LibraryService.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private LibraryContext _libraryContext;

        public LibraryController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        // GET: api/<LibraryController>
        [HttpGet]
        public IEnumerable<tblBooks> Get()
        {
            return _libraryContext.BookModel;
        }

        // GET api/<LibraryController>/5
        [HttpGet("{id}")]
        public tblBooks Get(string id)
        {
            return _libraryContext.BookModel.FirstOrDefault(s => s.BooKId == id);
        }

        // POST api/<LibraryController>
        [HttpPost]
        public void Post([FromBody] tblBooks value)
        {           
            value.BooKId = Guid.NewGuid().ToString();
            _libraryContext.BookModel.Add(value);
            _libraryContext.SaveChanges();
        }

        // PUT api/<LibraryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] tblBooks value)
        {
            var employee = _libraryContext.BookModel.FirstOrDefault(s => s.Id == id);
            if (employee != null)
            {
                _libraryContext.Entry<tblBooks>(employee).CurrentValues.SetValues(value);
                _libraryContext.SaveChanges();
            }
        }

        // DELETE api/<LibraryController>/5       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _libraryContext.BookModel.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _libraryContext.BookModel.Remove(student);
                _libraryContext.SaveChanges();
            }
        }
    }
}
