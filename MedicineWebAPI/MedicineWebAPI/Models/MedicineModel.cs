namespace MedicineWebAPI.Models
{
    public class MedicineModel:BaseModel
    {
        public int MedicineId { get; set; }
        public string? MedicineName { get; set; }
        public string? Manufecturer { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? ImageUrl { get; set; }
    }
}
