using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPages.Model;

namespace RazorPages.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _applicationDbContext.Book.ToList();
            return Json(new {data = books});
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _applicationDbContext.Book.FirstOrDefaultAsync(u => u.Id == id);
            _applicationDbContext.Book.Remove(book);
            await _applicationDbContext.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
