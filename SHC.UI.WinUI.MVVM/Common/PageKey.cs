using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.WinUI.MVVM.Common;

public class PageKey
{
    public string Key { get; }

    private PageKey(string key)
    {
        Key = key;
    }

    public static readonly PageKey Login = new PageKey("Login");
    public static readonly PageKey RegisterPatient = new PageKey("RegisterPatient");
    public static readonly PageKey Content = new PageKey("Content");
    public static readonly PageKey Settings = new PageKey("Settings");
    public static readonly PageKey PatientEssentialInfo = new PageKey("PatientEssentialInfo");
    public static readonly PageKey PatientOptionalInfo = new PageKey("PatientOptionalInfo");
}
