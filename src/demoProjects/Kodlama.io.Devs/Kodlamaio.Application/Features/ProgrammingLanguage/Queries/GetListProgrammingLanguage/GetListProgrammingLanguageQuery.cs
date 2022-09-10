using Application.Features.programmingLanguage.Models;
using Application.Features.programmingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.programmingLanguage.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery: IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper , ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }
            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {


                IPaginate<ProgrammingLanguage> programmingLanguage = await _programmingLanguageRepository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                    include: t => t.Include(t=>t.Technologies)
                    ); 
                        
                ProgrammingLanguageListModel mappedProgrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguage);
                return mappedProgrammingLanguageListModel;
            }
        }
    }
}