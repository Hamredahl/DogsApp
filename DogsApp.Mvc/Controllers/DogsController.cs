using DogsApp.Mvc.Models;
using DogsApp.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Mvc.Controllers;

public class DogsController : Controller
{
    static readonly DogService dogService = new();

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

    [HttpPost("edit")]
    public IActionResult Edit(Dog updatedDog)
    {
        dogService.EditDog(updatedDog);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("remove")]
    public IActionResult Remove(int Id)
    {
        dogService.RemoveDog(dogService.GetDogById(Id));
        return RedirectToAction(nameof(Index));
    }
}
