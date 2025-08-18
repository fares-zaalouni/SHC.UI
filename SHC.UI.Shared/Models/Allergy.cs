using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Models
{
    public class Allergy
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Allergent { get; private set; }
        public Guid PatientId;
        public AllergySeverity AllergySeverity { get; private set; }

        
    }
}

