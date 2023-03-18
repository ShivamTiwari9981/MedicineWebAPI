using System;
using System.Collections.Generic;

namespace MedicineWebAPI.MedicineDb
{
    public partial class TblMedicine
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = null!;
        public string Manufecturer { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ImageUrl { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CrtdOn { get; set; }
        public DateTime UpdtOn { get; set; }
    }
}
