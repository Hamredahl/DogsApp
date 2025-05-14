using DogsApp.Mvc.Models;
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

    [HttpGet("create")]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")] 
    public IActionResult Create(Dog dog)
    {
        dogService.AddDog(dog);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit(int Id)
    {
        var model = dogService.GetDogById(Id);
        return View(model);
    }

    [HttpPost("edit/{id}")]
    public IActionResult Edit(Dog dog)
    {
        dogService.EditDog(dog);
        return RedirectToAction(nameof(Index));
    }
}
