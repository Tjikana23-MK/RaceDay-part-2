using System.ComponentModel.DataAnnotations;
namespace RaceDay.Api.DTOs;
public record RegisterRequest([Required,MaxLength(100)] string FullName,[Required,EmailAddress] string Email,[Required,MinLength(8)] string Password,[Required] string Role,string? Phone);
public record LoginRequest([Required,EmailAddress] string Email,[Required] string Password);
public record ProfileUpdateRequest([Required,MaxLength(100)] string FullName,[EmailAddress] string Email,string? Phone);
public record EventRequest([Required,MaxLength(150)] string Name,string Description,DateTime EventDate,[Required] string Location,[Range(0.1,1000)] decimal DistanceKm,int EventTypeId);
public record CategoryRequest([Required,MaxLength(80)] string Name,string CategoryType,int? MinimumAge,int? MaximumAge,decimal? DistanceKm);
public record EnrolmentRequest(int EventId,int CategoryId);
public record ResultRequest(TimeSpan FinishTime,[Range(1,int.MaxValue)] int FinishingPosition);
