using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Exentions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //seeding dada for AppConfig
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig
                {
                    Key = "HomeTitle",
                    Value = "This is home page of eShopSolution"
                },
                new AppConfig
                {
                    Key = "HomeKeyword",
                    Value = "This is keyword of eShopSolution"
                },
                new AppConfig
                {
                    Key = "HomeDescription",
                    Value = "This is description of eShopSolution"
                });
            //seeding data for language
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language { Id = "en-US", Name = "English", IsDefault = false }
            );

            //seeding data for category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active
                },
                new Category
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active
                }
            );

            //seeding data for category translation
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Áo nam",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-nam",
                    SeoDescription = "Áo nam thời trang",
                    SeoTitle = "Áo nam thời trang"
                },
                new CategoryTranslation
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Men's Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "mens-shirt",
                    SeoDescription = "The shirt product by men",
                    SeoTitle = "The shirt product by men"
                },
                new CategoryTranslation
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Áo nữ",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-nu",
                    SeoDescription = "Áo nữ thời trang",
                    SeoTitle = "Áo nữ thời trang"
                },
                new CategoryTranslation
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Women's Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "womens-shirt",
                    SeoDescription = "The shirt product by women",
                    SeoTitle = "The shirt product by women"
                }
            );

            //seeding data for product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    DateCreated = new DateTime(2025,8,19),
                    OriginalPrice = 100000,
                    Price = 80000,
                    Stock = 0,
                    ViewCount = 0
                }

            );

            //seeding data for product translation
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation
                {
                    Id = 1,
                    Name = "Áo sơ mi nam Việt Tiến",
                    Description = "Áo sơ mi nam Việt Tiến",
                    Details = "Áo sơ mi nam Việt Tiến",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-so-mi-nam-Viet-Tien",
                    SeoDescription = "Áo sơ mi nam Việt Tiến",
                    SeoTitle = "Áo sơ mi nam Việt Tiến",
                    ProductId = 1
                },
                new ProductTranslation
                {
                    Id = 2,
                    Name = "Viet Tien men T-Shirt",
                    Description = "Viet Tien men T-Shirt",
                    Details = "Viet Tien men T-Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "viet-tien-men-t-shirt",
                    SeoDescription = "Viet Tien men T-Shirt",
                    SeoTitle = "Viet Tien men T-Shirt",
                    ProductId = 1
                });

            //seeding data for product in category
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory
                {
                    CategoryId = 1,
                    ProductId = 1
                }
            );
        }
    }
}
