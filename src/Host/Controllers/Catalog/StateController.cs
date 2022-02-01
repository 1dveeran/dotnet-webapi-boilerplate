using Microsoft.AspNetCore.Mvc;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class StateController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
