using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IPatientRepository
    {
        public void AddNewPatient(Patient patient);
        IEnumerable<Patient> AllPatients();
        Patient GetPatientById(int id);
        void UpdatePatient(Patient patient);
    }
}
