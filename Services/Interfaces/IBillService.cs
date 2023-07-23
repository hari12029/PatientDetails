using DataAccess.Entities;
using ViewModels.ViewModel;

namespace Services.Interfaces
{
    public interface IBillService
    {
        public void CreateBill(BillViewModel billViewModel);
        IEnumerable<BillViewModel> AllBills();
        BillViewModel GetBillById(int id);
        void UpdateBill(BillViewModel billViewModel);
    }
}
