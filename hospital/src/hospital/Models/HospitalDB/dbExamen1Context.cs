using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hospital.Models.HospitalDB
{
    public partial class dbExamen1Context : DbContext
    {
        public dbExamen1Context()
        {
        }

        public dbExamen1Context(DbContextOptions<dbExamen1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEspecialidad> TblEspecialidads { get; set; } = null!;
        public virtual DbSet<TblHistorialClinico> TblHistorialClinicos { get; set; } = null!;
        public virtual DbSet<TblMedicamento> TblMedicamentos { get; set; } = null!;
        public virtual DbSet<TblMedicamentosRecetum> TblMedicamentosReceta { get; set; } = null!;
        public virtual DbSet<TblMedico> TblMedicos { get; set; } = null!;
        public virtual DbSet<TblPaciente> TblPacientes { get; set; } = null!;
        public virtual DbSet<TblRecetum> TblReceta { get; set; } = null!;
        public virtual DbSet<TblTipoDosi> TblTipoDoses { get; set; } = null!;
        public virtual DbSet<TblTipoLapso> TblTipoLapsos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("dbLocalExamen_1");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblEspecialidad>(entity =>
            {
                entity.HasKey(e => e.PkEspecialidadId);

                entity.ToTable("tblEspecialidad");

                entity.Property(e => e.PkEspecialidadId).HasColumnName("pkEspecialidadID");

                entity.Property(e => e.CodigoEspecialidad)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");
            });

            modelBuilder.Entity<TblHistorialClinico>(entity =>
            {
                entity.HasKey(e => e.PkHitorialClinicoId);

                entity.ToTable("tblHistorialClinico");

                entity.Property(e => e.PkHitorialClinicoId).HasColumnName("pkHitorialClinicoID");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Diagnostico)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.DtFechaConsulta)
                    .HasColumnType("datetime")
                    .HasColumnName("dtFechaConsulta");

                entity.Property(e => e.FkMedicoId).HasColumnName("fkMedicoID");

                entity.Property(e => e.FkPacienteId).HasColumnName("fkPacienteID");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.Sitomas)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.HasOne(d => d.FkMedico)
                    .WithMany(p => p.TblHistorialClinicos)
                    .HasForeignKey(d => d.FkMedicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHistorialClinico_tblMedico");

                entity.HasOne(d => d.FkPaciente)
                    .WithMany(p => p.TblHistorialClinicos)
                    .HasForeignKey(d => d.FkPacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHistorialClinico_tblPaciente");
            });

            modelBuilder.Entity<TblMedicamento>(entity =>
            {
                entity.HasKey(e => e.PkMedicamentoId);

                entity.ToTable("tblMedicamento");

                entity.Property(e => e.PkMedicamentoId).HasColumnName("pkMedicamentoID");

                entity.Property(e => e.CodigoMedicamento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");
            });

            modelBuilder.Entity<TblMedicamentosRecetum>(entity =>
            {
                entity.HasKey(e => e.PkMedicametosRecetaId);

                entity.ToTable("tblMedicamentosReceta");

                entity.Property(e => e.PkMedicametosRecetaId).HasColumnName("pkMedicametosRecetaID");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkMedicamentoId).HasColumnName("fkMedicamentoID");

                entity.Property(e => e.FkRecetaId).HasColumnName("fkRecetaID");

                entity.Property(e => e.FkTipoDosis).HasColumnName("fkTipoDosis");

                entity.Property(e => e.FkTipoLapsoId).HasColumnName("fkTipoLapsoID");

                entity.HasOne(d => d.FkMedicamento)
                    .WithMany(p => p.TblMedicamentosReceta)
                    .HasForeignKey(d => d.FkMedicamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMedicamentosReceta_tblMedicamento");

                entity.HasOne(d => d.FkReceta)
                    .WithMany(p => p.TblMedicamentosReceta)
                    .HasForeignKey(d => d.FkRecetaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMedicamentosReceta_tblReceta");

                entity.HasOne(d => d.FkTipoDosisNavigation)
                    .WithMany(p => p.TblMedicamentosReceta)
                    .HasForeignKey(d => d.FkTipoDosis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMedicamentosReceta_tblTipoDosis");

                entity.HasOne(d => d.FkTipoLapso)
                    .WithMany(p => p.TblMedicamentosReceta)
                    .HasForeignKey(d => d.FkTipoLapsoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMedicamentosReceta_tblTipoLapso");
            });

            modelBuilder.Entity<TblMedico>(entity =>
            {
                entity.HasKey(e => e.PkMedicoId);

                entity.ToTable("tblMedico");

                entity.Property(e => e.PkMedicoId).HasColumnName("pkMedicoID");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.CedulaProfesional)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.FkEspecialidadId).HasColumnName("fkEspecialidadID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.HasOne(d => d.FkEspecialidad)
                    .WithMany(p => p.TblMedicos)
                    .HasForeignKey(d => d.FkEspecialidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMedico_tblEspecialidad");
            });

            modelBuilder.Entity<TblPaciente>(entity =>
            {
                entity.HasKey(e => e.PkPacienteId)
                    .HasName("PK_tblMedicos");

                entity.ToTable("tblPaciente");

                entity.Property(e => e.PkPacienteId).HasColumnName("pkPacienteID");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Domicillio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");
            });

            modelBuilder.Entity<TblRecetum>(entity =>
            {
                entity.HasKey(e => e.PkRecetaId);

                entity.ToTable("tblReceta");

                entity.Property(e => e.PkRecetaId).HasColumnName("pkRecetaID");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkHistorialClinicoId).HasColumnName("fkHistorialClinicoID");

                entity.Property(e => e.FkMedicamentoId).HasColumnName("fkMedicamentoID");

                entity.Property(e => e.FkTipoDosisId).HasColumnName("fkTipoDosisID");

                entity.Property(e => e.FkTipoLapsoId).HasColumnName("fkTipoLapsoID");

                entity.HasOne(d => d.FkHistorialClinico)
                    .WithMany(p => p.TblReceta)
                    .HasForeignKey(d => d.FkHistorialClinicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblReceta_tblHistorialClinico");
            });

            modelBuilder.Entity<TblTipoDosi>(entity =>
            {
                entity.HasKey(e => e.PkTipoDosisId);

                entity.ToTable("tblTipoDosis");

                entity.Property(e => e.PkTipoDosisId).HasColumnName("pkTipoDosisID");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");
            });

            modelBuilder.Entity<TblTipoLapso>(entity =>
            {
                entity.HasKey(e => e.PkTipoLapsoId);

                entity.ToTable("tblTipoLapso");

                entity.Property(e => e.PkTipoLapsoId).HasColumnName("pkTipoLapsoID");

                entity.Property(e => e.CrBy).HasDefaultValueSql("(user_id())");

                entity.Property(e => e.CrDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .UseCollation("Traditional_Spanish_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
