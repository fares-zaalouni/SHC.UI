using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.Shared.Services;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Forms;
using SHC.UI.WinUI.MVVM.Forms.Validators;
using SHC.UI.WinUI.MVVM.Interfaces;


namespace SHC.UI.WinUI.MVVM.ViewModels;

public partial class PatientOptionalInfoViewModel : ObservableObject, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly IPatientService _patientService;
    public required IDialogFactory dialogFactory;
    public required RegisterPatientRequestDTO RegisterPatientRequest { get; set; }
    public Form OptionalPatientInfo;
    
    public PatientOptionalInfoViewModel(
        INavigationService navigationService,
        IPatientService patientService
        )
    {
        _navigationService = navigationService;
        _patientService = patientService;

        OptionalPatientInfo = InitForm();
        
    }
    public void SetDialogFactory(IDialogFactory dialogFactory)
    {
        this.dialogFactory = dialogFactory;
    }

    private Form InitForm()
    {
        return new Form(
            new Dictionary<string, IFormField>()
            {
                {
                    nameof(RegisterPatientRequestDTO.Email),
                    new FormField<string>("Email", "Enter email",
                    validators: [new RegExValidator(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", "Invalid email format")]
                    )
                },
                {
                    nameof(RegisterPatientRequestDTO.Cin),
                    new FormField<string>("Cin", "Enter Cin",
                    validators: [new LengthValidator(8, "CIN must be 8 characters long")]
                    )
                },
                {
                    nameof(RegisterPatientRequestDTO.EmergencyContactName),
                    new FormField<string>("Emergency Contact Name", "Enter emergency contact name",
                    validators: [new MinLengthValidator(3, "Emergency contact name should be at least 3 characters long!")]
                    )
                },
                {
                    nameof(RegisterPatientRequestDTO.EmergencyContactPhone),
                    new FormField<string>("Emergency Contact Phone Number", "Enter emergency contact name number",
                    validators: [new LengthValidator(8, "Emergency contact phone number must be 8 characters long")]
                    )
                }
            }
        );
    }
    public IFormField Email
    => OptionalPatientInfo.Fields[nameof(RegisterPatientRequestDTO.Email)];

    public IFormField Cin
        => OptionalPatientInfo.Fields[nameof(RegisterPatientRequestDTO.Cin)];

    public IFormField EmergencyContactName
        => OptionalPatientInfo.Fields[nameof(RegisterPatientRequestDTO.EmergencyContactName)];

    public IFormField EmergencyContactPhone
        => OptionalPatientInfo.Fields[nameof(RegisterPatientRequestDTO.EmergencyContactPhone)];
    public void OnNavigatedTo(object parameter)
    {
        if (parameter is RegisterPatientRequestDTO patientRequestDTO)
        {
            RegisterPatientRequest = patientRequestDTO;
        }
    }
    public void OnNavigatedFrom()
    {
        throw new NotImplementedException();
    }
    [RelayCommand]
    public void GoBack()
    {
        _navigationService.GoBack(PageKey.PatientOptionalInfo);
    }
    [RelayCommand]
    public async Task Submit()
    {
        if (OptionalPatientInfo.IsValid())
        {
            OptionalPatientInfo.CastTo(RegisterPatientRequest);
            var result = await _patientService.RegisterPatient(RegisterPatientRequest);
            if (result.IsSuccess)
            {
                dialogFactory.PopUp("Patient Added","Chose action", () => _navigationService.Navigate(PageKey.Login) );
            }
        }
    }

}
