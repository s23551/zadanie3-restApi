﻿namespace zadanie3_restApi.Animals;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    Animal GetAnimal(int idAnimal);
    bool AddAnimal(AnimalDTO dto);
    bool UpdateAnimal(int id, AnimalDTO dto);
    bool DeleteAnimal(int id);
}