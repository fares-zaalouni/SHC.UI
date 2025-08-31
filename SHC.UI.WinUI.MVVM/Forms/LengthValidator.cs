using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.WinUI.MVVM.Forms.Validators;

public class LengthValidator : IValidator<string>
{
    private readonly int _length;
    public string ErrorMessage { get; } = string.Empty;

    public LengthValidator(int length, string errorMessage = "Value isn't the correct length")
    {
        _length = length;
        ErrorMessage = errorMessage;
    }
    public bool Validate(string value)
    {
        if (value is null) return false;
        return value.Length == _length;
    }
}
