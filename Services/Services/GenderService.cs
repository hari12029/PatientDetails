using DataAccess.Entities;
using DataAccess.Interfaces;
using Services.Interfaces;
using ViewModels.ViewModel;

namespace Services.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _iGenderRepository;
        public GenderService(IGenderRepository genderRepository)
        {
            _iGenderRepository = genderRepository;
        }
        public IEnumerable<GenderViewModel> Genders()
        {
            IEnumerable<Gender> genders = _iGenderRepository.GetGenders();
            var genderViewModel = genders.Select(x => new GenderViewModel
            {
                Id = x.Id,
                Genders = x.Genders
            });
            return genderViewModel;
        }
    }
}
