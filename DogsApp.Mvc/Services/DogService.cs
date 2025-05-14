using DogsApp.Mvc.Models;
using Microsoft.AspNetCore.SignalR;
using System.Globalization;

namespace DogsApp.Mvc.Services;

public class DogService
{
    //private List<Dog> dogs = [

    //    ];

    private static List<Dog> dogs = new List<Dog>
        {
            new Dog { Id = 1, Name = "Buddy", Age = "3" },
            new Dog { Id = 2, Name = "Max", Age = "5" }
        };

    public void AddDog(Dog dog)
    {
        if (dogs.Count != 0)
        {
            dog.Id = dogs.Max(x => x.Id) + 1;
        }

        dogs.Add(dog);
    }

    public void EditDog(Dog updatedDog)
    {
        Dog dog = dogs.First(d => d.Id == updatedDog.Id);
        try
        {
            dog.Name = updatedDog.Name;
            dog.Age = updatedDog.Age;
        }
        catch (Exception e)
        {
            throw new Exception("Dog not found", e);
        }
    }

    public void RemoveDog(Dog dog)
    {
        Dog toRemove = dogs.First(d => d.Id == dog.Id);
        try
        {
            dogs.Remove(dog);
        }
        catch (Exception e)
        {
            throw new Exception("Dog not found", e);
        }
    }

    public Dog[] GetAllDogs() => dogs
        .OrderBy(d => d.Name)
        .ToArray();

    public Dog? GetDogById(int Id) => dogs
        .SingleOrDefault(d => d.Id == Id);

}
