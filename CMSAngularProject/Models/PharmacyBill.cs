using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class PharmacyBill
{
    public int BillId { get; set; }

    public int PrescriptionId { get; set; }

    public DateTime? BillDate { get; set; }

    public bool? PaymentStatus { get; set; }

    public virtual ICollection<PharmacyBillItem> PharmacyBillItems { get; set; } = new List<PharmacyBillItem>();

    public virtual Prescription Prescription { get; set; } = null!;
}
