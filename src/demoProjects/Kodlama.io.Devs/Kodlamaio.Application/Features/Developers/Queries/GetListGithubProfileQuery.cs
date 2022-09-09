using Application.Features.GitHubProfiles.Models;
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

namespace Application.Features.Developers.Queries
{
    public class GetListGithubProfileQuery : IRequest<GitHubProfileListModel>
    {

        public PageRequest PageRequest { get; set; }
        public class GetListGithubProfileQueryHandler : IRequestHandler<GetListGithubProfileQuery, GitHubProfileListModel>
        {
            IGitHubProfileRepository _gitHubProfileRepository;
            IMapper _mapper;

            public GetListGithubProfileQueryHandler(IGitHubProfileRepository gitHubProfileRepository, IMapper mapper)
            {
                _gitHubProfileRepository = gitHubProfileRepository;
                _mapper = mapper;
            }

            public async Task<GitHubProfileListModel> Handle(GetListGithubProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GitHubProfile> gitHubProfile = await _gitHubProfileRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: x => x.Include(x => x.Developer));
                
                

                GitHubProfileListModel _mappedGitHubProfile = _mapper.Map<GitHubProfileListModel>(gitHubProfile);

                return _mappedGitHubProfile;


            }
        }
    }
}

