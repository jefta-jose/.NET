using GameStore.Api;
using GameStore.Api.Endpoints; // This is where your API endpoints are defined

//-----------------------------------------------------
// Create a new builder for the web application
var builder = WebApplication.CreateBuilder(args);
// Build the web application using the builder
var app = builder.Build();
//-----------------------------------------------------

var connString = "Data Source = GameStore.db"; //var connString = "Data Source = GameStore.db";: This line is creating a variable named connString and setting it to the string "Data Source = GameStore.db". This string is the connection string for your SQLite database. It tells your application where to find the database file (GameStore.db).
builder.Services.AddSqlite<GameStoreContext>(connString); //builder.Services.AddSqlite<GameStoreContext>(connString);: This line is adding the GameStoreContext to the service container with a SQLite database provider. The AddSqlite method is an extension method provided by Entity Framework Core to register the context with dependency injection. It’s saying “I want to use SQLite as my database for GameStoreContext, and here’s the connection string to use.”

//-----------------------------------------------------
// Map the game endpoints/routes to the application. 
app.MapGamesEndpoints();
//-----------------------------------------------------


//-----------------------------------------------------
// Run the application. This starts listening for HTTP requests.
app.Run();
//-----------------------------------------------------
