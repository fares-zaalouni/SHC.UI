using CommunityToolkit.Mvvm.ComponentModel;
using SHC.UI.WinUI.MVVM.Forms.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SHC.UI.WinUI.MVVM.Forms;

public partial class FormField<T> : ObservableObject, IFormField
{
    [ObservableProperty]
    public partial string? Label { get; set; }
    [ObservableProperty]
    public partial T? Placeholder { get; set; }
    [ObservableProperty]
    public partial T? Value { get; set; }

    [ObservableProperty]
    public  partial string? ErrorMessage { get; set; }
    public IList<IValidator<T?>>? Validators { get; set; }
    public IList<ValueTuple<Func<T?, bool>, string>>? ValidatorFunctions { get; set; }
    public bool IsPassword { get; set; }

    object? IFormField.Value
    {
        get => Value;
        set
        {
            Value = (T?)value;
        }
    }
    object? IFormField.Placeholder {
        get => Placeholder;
        set
        {
            Placeholder = (T?)value;
        }
    }
    public FormField(string? label = null,
        T? placeholder = default,
        bool isPassword = false,
        T value = default,
        IList<ValueTuple<Func<T, bool>, string>>? validatorFunctions = null,
        IList<IValidator<T>>? validators = null
        )
    {
        Label = label;
        Placeholder = placeholder;
        IsPassword = isPassword;
        Value = value;
        ValidatorFunctions = validatorFunctions;
        Validators = validators;
    }
    public bool IsValid()
    {
        bool isValid = true;
        var errors = new List<string>();
        if (Validators != null)
        {
            foreach (var validator in Validators)
            {
                if (!validator.Validate(Value))
                {
                    errors.Add(validator.ErrorMessage);
                    isValid = false;
                }
            }
        }
        else if (ValidatorFunctions != null)
        {
            foreach (var (func, errorMessage) in ValidatorFunctions)
            {
                if (!func(Value))
                {
                    errors.Add(errorMessage);
                    isValid = false;
                }
            }            
        }
        ErrorMessage = string.Join(Environment.NewLine, errors);
        return isValid;
    }
}
