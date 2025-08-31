

namespace SHC.UI.WinUI.MVVM.Forms.Validators;

internal class RegExValidator : IValidator<string>
{
    private readonly string _pattern;
    public string ErrorMessage { get; } = string.Empty;
    public RegExValidator(string pattern, string errorMessage = "Value doesn't match the required pattern")
    {
        _pattern = pattern;
        ErrorMessage = errorMessage;
    }
    public bool Validate(string value)
    {
        if (value is null) return false;

        return System.Text.RegularExpressions.Regex.IsMatch(value, _pattern);
    }
}
