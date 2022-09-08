using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology;

public class DeleteTechnologyCommand:IRequest<DeletedTechnologyDto>
{
    public string Name { get; set; }
    public int Id { get; set; }

    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology technology = await _technologyRepository.GetAsync(t=>t.Id==request.Id);

            Technology deleteTEchnology = await _technologyRepository.DeleteAsync(technology);
            DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deleteTEchnology);
            return deletedTechnologyDto;

        }
    }
    
}