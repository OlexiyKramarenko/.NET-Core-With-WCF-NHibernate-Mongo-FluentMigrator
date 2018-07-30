using Microsoft.AspNetCore.Identity;
using MShop.DataLayer.EF.Entities.Users;
using System;
using System.Linq;
using System.Text;

namespace MShop.DataLayer.EF
{
    public static class DbInitializer
    {
        public static void Initialize(DataBaseContext db)
        {
            try
            {
                IQueryable<IdentityUserRole<string>> userRoles = db.UserRoles;
                db.UserRoles.RemoveRange(userRoles);
                db.SaveChanges();

                IQueryable<ApplicationUser> users = db.Users;
                db.Users.RemoveRange(users);
                db.SaveChanges();

                IQueryable<IdentityRole> roles = db.Roles;
                db.Roles.RemoveRange(roles);
                db.SaveChanges();


                var admin = new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = "Administrator_Vasya", PasswordHash = CreateMD5("123123") };
                var user = new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = "Simple_User_Makar", PasswordHash = CreateMD5("456456") };
                db.Users.Add(admin);
                db.Users.Add(user);
                db.SaveChanges();

                var adminRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "admin" };
                var userRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "user" };
                db.Roles.Add(adminRole);
                db.Roles.Add(userRole);
                db.SaveChanges();

                var userRole1 = new IdentityUserRole<string> { UserId = admin.Id, RoleId = adminRole.Id };
                var userRole2 = new IdentityUserRole<string> { UserId = user.Id, RoleId = userRole.Id };
                db.UserRoles.Add(userRole1);
                db.UserRoles.Add(userRole2);
                db.SaveChanges();

                //--------------------------------------------


                //db.Polls.AddRange(testData.polls);
                //int result = db.SaveChanges();
                //db.Departments.AddRange(testData.departments);
                //result = db.SaveChanges();
                //db.OrderStatuses.AddRange(testData.orderStatuses);
                //result = db.SaveChanges();
                ////db.Orders.AddRange(testData.orders);
                ////result = db.SaveChanges();

                //db.ShippingMethods.AddRange(testData.shippingMethods);
                //result = db.SaveChanges();
                //db.Newsletters.AddRange(testData.newsletters);
                //result = db.SaveChanges();
                //db.Forums.AddRange(testData.forums);
                //result = db.SaveChanges();
                //db.Categories.AddRange(testData.categories);
                //result = db.SaveChanges();
            }
            catch (Exception exc)
            {
                throw;
            }
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
