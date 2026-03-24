using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class LabTest
{
    public int LabTestId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<PrescriptionLabTest> PrescriptionLabTests { get; set; } = new List<PrescriptionLabTest>();
}
