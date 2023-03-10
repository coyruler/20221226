using BookStore.Models.DTOs;
using BookStore.Models.EFModels;
using BookStore.Models.Services.InterFaces;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Member = BookStore.Models.EFModels.Member;

namespace BookStore.Models.Infrastructures.Respositories
{
    public class MemberRepository : IMemberRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(RegisterDto dto)
        {
            Member member = new Member
            {
                Account = dto.Account,
                EncryptedPassword = dto.EncryptedPassword,
                Email = dto.Email,
                Name = dto.Name,
                Mobile = dto.Mobile,
                IsConfirmed = false, //預設是未確認的會員
                ConfirmCode = dto.ConfirmCode
            };

            db.Members.Add(member);
            db.SaveChanges();
        }

        public bool IsExists(string account)
        {
            //var entity = db.Members.SingleOrDefault(x => x.Account == account);
            var entity = db.Members.FirstOrDefault(x => x.Account == account);

            return (entity != null);

        }

        public MemberDto Load(int memberId)
        {
            Member entity = db.Members.SingleOrDefault(x => x.Id == memberId);
            if (entity == null) return null;

            MemberDto result = new MemberDto
            {
                Id = entity.Id,
                Account = entity.Account,
                EncryptedPassword = entity.EncryptedPassword,
                Email = entity.Email,
                Name = entity.Name,
                Mobile = entity.Mobile,
                IsConfirmed = entity.IsConfirmed,
                ConfirmCode = entity.ConfirmCode
            };

            return result;
        }

        public void ActiveRegister(int memberId)
        {
            var member = db.Members.Find(memberId);
            member.IsConfirmed = true;
            member.ConfirmCode = null;
            db.SaveChanges();
        }
        
        public MemberDto GetByAccount(string account)
        {
            return db.Members
                .SingleOrDefault(x => x.Account == account)
                .ToDto();
        }
    }
}