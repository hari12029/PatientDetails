using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly PatientDBContext _patientDBContext;

        public BillRepository(PatientDBContext patientDBContext)
        {
            _patientDBContext = patientDBContext;
        }
        public void CreateBill(Bill bill)
        {
            _patientDBContext.Bills.Add(bill);
            _patientDBContext.SaveChanges();
        }

        public IEnumerable<Bill> AllBills()
        {
            var bills = _patientDBContext.Bills.ToList();
            return bills;
        }

        public Bill GetBillById(int id)
        {
            var bill = _patientDBContext.Bills.Find(id);
            return bill;
        }

        public void UpdateBill(Bill bill)
        {
            _patientDBContext.Update(bill);
            _patientDBContext.SaveChanges();
        }
    }
}

