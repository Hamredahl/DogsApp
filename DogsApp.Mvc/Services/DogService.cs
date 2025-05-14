using DogsApp.Mvc.Models;
using Microsoft.AspNetCore.SignalR;

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

    public Dog[] GetAllDogs() => dogs
        .OrderBy(d => d.Name)
        .ToArray();
    

    public Dog? GetDogById(int Id) => dogs
        .SingleOrDefault(d => d.Id == Id);
    
}
