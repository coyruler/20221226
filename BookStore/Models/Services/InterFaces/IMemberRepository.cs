using BookStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Services.InterFaces
{
    public interface IMemberRepository
    {
        bool IsExists(string account);
        void Create(RegisterDto dto);
        MemberDto Load(int memberId);
        void ActiveRegister(int memberId);
        MemberDto GetByAccount(string account);

    }
}