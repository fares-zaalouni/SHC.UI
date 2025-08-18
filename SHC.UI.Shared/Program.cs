// See https://aka.ms/new-console-template for more information
using SHC.UI.Shared.DTOs;
using SHC.UI.Shared.Services;
Console.WriteLine("hello");
HttpClient httpClient = new HttpClient();
RegisterPatientDTO patientDTO = new RegisterPatientDTO();
patientDTO.Cin = "12345678";
patientDTO.Firstname = "fares";
patientDTO.Lastname = "zaalounini";
patientDTO.Email = "fares.zaalouni@gmail.com";
patientDTO.Dob = new DateTime(year: 2000, month: 1, day: 1);
patientDTO.Password = "Hellow852";
patientDTO.PhoneNumber = "12365478";
PatientService patientService = new PatientService(httpClient);
await patientService.RegisterPatient(patientDTO);