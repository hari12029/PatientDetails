using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly PatientDBContext _patientDBContext;
        public GenderRepository(PatientDBContext patientDBContext)
        {
            _patientDBContext = patientDBContext;
        }

        public IEnumerable<Gender> GetGenders()
        {
            return _patientDBContext.Genders.ToList();
        }
    }
}
