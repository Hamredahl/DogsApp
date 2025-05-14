using DogsApp.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Mvc.Controllers;

public class DogsController : Controller
{
    static DogService dogService = new DogService();

    [HttpGet("")]
    public IActionResult Index()
    {
        var model = dogService.GetAllDogs();
        return View(model);
    }


}
