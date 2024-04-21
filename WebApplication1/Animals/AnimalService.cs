namespace WebApplication1.Animals;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAllAnimals(string orderBy);
    bool AddNewAnimal(CreateAnimalDto dto);
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
        return _animalRepository.CreateNewAnimal(dto.Name,dto.Description,dto.Category,dto.Area);
    }

    public bool UpdateAnimal(int id)
    {
        return _animalRepository.UpdateAnimal(id);
    }
}