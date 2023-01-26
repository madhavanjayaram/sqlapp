using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Services;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Models.Product> Products;
        public readonly IProductService _productservice;
        public IndexModel(IProductService productservice)
        {
            _productservice = productservice;
        }
        public void OnGet()
        {
            Products = _productservice.GetProducts();
        }
    }
}