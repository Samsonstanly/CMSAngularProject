using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public int EmployeeId { get; set; }

    public int SpecializationId { get; set; }

    public decimal ConsultationFee { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual Specialization Specialization { get; set; } = null!;
}
