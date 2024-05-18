using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;


public static class GamesEndpoints
{
    const string GameEndpoint = "GetGame";

    /*
    Here we create a List of games
    but this List, is of type <GameDto>
    which means it can only contain objects that follow the 
    structure defined in the GameDto class.

    new (...): This syntax is used to create a new instance of an 
    object. In this case, it's creating a new GameDto object.
    */


    // the difference in declaring a static class and omiting it is that if you declare static you can acess it directly without having to create an instance
    // readonly: since our list has predefined valeus its reccomended we use the read only valeu
    private static readonly List<GameDto> games = [ // THIS LIST METHOD IS USED WHEN WE HAVE PREDEFINED VALEUS 
        new(
        1,
        "God Of War",
        "Fighting",
        89.76M,
        new DateOnly(2001,1,6)
    ),
    new(
        2,
        "WatchDogs 2",
        "Free Roam",
        59.76M,
        new DateOnly(2004,10,26)
    ),
    new(
        3,
        "Fifa 24",
        "Football",
        29.76M,
        new DateOnly(2015,10,16)
    ),
];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)  
    // RouteGroupBuilder represents a group of routes 
    // MapGamesEndpoints is a method(); that we are going to call in the program.cs file
    {

        var group = app.MapGroup("games"); // instead of having to hard code the endpoint games everytime  we store it in group and the pass group as our endpoint name

        
        //getting all games
        group.MapGet("", () => games);

        //getting a game by its ID
        group.MapGet("/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GameEndpoint);

        //creating a game
        group.MapPost("", (CreateGameDto newGame) =>
        {

            // if(string.IsNullOrEmpty(newGame.Name)){
            //     return Results.BadRequest("Name is required");
            // } // easy implementation of not allowing an empty Name field

            GameDto game = new(  // we are creating a single game of type GameDto
                games.Count + 1, // count the number of games and increment them by one and set it as the new id.
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate);

            games.Add(game); // from our list of games we want to add a new game

            return Results.CreatedAtRoute(GameEndpoint, new { id = game.Id }, game);
        }) .WithParameterValidation(); // this method works with our data annotations for field validation!!

        // updating a game 
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // deleting a game
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group; // innitialy we were returning app but since now we are storing  our endpoints in group we return group
    }
}
