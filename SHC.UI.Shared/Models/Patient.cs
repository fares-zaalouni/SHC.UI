using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Models
{
    public class Patient : User
    {
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public BloodType? BloodType { get; set; }
        public float? Weight { get; set; }
        public float? Height { get; set; }
        public  IList<Appointment> Appointments { get; set; } = new List<Appointment>();
        public  IList<Allergy> Allergies { get; set; } = new List<Allergy>();
        public  IList<MedicalCondition> MedicalConditions { get; set; } = new List<MedicalCondition>();
        public  IList<MedicalPlan> MedicalPlans { get; set; } = new List<MedicalPlan>();
    }
}
