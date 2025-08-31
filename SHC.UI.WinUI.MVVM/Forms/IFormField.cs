using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.WinUI.MVVM.Forms;

public interface IFormField
{
    object? Value { get; set; }
    object? Placeholder { get; set; }
    string? Label { get; set; }
    string? ErrorMessage { get; set; }
    bool IsValid();
}
