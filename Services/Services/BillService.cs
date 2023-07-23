using DataAccess.Entities;
using DataAccess.Interfaces;
using Services.Interfaces;
using ViewModels.ViewModel;

namespace Services.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _iBillRepository;
        private readonly IPatientRepository _iPatientRepository;
        public BillService(IBillRepository billRepository, IPatientRepository patientRepository)
        {
            _iBillRepository = billRepository;
            _iPatientRepository = patientRepository;
        }
        public IEnumerable<BillViewModel> AllBills()
        {
            var bill = _iBillRepository.AllBills();
            var patient = _iPatientRepository.AllPatients();
            var results = from B in bill
                          join P in patient
                          on B.PatientId equals P.PatientId
                          select new
                          {
                              PatientId = P.Name,
                              BillId = B.BillId,
                              AmountPaid = B.AmountPaid,
                              Balance = B.Balance,
                              ItemName = B.ItemName,
                              BillDate = B.BillDate,
                              TotalAmount = B.TotalAmount,
                              PatientName = P.Name
                          };

            var billViewModel = results.Select(x => new BillViewModel
            {
                  BillId = x.BillId,
                  AmountPaid = x.AmountPaid,
                  Balance = x.Balance,
                  ItemName = x.ItemName,
                  PatientName = x.PatientName,
                  BillDate = x.BillDate?.ToString("dd/MM/yyyy"),
                  TotalAmount = x.TotalAmount
            });
            return billViewModel;
        }

        public IEnumerable<BillViewModel> AllBillsByDates(CreateReportViewModel createReportViewModel)
        {
            var bill = _iBillRepository.AllBills();
            var billList = (from bl in bill
                      where (bl.BillDate >= createReportViewModel.StartDate && bl.BillDate <= createReportViewModel.EndDate)
                      select bl).ToList();
            var patient = _iPatientRepository.AllPatients();
            var results = from B in billList
                          join P in patient
                          on B.PatientId equals P.PatientId
                          select new
                          {
                              PatientId = P.Name,
                              BillId = B.BillId,
                              AmountPaid = B.AmountPaid,
                              Balance = B.Balance,
                              ItemName = B.ItemName,
                              BillDate = B.BillDate,
                              TotalAmount = B.TotalAmount,
                              PatientName = P.Name
                          };

            var billViewModel = results.Select(x => new BillViewModel
            {
                BillId = x.BillId,
                AmountPaid = x.AmountPaid,
                Balance = x.Balance,
                ItemName = x.ItemName,
                PatientName = x.PatientName,
                BillDate = x.BillDate?.ToString("dd/MM/yyyy"),
                TotalAmount = x.TotalAmount
            });
            return billViewModel;
        }


        public void CreateBill(BillViewModel billViewModel)
        {
            Bill bill = new Bill()
            {
                AmountPaid = billViewModel.AmountPaid,
                Balance = billViewModel.Balance,
                BillDate = DateTime.Parse(billViewModel.BillDate),
                TotalAmount = billViewModel.TotalAmount,
                ItemName = billViewModel.ItemName,
                PatientId = Convert.ToInt32(billViewModel.PatientName)
            };
            _iBillRepository.CreateBill(bill);
        }

        public BillViewModel GetBillById(int id)
        {
            var bill = _iBillRepository.GetBillById(id);
            var billViewModel = new BillViewModel()
            {
                Balance = bill.Balance,
                BillId = bill.BillId,
                AmountPaid = bill.AmountPaid,
                BillDate = bill.BillDate?.ToString("dd/MM/yyyy"),
                ItemName = bill.ItemName,
                PatientId = bill.PatientId,
                TotalAmount = bill.TotalAmount
            };
            return billViewModel;
        }

        public void UpdateBill(BillViewModel billViewModel)
        {
            var bill = _iBillRepository.GetBillById(billViewModel.BillId);
            if (bill != null)
            {
                bill.Balance = billViewModel.Balance;
                bill.BillId = billViewModel.BillId;
                bill.PatientId = billViewModel.PatientId;
                bill.BillDate = DateTime.Parse(billViewModel.BillDate);
                bill.AmountPaid = billViewModel.AmountPaid;
                bill.TotalAmount = billViewModel.TotalAmount;
                bill.ItemName = billViewModel.ItemName;
                _iBillRepository.UpdateBill(bill);
            }
        }
    }
}
