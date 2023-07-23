using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public DateTime? BillDate { get; set; }
        public string? ItemName { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
        public int? PatientId { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
