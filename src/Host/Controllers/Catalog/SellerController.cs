using Microsoft.AspNetCore.Mvc;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class SellerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
