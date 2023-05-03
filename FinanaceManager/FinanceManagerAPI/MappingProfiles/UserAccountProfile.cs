using AutoMapper;
using FinanceManagerAPI.DTO;
using FinanceManagerAPI.Models;

namespace FinanceManagerAPI.MappingProfiles {
    public class UserAccountProfile : Profile {

        public UserAccountProfile() {

            CreateMap<UserAccountUpdateDto, UserAccount>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserAccountCreateDto, UserAccount>();

        }

    }
}
