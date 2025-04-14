using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Model;

namespace RazorPages.Pages.BookList
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task OnGet()
        {
            Books = await _applicationDbContext.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _applicationDbContext.Book.FindAsync(id);
            if (book == null) { 
                return NotFound();
            }
            else
            {
                _applicationDbContext.Book.Remove(book);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
               
        }

        public IEnumerable<Book> Books { get; set; }


    }
}
