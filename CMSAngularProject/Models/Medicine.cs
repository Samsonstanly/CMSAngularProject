using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class Medicine
{
    public int MedicineId { get; set; }

    public string Name { get; set; } = null!;

    public int MedicineTypeId { get; set; }

    public decimal Price { get; set; }

    public int StockQty { get; set; }

    public virtual MedicineType MedicineType { get; set; } = null!;

    public virtual ICollection<PharmacyBillItem> PharmacyBillItems { get; set; } = new List<PharmacyBillItem>();

    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}
