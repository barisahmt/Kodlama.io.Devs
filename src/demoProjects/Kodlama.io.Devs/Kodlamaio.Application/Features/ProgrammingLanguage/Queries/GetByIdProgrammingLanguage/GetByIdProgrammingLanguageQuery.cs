using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.programmingLanguage.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery :IRequest<GetByIdProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery , GetByIdProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository  _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;


            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? language = await _programmingLanguageRepository.GetAsync(l=>l.Id == request.Id);

                _programmingLanguageBusinessRules.ProgrammingLanguageCheckId(language);

                GetByIdProgrammingLanguageDto getByIdProgrammingLanguageDto = _mapper.Map<GetByIdProgrammingLanguageDto>(language);
                return getByIdProgrammingLanguageDto;
            }
        }
    }
}
