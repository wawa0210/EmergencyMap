using AutoMapper;
using EmergencyAccount.Etity;
using EmergencyAccount.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyApi.App_Start
{
    public class MapperInit
    {
        public static void InitMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TableAccountManager, EntityAccountManager>()
                   .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                   .ForMember(x => x.RoleId, y => y.MapFrom(z => z.RoleId))
                   .ForMember(x => x.DeptId, y => y.MapFrom(z => z.DeptId))
                   .ForMember(x => x.UserPwd, y => y.MapFrom(z => z.UserPwd))
                   .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                   .ForMember(x => x.UserSalt, y => y.MapFrom(z => z.UserSalt))
                   .ForMember(x => x.RealName, y => y.MapFrom(z => z.RealName))
                   .ForMember(x => x.Tel, y => y.MapFrom(z => z.Tel))
                   .ForMember(x => x.IsLock, y => y.MapFrom(z => z.IsLock))
                   .ForMember(x => x.Level, y => y.MapFrom(z => z.Level))
                   .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
                   .ForAllOtherMembers(x => x.Ignore());
            }
            );
        }
    }
}