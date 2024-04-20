namespace zadanie3_restApi.Animals;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals();
}