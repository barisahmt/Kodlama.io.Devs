using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Queries.GetListTechnology;

public class GetListTechnologyQuery : IRequest<TechnologyListModel>
{
    public PageRequest? PageRequest { get; set; }

    public class GetByIdTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
    {
        private ITechnologyRepository _technologyRepository;
        private IMapper _mapper;

        public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            => (_technologyRepository, _mapper) = (technologyRepository, mapper);


        public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
        {
           IPaginate<Technology> technology = await _technologyRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
           
           TechnologyListModel mappedTechnology = _mapper.Map<TechnologyListModel>(technology);
           return mappedTechnology;

        }
    }
}
        
    
