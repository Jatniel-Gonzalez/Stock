namespace Stock.Models
{
    public partial class StocktakingJkContext : DbContext
    {
        public StocktakingJkContext()
        {
        }

        public StocktakingJkContext(DbContextOptions<StocktakingJkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acquisition> Acquisitions { get; set; }

        public virtual DbSet<Category> Categories { get; set; }


        public virtual DbSet<ExistenceByRegion> ExistenceByRegions { get; set; }

        public virtual DbSet<Movement> Movements { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Region> Regions { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CSJVP05\\SQLEXPRESS; Database=Stocktaking_JK; Trusted_Connection=True; TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acquisition>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("Acquisition");

                entity.Property(e => e.IdProduct)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_product");
                entity.Property(e => e.IdSupplier).HasColumnName("ID_supplier");

                entity.HasOne(d => d.IdProductNavigation).WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acquisition_Product");

                entity.HasOne(d => d.IdSupplierNavigation).WithMany()
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("FK_Acquisition_Supplier");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("ID_category");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExistenceByRegion>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("ExistenceByRegion");

                entity.Property(e => e.IdProduct).HasColumnName("ID_product");
                entity.Property(e => e.IdRegion).HasColumnName("ID_region");

                entity.HasOne(d => d.IdProductNavigation).WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_ExistenceByRegion_Product");

                entity.HasOne(d => d.IdRegionNavigation).WithMany()
                    .HasForeignKey(d => d.IdRegion)
                    .HasConstraintName("FK_ExistenceByRegion_Region");
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasKey(e => e.IdMotion);

                entity.ToTable("Movement");

                entity.Property(e => e.IdMotion).HasColumnName("ID_motion");
                entity.Property(e => e.DateAndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_and_Time");
                entity.Property(e => e.IdProduct).HasColumnName("ID_product");
                entity.Property(e => e.TypeMotion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("type_motion");

                entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Movements)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Movement_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("ID_Product");
                entity.Property(e => e.AmountProduct).HasColumnName("Amount_Product");
                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false);
                entity.Property(e => e.IdCategory).HasColumnName("ID_category");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.IdRegion);

                entity.ToTable("Region");

                entity.Property(e => e.IdRegion).HasColumnName("ID_region");
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(130)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier);

                entity.ToTable("Supplier");

                entity.Property(e => e.IdSupplier).HasColumnName("ID_supplier");
                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false);
                entity.Property(e => e.Contact)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}