using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class PrescriptionMedicine
{
    public int Id { get; set; }

    public int PrescriptionId { get; set; }

    public int MedicineId { get; set; }

    public string? Dosage { get; set; }

    public int? Quantity { get; set; }

    public virtual Medicine Medicine { get; set; } = null!;

    public virtual Prescription Prescription { get; set; } = null!;
}
