using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int AppointmentId { get; set; }

    public int DoctorId { get; set; }

    public string? Notes { get; set; }

    public DateTime? FollowUpDate { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual PharmacyBill? PharmacyBill { get; set; }

    public virtual ICollection<PrescriptionLabTest> PrescriptionLabTests { get; set; } = new List<PrescriptionLabTest>();

    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}
