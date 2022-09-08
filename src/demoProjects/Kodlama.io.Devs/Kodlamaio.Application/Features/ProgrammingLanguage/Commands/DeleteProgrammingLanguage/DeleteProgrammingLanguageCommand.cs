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

namespace Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }
            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage language = await _programmingLanguageRepository.GetAsync(l => l.Id == request.Id);

                 _programmingLanguageBusinessRules.ProgrammingLanguageCheckId(language);

                ProgrammingLanguage deleteProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(language);
                DeletedProgrammingLanguageDto deleteProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deleteProgrammingLanguage);
                return deleteProgrammingLanguageDto;
            }
        }
    }
}


