using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api;

public class GameStoreContext (DbContextOptions<GameStoreContext> options) : DbContext(options)
// WE have created a class GameStoreContext that takes a parameter options
// options is of type DbContextOptions<GameStoreContext>
// DbContextOptions is specifically for GameStoreContext
// In C#, the fullcolon (:) is used in a constructor to call the constructor of a base class (with the base keyword) or to call another constructor in the same class (with the this keyword).
{
    public DbSet<Game> Games => Set<Game>();
    
    // public DbSet<Game> Games => Set<Game>(); // GAME HERE REPRESENTS OUR TABLE GAME IN THE ENTITIES FOLDER
    //is defining a property called Games that represents the collection of Game entities in the database.

    // => Set<Game>(); Gives access to the data for the Game type in the database

    public DbSet<Genre> Genres => Set<Genre>();
    
    
}
