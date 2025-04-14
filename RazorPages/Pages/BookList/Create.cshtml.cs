using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Model;

namespace RazorPages.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public CreateModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid)
            {
                await _applicationDbContext.Book.AddAsync(Book);
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
