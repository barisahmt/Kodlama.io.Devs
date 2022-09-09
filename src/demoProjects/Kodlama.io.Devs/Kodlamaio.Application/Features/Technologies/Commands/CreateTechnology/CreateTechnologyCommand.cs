using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
    {
        private ITechnologyRepository _technologyrepository;
        private IMapper _mapper;

        public CreateTechnologyCommandHandler(ITechnologyRepository technologyrepository, IMapper mapper)
        {
            _technologyrepository = technologyrepository;
            _mapper = mapper;
        }

        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {

            var ap = _mapper.Map<Technology>(request);
            await _technologyrepository.AddAsync(ap);
            CreatedTechnologyDto createdTechnologyDto =  _mapper.Map<CreatedTechnologyDto>(ap);
            return createdTechnologyDto;
        }
    }
}