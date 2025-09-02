using SHC.UI.Shared.Models;


namespace SHC.UI.Shared.DTOs.Requests
{
    public class LoginRequestDTO
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Guid DeviceId { get; set; }
        public Roles Role { get; set; }
        public LoginRequestDTO(string phoneNumber, string password, Roles role, Guid deviceId)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;
            DeviceId = deviceId;
        }
    }
}
