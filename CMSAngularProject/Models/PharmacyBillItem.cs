using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class PharmacyBillItem
{
    public int Id { get; set; }

    public int BillId { get; set; }

    public int MedicineId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? SubTotal { get; set; }

    public virtual PharmacyBill Bill { get; set; } = null!;

    public virtual Medicine Medicine { get; set; } = null!;
}
