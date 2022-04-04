using AccountTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountTask.Models
{
    public class User : IAccount
    {
        private static int _id;
        private string _password;

        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password
        {
            get 
            { 
                return _password; 
            }
            set 
            {
                if (PasswordChecker(value))
                {
                    _password = value;
                }
            }
        }

        public int Id { get; }

        static User()
        {
            _id = 0;
        }

        private User()
        {
            _id++;
            Id = _id;
        }

        public User(string email, string password):this()
        {
            Email = email;
            Password = password;
        }

        public bool PasswordChecker(string password)
        {
            if (!String.IsNullOrEmpty(password) && !String.IsNullOrWhiteSpace(password) && password.Length >= 8)
            {
                bool isUpper = false;
                bool isLower = false;
                bool isDigit = false;

                foreach (var item in password)
                {
                    if (char.IsUpper(item)) isUpper = true;
                    else if (char.IsLower(item)) isLower = true;
                    else if (char.IsDigit(item)) isDigit = true;

                    if (isUpper && isLower && isDigit) return true;
                }
            }

            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} Fullname: {Fullname} Email: {Email}");
        }

        public static bool PassWordCheckerStatic(string password)
        {
            User user = new User();
            _id--;
            return user.PasswordChecker(password);
        }
    }
}
