using BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Xml.Linq;

namespace BookStore.Models.ViewsModels
{
    public class RegisterVM
    {
        public int Id { get; set; }


        [Display(Name = "帳號")]
        [Required]
        [StringLength(30)]
        public string Account { get; set; }

        [Required]
        [StringLength(70)]
        [DataType(DataType.Password)]
        public string EncryptedPassword { get; set; }

        [Required]
        [StringLength(70)]
        [Compare(nameof(EncryptedPassword))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Mobile { get; set; }
    }
    public static class RegistrerVMExts
    {
        public static RegisterDto ToRequestDto (this RegisterVM source)
        {
            return new RegisterDto
            {
                Account = source.Account,
                Password = source.EncryptedPassword,
                Email = source.Email,
                Name = source.Name,
                Mobile = source.Mobile,
            };
        }
    }
}