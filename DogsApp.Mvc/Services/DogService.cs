using DogsApp.Mvc.Models;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;

namespace DogsApp.Mvc.Services;

public class DogService
{
    private List<Dog> dogs = [

        ];


    public void AddDog(Dog dog)
    {
    try { dog.Id = dogs.Max(d => d.Id) + 1; }
    catch (Exception ex) { dog.Id = 1; }

        dogs.Add(dog);
    }

    public void EditDog(Dog dog)
    {
        Dog toEdit = dogs.First(d => d.Id == dog.Id);
        toEdit.Name = dog.Name;
        toEdit.Age = dog.Age;
    }

    public Dog[] GetAllDogs() => dogs
        .OrderBy(d => d.Name)
        .ToArray();    

    public Dog? GetDogById(int Id) => dogs
        .SingleOrDefault(d => d.Id == Id);
    
}
