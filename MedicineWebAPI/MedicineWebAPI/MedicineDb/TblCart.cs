using System;
using System.Collections.Generic;

namespace MedicineWebAPI.MedicineDb
{
    public partial class TblCart
    {
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public int? MedicineId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CrtdOn { get; set; }
        public DateTime UpdtOn { get; set; }
    }
}
