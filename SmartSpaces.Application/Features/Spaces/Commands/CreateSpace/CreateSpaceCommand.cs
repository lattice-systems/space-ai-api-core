using MediatR;

namespace SmartSpaces.Application.Features.Spaces.Commands.CreateSpace;
public record CreateSpaceCommand(string Name, int Capacity) : IRequest<Guid>;