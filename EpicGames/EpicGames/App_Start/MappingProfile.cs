using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EpicGames.Dtos;
using EpicGames.Models;

namespace EpicGames.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Account, AccountDto>();
            Mapper.CreateMap<AccountDto, Account>();
            Mapper.CreateMap<ConsoleType, ConsoleTypeDto>();
        }
        
    }
}