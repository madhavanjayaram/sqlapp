using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Models.Product> Products;
        public void OnGet()
        {
            ProductService ps = new ProductService();
            Products = ps.GetProducts();
        }
    }
}