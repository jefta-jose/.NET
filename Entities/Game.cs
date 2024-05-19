using GameStore.Api.Entities;

namespace GameStore.Api;

public class Game
{
    // Primary key for the Game table
    public int Id { get; set; }

    // Name of the game, required field
    public required string Name { get; set; }

    // Foreign key for the Genre table
    // This establishes a relationship between the Game and Genre tables
    // Each game is associated with a genre via this GenreId
    // WE KNOW THAT ITS A FOREIGN KEY BECAUSE OF THE NAMING CONVETION
    public int GenreId { get; set; }

    // Navigation property for the Genre table
    // This allows you to access the related Genre entity directly from a Game entity
    // The Genre can be null, meaning a game might not have an associated genre
    public Genre? Genre { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
    
}
