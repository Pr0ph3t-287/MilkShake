using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;
using System;
using System.Configuration;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MilkShake.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<User> userRepository;
        private readonly UserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, UserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            userRepository = new UserRepository(_unitOfWork);
            _userRepository = userRepository;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            string hashedPassword = HashPassword(password); // Hash the password

            var actual = (user.Result as OkObjectResult).Value as User;
            string hashedPassword2 = actual.PasswordHash;

            // Simulating login attempt with the same password
            if (VerifyPassword(password, hashedPassword2))
            {
                return actual;
            } 
            else
            {
                return null;
            }
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Method to compare a hashed bcrypt password with the unencrypted password
        private static bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
        }
    }
}