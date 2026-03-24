using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CMSAngularProject.Models;

public partial class CampSixContext : DbContext
{
    public CampSixContext()
    {
    }

    public CampSixContext(DbContextOptions<CampSixContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<LabResult> LabResults { get; set; }

    public virtual DbSet<LabTest> LabTests { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<MedicineType> MedicineTypes { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PharmacyBill> PharmacyBills { get; set; }

    public virtual DbSet<PharmacyBillItem> PharmacyBillItems { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<PrescriptionLabTest> PrescriptionLabTests { get; set; }

    public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SAMSON\\SQLEXPRESS;Initial Catalog=CampSix;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC2E436ABDA");

            entity.HasIndex(e => e.DoctorId, "IX_Appointment_Doctor");

            entity.HasIndex(e => e.PatientId, "IX_Appointment_Patient");

            entity.HasIndex(e => new { e.DoctorId, e.SlotStart }, "UQ_Doctor_Slot").IsUnique();

            entity.HasIndex(e => e.Token, "UQ__Appointm__1EB4F817F641F90D").IsUnique();

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("BOOKED");
            entity.Property(e => e.Token)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Patient");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EBF725D9754");

            entity.HasIndex(e => e.EmployeeId, "UQ__Doctors__7AD04F10347E1785").IsUnique();

            entity.Property(e => e.ConsultationFee).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Employee).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Employee");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Specialization");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11AE6BB93A");

            entity.HasIndex(e => e.Username, "UQ__Employee__536C85E4BF71C9ED").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<LabResult>(entity =>
        {
            entity.HasKey(e => e.LabResultId).HasName("PK__LabResul__3CEBE3B6981067D4");

            entity.HasIndex(e => e.PrescriptionLabTestId, "UQ__LabResul__67DB6C7B90E28BC1").IsUnique();

            entity.Property(e => e.Result)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.PrescriptionLabTest).WithOne(p => p.LabResult)
                .HasForeignKey<LabResult>(d => d.PrescriptionLabTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LabResult_PLT");
        });

        modelBuilder.Entity<LabTest>(entity =>
        {
            entity.HasKey(e => e.LabTestId).HasName("PK__LabTests__64D33925C852F73F");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("PK__Medicine__4F212890DCC04064");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MedicineType).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.MedicineTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Type");
        });

        modelBuilder.Entity<MedicineType>(entity =>
        {
            entity.HasKey(e => e.MedicineTypeId).HasName("PK__Medicine__AB4D179454F016C2");

            entity.HasIndex(e => e.TypeName, "UQ__Medicine__D4E7DFA80DEE0751").IsUnique();

            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC366D5DCBD4D");

            entity.HasIndex(e => e.Phone, "UQ__Patients__5C7E359E6636AA6D").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Patient_Employee");
        });

        modelBuilder.Entity<PharmacyBill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Pharmacy__11F2FC6AC406C401");

            entity.HasIndex(e => e.PrescriptionId, "UQ__Pharmacy__401308337D5987CE").IsUnique();

            entity.Property(e => e.BillDate).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.PaymentStatus).HasDefaultValue(false);

            entity.HasOne(d => d.Prescription).WithOne(p => p.PharmacyBill)
                .HasForeignKey<PharmacyBill>(d => d.PrescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PharmacyBill_Prescription");
        });

        modelBuilder.Entity<PharmacyBillItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pharmacy__3214EC079782FC59");

            entity.HasIndex(e => e.BillId, "IX_PBI_Bill");

            entity.Property(e => e.SubTotal)
                .HasComputedColumnSql("([Quantity]*[UnitPrice])", true)
                .HasColumnType("decimal(21, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Bill).WithMany(p => p.PharmacyBillItems)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PBI_Bill");

            entity.HasOne(d => d.Medicine).WithMany(p => p.PharmacyBillItems)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PBI_Medicine");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__4013083225326227");

            entity.HasIndex(e => e.AppointmentId, "IX_Prescription_Appointment");

            entity.HasIndex(e => e.AppointmentId, "UQ__Prescrip__8ECDFCC3E4E58EC2").IsUnique();

            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Appointment).WithOne(p => p.Prescription)
                .HasForeignKey<Prescription>(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Appointment");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Doctor");
        });

        modelBuilder.Entity<PrescriptionLabTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prescrip__3214EC070AECA3B1");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.LabTest).WithMany(p => p.PrescriptionLabTests)
                .HasForeignKey(d => d.LabTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PLT_LabTest");

            entity.HasOne(d => d.Prescription).WithMany(p => p.PrescriptionLabTests)
                .HasForeignKey(d => d.PrescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PLT_Prescription");
        });

        modelBuilder.Entity<PrescriptionMedicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prescrip__3214EC07152B2A25");

            entity.HasIndex(e => e.PrescriptionId, "IX_PM_Prescription");

            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Medicine).WithMany(p => p.PrescriptionMedicines)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PM_Medicine");

            entity.HasOne(d => d.Prescription).WithMany(p => p.PrescriptionMedicines)
                .HasForeignKey(d => d.PrescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PM_Prescription");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A6E9542BE");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61609F9995F4").IsUnique();

            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecializationId).HasName("PK__Speciali__5809D86F9DB32BB7");

            entity.HasIndex(e => e.Name, "UQ__Speciali__737584F69F60CAB0").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
