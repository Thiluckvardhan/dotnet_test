namespace Question1
{
    /// <summary>
    /// Patient billing data model with charges, discounts, and totals.
    /// Computed fields (gross, discount, final) are set by the billing logic.
    /// </summary>
    public class PatientBill
    {
        public string BillId { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public bool HasInsurance { get; set; }
        public decimal ConsultationFee { get; set; }
        public decimal LabCharges { get; set; }
        public decimal MedicineCharges { get; set; }
        // Sum of ConsultationFee + LabCharges + MedicineCharges
        public decimal GrossAmount { get; set; }
        // Discount applied (e.g., 10% when insured)
        public decimal DiscountAmount { get; set; }
        // Net payable after discount: GrossAmount - DiscountAmount
        public decimal FinalPayable { get; set; }

    }
}