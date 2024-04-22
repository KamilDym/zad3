using WebApplication1.Animals;
using WebApplication1.Models.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAllAnimals(string orderBy);
    bool AddNewAnimal(CreateAnimalDto dto);
    bool Exist(int idAnimal);
    bool UpdateAnimal(int idAnimal, CreateAnimalDto animal);
    bool DeleteAnimal(int id);
}

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAllAnimals(string orderBy)
    {
        return _animalRepository.FetchAllAnimals(orderBy);
    }

    public bool AddNewAnimal(CreateAnimalDto dto)
    {
        return _animalRepository.CreateNewAnimal(dto.Name, dto.Description, dto.Category, dto.Area);
    }

    public bool Exist(int idAnimal)
    {
        return _animalRepository.Exist(idAnimal);
    }

    public bool UpdateAnimal(int idAnimal, CreateAnimalDto animal)
    {
        return _animalRepository.UpdateAnimal(idAnimal, animal.Name, animal.Description, animal.Category, animal.Area);
    }

    public bool DeleteAnimal(int id)
    {
        return _animalRepository.DeleteAnimal(id);
    }
}