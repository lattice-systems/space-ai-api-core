using MediatR;
using AutoMapper;
using SmartSpaces.Domain.Entities;

namespace SmartSpaces.Application.Features.Spaces.Commands.CreateSpace;

public class CreateSpaceCommandHandler : IRequestHandler<CreateSpaceCommand, Guid>
{
    private readonly IMapper _mapper;

    // Aquí inyectarías también tu repositorio o DB Context en el futuro
    public CreateSpaceCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateSpaceCommand request, CancellationToken cancellationToken)
    {
        // 1. Uso de AutoMapper: Traduce el comando de la API directo a una Entidad de Dominio
        var newSpace = _mapper.Map<Space>(request);

        // Generamos un ID simulando lo que haría la base de datos
        newSpace.Id = Guid.NewGuid();

        // 2. Aquí iría el código para guardar en la Base de Datos usando la entidad 'newSpace'
        // _repository.Add(newSpace);

        // 3. Retornamos el ID del espacio creado
        return await Task.FromResult(newSpace.Id);
    }
}