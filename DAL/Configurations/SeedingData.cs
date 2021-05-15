using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlannerApi.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.DAL.Configurations
{
    public static class SeedingData
    {
        #region Seed
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "220c495c-95f9-411d-aa86-6b96c2778765",
                    UserName = "Programmer1",
                    NormalizedUserName = "PROGRAMMER1",
                    Email = "Programmer1@gmail.com",
                    NormalizedEmail = "PROGRAMMER1@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEB8qNp+eOtMx8JJXoZofJRmtbZRzM+VAs4RRxM9jeCDlt3JFNCZUOHPztHsOQsFC2Q==",
                    SecurityStamp = "UVK6CZ72YKWZSNU3TOGGRWOPDCTB3YYS",
                    ConcurrencyStamp = "385ab67e-b229-475b-b110-cf22336fa7df",
                    FirstName = "Programmer1",
                    LastName = "Test",
                    Login = "Programmer1"
                },
                new User
                {
                    Id = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                    UserName = "Mannager1",
                    NormalizedUserName = "MANNAGER1",
                    Email = "Mannager1@gmail.com",
                    NormalizedEmail = "MANNAGER1@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEG7KrHWyF6XjbIf9Lo4U2t/gGw55YYSUCuWE3HiKLlEZ1sER+4J8ILQu6XMvEMb+SQ==",
                    SecurityStamp = "A6RBR4GFIXSS22R7VNE2DROTJVBZJAP7",
                    ConcurrencyStamp = "bbb82cb3-52aa-4343-aa6a-fe6905691128",
                    FirstName = "Mannager1",
                    LastName = "TestMannager1",
                    Login = "Mannager1"
                },
                new User
                {
                    Id = "72546802-9b55-4a9c-9a4e-50bac18a0028",
                    UserName = "Mannager2",
                    NormalizedUserName = "MANNAGER2",
                    Email = "Mannager2@gmail.com",
                    NormalizedEmail = "MANNAGER2@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAENQEpU1VkSDlK8cljaXgMLq+u7Ij51goayAWqOCG4l0r8so2kXS5R319JOlzyEwZGQ==",
                    SecurityStamp = "F32OM56TU5PENGU2UTFFNLD3CYB23KY5",
                    ConcurrencyStamp = "ad608c87-5358-44a0-adbb-73fd943e967e",
                    FirstName = "Mannager2",
                    LastName = "TestMannager2",
                    Login = "Mannager2"
                },
                new User
                {
                    Id = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                    UserName = "Tester1",
                    NormalizedUserName = "TESTER1",
                    Email = "Tester1@gmail.com",
                    NormalizedEmail = "TESTER1@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAENCwxi/ZRTSt1d/QDilsEjojuoP8a+xlASCUUfFmKdLw+CE/5pWmXaMkubsBCpNUYg==",
                    SecurityStamp = "VHO7IDMB3IEVT5G4B75CR55SDVG6DWCE",
                    ConcurrencyStamp = "5394588e-ac19-49c7-8561-d2c2ecdff835",
                    FirstName = "Tester1",
                    LastName = "TestTester1",
                    Login = "Tester1"
                },
                new User
                {
                    Id = "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3",
                    UserName = "Programmer2",
                    NormalizedUserName = "PROGRAMMER2",
                    Email = "Programmer2@gmail.com",
                    NormalizedEmail = "PROGRAMMER2@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEDR2zGwptCW0FbPNOrTN/vpprMfJkPfVt2qSMVbTxYKmYUbzKB2TmKjhOp/jLTo6bA==",
                    SecurityStamp = "KLHMYUGUJW7FOETIP7WLOKSUONMWV4WO",
                    ConcurrencyStamp = "61006890-1a43-42e8-9d07-ac32a67f7690",
                    FirstName = "Programmer2",
                    LastName = "Test2",
                    Login = "Programmer2"
                }
                );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "222667d9-4543-498e-948a-5fc1c2dc2d62",
                    Name = "Mannager",
                    NormalizedName = "MANNAGER",
                    ConcurrencyStamp = "2420f8b1-58d7-49a7-8e44-7228b415b93a"
                },
                new IdentityRole
                {
                    Id = "471cd850-b05f-46ef-9c3b-5785ba3fadcd",
                    Name = "Programmer",
                    NormalizedName = "PROGRAMMER",
                    ConcurrencyStamp = "85cadb0c-05e9-4f65-8786-e33e35403468"
                },
                new IdentityRole
                {
                    Id = "b83721c8-b13c-4f4e-89a9-7797c4ed0c85",
                    Name = "Tester",
                    NormalizedName = "TESTER",
                    ConcurrencyStamp = "92265458-1b6a-4a35-99bd-39feda4d1d7a"
                }
                );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "220c495c-95f9-411d-aa86-6b96c2778765",
                    RoleId = "471cd850-b05f-46ef-9c3b-5785ba3fadcd"
                },
                new IdentityUserRole<string>
                {
                    UserId = "547fb67e-7bac-4e68-ae07-7d7a2309b9d9",
                    RoleId = "222667d9-4543-498e-948a-5fc1c2dc2d62"
                }, new IdentityUserRole<string>
                {
                    UserId = "72546802-9b55-4a9c-9a4e-50bac18a0028",
                    RoleId = "222667d9-4543-498e-948a-5fc1c2dc2d62"
                }, new IdentityUserRole<string>
                {
                    UserId = "877a0a41-23b3-4511-89f5-13d1cd5b750a",
                    RoleId = "b83721c8-b13c-4f4e-89a9-7797c4ed0c85"
                }, new IdentityUserRole<string>
                {
                    UserId = "bf6bea78-174a-4584-8b2e-25a2eb8a1dd3",
                    RoleId = "471cd850-b05f-46ef-9c3b-5785ba3fadcd"
                }
                );
        }
        #endregion
    }
}
