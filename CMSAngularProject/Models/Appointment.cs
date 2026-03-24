using System;
using System.Collections.Generic;

namespace CMSAngularProject.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public DateTime SlotStart { get; set; }

    public DateTime SlotEnd { get; set; }

    public string Token { get; set; } = null!;

    public string? Status { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Prescription? Prescription { get; set; }
}
