using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;

namespace RazorPages.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _applicationDbContext;

        public EditModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _applicationDbContext.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var bookFromDb = await _applicationDbContext.Book.FindAsync(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.ISBN = Book.ISBN;
                bookFromDb.Title = Book.Title;
               
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {

                return Page();
            }
        }
    }
}
