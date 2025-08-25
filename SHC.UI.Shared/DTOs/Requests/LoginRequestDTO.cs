using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.DTOs.Requests
{
    public class LoginRequestDTO
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Guid DeviceId { get; set; }
        public string LoginType { get; set; }
        public LoginRequestDTO(string phoneNumber, string password, string loginType, Guid deviceId)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            LoginType = loginType;
            DeviceId = deviceId;
        }
    }
}
