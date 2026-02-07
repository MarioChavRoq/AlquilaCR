using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class AlquilaCrContext : DbContext
{
    public AlquilaCrContext()
    {
    }

    public AlquilaCrContext(DbContextOptions<AlquilaCrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<ImagenesPropiedad> ImagenesPropiedads { get; set; }

    public virtual DbSet<PerfilInquilino> PerfilInquilinos { get; set; }

    public virtual DbSet<Propiedade> Propiedades { get; set; }

    public virtual DbSet<PropuestasPropiedad> PropuestasPropiedads { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SolicitudesAlquiler> SolicitudesAlquilers { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9D2B80E3C59");

            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCita).HasColumnType("datetime");

            entity.HasOne(d => d.Inquilino).WithMany(p => p.CitaInquilinos)
                .HasForeignKey(d => d.InquilinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citas_Inquilino");

            entity.HasOne(d => d.Propiedad).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PropiedadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citas_Propiedades");

            entity.HasOne(d => d.Propietario).WithMany(p => p.CitaPropietarios)
                .HasForeignKey(d => d.PropietarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Citas_Propietario");
        });

        modelBuilder.Entity<ImagenesPropiedad>(entity =>
        {
            entity.HasKey(e => e.ImagenId).HasName("PK__Imagenes__0C7D20B7F36D2181");

            entity.ToTable("ImagenesPropiedad");

            entity.Property(e => e.Orden).HasDefaultValue(1);
            entity.Property(e => e.UrlImagen).HasMaxLength(255);

            entity.HasOne(d => d.Propiedad).WithMany(p => p.ImagenesPropiedads)
                .HasForeignKey(d => d.PropiedadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImagenesPropiedad_Propiedades");
        });

        modelBuilder.Entity<PerfilInquilino>(entity =>
        {
            entity.HasKey(e => e.PerfilInquilinoId).HasName("PK__PerfilIn__1D8A21353DAB45FD");

            entity.ToTable("PerfilInquilino");

            entity.HasIndex(e => e.UsuarioId, "UQ__PerfilIn__2B3DE7B95604D098").IsUnique();

            entity.Property(e => e.IngresoMensual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NotasAdicionales).HasMaxLength(500);
            entity.Property(e => e.Ocupacion).HasMaxLength(150);

            entity.HasOne(d => d.Usuario).WithOne(p => p.PerfilInquilino)
                .HasForeignKey<PerfilInquilino>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilInquilino_Usuarios");
        });

        modelBuilder.Entity<Propiedade>(entity =>
        {
            entity.HasKey(e => e.PropiedadId).HasName("PK__Propieda__D4B8C06D22C4EEFF");

            entity.Property(e => e.Canton).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.DireccionExacta).HasMaxLength(255);
            entity.Property(e => e.PrecioMensual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Provincia).HasMaxLength(100);
            entity.Property(e => e.TipoPropiedad).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(150);

            entity.HasOne(d => d.Propietario).WithMany(p => p.Propiedades)
                .HasForeignKey(d => d.PropietarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Propiedades_Usuarios");
        });

        modelBuilder.Entity<PropuestasPropiedad>(entity =>
        {
            entity.HasKey(e => e.PropuestaId).HasName("PK__Propuest__4B0678620F05686F");

            entity.ToTable("PropuestasPropiedad");

            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Mensaje).HasMaxLength(500);

            entity.HasOne(d => d.Inquilino).WithMany(p => p.PropuestasPropiedads)
                .HasForeignKey(d => d.InquilinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Propuestas_Usuarios");

            entity.HasOne(d => d.Propiedad).WithMany(p => p.PropuestasPropiedads)
                .HasForeignKey(d => d.PropiedadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Propuestas_Propiedades");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302F1623392F6");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<SolicitudesAlquiler>(entity =>
        {
            entity.HasKey(e => e.SolicitudId).HasName("PK__Solicitu__85E95DC797A80C41");

            entity.ToTable("SolicitudesAlquiler");

            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Mensaje).HasMaxLength(500);

            entity.HasOne(d => d.Inquilino).WithMany(p => p.SolicitudesAlquilers)
                .HasForeignKey(d => d.InquilinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_Usuarios");

            entity.HasOne(d => d.Propiedad).WithMany(p => p.SolicitudesAlquilers)
                .HasForeignKey(d => d.PropiedadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_Propiedades");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B8CBCCB7AA");

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.DescripcionPerfil).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.ImagenPerfilUrl).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<UsuarioRole>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CDCA9BC5DD4D");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRoles)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRoles_Roles");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRoles)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRoles_Usuarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
