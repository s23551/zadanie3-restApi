namespace zadanie3_restApi.Animals;

public interface IAnimalsRepository
{
    IEnumerable<Animals> GetAnimals();
}