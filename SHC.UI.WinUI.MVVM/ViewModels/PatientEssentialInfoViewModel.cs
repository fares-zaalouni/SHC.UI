
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.Shared.Models;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Forms;
using SHC.UI.WinUI.MVVM.Forms.Validators;
using SHC.UI.WinUI.MVVM.Interfaces;

namespace SHC.UI.WinUI.MVVM.ViewModels;

public partial class PatientEssentialInfoViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    public readonly Form EssentialPatientInfo;
    public IFormField FirstName => EssentialPatientInfo.Fields[nameof(RegisterPatientRequestDTO.Firstname)];
    public IFormField LastName => EssentialPatientInfo.Fields[nameof(RegisterPatientRequestDTO.Lastname)];
    public IFormField Phone => EssentialPatientInfo.Fields[nameof(RegisterPatientRequestDTO.PhoneNumber)];
    public IFormField DateOfBirth => EssentialPatientInfo.Fields[nameof(RegisterPatientRequestDTO.Dob)];
    public IFormField Password => EssentialPatientInfo.Fields[nameof(RegisterPatientRequestDTO.Password)];
    public IFormField ConfirmPassword => EssentialPatientInfo.Fields["ConfirmPassword"];
    public PatientEssentialInfoViewModel(INavigationService navigationService)
    {
        EssentialPatientInfo = new Form(
            new Dictionary<string, IFormField>()
            {
                    {
                        nameof(RegisterPatientRequestDTO.Firstname),
                        new FormField<string>("First Name", "Enter firstname",
                       validators: [new MinLengthValidator(3, "Firstname should be at least 3 characters long!")]
                       )
                    },
                    {
                        nameof(RegisterPatientRequestDTO.Lastname),
                        new FormField<string>("Last Name", "Enter lastname",
                       validators: [new MinLengthValidator(3, "Lastname should be at least 3 characters long!")]
                       )
                    },
                    {
                        nameof(RegisterPatientRequestDTO.PhoneNumber),
                        new FormField<string>("Phone Number", "Enter email",
                       validators: [new LengthValidator(8, "Phone number must be 8 characters long")]
                       )
                    },
                    {
                        nameof(RegisterPatientRequestDTO.Dob),
                        new FormField<DateTimeOffset>("Date of Birth", value: DateTimeOffset.Now,
                        validators: [new DateBeforeValidator(DateTime.Now, "Date of birth must be before today")]
                        )
                    },
                    {
                        nameof(RegisterPatientRequestDTO.Password),
                        new FormField<string>("Password", "Enter password",
                        validators: [
                            new RegExValidator("^(?=.*[A-Z]).*$", "Password must have an uppercase"),
                            new RegExValidator("^(?=.*\\d).*$", "Password must have a digit"),
                            new MinLengthValidator(8, "Password should be at least 8 characters long!")
                            ]
                       )
                    },
                    {
                        "ConfirmPassword",
                        new FormField<string>("Confirm Password", "Re-enter password",
                        validatorFunctions : [
                            ( (value) => value == ((FormField<string>)EssentialPatientInfo!.Fields[nameof(RegisterPatientRequestDTO.Password)]).Value, "Passwords do not match!")
                            ]
                       )
                    },
            });
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Continue()
    {
        if (EssentialPatientInfo.IsValid())
        {
            RegisterPatientRequestDTO dto = new();
            EssentialPatientInfo.CastTo(dto);
            _navigationService.Navigate(PageKey.PatientOptionalInfo, dto);
        }

    }

    
}
