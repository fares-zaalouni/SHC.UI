


namespace SHC.UI.Shared.Models
{
    public class MedicalCondition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid PatientId;
    }
}
