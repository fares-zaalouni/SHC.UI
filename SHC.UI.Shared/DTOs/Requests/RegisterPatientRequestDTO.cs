using SHC.UI.Shared.Models;


namespace SHC.UI.Shared.DTOs.Requests;

public class RegisterPatientRequestDTO
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Cin { get; set; }
    public DateTime Dob { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public BloodType? BloodType { get; set; }
    public float? Weight { get; set; }
    public float? Height { get; set; }
}
