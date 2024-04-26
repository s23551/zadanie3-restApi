namespace zadanie3_restApi.Animals;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalsRepository.GetAnimals(orderBy);
    }

    public Animal GetAnimal(int idAnimal)
    {
        return _animalsRepository.GetAnimal(idAnimal);
    }

    public bool AddAnimal(AnimalDTO dto)
    {
        return _animalsRepository.AddAnimal(dto);
    }

    public bool UpdateAnimal(int id, AnimalDTO dto)
    {
        return _animalsRepository.UpdateAnimal(id, dto);
    }

    public bool DeleteAnimal(int id)
    {
        return _animalsRepository.DeleteAnimal(id);
    }
}