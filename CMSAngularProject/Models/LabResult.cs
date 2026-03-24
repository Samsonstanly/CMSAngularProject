using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class LabResult
{
    public int LabResultId { get; set; }

    public int PrescriptionLabTestId { get; set; }

    public string? Result { get; set; }

    public virtual PrescriptionLabTest PrescriptionLabTest { get; set; } = null!;
}
