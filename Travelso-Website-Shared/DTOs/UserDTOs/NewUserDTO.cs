using System.ComponentModel.DataAnnotations;

namespace Travelso_Website_Shared.DTOs.UserDTOs;

public class NewUserDTO
{
    public string UserId { get; set; }
    public string Email { get; set; }
}