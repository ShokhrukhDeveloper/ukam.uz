#pragma warning disable
using Backend.Uckam.Entities;

namespace Backend.Uckam.data;

public class AppDbInitialize
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            context.Database.EnsureCreated();

            //Users 
            if (!context.Users.Any())
            {
                context.Users.AddRange(new List<User>()
                {
                    new User ()
                    {
                        FirstName = "G'olibjon",
                        UserName = "Adi",
                        LastName = "Turdialiyev",
                        UserImage = "pg",
                        Role = Entities.Enums.ERole.SuperAdmin,
                        Balance = 123.213,
                        PasswordHash = "salom",
                        Block = false,
                        Language = Entities.Enums.ELanguage.Uzb,


                    },
                    new User ()
                    {
                        FirstName = "Abdulaziz",
                        UserName = "Developer",
                        UserImage = "jpg",
                        Role = Entities.Enums.ERole.SuperAdmin,
                        Balance = 123.000,
                        PasswordHash = "salom",
                        Block = false,
                        Language = Entities.Enums.ELanguage.Uzb,
                    }
                });
                context.SaveChanges();
            }
        }
    }
}