using Application.Features.Developers.Dtos;
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

namespace Application.Features.GitHubProfiles.Commands.CreateGitHubProfile
{
    public class CreateGitHubProfileCommand:IRequest<CreatedGitHubProfileDto>
    {
        public int DevoloperId { get; set; }
        public string GithubUrl { get; set; }
        public  class CreateGitHubProfileCommandHandler :IRequestHandler<CreateGitHubProfileCommand,CreatedGitHubProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;

            public async Task<CreatedGitHubProfileDto> Handle(CreateGitHubProfileCommand request, CancellationToken cancellationToken)
            {
                GitHubProfile gitHubProfile = _mapper.Map<GitHubProfile>(request);

                gitHubProfile = await _gitHubProfileRepository.AddAsync(gitHubProfile);

                CreatedGitHubProfileDto createdGitHubProfileDto = _mapper.Map<CreatedGitHubProfileDto>(gitHubProfile);

                return createdGitHubProfileDto;

            }
        }
    }
}
