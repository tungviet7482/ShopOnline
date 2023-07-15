 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Entities;
using System;

namespace Shop.Data.EntityF
{
    public static class ModelBuiderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Đồng phục công sở",
                    SortOrder = 1,
                    ParentId = null,
                    IsShowOnHome = true,
                    Status = Enums.Status.Active
                },
                new Category()
                {
                    Id = 2,
                    Name = "Đồng phục áo Polo",
                    SortOrder = 2,
                    ParentId = 1,
                    IsShowOnHome = true,
                    Status = Enums.Status.Active
                },
                new Category()
                {
                    Id = 3,
                    Name = "Đồng phục áo sơ mi",
                    SortOrder = 3,
                    ParentId = 1,
                    IsShowOnHome = true,
                    Status = Enums.Status.Active
                },
                new Category()
                {
                    Id = 4,
                    Name = "Đồng phục ngành dịch vụ",
                    SortOrder = 4,
                    ParentId = null,
                    IsShowOnHome = true,
                    Status = Enums.Status.Active
                }, 
                new Category()
                {
                    Id = 5,
                    Name = "Đồng phục nhà hàng",
                    SortOrder = 5,
                    ParentId = 4,
                    IsShowOnHome = true,
                    Status = Enums.Status.Active
                }, 
                new Category()
                {
                    Id = 6,
                    Name = "Đồng phục kỹ thuật",
                    SortOrder = 6,
                    ParentId = null,
                    IsShowOnHome = true,
                    Status = Enums.Status.Active
                },
                new Category()
                {
                    Id = 7,
                    Name = "Đồng phục bảo hộ lao động",
                    SortOrder = 7,
                    ParentId = 6,
                    IsShowOnHome = true,
                    Status = Enums.Status.Active
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Áo polo PL029",
                    Description = "Áo polo dài tay, hiện đại, lịch sự",
                    Details = "Áo polo dài tay, hiện đại, lịch sự",
                    Price = 250000,
                    OriginalPrice = 200000,
                    Stock = 0,
                    ViewCount = 0,
                    DateCreated = DateTime.Now,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Áo polo PL009",
                    Description = "Áo polo cổ bẻ, chuẩn form, đứng dáng.",
                    Details = "Áo polo cổ bẻ, chuẩn form, đứng dáng.",
                    Price = 550000,
                    OriginalPrice = 400000,
                    Stock = 0,
                    ViewCount = 0,
                    DateCreated = DateTime.Now,
                },
                new Product()
                {
                    Id = 3,
                    Name = "Áo sơ mi dài tay SM026",
                    Description = "Sơ mi cổ sen cách điệu",
                    Details = "Sơ mi cổ sen cách điệu",
                    Price = 150000,
                    OriginalPrice = 100000,
                    Stock = 0,
                    ViewCount = 0,
                    DateCreated = DateTime.Now,
                },
                new Product()
                {
                    Id = 4,
                    Name = "Đồng phục nhà hàng NH010",
                    Description = "Sang trọng, thanh lịch",
                    Details = "Sang trọng, thanh lịch",
                    Price = 100000,
                    OriginalPrice = 80000,
                    Stock = 0,
                    ViewCount = 0,
                    DateCreated = DateTime.Now,
                },
                new Product()
                {
                    Id = 5,
                    Name = "Đồng phục bảo hộ lao động LD010",
                    Description = "Hiện đại, An toàn",
                    Details = "Hiện đại, An toàn",
                    Price = 800000,
                    OriginalPrice = 500000,
                    Stock = 0,
                    ViewCount = 0,
                    DateCreated = DateTime.Now,
                },
                new Product()
                {
                    Id = 6,
                    Name = "Đồng phục bảo hộ lao động LD004",
                    Description = "Hiện đại, An toàn",
                    Details = "Hiện đại, An toàn",
                    Price = 600000,
                    OriginalPrice = 400000,
                    Stock = 0,
                    ViewCount = 0,
                    DateCreated = DateTime.Now,
                }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    CategoryId = 2,
                    ProductId = 1
                },
                new ProductInCategory()
                {
                    CategoryId = 2,
                    ProductId = 2
                },
                new ProductInCategory()
                {
                    CategoryId = 3,
                    ProductId = 3
                },
                new ProductInCategory()
                {
                    CategoryId = 5,
                    ProductId = 4
                },
                new ProductInCategory()
                {
                    CategoryId = 7,
                    ProductId = 5
                },
                new ProductInCategory()
                {
                    CategoryId = 7,
                    ProductId = 6
                }
                );

            Guid r1 = Guid.NewGuid();
            Guid r2= Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole()
                {
                    Id = r1,
                    Name = "admin",
                    NormalizedName = "admin",
                },
                new AppRole()
                {
                    Id = r2,
                    Name = "member",
                    NormalizedName = "member",
                }
                );

            Guid user1 = Guid.NewGuid();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = user1,
                    FirstName = "Tùng",
                    LastName = "Quang",
                    PhoneNumber = "01224532456",
                    Email = "a@gmail.com",
                    NormalizedEmail = "a@gmail.com",
                    UserName = "a",
                    NormalizedUserName = "a",
                    PasswordHash = (new PasswordHasher<AppUser>()).HashPassword(null, "Tung123*"),
                    Dob = new DateTime(2002, 01, 31),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
                );

            Guid ur = Guid.NewGuid();
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>()
                {
                    RoleId = r1,
                    UserId = user1
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = r2,
                    UserId = user1
                }
                ) ;
        }
    }
}
