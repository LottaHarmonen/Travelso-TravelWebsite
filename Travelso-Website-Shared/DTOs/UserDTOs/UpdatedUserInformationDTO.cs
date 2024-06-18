using System.ComponentModel.DataAnnotations;

namespace Travelso_Website_Shared.DTOs.UserDTOs;

public class UpdatedUserInformationDTO
{
    public string? UserName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? ProfileImage { get; set; }
}