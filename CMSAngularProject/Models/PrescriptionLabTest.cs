using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class PrescriptionLabTest
{
    public int Id { get; set; }

    public int PrescriptionId { get; set; }

    public int LabTestId { get; set; }

    public string? Status { get; set; }

    public virtual LabResult? LabResult { get; set; }

    public virtual LabTest LabTest { get; set; } = null!;

    public virtual Prescription Prescription { get; set; } = null!;
}
