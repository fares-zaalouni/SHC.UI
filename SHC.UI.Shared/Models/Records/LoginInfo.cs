using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Models.Records;

public record LoginInfo(string Firstname, string Lastname)
{
    public string FullName => $"{Firstname} {Lastname}";
}
