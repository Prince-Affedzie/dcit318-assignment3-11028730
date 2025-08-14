using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare_System
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string MedicationName { get; set; }
        public DateTime DateIssued { get; set; }

        public Prescription(int id, int patientId, string medicationName, DateTime dateIssued)
        {
            Id = id;
            PatientId = patientId;
            MedicationName = medicationName;
            DateIssued = dateIssued;
        }

        public override string ToString() => $"Prescription #{Id} for Patient {PatientId}: {MedicationName} ({DateIssued:d})";
    }
}
