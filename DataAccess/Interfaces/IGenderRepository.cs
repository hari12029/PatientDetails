using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IGenderRepository
    {
        IEnumerable<Gender> GetGenders();
    }
}
