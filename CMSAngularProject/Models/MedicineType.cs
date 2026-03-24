using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class MedicineType
{
    public int MedicineTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
