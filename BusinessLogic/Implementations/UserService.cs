using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{
    public class UserService : IUserService
    {
        private readonly Context _context;
        public UserService(Context context)
        {
            _context = context;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string? Authenticate(string username, string password)
        {
            var user = _context?.Users?.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
                return null;

            return Base64Encode($"{user.Username}:{user.Password}");
        }
    }
}
