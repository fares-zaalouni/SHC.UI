
namespace SHC.UI.WinUI.MVVM.Forms.Validators;

public class DateBeforeValidator : IValidator<DateTime>, IValidator<DateTimeOffset>
{
    private readonly DateTime _date;
    public string ErrorMessage { get; } = string.Empty;
    public DateBeforeValidator(DateTime date, string errorMessage = "Date is not before the required date")
    {
        _date = date;
        ErrorMessage = errorMessage;
    }
    public DateBeforeValidator(DateTimeOffset date, string errorMessage = "Date is not before the required date")
    {
        _date = date.DateTime;
        ErrorMessage = errorMessage;
    }
    public bool Validate(DateTime value)
    {
        return value < _date;
    }

    public bool Validate(DateTimeOffset value)
    {
        return value.DateTime < _date;
    }
}
