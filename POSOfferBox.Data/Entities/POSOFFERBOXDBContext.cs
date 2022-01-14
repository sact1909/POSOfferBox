using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace POSOfferBox.Data.Entities
{
    public partial class POSOFFERBOXDBContext : DbContext
    {
        public POSOFFERBOXDBContext()
        {
        }

        public POSOFFERBOXDBContext(DbContextOptions<POSOFFERBOXDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSaleItem> ProductSaleItems { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleStatus> SaleStatuses { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserHasRole> UserHasRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Password=stevencheco1909;Persist Security Info=True;User ID=sa;Initial Catalog=POSOFFERBOXDB;Data Source=DESKTOP-1QDB0MI\\PCSQLSERVER");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("CONTRACT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.SaleId).HasColumnName("SALE_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CONTRACT_CUSTOMERS");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK_CONTRACT_SALES");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.Rnc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RNC");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("date")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AvailableStock).HasColumnName("AVAILABLE_STOCK");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Flag).HasColumnName("FLAG");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.PriceUnit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE_UNIT");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.Sku)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SKU");
            });

            modelBuilder.Entity<ProductSaleItem>(entity =>
            {
                entity.ToTable("PRODUCT_SALE_ITEM");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.PriceUnit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE_UNIT");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.QuantitySold)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("QUANTITY_SOLD");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.SaleId).HasColumnName("SALE_ID");

                entity.Property(e => e.TaxAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TAX_AMOUNT");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSaleItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PRODUCT_SALE_ITEM_PRODUCTS");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.ProductSaleItems)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK_PRODUCT_SALE_ITEM_SALES");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("SALES");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("AMOUNT_PAID");

                entity.Property(e => e.PaidDate)
                    .HasColumnType("date")
                    .HasColumnName("PAID_DATE");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.SaleStatusId).HasColumnName("SALE_STATUS_ID");

                entity.Property(e => e.TaxAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TAX_AMOUNT");

                entity.Property(e => e.UserHasRoleId).HasColumnName("USER_HAS_ROLE_ID");

                entity.HasOne(d => d.SaleStatus)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SaleStatusId)
                    .HasConstraintName("FK_SALES_SALE_STATUS");

                entity.HasOne(d => d.UserHasRole)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserHasRoleId)
                    .HasConstraintName("FK_SALES_USER_HAS_ROLE");
            });

            modelBuilder.Entity<SaleStatus>(entity =>
            {
                entity.ToTable("SALE_STATUS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_NAME");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("STOCK");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.InStock)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IN_STOCK");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("date")
                    .HasColumnName("LAST_UPDATE");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Stock)
                    .HasForeignKey<Stock>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STOCK_PRODUCTS");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<UserHasRole>(entity =>
            {
                entity.ToTable("USER_HAS_ROLE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("REGISTER_DATE");

                entity.Property(e => e.RoleEndTime)
                    .HasColumnType("date")
                    .HasColumnName("ROLE_END_TIME");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleStartTime)
                    .HasColumnType("date")
                    .HasColumnName("ROLE_START_TIME");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserHasRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_USER_HAS_ROLE_ROLES");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserHasRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_USER_HAS_ROLE_USERS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
