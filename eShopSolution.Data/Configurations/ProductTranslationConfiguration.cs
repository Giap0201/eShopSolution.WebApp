using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SeoDescription).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SeoTitle).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Details).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Details).IsRequired().HasMaxLength(500);
            builder.Property(x => x.LanguageId).IsRequired().IsUnicode(false).HasMaxLength(5);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductTranslations).
                HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Language).WithMany(x => x.ProductTranslations).
                HasForeignKey(x => x.LanguageId);   
        }
    }
}
