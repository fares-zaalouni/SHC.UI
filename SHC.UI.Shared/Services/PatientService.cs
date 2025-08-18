using SHC.UI.Shared.Common;
using SHC.UI.Shared.DTOs;
using System.Text;
using System.Text.Json;


namespace SHC.UI.Shared.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiSettings = ConfigProvider.ApiSettings;
            _httpClient.BaseAddress = new Uri(_apiSettings.BaseUrl);

        }

        public async Task RegisterPatient(RegisterPatientDTO registerPatientDTO)
        {
            var json = JsonSerializer.Serialize(registerPatientDTO);
            Console.WriteLine(json);
            // Wrap JSON in HttpContent with proper encoding and media type
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send POST request with JSON body
            try
            {
                var response = await _httpClient.PostAsync(_apiSettings.RegisterPatientEndpoint, content);
                Console.WriteLine(_apiSettings.RegisterPatientEndpoint);

                Console.WriteLine(response);
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            // Return true if successful (status code 200-299)
        }
    }
}
