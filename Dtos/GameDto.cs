namespace GameStore.Api.Dtos;
/*
/GameDto.cs: This file defines a class named GameDto which
represents the structure of a game. It has several 
properties like Id, Name, Genre, Price, and ReleaseDate.
This class is essentially a blueprint for how each game
object should look like.
*/


public record class GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);

// from this class 
//we can create a predefine game using a List<T> ie List<GameDto> games = [new(....), new(...)];
// or we can create a single game of type GameDto ie GameDto game = new(...);