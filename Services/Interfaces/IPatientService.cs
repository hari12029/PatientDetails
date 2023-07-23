using ViewModels.ViewModel;

namespace Services.Interfaces
{
    public interface IPatientService
    {
        public void AddNewPatient(PatientViiewModel patientViiewModel);
        IEnumerable<PatientViiewModel> AllPatients();
        PatientViiewModel GetPatientById(int id);
        void UpdatePatient(PatientViiewModel patientViiewModel);
    }
}
