using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDBContext _patientDBContext;

        public PatientRepository(PatientDBContext patientDBContext)
        {
            _patientDBContext = patientDBContext;
        }
        public void AddNewPatient(Patient patient)
        {
            _patientDBContext.Patients.Add(patient);
            _patientDBContext.SaveChanges();
        }

        public IEnumerable<Patient> AllPatients()
        {
           var patients =  _patientDBContext.Patients.ToList();
            return patients;
        }

        public Patient GetPatientById(int id)
        {
            var patient = _patientDBContext.Patients.Find(id);
            return patient;
        }

        public void UpdatePatient(Patient patient)
        {
            _patientDBContext.Update(patient);
            _patientDBContext.SaveChanges();
        }
    }
}
