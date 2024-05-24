using System.ComponentModel.DataAnnotations;

namespace Travelso_Website_Shared.Entities;

public class Destination
{
    [Key]
    public int DestinationId { get; set; }

    public string Name { get; set; }

    public string? ImageUrl { get; set; }

    public int CountryId { get; set; } 
    public Country Country { get; set; }
}