using Application.Features.GitHubProfiles.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubProfiles.Commands.DeleteGitHubProfiles
{
    public class DeleteGitHubProfileCommand : IRequest<DeletedGitHubProfileDto>
    {
        public int Id { get; set; }

        public class DeleteGitHubProfileCommandQuery : IRequestHandler<DeleteGitHubProfileCommand, DeletedGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
     

            public DeleteGitHubProfileCommandQuery(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
                => (_mapper, _gitHubProfileRepository) =
                    (mapper, gitHubProfileRepository);

            public async Task<DeletedGitHubProfileDto> Handle(DeleteGitHubProfileCommand request,
                CancellationToken cancellationToken)
            {
                GitHubProfile gitHubProfile = await _gitHubProfileRepository.GetAsync(g => g.Id == request.Id);
               

                gitHubProfile = await _gitHubProfileRepository.DeleteAsync(gitHubProfile);

                DeletedGitHubProfileDto deletedGitHubProfileDto = _mapper.Map<DeletedGitHubProfileDto>(gitHubProfile);

                return deletedGitHubProfileDto;
            }
        }
    }
}
