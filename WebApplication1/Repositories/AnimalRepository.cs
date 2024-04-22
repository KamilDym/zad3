using System.Data.SqlClient;
using WebApplication1.Animals;

namespace WebApplication1.Repositories;

public interface IAnimalRepository
{
    public IEnumerable<Animal> FetchAllAnimals(string orderBy);
    public bool CreateNewAnimal(string Name, string Description, string Category, string Area);
    public bool UpdateAnimal(int id, string Name, string Description, string Category, string Area);
    bool Exist(int idAnimal);
    bool DeleteAnimal(int id);
}

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> FetchAllAnimals(string orderBy)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();

        var safeOrderBy = new string[] { "Name", "Description", "Category", "Area" }.Contains(orderBy)
            ? orderBy
            : "Name";
        var command = new SqlCommand($"SELECT * FROM Animal ORDER BY {safeOrderBy} ASC", connection);
        using var reader = command.ExecuteReader();

        var animals = new List<Animal>();
        while (reader.Read())
        {
            var animal = new Animal()
            {
                IdAnimal = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString()!,
                Description = reader["Description"].ToString()!,
                Category = reader["Category"].ToString()!,
                Area = reader["Area"].ToString()!
            };
            animals.Add(animal);
        }

        return animals;
    }
    

    public bool CreateNewAnimal(string name, string description, string category, string area)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        var command = new SqlCommand($"INSERT INTO Animal (Name,Description,Category,Area) VALUES (@name,@description,@category,@area)", connection);
        command.Parameters.AddWithValue("@name",name);
        command.Parameters.AddWithValue("@description",description);
        command.Parameters.AddWithValue("@category",category);
        command.Parameters.AddWithValue("@area",area);
        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;

    }

    public bool Exist(int idAnimal)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        var command = new SqlCommand($"SELECT IdAnimal FROM Animal WHERE IdAnimal = @idAnimal",connection);
        command.Parameters.AddWithValue("@idAnimal", idAnimal);
        using var reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            return true;
        }
        return false;
    }

    public bool DeleteAnimal(int id)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        var command = new SqlCommand($"DELETE FROM Animal WHERE IdAnimal = {id}",connection);
        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }

    public bool UpdateAnimal(int id, string name, string description, string category, string area)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        //@name,@description,@category,@area
        var command = new SqlCommand($"UPDATE Animal SET Name = @name, Description = @description ,Category = @category, Area = @area WHERE IdAnimal = {id}",connection);
        command.Parameters.AddWithValue("@name",name);
        command.Parameters.AddWithValue("@description",description);
        command.Parameters.AddWithValue("@category",category);
        command.Parameters.AddWithValue("@area",area);
        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }

   
}