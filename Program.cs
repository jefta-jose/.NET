using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GameEndpoint = "GetGame";

/*
Here we create a List of games
but this List, is of type <GameDto>
which means it can only contain objects that follow the 
structure defined in the GameDto class.

new (...): This syntax is used to create a new instance of an 
object. In this case, it's creating a new GameDto object.
*/


List<GameDto> games = [ // THIS LIST METHOD IS USED WHEN WE HAVE PREDEFINED VALEUS 
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

//getting all games
app.MapGet("games", ()=> games);

//getting a game by its ID
app.MapGet("games/{id}", ( int id ) => games.Find(game => game.Id == id) ).WithName(GameEndpoint);

//creating a game
app.MapPost("games", ( CreateGameDto newGame) =>
{
    GameDto game = new(  // we are creating a single game of type GameDto
        games.Count + 1, // count the number of games and increment them by one and set it as the new id.
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);

        games.Add(game); // from our list of games we want to add a new game

        return Results.CreatedAtRoute(GameEndpoint, new {id = game.Id}, game);
});

// updating a game 
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame)=>{
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
app.MapDelete("games/{id}", (int id)=>{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});


app.Run();
