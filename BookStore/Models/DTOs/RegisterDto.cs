using BookStore.Models.Infrastructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.DTOs
{
    public class RegisterDto
    {
        public const string SALT = "!@#$$DGTEGYT";
        public string Account { get; set; }
        public string Password { get; set; }
        public string EncryptedPassword
        {
            get
            {
                //string SALT = "!@#$$DGTEGYT";
                string result = HashUtility.ToSHA256(this.Password, SALT);
                return result;
            }
        }

        public string Email { get; set; }
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string ConfirmCode { get; set; }
    }
}