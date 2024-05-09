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
List<GameDto> games = [
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
app.MapGet("games/{id}", ( int id) => games.Find(game => game.Id == id) ).WithName(GameEndpoint);

//creating a game
app.MapPost("games", ( CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);

        games.Add(game);

        return Results.CreatedAtRoute(GameEndpoint, new {id = game.Id}, game);
});


app.Run();
