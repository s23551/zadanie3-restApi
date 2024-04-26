using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

namespace zadanie3_restApi.Animals;
using System.Data.SqlClient;

public class AnimalsRepository : IAnimalsRepository
{
    private IConfiguration _configuration;
    
    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        if (orderBy != "Description" && orderBy != "Category" && orderBy != "Area")
        {
            orderBy = "Name";
        } 
        
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY {orderBy}";
        
        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            animals.Add(animal);
        }
        
        return animals;
    }

    public Animal GetAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd =
            new SqlCommand("SELECT IdAnimal, Name, Description, Category, Area FROM Animal WHERE IdAnimal=@id", con);
        cmd.Parameters.AddWithValue("@id", idAnimal);

        var dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            return animal;
        }
        return null;
    }

    public bool AddAnimal(AnimalDTO dto)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();

        using var command = new SqlCommand("INSERT INTO Animal (Name, Description, Category, Area) VALUES " +
                                           "(@name, @description, @category, @area)", connection);
        command.Parameters.AddWithValue("@name", dto.Name);
        command.Parameters.AddWithValue("@description", dto.Description);
        command.Parameters.AddWithValue("@category", dto.Category);
        command.Parameters.AddWithValue("@area", dto.Area);

        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }

    public bool UpdateAnimal(int id, AnimalDTO dto)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();

        using var command = new SqlCommand("UPDATE Animal SET Name=@name, Description=@description, " +
                                           "Category=@category, Area=@area WHERE IdAnimal=@id", connection);
        command.Parameters.AddWithValue("@name", dto.Name);
        command.Parameters.AddWithValue("@description", dto.Description);
        command.Parameters.AddWithValue("@category", dto.Category);
        command.Parameters.AddWithValue("@area", dto.Area);
        command.Parameters.AddWithValue("@id", id);

        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }

    public bool DeleteAnimal(int id)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();

        using var command = new SqlCommand("DELETE Animal WHERE IdAnimal=@id", conn);
        command.Parameters.AddWithValue("@id", id);

        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }
}