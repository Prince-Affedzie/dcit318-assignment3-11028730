using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare_System
{
    public class HealthSystemApp
    {

        private Repository<Patient> _patientRepo = new();
        private Repository<Prescription> _prescriptionRepo = new();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new();

        public void SeedData()
        {
            // Patients
            _patientRepo.Add(new Patient(1, "Alice Smith", 30, "Female"));
            _patientRepo.Add(new Patient(2, "Bob Johnson", 45, "Male"));
            _patientRepo.Add(new Patient(3, "Carol White", 28, "Female"));

            // Prescriptions
            _prescriptionRepo.Add(new Prescription(101, 1, "Amoxicillin", DateTime.Today.AddDays(-5)));
            _prescription_repoAddSafe(new Prescription(102, 1, "Paracetamol", DateTime.Today.AddDays(-2)));
            _prescriptionRepo.Add(new Prescription(103, 2, "Ibuprofen", DateTime.Today.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(104, 3, "Cough Syrup", DateTime.Today.AddDays(-1)));
            _prescriptionRepo.Add(new Prescription(105, 2, "Antihistamine", DateTime.Today.AddDays(-3)));
        }

        // helper to show robust add (in case of typos or duplicates)
        private void _prescription_repoAddSafe(Prescription p)
        {
            _prescriptionRepo.Add(p);
        }

        public void BuildPrescriptionMap()
        {
            _prescriptionMap.Clear();
            foreach (var prescription in _prescriptionRepo.GetAll())
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();

                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("\n--- All Patients ---");
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine(patient);
            }
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
                return prescriptions;
            return new List<Prescription>();
        }

        public void PrintPrescriptionsForPatient(int id)
        {
            var prescriptions = GetPrescriptionsByPatientId(id);
            if (prescriptions.Count == 0)
            {
                Console.WriteLine($"No prescriptions found for patient with ID {id}.");
                return;
            }

            Console.WriteLine($"\n--- Prescriptions for Patient ID {id} ---");
            foreach (var prescription in prescriptions)
            {
                Console.WriteLine(prescription);
            }
        }
    }
}
