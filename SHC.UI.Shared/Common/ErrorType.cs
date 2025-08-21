using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Common;

public enum ErrorType
{
    None,              
    Validation,        
    Unauthorized,    
    NotFound,          
    Conflict,          
    Server,           
    Network,           
    Unexpected
}
