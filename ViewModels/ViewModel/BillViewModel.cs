using DataAccess.Entities;

namespace ViewModels.ViewModel
{
    public class BillViewModel
    {
        public int BillId { get; set; }
        public string BillDate { get; set; }
        public string? ItemName { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
