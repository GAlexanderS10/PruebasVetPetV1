using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebasVetPetV1.Models
{
    public partial class PRUEBASVETPETContext : DbContext
    {
        public PRUEBASVETPETContext()
        {
        }

        public PRUEBASVETPETContext(DbContextOptions<PRUEBASVETPETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citum> Cita { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Mascotum> Mascota { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-89KUG9V2\\SQLEXPRESS;Initial Catalog=PRUEBASVETPET;Integrated Security=SSPI; User ID=sa;Password=**;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citum>(entity =>
            {
                entity.HasKey(e => e.NumCita)
                    .HasName("PK__CITA__7AD3B95D9FA0C9AD");

                entity.ToTable("CITA");

                entity.Property(e => e.NumCita)
                    .ValueGeneratedNever()
                    .HasColumnName("numCita");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_Id");

                entity.Property(e => e.DniPropietario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dniPropietario");

                entity.Property(e => e.Especie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("especie");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.NombreMascota)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreMascota");

                entity.Property(e => e.Raza)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("raza");

                entity.Property(e => e.Servicio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("servicio");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__CITA__cliente_Id__4CA06362");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.NroIdentidad)
                    .HasMaxLength(30)
                    .HasColumnName("nroIdentidad");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(50)
                    .HasColumnName("tipoDocumento");
            });

            modelBuilder.Entity<Mascotum>(entity =>
            {
                entity.HasKey(e => e.MascotaId)
                    .HasName("PK__MASCOTA__DE2B26BF05C67090");

                entity.ToTable("MASCOTA");

                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_Id");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .HasColumnName("color");

                entity.Property(e => e.Especie)
                    .HasMaxLength(20)
                    .HasColumnName("especie");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Microchip)
                    .HasMaxLength(60)
                    .HasColumnName("microchip");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .HasColumnName("nombre");

                entity.Property(e => e.Raza)
                    .HasMaxLength(50)
                    .HasColumnName("raza");

                entity.Property(e => e.Registro)
                    .HasMaxLength(40)
                    .HasColumnName("registro");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(20)
                    .HasColumnName("sexo");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__MASCOTA__cliente__49C3F6B7");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("ROL");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("SERVICIO");

                entity.Property(e => e.ServicioId).HasColumnName("servicioId");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("precio");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(60)
                    .HasColumnName("nacionalidad");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .HasColumnName("nombres");

                entity.Property(e => e.NroIdentidad)
                    .HasMaxLength(30)
                    .HasColumnName("nroIdentidad");

                entity.Property(e => e.Passwo)
                    .HasMaxLength(100)
                    .HasColumnName("passwo");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(50)
                    .HasColumnName("tipoDocumento");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("userName");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
