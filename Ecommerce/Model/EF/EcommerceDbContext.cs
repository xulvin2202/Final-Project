namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext()
            : base("name=Ecommerce")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Content_Category> Content_Category { get; set; }
        public virtual DbSet<Content_Tag> Content_Tag { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Madein> Madeins { get; set; }
        public virtual DbSet<MainCategory> MainCategories { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Menu_Type> Menu_Type { get; set; }
        public virtual DbSet<Position_Poster> Position_Poster { get; set; }
        public virtual DbSet<Poster> Posters { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Attribute> Product_Attribute { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Sub_Category_Attribute> Sub_Category_Attribute { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Brand)
                .HasForeignKey(e => e.Brand_ID);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Materials)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_ID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_ID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Color)
                .HasForeignKey(e => e.Color_ID);

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Content_Category>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Content_Category>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Content_Category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Content_Category>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Content_Category>()
                .HasMany(e => e.Contents)
                .WithOptional(e => e.Content_Category)
                .HasForeignKey(e => e.Content_Category_ID);

            modelBuilder.Entity<Content_Tag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Madein>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Madein>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Madein>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Madein>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Madein)
                .HasForeignKey(e => e.Madein_ID);

            modelBuilder.Entity<MainCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<MainCategory>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<MainCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MainCategory>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<MainCategory>()
                .HasMany(e => e.Brands)
                .WithOptional(e => e.MainCategory)
                .HasForeignKey(e => e.MainCategory_ID);

            modelBuilder.Entity<MainCategory>()
                .HasMany(e => e.Categories)
                .WithOptional(e => e.MainCategory)
                .HasForeignKey(e => e.MainCategory_ID);

            modelBuilder.Entity<MainCategory>()
                .HasMany(e => e.Colors)
                .WithOptional(e => e.MainCategory)
                .HasForeignKey(e => e.MainCategory_ID);

            modelBuilder.Entity<MainCategory>()
                .HasMany(e => e.Madeins)
                .WithOptional(e => e.MainCategory)
                .HasForeignKey(e => e.MainCategory_ID);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.Material_ID);

            modelBuilder.Entity<Menu>()
                .Property(e => e.TypeID)
                .IsFixedLength();

            modelBuilder.Entity<Position_Poster>()
                .HasMany(e => e.Posters)
                .WithOptional(e => e.Position_Poster)
                .HasForeignKey(e => e.Position_Poster_ID);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Attribute)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_ID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_ID);

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Review>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Review>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Slide>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Sub_Category_Attribute>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Sub_Category_Attribute>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Sub_Category_Attribute>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Sub_Category_Attribute>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.SubCategory_ID);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Sub_Category_Attribute)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.Sub_Category_ID);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}
