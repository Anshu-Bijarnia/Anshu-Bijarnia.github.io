using Amazon.DataAccess.Data;
using Amazon.Models;
using Amazon.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Amazon.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public DbInitializer(
            UserManager<IdentityUser> userManeger,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManeger;
            _db = db;
        }
        public void Initialize()
        {

            // Migration if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }
            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();

                // If roles are not created, then create admin user as well
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Anshu Bijarnia",
                    PhoneNumber = "+911234567890",
                    StreetAddress = "1 test",
                    State = "Delhi",
                    PostalCode = "110011",
                    City = "New Delhi"
                }, "Admin@101").GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "customer@gmail.com",
                    Email = "customer@gmail.com",
                    Name = "Atul Bijarnia",
                    PhoneNumber = "+911234567890",
                    StreetAddress = "1 test",
                    State = "Delhi",
                    PostalCode = "110011",
                    City = "New Delhi"
                }, "Admin@101").GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "company@gmail.com",
                    Email = "company@gmail.com",
                    Name = "Dtu coders",
                    PhoneNumber = "+911234567890",
                    StreetAddress = "1 test",
                    State = "Delhi",
                    PostalCode = "110011",
                    City = "New Delhi"
                }, "Admin@101").GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "employee@gmail.com",
                    Email = "employee@gmail.com",
                    Name = "Nitesh Bijarnia",
                    PhoneNumber = "+911234567890",
                    StreetAddress = "1 test",
                    State = "Delhi",
                    PostalCode = "110011",
                    City = "New Delhi"
                }, "Admin@101").GetAwaiter().GetResult();

                ApplicationUser admin = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(admin, SD.Role_Admin).GetAwaiter().GetResult();

                ApplicationUser customer = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "customer@gmail.com");
                _userManager.AddToRoleAsync(customer, SD.Role_Customer).GetAwaiter().GetResult();

                ApplicationUser company = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "company@gmail.com");
                _userManager.AddToRoleAsync(company, SD.Role_Company).GetAwaiter().GetResult();

                ApplicationUser employee = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "employee@gmail.com");
                _userManager.AddToRoleAsync(employee, SD.Role_Employee).GetAwaiter().GetResult();
            }
        }
    }
}
