using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IBillRepository
    { 
        void CreateBill(Bill bill);
        IEnumerable<Bill> AllBills();
        Bill GetBillById(int id);
        void UpdateBill(Bill bill);
    }
}
