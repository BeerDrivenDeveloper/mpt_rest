

using AutoMapper;
using mpt_rest.Dtos;
using mpt_rest.Models;

namespace mpt_rest.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile() {
            CreateMap<TicketSaveDto, Ticket>();
            CreateMap<Ticket, TicketViewDto>();
        }
    }
}
