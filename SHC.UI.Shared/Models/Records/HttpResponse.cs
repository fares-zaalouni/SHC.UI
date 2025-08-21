using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Models.Records;

public record HttpResponse<TContent>
{
    public TContent? Content { get; }
    public HttpStatusCode StatusCode { get; }

    public HttpResponse(TContent? content, HttpStatusCode statusCode)
    {
        Content = content;
        StatusCode = statusCode;
    }
}
