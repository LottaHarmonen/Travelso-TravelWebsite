using System.ComponentModel.DataAnnotations;

namespace Travelso_Website_Shared.Entities;

public class Country
{
    [Key]
    public int CountryId { get; set; } 

    public string Name { get; set; }

    public string ImageURL { get; set; }

    public virtual ICollection<Destination> Destinations { get; set; }

    public virtual ICollection<TravelsoUser> TravelsoUsers { get; set; }
}