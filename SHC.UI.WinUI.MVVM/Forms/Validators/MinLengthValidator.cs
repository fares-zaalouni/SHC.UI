using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.WinUI.MVVM.Forms.Validators;

public class MinLengthValidator : IValidator<string>
{
    private readonly int _minLength;
    public string ErrorMessage { get; } = string.Empty;

    public MinLengthValidator(int minLength, string errorMessage = "Value is too short")
    {
        _minLength = minLength;
        ErrorMessage = errorMessage;
    }
    public bool Validate(string value)
    {
        if (value is null) return false;
        return value.Length >= _minLength;
    }
}
