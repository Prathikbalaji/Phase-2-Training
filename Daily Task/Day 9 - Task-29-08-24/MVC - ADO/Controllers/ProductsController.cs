using Microsoft.AspNetCore.Mvc;
using ADOmvc.Data_Access;
using ADOmvc.Models;


namespace ADOmvc.Controllers
{
    public class ProductsController : Controller
    {
        ProductDataAccess pd = new ProductDataAccess();
        public IActionResult Index()
        {
            List<Products> lst = pd.select();
            return View(lst);
        }

        

    }
}
