using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EO=RacingCompetition.RacingData.BusinessObjects;
using BO=RacingCompetition.RacingData.Entities;

namespace RacingCompetition.RacingData.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<EO.Player, BO.Player>().ReverseMap();
        }
    }
}
