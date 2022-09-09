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

namespace Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile
{
    public class UpdateGitHubProfileCommand : IRequest<UpdatedGitHubProfileDto>
    {
        public int Id { get; set; }
        public string ProfileUrl { get; set; }

        public class
            UpdateGitHubProfileCommandHandler : IRequestHandler<UpdateGitHubProfileCommand, UpdatedGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
           

            public UpdateGitHubProfileCommandHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
                => (_mapper, _gitHubProfileRepository) =
                    (mapper, gitHubProfileRepository);

            public async Task<UpdatedGitHubProfileDto> Handle(UpdateGitHubProfileCommand request,
                CancellationToken cancellationToken)
            {
                GitHubProfile gitHubProfile = await _gitHubProfileRepository.GetAsync(g => g.Id == request.Id);

                gitHubProfile = await _gitHubProfileRepository.UpdateAsync(_mapper.Map(request, gitHubProfile));

                UpdatedGitHubProfileDto updatedGitHubProfileDto = _mapper.Map<UpdatedGitHubProfileDto>(gitHubProfile);

                return updatedGitHubProfileDto;
            }
        }
    }
}
