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

namespace Application.Features.programmingLanguage.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand :IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateProgrammingLanguageCommandHandler :IRequestHandler<UpdateProgrammingLanguageCommand , UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;


            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }


            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage language = await _programmingLanguageRepository.GetAsync(l => l.Id == request.Id);

                _programmingLanguageBusinessRules.ProgrammingLanguageCheckId(language);

                language.Name = request.Name;

                ProgrammingLanguage updateProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(language);
                UpdatedProgrammingLanguageDto updateProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updateProgrammingLanguage);
                return updateProgrammingLanguageDto;

            }
        }
        
    }
}
