

namespace SHC.UI.Shared.Models
{
    public class MedicationIntake
    {
        public Guid Id { get; private set; }
        public float Doze { get; private set; }
        public DateTime IntakeTime { get; private set; }
        public Guid PatientId;

    }
}
