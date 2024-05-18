using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;


//using data annotations to implement field validation in .NET

//NB: to use data annotations we need line 1; using System.ComponentModel.DataAnnotations;
public record class CreateGameDto(
   [Required] [StringLength(50)] string Name, // our name must be inputed and it should not be more that 50 characters long
    [Required] [StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);

// this alone does not set the validations it requires more support
// instead we are going to download a nuget packet manager and pass a method provided by nuget in our endpoint
// that method is called .WithParameterValidation()