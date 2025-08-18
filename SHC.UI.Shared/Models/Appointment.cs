

namespace SHC.UI.Shared.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsUrgent { get; set; }
        public int DurationInMin { get;  set; }
        public Guid PatientId { get; set; }
        
    }
}
