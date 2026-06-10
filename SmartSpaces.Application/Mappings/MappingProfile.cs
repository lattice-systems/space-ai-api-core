using AutoMapper;
using SmartSpaces.Application.Features.Spaces.Commands.CreateSpace;
using SmartSpaces.Domain.Entities;

namespace SmartSpaces.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Le decimos a AutoMapper: "Puedes mapear las propiedades de este Comando a esta Entidad"
        CreateMap<CreateSpaceCommand, Space>();
    }
}