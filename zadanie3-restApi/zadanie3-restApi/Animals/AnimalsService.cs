﻿namespace zadanie3_restApi.Animals;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    public IEnumerable<Animals> GetAnimals()
    {
        return _animalsRepository.GetAnimals();
    }
}