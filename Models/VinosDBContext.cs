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
        public virtual DbSet<Finca> Finca { get; set; }
        public virtual DbSet<Inventariodtl> Inventariodtl { get; set; }
        public virtual DbSet<Inventariohdr> Inventariohdr { get; set; }
        public virtual DbSet<Materiaprima> Materiaprima { get; set; }
        public virtual DbSet<Ordendeproducciondtl> Ordendeproducciondtl { get; set; }
        public virtual DbSet<Ordendeproduccionhdr> Ordendeproduccionhdr { get; set; }
        public virtual DbSet<Personalorden> Personalorden { get; set; }
        public virtual DbSet<Personalvisita> Personalvisita { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Proveedorvisita> Proveedorvisita { get; set; }
        public virtual DbSet<Receta> Receta { get; set; }
        public virtual DbSet<Recetadetalle> Recetadetalle { get; set; }
        public virtual DbSet<Recetahdr> Recetahdr { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Visitahdr> Visitahdr { get; set; }

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

                entity.HasOne(d => d.IdactividadNavigation)
                    .WithMany(p => p.Actividadvisita)
                    .HasForeignKey(d => d.Idactividad)
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

            modelBuilder.Entity<Inventariodtl>(entity =>
            {
                entity.HasKey(e => e.Idinventariodetalle)
                    .HasName("inventariodtl_pkey");

                entity.ToTable("inventariodtl");

                entity.Property(e => e.Idinventariodetalle)
                    .HasColumnName("idinventariodetalle")
                    .ValueGeneratedNever();

                entity.Property(e => e.Existencia).HasColumnName("existencia");

                entity.Property(e => e.Idinventario).HasColumnName("idinventario");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdinventarioNavigation)
                    .WithMany(p => p.Inventariodtl)
                    .HasForeignKey(d => d.Idinventario)
                    .HasConstraintName("fk_inventario");
            });

            modelBuilder.Entity<Inventariohdr>(entity =>
            {
                entity.HasKey(e => e.Idinventario)
                    .HasName("inventariohdr_pkey");

                entity.ToTable("inventariohdr");

                entity.Property(e => e.Idinventario)
                    .HasColumnName("idinventario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
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

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Ordendeproducciondtl>(entity =>
            {
                entity.HasKey(e => e.Idordendetalle)
                    .HasName("ordendeproducciondtl_pkey");

                entity.ToTable("ordendeproducciondtl");

                entity.Property(e => e.Idordendetalle)
                    .HasColumnName("idordendetalle")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idorden).HasColumnName("idorden");

                entity.Property(e => e.Idpersonal).HasColumnName("idpersonal");

                entity.Property(e => e.Idreceta).HasColumnName("idreceta");

                entity.HasOne(d => d.IdordenNavigation)
                    .WithMany(p => p.Ordendeproducciondtl)
                    .HasForeignKey(d => d.Idorden)
                    .HasConstraintName("fk_ordendeproducciondtl");

                entity.HasOne(d => d.IdpersonalNavigation)
                    .WithMany(p => p.Ordendeproducciondtl)
                    .HasForeignKey(d => d.Idpersonal)
                    .HasConstraintName("fk_personal");
            });

            modelBuilder.Entity<Ordendeproduccionhdr>(entity =>
            {
                entity.HasKey(e => e.Idorden)
                    .HasName("ordendeproduccionhdr_pkey");

                entity.ToTable("ordendeproduccionhdr");

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

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.Personalvisita)
                    .HasForeignKey(d => d.Idempleado)
                    .HasConstraintName("fk_personal");
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

            modelBuilder.Entity<Proveedorvisita>(entity =>
            {
                entity.HasKey(e => e.Idproveedorvisita)
                    .HasName("proveedorvisita_pkey");

                entity.ToTable("proveedorvisita");

                entity.Property(e => e.Idproveedorvisita)
                    .HasColumnName("idproveedorvisita")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Proveedorvisita)
                    .HasForeignKey(d => d.Idproveedor)
                    .HasConstraintName("fk_proveedorvisita");
            });

            modelBuilder.Entity<Receta>(entity =>
            {
                entity.HasKey(e => e.Idreceta)
                    .HasName("receta_pkey");

                entity.ToTable("receta");

                entity.Property(e => e.Idreceta)
                    .HasColumnName("idreceta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("fk_recetahdr");
            });

            modelBuilder.Entity<Recetadetalle>(entity =>
            {
                entity.HasKey(e => e.Idrecetadetalle)
                    .HasName("recetadetalle_pkey");

                entity.ToTable("recetadetalle");

                entity.Property(e => e.Idrecetadetalle)
                    .HasColumnName("idrecetadetalle")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Idmateriaprima).HasColumnName("idmateriaprima");

                entity.Property(e => e.Idreceta).HasColumnName("idreceta");

                entity.Property(e => e.Medida)
                    .HasColumnName("medida")
                    .HasMaxLength(50);

                entity.Property(e => e.Periodicidad).HasColumnName("periodicidad");

                entity.HasOne(d => d.IdmateriaprimaNavigation)
                    .WithMany(p => p.Recetadetalle)
                    .HasForeignKey(d => d.Idmateriaprima)
                    .HasConstraintName("fk_materiaprima");

                entity.HasOne(d => d.IdrecetaNavigation)
                    .WithMany(p => p.Recetadetalle)
                    .HasForeignKey(d => d.Idreceta)
                    .HasConstraintName("fk_idreceta");
            });

            modelBuilder.Entity<Recetahdr>(entity =>
            {
                entity.HasKey(e => e.Idreceta)
                    .HasName("recetahdr_pkey");

                entity.ToTable("recetahdr");

                entity.Property(e => e.Idreceta)
                    .HasColumnName("idreceta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Recetahdr)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("fk_recetahdr");
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

            modelBuilder.Entity<Visitahdr>(entity =>
            {
                entity.HasKey(e => e.Idvisita)
                    .HasName("visita_pkey");

                entity.ToTable("visitahdr");

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

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.HasOne(d => d.IdfincaNavigation)
                    .WithMany(p => p.Visitahdr)
                    .HasForeignKey(d => d.Idfinca)
                    .HasConstraintName("fk_finca");
            });
        }
    }
}
