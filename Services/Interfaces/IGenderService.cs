using ViewModels.ViewModel;

namespace Services.Interfaces
{
    public interface IGenderService
    {
        IEnumerable<GenderViewModel> Genders();
    }
}
