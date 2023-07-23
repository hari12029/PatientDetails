using DataAccess.Entities;
using DataAccess.Interfaces;
using Services.Interfaces;
using ViewModels.ViewModel;

namespace Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _iPatientRepository;
        private readonly IGenderRepository _iGenderRepository;
        public PatientService(IPatientRepository patientRepository, IGenderRepository genderRepository)
        {
            _iPatientRepository = patientRepository;
            _iGenderRepository = genderRepository;
        }
        public void AddNewPatient(PatientViiewModel patientViiewModel)
        {
            Patient patient = new Patient()
            {
                Name = patientViiewModel.Name,
                Gender = patientViiewModel.Genders,
                PhoneNumber = patientViiewModel.PhoneNumber,
                Age = patientViiewModel.Age
            };
            _iPatientRepository.AddNewPatient(patient);
           
        }

        public IEnumerable<PatientViiewModel> AllPatients()
        {
            var patient = _iPatientRepository.AllPatients();
              var gender = _iGenderRepository.GetGenders();
          
            var results = from p in patient
                          join g in gender
                          on p.Gender equals g.Id.ToString()
                          select new
                          {
                              PatientId = p.PatientId,
                              Name = p.Name,
                              Gender = p.Gender,
                              Age = p.Age,
                              PhoneNumber = p.PhoneNumber,
                              Genders = g.Genders
                          };
           
            var patientViewModel = results.Select(x => new PatientViiewModel
            {
                PatientId = x.PatientId,
                Age = x.Age,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Gender = x.Gender,
                Genders = x.Genders
            }).ToList();

            return patientViewModel;
        }

        public PatientViiewModel GetPatientById(int id)
        {
            var patient = _iPatientRepository.GetPatientById(id);
            var patientViewModel = new PatientViiewModel()
            {
                PatientId = patient.PatientId,
                Name = patient.Name,
                Age = patient.Age,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber
            };
            return patientViewModel;
        }

        public void UpdatePatient(PatientViiewModel patientViiewModel)
        {
            var patient = _iPatientRepository.GetPatientById(patientViiewModel.PatientId);
            if(patient != null)
            {
                patient.PhoneNumber = patientViiewModel.PhoneNumber;
                patient.Gender = patientViiewModel.Genders;
                patient.Age = patientViiewModel.Age;
                patient.Name = patientViiewModel.Name;
                _iPatientRepository.UpdatePatient(patient);
            }
        }
    }
}
