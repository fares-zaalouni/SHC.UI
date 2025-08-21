using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Common;

public class ErrorDetail
{
    public ErrorType Type { get; }
    public string Message { get; }

    public ErrorDetail(ErrorType type, string message)
    {
        Type = type;
        Message = message;
    }
}
