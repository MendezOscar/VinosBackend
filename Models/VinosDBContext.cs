using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VinosBackend.Models
{
    public partial class VinosDBContext : DbContext
    {
        public VinosDBContext()
        {
        }

        public VinosDBContext(DbContextOptions<VinosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividades> Actividades { get; set; }
        public virtual DbSet<Actividadvisita> Actividadvisita { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Existencias> Existencias { get; set; }
        public virtual DbSet<Finca> Finca { get; set; }
        public virtual DbSet<Kardex> Kardex { get; set; }
        public virtual DbSet<Materiaprima> Materiaprima { get; set; }
        public virtual DbSet<Materiaprimaoden> Materiaprimaoden { get; set; }
        public virtual DbSet<Ordendeproduccion> Ordendeproduccion { get; set; }
        public virtual DbSet<Personalorden> Personalorden { get; set; }
        public virtual DbSet<Personalvisita> Personalvisita { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Visita> Visita { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=VinosDB;Username=lala;Password=L@la");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Actividades>(entity =>
            {
                entity.HasKey(e => e.Idactividad)
                    .HasName("actividades_pkey");

                entity.ToTable("actividades");

                entity.Property(e => e.Idactividad)
                    .HasColumnName("idactividad")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200);

                entity.Property(e => e.Numerodevisita).HasColumnName("numerodevisita");
            });

            modelBuilder.Entity<Actividadvisita>(entity =>
            {
                entity.HasKey(e => e.Actividadvisita1)
                    .HasName("actividadvisita_pkey");

                entity.ToTable("actividadvisita");

                entity.Property(e => e.Actividadvisita1)
                    .HasColumnName("actividadvisita")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idactividad).HasColumnName("idactividad");

                entity.HasOne(d => d.IdvisitaNavigation)
                    .WithMany(p => p.Actividadvisita)
                    .HasForeignKey(d => d.Idvisita)
                    .HasConstraintName("fk_actividadvisita");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Idempleado)
                    .HasName("empleado_pkey");

                entity.ToTable("empleado");

                entity.Property(e => e.Idempleado)
                    .HasColumnName("idempleado")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(100);

                entity.Property(e => e.Cargo)
                    .HasColumnName("cargo")
                    .HasMaxLength(100);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnName("fechanacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Existencias>(entity =>
            {
                entity.HasKey(e => e.Idexistencia)
                    .HasName("existencias_pkey");

                entity.ToTable("existencias");

                entity.Property(e => e.Idexistencia)
                    .HasColumnName("idexistencia")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Item).HasColumnName("item");
            });

            modelBuilder.Entity<Finca>(entity =>
            {
                entity.HasKey(e => e.Idfinca)
                    .HasName("finca_pkey");

                entity.ToTable("finca");

                entity.Property(e => e.Idfinca)
                    .HasColumnName("idfinca")
                    .ValueGeneratedNever();

                entity.Property(e => e.Contacto)
                    .HasColumnName("contacto")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.Dueno)
                    .HasColumnName("dueno")
                    .HasMaxLength(100);

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Finca)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("fk_idproducto");
            });

            modelBuilder.Entity<Kardex>(entity =>
            {
                entity.HasKey(e => e.Idkardex)
                    .HasName("kardex_pkey");

                entity.ToTable("kardex");

                entity.Property(e => e.Idkardex)
                    .HasColumnName("idkardex")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.Motivo)
                    .HasColumnName("motivo")
                    .HasMaxLength(300);

                entity.Property(e => e.Transaccion)
                    .HasColumnName("transaccion")
                    .HasColumnType("char");
            });

            modelBuilder.Entity<Materiaprima>(entity =>
            {
                entity.HasKey(e => e.Idmateriaprima)
                    .HasName("materiaprima_pkey");

                entity.ToTable("materiaprima");

                entity.Property(e => e.Idmateriaprima)
                    .HasColumnName("idmateriaprima")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(1000);

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Materiaprima)
                    .HasForeignKey(d => d.Idproveedor)
                    .HasConstraintName("fk_idproveedor");
            });

            modelBuilder.Entity<Materiaprimaoden>(entity =>
            {
                entity.HasKey(e => e.Idmateriaprimaorden)
                    .HasName("idmateriaprimaorden");

                entity.ToTable("materiaprimaoden");

                entity.Property(e => e.Idmateriaprimaorden)
                    .HasColumnName("idmateriaprimaorden")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idmateriaprima).HasColumnName("idmateriaprima");

                entity.Property(e => e.Idorden).HasColumnName("idorden");

                entity.HasOne(d => d.IdordenNavigation)
                    .WithMany(p => p.Materiaprimaoden)
                    .HasForeignKey(d => d.Idorden)
                    .HasConstraintName("fk_materiaprimaorden");
            });

            modelBuilder.Entity<Ordendeproduccion>(entity =>
            {
                entity.HasKey(e => e.Idorden)
                    .HasName("ordendeproduccionhdr_pkey");

                entity.ToTable("ordendeproduccion");

                entity.Property(e => e.Idorden)
                    .HasColumnName("idorden")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(1000);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Personalorden>(entity =>
            {
                entity.HasKey(e => e.Idpersonal)
                    .HasName("personalorden_pkey");

                entity.ToTable("personalorden");

                entity.Property(e => e.Idpersonal)
                    .HasColumnName("idpersonal")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idempleado).HasColumnName("idempleado");

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.Personalorden)
                    .HasForeignKey(d => d.Idempleado)
                    .HasConstraintName("fk_product");
            });

            modelBuilder.Entity<Personalvisita>(entity =>
            {
                entity.HasKey(e => e.Idpersonalvisita)
                    .HasName("personalvisita_pkey");

                entity.ToTable("personalvisita");

                entity.Property(e => e.Idpersonalvisita)
                    .HasColumnName("idpersonalvisita")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idempleado).HasColumnName("idempleado");

                entity.Property(e => e.Idvisita).HasColumnName("idvisita");

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.Personalvisita)
                    .HasForeignKey(d => d.Idempleado)
                    .HasConstraintName("fk_personal");

                entity.HasOne(d => d.IdvisitaNavigation)
                    .WithMany(p => p.Personalvisita)
                    .HasForeignKey(d => d.Idvisita)
                    .HasConstraintName("fk_visitapersonal");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("producto_pkey");

                entity.ToTable("producto");

                entity.Property(e => e.Idproducto)
                    .HasColumnName("idproducto")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Idproveedor)
                    .HasName("proveedor_pkey");

                entity.ToTable("proveedor");

                entity.Property(e => e.Idproveedor)
                    .HasColumnName("idproveedor")
                    .ValueGeneratedNever();

                entity.Property(e => e.Contacto)
                    .HasColumnName("contacto")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("usuario_pkey");

                entity.ToTable("usuario");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasMaxLength(20);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Visita>(entity =>
            {
                entity.HasKey(e => e.Idvisita)
                    .HasName("visita_pkey");

                entity.ToTable("visita");

                entity.Property(e => e.Idvisita)
                    .HasColumnName("idvisita")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Idfinca).HasColumnName("idfinca");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.HasOne(d => d.IdfincaNavigation)
                    .WithMany(p => p.Visita)
                    .HasForeignKey(d => d.Idfinca)
                    .HasConstraintName("fk_finca");
            });
        }
    }
}
