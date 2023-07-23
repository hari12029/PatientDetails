using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Bills = new HashSet<Bill>();
        }

        public int PatientId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
