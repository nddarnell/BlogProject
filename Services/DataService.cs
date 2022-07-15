using BlogProject.Data;
using BlogProject.Enums;
using BlogProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            //Task: Create the database from the Migrations Folder
            await _dbContext.Database.MigrateAsync();


            //Task 1: Seed a few Roles into the system
            await SeedRolesAsync();

            //Task 2: Seed a few users into the system
            await SeedUsersAsync();


        }

        private async Task SeedRolesAsync()
        {
            //If there are already roles in the system, do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }
            //Otherwise we want to create a few roles
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the role manager to create Roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        private async Task SeedUsersAsync()
        {
            //If there are already Users in the system, do nothing.
            if (_dbContext.Users.Any())
            {
                return;
            }
            //Otherwise we want to create a few Users

            //Step 1: Creates a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "nddarnell90@hotmail.com",
                UserName = "NathanD",
                FirstName = "Nathan",
                LastName = "Darnell",
                PhoneNumber = "(928) 750 2098",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by adminUser variable
            await _userManager.CreateAsync(adminUser, "Password13!");


            //Step 3: Add new user to the administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Step 1: Create the moderator User
            var modUser = new BlogUser()
            {
                Email = "josh.hutchinson555@gmail.com",
                UserName = "Ronako",
                FirstName = "Josh",
                LastName = "Hutchinson",
                PhoneNumber = "(480) 435-1743",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(modUser, "Abc&123!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());




        }





    }
}
