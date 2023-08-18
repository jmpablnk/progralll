using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_Final.Models
{
    public partial class PROYECTOFINALContext : DbContext
    {
        public PROYECTOFINALContext()
        {
        }

        public PROYECTOFINALContext(DbContextOptions<PROYECTOFINALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TProyecto> TProyecto { get; set; }
        public virtual DbSet<TRole> TRole { get; set; }
        public virtual DbSet<TTarea> TTarea { get; set; }
        public virtual DbSet<TUsuario> TUsuario { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TProyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PK_ID_PROYECTO");

                entity.ToTable("T_PROYECTO", "SCH_PROYECTOS");

                entity.Property(e => e.IdProyecto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PROYECTO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_FIN");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_INICIO");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");
            });

            modelBuilder.Entity<TRole>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK_ID_ROL");

                entity.ToTable("T_ROLES", "SCH_SEGURIDAD");

                entity.Property(e => e.IdRol)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ROL");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_ROL");
            });

            modelBuilder.Entity<TTarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK_ID_TAREA");

                entity.ToTable("T_TAREA", "SCH_PROYECTOS");

                entity.Property(e => e.IdTarea)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TAREA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_FIN");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_INICIO");

                entity.Property(e => e.IdProyecto).HasColumnName("ID_PROYECTO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.NivelDificultad).HasColumnName("NIVEL_DIFICULTAD");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.TTareas)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PROYECTO_TAREA");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TTareas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_USUARIO_TAREA");
            });

            modelBuilder.Entity<TUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_ID_USUARIO");

                entity.ToTable("T_USUARIO", "SCH_USUARIO");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_USUARIO");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.TUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ROL_USUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
