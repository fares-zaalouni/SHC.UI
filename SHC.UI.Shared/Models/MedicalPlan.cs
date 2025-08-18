using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Models
{
    public class MedicalPlan
    {
        public Guid Id { get; private set; }
        public string MedicationName { get; private set; }
        public float DailyDoze { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public MedicationType MedicationType { get; private set; }
        public virtual IList<MedicationIntake> MedicationIntakes { get; private set; }
        public Guid PatientId;

        
    }
}
