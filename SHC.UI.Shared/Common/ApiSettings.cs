using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Common
{
    public class ApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string RegisterPatientEndpoint { get; set; } = string.Empty;
        public string LoginEndpoint { get; set; } = string.Empty;
        public string RenewTokensEndpoint { get; set; } = string.Empty;

    }
}
