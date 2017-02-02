using BetterTaxi.Models;
using BetterTaxi.Web.ViewModels;
using BetterTaxi.Web.WebApiViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetterTaxi.Web.Infrastructure.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config => {
                config.CreateMap<ApplicationUser, UserItemViewModel>()
                 .ForMember(m => m.FullName, opt => opt.MapFrom(t => t.FirstName + " " + t.MiddleName + " " + t.LastName))
                 .ForMember(m => m.Roles, opt => opt.MapFrom(t => t.Roles.Where(r => r.UserId == t.Id).Select(r => r.RoleId).ToList()));



                // Mapping web api
                config.CreateMap<Photo, PhotoDTO>();
                config.CreateMap<PhotoDTO, Photo>();

            });
        }
    }
}